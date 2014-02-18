using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using DotMaysWind.MouseRecorder.Helper;
using DotMaysWind.MouseRecorder.NativeMethod;

namespace DotMaysWind.MouseRecorder
{
    public partial class MainForm : Form
    {
        #region 常量
        private const String RecordFileName = "record.dat";
        #endregion

        #region 字段
        private List<Point> _recordPoints;
        private RunningStatus _status;

        private Hotkey _hotkey;
        private Int32 _recordHotkeyID;
        private Int32 _startHotkeyID;
        private Int32 _endHotkeyID;
        #endregion

        #region 构造方法
        public MainForm()
        {
            InitializeComponent();

            this._recordPoints = new List<Point>();
            this._status = RunningStatus.Stoped;

            this._hotkey = new Hotkey(this.Handle);
            this._hotkey.OnHotkeyPressed += new HotkeyEventHandler(OnHotkey_Press);
        }
        #endregion

        #region 事件方法
        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Point> points = FileHelper.LoadFromFile<List<Point>>(this.GetRecordFilePath());

            if (points != null)
            {
                this._recordPoints = points;
            }

            this._recordHotkeyID = this._hotkey.RegisterHotkey(Keys.F1, KeyFlags.MOD_CONTROL);
            this._startHotkeyID = this._hotkey.RegisterHotkey(Keys.F2, KeyFlags.MOD_CONTROL);
            this._endHotkeyID = this._hotkey.RegisterHotkey(Keys.F3, KeyFlags.MOD_CONTROL);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._hotkey.UnregisterHotkeys();
        }

        private void OnHotkey_Press(Int32 hotkeyID)
        {
            if (hotkeyID == this._recordHotkeyID && this._status == RunningStatus.Stoped)
            {
                this._status = RunningStatus.Recording;
                this.bgWorker.RunWorkerAsync();
            }
            else if (hotkeyID == this._startHotkeyID && this._status == RunningStatus.Stoped)
            {
                this._status = RunningStatus.Playing;
                this.bgWorker.RunWorkerAsync();
            }
            else if (hotkeyID == this._endHotkeyID && this._status != RunningStatus.Stoped)
            {
                this._status = RunningStatus.Stoped;
                this.bgWorker.CancelAsync();
            }
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                this.lblStatus.Text = String.Format("Status : {0}...", this._status.ToString());
            }));

            if (this._status == RunningStatus.Recording)
            {
                Point p = new Point();

                this._recordPoints.Clear();

                while (this._status != RunningStatus.Stoped)
                {
                    MouseCursor.GetCursorPos(ref p);
                    this._recordPoints.Add(p);

                    /*this.Invoke(new Action(() =>
                    {
                        this.Text = p.X + "," + p.Y;
                    }));*/

                    Thread.Sleep(10);
                }

                if (this._recordPoints.Count > 0)
                {
                    FileHelper.SaveToFile(this.GetRecordFilePath(), this._recordPoints);
                }
            }
            else if (this._status == RunningStatus.Playing)
            {
                if (this._recordPoints.Count < 1)
                {
                    this._status = RunningStatus.Stoped;
                }

                Int32 speed = (Int32)this.nudSpeed.Value;
                Int32 current = 0;

                while (this._status != RunningStatus.Stoped)
                {
                    current += speed;

                    if (current >= this._recordPoints.Count)
                    {
                        current = 0;
                    }

                    MouseCursor.SetCursorPos(this._recordPoints[current].X, this._recordPoints[current].Y);

                    Thread.Sleep(10);
                }
            }

            this.Invoke(new Action(() =>
            {
                this.lblStatus.Text = "Status : Ended.";
            }));
        }
        #endregion

        #region 私有方法
        private String GetRecordFilePath()
        {
            String filePath = Path.Combine(Application.StartupPath, RecordFileName);

            return filePath;
        }
        #endregion
    }
}

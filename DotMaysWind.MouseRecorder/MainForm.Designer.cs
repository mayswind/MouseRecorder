namespace DotMaysWind.MouseRecorder
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.lblInfoStart = new System.Windows.Forms.Label();
            this.lblInfoEnd = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblInfoRecord = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblInfoSpeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // lblInfoStart
            // 
            this.lblInfoStart.AutoSize = true;
            this.lblInfoStart.Location = new System.Drawing.Point(12, 30);
            this.lblInfoStart.Name = "lblInfoStart";
            this.lblInfoStart.Size = new System.Drawing.Size(107, 12);
            this.lblInfoStart.TabIndex = 1;
            this.lblInfoStart.Text = "Ctrl + F2 : Start";
            // 
            // lblInfoEnd
            // 
            this.lblInfoEnd.AutoSize = true;
            this.lblInfoEnd.Location = new System.Drawing.Point(12, 51);
            this.lblInfoEnd.Name = "lblInfoEnd";
            this.lblInfoEnd.Size = new System.Drawing.Size(101, 12);
            this.lblInfoEnd.TabIndex = 2;
            this.lblInfoEnd.Text = "Ctrl + F3 : Stop";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 73);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(95, 12);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status : Stoped";
            // 
            // lblInfoRecord
            // 
            this.lblInfoRecord.AutoSize = true;
            this.lblInfoRecord.Location = new System.Drawing.Point(12, 9);
            this.lblInfoRecord.Name = "lblInfoRecord";
            this.lblInfoRecord.Size = new System.Drawing.Size(113, 12);
            this.lblInfoRecord.TabIndex = 0;
            this.lblInfoRecord.Text = "Ctrl + F1 : Record";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(83, 92);
            this.nudSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(48, 21);
            this.nudSpeed.TabIndex = 4;
            this.nudSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblInfoSpeed
            // 
            this.lblInfoSpeed.AutoSize = true;
            this.lblInfoSpeed.Location = new System.Drawing.Point(12, 94);
            this.lblInfoSpeed.Name = "lblInfoSpeed";
            this.lblInfoSpeed.Size = new System.Drawing.Size(47, 12);
            this.lblInfoSpeed.TabIndex = 5;
            this.lblInfoSpeed.Text = "Speed :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(148, 122);
            this.Controls.Add(this.lblInfoSpeed);
            this.Controls.Add(this.nudSpeed);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblInfoEnd);
            this.Controls.Add(this.lblInfoRecord);
            this.Controls.Add(this.lblInfoStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouse Recorder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label lblInfoStart;
        private System.Windows.Forms.Label lblInfoEnd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblInfoRecord;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.Label lblInfoSpeed;
    }
}


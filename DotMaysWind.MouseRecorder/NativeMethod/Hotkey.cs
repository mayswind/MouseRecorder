using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DotMaysWind.MouseRecorder.NativeMethod
{
    /// <summary>
    /// 热键封装类
    /// </summary>
    internal class Hotkey : IMessageFilter
    {
        #region 字段
        private Dictionary<UInt32, UInt32> _keyIDs;
        private IntPtr _hWnd;
        #endregion

        #region 事件
        /// <summary>
        /// 热键触发事件
        /// </summary>
        public event HotkeyEventHandler OnHotkeyPressed;
        #endregion

        #region 外部方法
        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);

        [DllImport("user32.dll")]
        public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);
        #endregion

        #region 构造方法
        internal Hotkey(IntPtr hWnd)
        {
            this._keyIDs = new Dictionary<UInt32, UInt32>();
            this._hWnd = hWnd;

            Application.AddMessageFilter(this);
        }
        #endregion

        #region 方法
        internal Int32 RegisterHotkey(Keys key, KeyFlags keyflags)
        {
            UInt32 hotkeyid = GlobalAddAtom(Guid.NewGuid().ToString());
            RegisterHotKey((IntPtr)this._hWnd, hotkeyid, (UInt32)keyflags, (UInt32)key);

            this._keyIDs[hotkeyid] = hotkeyid;

            return (Int32)hotkeyid;
        }

        internal void UnregisterHotkeys()
        {
            Application.RemoveMessageFilter(this);

            foreach (UInt32 key in this._keyIDs.Keys)
            {
                UnregisterHotKey(this._hWnd, key);
                GlobalDeleteAtom(key);
            }
        }

        Boolean IMessageFilter.PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x312)
            {
                if (OnHotkeyPressed != null)
                {
                    foreach (UInt32 key in this._keyIDs.Keys)
                    {
                        if ((UInt32)m.WParam == key)
                        {
                            this.OnHotkeyPressed((Int32)m.WParam);
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        #endregion
    }
}
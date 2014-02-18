using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DotMaysWind.MouseRecorder.NativeMethod
{
    /// <summary>
    /// 鼠标指针控制方法
    /// </summary>
    internal static class MouseCursor
    {
        /// <summary>
        /// 设置鼠标指针
        /// </summary>
        /// <param name="x">屏幕横坐标</param>
        /// <param name="y">屏幕纵坐标</param>
        /// <returns>是否成功</returns>
        [DllImport("User32.dll")]
        internal static extern Boolean SetCursorPos(Int32 x, Int32 y);

        /// <summary>
        /// 获取鼠标指针
        /// </summary>
        /// <param name="lpPoint">屏幕坐标点</param>
        /// <returns>是否成功</returns>
        [DllImport("User32.dll")]
        internal static extern Boolean GetCursorPos(ref Point lpPoint);
    }
}
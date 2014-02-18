using System;

namespace DotMaysWind.MouseRecorder.NativeMethod
{
    /// <summary>
    /// 按键类型
    /// </summary>
    [Flags]
    public enum KeyFlags
    {
        /// <summary>
        /// 无按键
        /// </summary>
        MOD_NONE = 0x0,

        /// <summary>
        /// Alt键
        /// </summary>
        MOD_ALT = 0x1,

        /// <summary>
        /// Ctrl键
        /// </summary>
        MOD_CONTROL = 0x2,

        /// <summary>
        /// Shift键
        /// </summary>
        MOD_SHIFT = 0x4,

        /// <summary>
        /// Win键
        /// </summary>
        MOD_WIN = 0x8
    }
}
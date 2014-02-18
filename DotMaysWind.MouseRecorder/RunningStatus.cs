using System;

namespace DotMaysWind.MouseRecorder
{
    /// <summary>
    /// 运行状态
    /// </summary>
    internal enum RunningStatus
    {
        /// <summary>
        /// 停止运行
        /// </summary>
        Stoped = 0,

        /// <summary>
        /// 录制中
        /// </summary>
        Recording = 1,

        /// <summary>
        /// 播放中
        /// </summary>
        Playing = 2
    }
}
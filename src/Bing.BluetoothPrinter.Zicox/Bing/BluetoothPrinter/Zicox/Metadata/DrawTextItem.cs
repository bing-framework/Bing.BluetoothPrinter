﻿namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 文字明细
    /// </summary>
    internal class DrawTextItem
    {
        /// <summary>
        /// 是否加粗
        /// </summary>
        public bool Bold { get; set; }

        /// <summary>
        /// 字体大小
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// 字体缩放
        /// </summary>
        public int FontZoom { get; set; }

        /// <summary>
        /// 是否反显
        /// </summary>
        public bool Reverse { get; set; }

        /// <summary>
        /// 旋转角度
        /// </summary>
        public int Rotate { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 文字起始x坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 文字起始y坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 是否下划线
        /// </summary>
        public bool Underline { get; set; }
    }
}

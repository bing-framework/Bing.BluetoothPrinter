﻿namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 一维条码明细
    /// </summary>
    internal class DrawBarcode1DItem
    {
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 窄条的单位宽度
        /// </summary>
        public int LineWidth { get; set; }

        /// <summary>
        /// 宽条与窄条的比率
        /// </summary>
        public int Ratio { get; set; } = 1;

        /// <summary>
        /// 旋转角度
        /// </summary>
        public int Rotate { get; set; }

        /// <summary>
        /// 条码内容
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 条码类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 条码起始x坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 条码起始y坐标
        /// </summary>
        public int Y { get; set; }
    }
}

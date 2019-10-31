namespace Bing.BluetoothPrinter.Zicox.Internal
{
    /// <summary>
    /// 打印条码明细
    /// </summary>
    internal class DrawBarcodeItem
    {
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 线条宽度
        /// </summary>
        public int LineWidth { get; set; }

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

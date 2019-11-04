namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 线条明细
    /// </summary>
    internal class DrawLineItem
    {
        /// <summary>
        /// 线条宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 线条起始点x坐标
        /// </summary>
        public int X0 { get; set; }

        /// <summary>
        /// 线条结束点x坐标
        /// </summary>
        public int X1 { get; set; }

        /// <summary>
        /// 线条起始点y坐标
        /// </summary>
        public int Y0 { get; set; }

        /// <summary>
        /// 线条结束点y坐标
        /// </summary>
        public int Y1 { get; set; }
    }
}

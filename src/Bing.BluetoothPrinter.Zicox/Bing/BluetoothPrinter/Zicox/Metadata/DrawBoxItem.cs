namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 矩形明细
    /// </summary>
    internal class DrawBoxItem
    {
        /// <summary>
        /// 线条宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 矩形框左上角x坐标
        /// </summary>
        public int X0 { get; set; }

        /// <summary>
        /// 矩形框右下角x坐标
        /// </summary>
        public int X1 { get; set; }

        /// <summary>
        /// 矩形框左上角y坐标
        /// </summary>
        public int Y0 { get; set; }

        /// <summary>
        /// 矩形框右下角y坐标
        /// </summary>
        public int Y1 { get; set; }
    }
}

namespace Bing.BluetoothPrinter.Zicox
{
    /// <summary>
    /// 芝柯打印客户端
    /// </summary>
    public class ZicoxPrintClient
    {
        /// <summary>
        /// 流
        /// </summary>
        private byte[] _buffer;

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; internal set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; internal set; }
    }
}

namespace Bing.BluetoothPrinter.Zicox.Internal
{
    /// <summary>
    /// 命令信息
    /// </summary>
    internal class CommandInfo
    {
        /// <summary>
        /// 是否已设置初始化页面信息
        /// </summary>
        public bool HasBegin { get; set; }

        /// <summary>
        /// 是否设置结尾信息。如：PRINT
        /// </summary>
        public bool HasEnd { get; set; }

        /// <summary>
        /// 重置
        /// </summary>
        public void Rest()
        {
            HasBegin = false;
            HasEnd = false;
        }
    }
}

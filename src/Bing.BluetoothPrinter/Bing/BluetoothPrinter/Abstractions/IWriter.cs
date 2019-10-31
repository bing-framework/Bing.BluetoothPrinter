namespace Bing.BluetoothPrinter.Abstractions
{
    /// <summary>
    /// 写入器操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IWriter<out T>
    {
        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字节数组</param>
        T Write(byte[] value);

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字符串</param>
        T Write(string value);
    }
}

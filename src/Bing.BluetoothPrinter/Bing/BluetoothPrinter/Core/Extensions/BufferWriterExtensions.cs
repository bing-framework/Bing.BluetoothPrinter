using Bing.BluetoothPrinter.Abstractions;

namespace Bing.BluetoothPrinter.Core.Extensions
{
    /// <summary>
    /// 缓冲区写入器(<see cref="IBufferWriter{T}"/>) 扩展
    /// </summary>
    public static class BufferWriterExtensions
    {
        /// <summary>
        /// 写入并换行
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="writer">缓冲区写入器</param>
        /// <param name="value">字符串</param>
        public static T WriteLine<T>(this IBufferWriter<T> writer, string value) => writer.Write($"{value}\r\n");
    }
}

using System.Text;
using Bing.BluetoothPrinter.Abstractions;
using Bing.BluetoothPrinter.Core.Internal;

namespace Bing.BluetoothPrinter.Core
{
    /// <summary>
    /// 缓冲区写入器工厂
    /// </summary>
    public static class BufferWriterFactory
    {

        /// <summary>
        /// 创建默认缓冲区写入器
        /// </summary>
        public static IBufferWriter CreateDefaultWriter() => CreateDefaultWriter(Encoding.GetEncoding("gbk"));

        /// <summary>
        /// 创建默认缓冲区写入器
        /// </summary>
        /// <param name="encoding">编码方式</param>
        public static IBufferWriter CreateDefaultWriter(Encoding encoding) => new BufferWriter(encoding);
    }
}

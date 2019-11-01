using System.Collections.Generic;
using System.Text;
using Bing.BluetoothPrinter.Abstractions;

namespace Bing.BluetoothPrinter.Core.Internal
{
    /// <summary>
    /// 缓冲区写入器
    /// </summary>
    internal class BufferWriter : IBufferWriter
    {
        /// <summary>
        /// 流缓冲区
        /// </summary>
        private List<byte> _buffer;

        /// <summary>
        /// 字符编码
        /// </summary>
        private readonly Encoding _encoding;

        /// <summary>
        /// 初始化一个<see cref="BufferWriter"/>类型的实例
        /// </summary>
        /// <param name="encoding">字符编码</param>
        public BufferWriter(Encoding encoding)
        {
            _encoding = encoding;
            _buffer = new List<byte>();
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字节数组</param>
        public IBufferWriter Write(byte[] value)
        {
            if (value == null)
                return this;
            _buffer.AddRange(value);
            return this;
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字符串</param>
        public IBufferWriter Write(string value)
        {
            if (string.IsNullOrEmpty(value))
                return this;
            var bytes = _encoding.GetBytes(value);
            _buffer.AddRange(bytes);
            return this;
        }

        /// <summary>
        /// 清空内容
        /// </summary>
        public IBufferWriter Clear()
        {
            _buffer.Clear();
            return this;
        }

        /// <summary>
        /// 获取二进制数组
        /// </summary>
        public byte[] GetBytes() => _buffer.ToArray();

        /// <summary>
        /// 转换为16进制
        /// </summary>
        public string ToHex()
        {
            if (_buffer.Count == 0)
                return string.Empty;
            var result = new StringBuilder();
            foreach (var b in _buffer)
                result.AppendFormat("{0:x2}", b);
            return result.Replace("-", "").ToString();
        }
    }
}

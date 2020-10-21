
// ReSharper disable once CheckNamespace
namespace Bing.BluetoothPrinter.Zicox
{
    /// <summary>
    /// 芝柯打印客户端(<see cref="ZicoxPrintClient"/>) 扩展
    /// </summary>
    public static partial class ZicoxPrintClientExtensions
    {
        /// <summary>
        /// COUNT 命令
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="count">递增值。任何整数值都不能超过20个字符。如果希望减小 TEXT/BARCODE 值，则可以在值前添加“-”符号。输出结果中将保值前导零。</param>
        /// <remarks>
        /// COUNT 命令可以用于打印多个标签，其中条码中编码的数字文本域或数字数据将针对每个标签依次递增或者递减。TEXT/BARCODE 命令字符串必须包含此数字数据，将其作为字符串的后若干字符。数字数据部分多可以包 含 20 个字符，且可以以‘-’符号作为前缀。增加或减少数字数据时不能以‘0’为增量或减量。前导零将予以保留。一个标签文件中多可使用三个 COUNT 命令。 递增/递减的数字数据包含在 TEXT 或 BARCODE 命令中，后面紧跟 COUNT 命令。 
        /// </remarks>
        public static ZicoxPrintClient Count(this ZicoxPrintClient client, int count) => client.WriteRawLine($"COUNT {count}");

        /// <summary>
        /// ENCODING 命令
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="encoding">编码格式。仅支持：ASCII、UTF-8、GB18030等编码</param>
        /// <remarks>
        /// ENCODING 控制命令可以指定要发送到打印机的数据的编码形式。
        /// </remarks>
        public static ZicoxPrintClient Encoding(this ZicoxPrintClient client, string encoding) => client.WriteRawLine($"ENCODING {encoding}");
    }
}

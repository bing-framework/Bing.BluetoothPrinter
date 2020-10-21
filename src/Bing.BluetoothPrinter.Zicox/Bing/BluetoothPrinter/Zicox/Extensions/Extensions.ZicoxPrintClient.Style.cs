
// ReSharper disable once CheckNamespace
namespace Bing.BluetoothPrinter.Zicox
{
    /// <summary>
    /// 芝柯打印客户端(<see cref="ZicoxPrintClient"/>) 扩展
    /// </summary>
    public static partial class ZicoxPrintClientExtensions
    {
        /// <summary>
        /// 重置字体放大倍数
        /// </summary>
        /// <param name="client">客户端</param>
        public static ZicoxPrintClient RestMag(this ZicoxPrintClient client) => client.WriteRawLine("SETMAG 0 0");

        /// <summary>
        /// 设置字体放大倍数
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="width">字体的宽度放大倍数。有效放大倍数为1到16。</param>
        /// <param name="height">字体的高度放大倍数。有效放大倍数为1到16。</param>
        /// <remarks>
        /// SETMAG 命令可将常驻字体放大指定的放大倍数。<br/>
        /// SETMAG 命令在标签打印后仍保持有效。这意味着要打印的下一标签将使用近设置的 SETMAG 值。要取消 SETMAG 值并使打印机可以 使用默认字体大小，请使用 SETMAG 命令，且放大倍数为 0,0。 
        /// </remarks>
        public static ZicoxPrintClient SetMag(this ZicoxPrintClient client, int width, int height) => client.WriteRawLine($"SETMAG {width} {height}");

    }
}

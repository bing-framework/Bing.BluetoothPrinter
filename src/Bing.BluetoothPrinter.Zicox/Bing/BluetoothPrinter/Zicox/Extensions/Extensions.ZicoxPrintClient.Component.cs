

// ReSharper disable once CheckNamespace
namespace Bing.BluetoothPrinter.Zicox
{
    /// <summary>
    /// 芝柯打印客户端(<see cref="ZicoxPrintClient"/>) 扩展
    /// </summary>
    public static partial class ZicoxPrintClientExtensions
    {
        #region DrawBarcode(条码)

        /// <summary>
        /// 打印条码。默认：CODE 128
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="x">条码起始x坐标</param>
        /// <param name="y">条码起始y坐标</param>
        /// <param name="text">条码内容</param>
        /// <param name="lineWidth">线宽</param>
        /// <param name="height">高度</param>
        public static ZicoxPrintClient DrawBarcode(this ZicoxPrintClient client, int x, int y, string text, int lineWidth, int height) => client.DrawBarcode1D("128", x, y, text, lineWidth, height, 0, 1);

        /// <summary>
        /// 打印条码。默认：CODE 128
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="x">条码起始x坐标</param>
        /// <param name="y">条码起始y坐标</param>
        /// <param name="text">条码内容</param>
        /// <param name="lineWidth">线宽</param>
        /// <param name="height">高度</param>
        /// <param name="rotate">旋转角度</param>
        public static ZicoxPrintClient DrawBarcode(this ZicoxPrintClient client, int x, int y, string text, int lineWidth, int height, int rotate) => client.DrawBarcode1D("128", x, y, text, lineWidth, height, rotate, 1);

        /// <summary>
        /// 打印条码。默认：CODE 128
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="x">条码起始x坐标</param>
        /// <param name="y">条码起始y坐标</param>
        /// <param name="text">条码内容</param>
        /// <param name="lineWidth">线宽</param>
        /// <param name="height">高度</param>
        /// <param name="rotate">旋转角度</param>
        /// <param name="ratio">宽条与窄条的比率</param>
        public static ZicoxPrintClient DrawBarcode(this ZicoxPrintClient client, int x, int y, string text, int lineWidth, int height, int rotate, int ratio) => client.DrawBarcode1D("128", x, y, text, lineWidth, height, rotate, ratio);

        #endregion
    }
}

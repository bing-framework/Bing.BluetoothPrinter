
// ReSharper disable once CheckNamespace
namespace Bing.BluetoothPrinter.Zicox
{
    /// <summary>
    /// 芝柯打印客户端(<see cref="ZicoxPrintClient"/>) 扩展
    /// </summary>
    public static partial class ZicoxPrintClientExtensions
    {
        /// <summary>
        /// 设置纸张
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public static ZicoxPrintClient SetPage(this ZicoxPrintClient client, int width, int height) => SetPage(client, width, height, 0);

        /// <summary>
        /// 设置纸张
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="rotate">旋转角度</param>
        public static ZicoxPrintClient SetPage(this ZicoxPrintClient client, int width, int height, int rotate)
        {
            client.PagerRotate = rotate;
            return client.Create(width, height);
        }

        /// <summary>
        /// 设置打印标签数
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="qty">打印标签数量</param>
        public static ZicoxPrintClient SetQty(this ZicoxPrintClient client, int qty)
        {
            client.Qty = qty < 1 ? 1 : qty > 1024 ? 1024 : qty;
            return client;
        }

        /// <summary>
        /// 设置标签横向偏移值
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="offset">偏移量</param>
        public static ZicoxPrintClient SetOffset(this ZicoxPrintClient client, int offset)
        {
            client.Offset = offset < 0 ? 0 : offset;
            return client;
        }
    }
}

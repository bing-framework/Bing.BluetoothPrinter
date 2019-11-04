using System.Text;

namespace Bing.BluetoothPrinter.Zicox.Extensions
{
    /// <summary>
    /// 芝柯打印客户端(<see cref="ZicoxPrintClient"/>) 扩展
    /// </summary>
    public static class ZicoxPrintClientExtensions
    {
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
        public static ZicoxPrintClient DrawBarcode(this ZicoxPrintClient client, int x, int y, string text, int lineWidth, int height, int rotate)
        {
            client.DrawBarcode1D("128", x, y, text, lineWidth, height, rotate, 1);
            return client;
        }

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
        public static ZicoxPrintClient DrawBarcode(this ZicoxPrintClient client, int x, int y, string text, int lineWidth, int height, int rotate, int ratio)
        {
            client.DrawBarcode1D("128", x, y, text, lineWidth, height, rotate, ratio);
            return client;
        }

        /// <summary>
        /// 绘制虚线
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="x0">虚线起始x坐标</param>
        /// <param name="y0">虚线起始y坐标</param>
        /// <param name="x1">虚线结束x坐标</param>
        /// <param name="y1">虚线结束y坐标</param>
        public static ZicoxPrintClient DrawDashLine(this ZicoxPrintClient client, int x0, int y0, int x1, int y1)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < x1; i= ((i + 16) - 1)+1)
                client.DrawText(x0 + i, y0 - 10, "-", 24, 0, 0, false, false, false);
            return client;
        }

        /// <summary>
        /// 打印填充矩形
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="x0">矩形框左上角x坐标</param>
        /// <param name="y0">矩形框左上角y坐标</param>
        /// <param name="x1">矩形框右下角x坐标</param>
        /// <param name="y1">矩形框右下角y坐标</param>
        public static ZicoxPrintClient DrawRectFill(this ZicoxPrintClient client, int x0, int y0, int x1, int y1)
        {
            client.CommandBuilder.Inverse(x0, x1, y0, y1, y1 - y0);
            return client;
        }

        /// <summary>
        /// 打印矩形
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="x0">矩形框左上角x坐标</param>
        /// <param name="y0">矩形框左上角y坐标</param>
        /// <param name="x1">矩形框右下角x坐标</param>
        /// <param name="y1">矩形框右下角y坐标</param>
        /// <param name="lineWidth">线宽</param>
        public static ZicoxPrintClient DrawRect(this ZicoxPrintClient client, int x0, int y0, int x1, int y1, int lineWidth)
        {
            client.DrawBox(x0, y0, x1, y1, lineWidth);
            return client;
        }

        
    }
}

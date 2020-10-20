using Bing.BluetoothPrinter.Core.Extensions;
using Bing.BluetoothPrinter.Zicox.Internal;

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

        /// <summary>
        /// 打印二维码
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="x">二维码起始x坐标</param>
        /// <param name="y">二维码起始y坐标</param>
        /// <param name="text">二维码内容</param>
        /// <param name="size">尺寸</param>
        /// <param name="level">二维码纠错级别</param>
        /// <param name="rotate">旋转角度</param>
        public static ZicoxPrintClient DrawQrCode(this ZicoxPrintClient client, int x, int y, string text,
            int size, int level, int rotate) =>
            client.DrawQrCode(x, y, text, size, Helper.ConvertErrorLevel(level), rotate);

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
            for (int i = 0; i < x1; i= ((i + 16) - 1)+1)
                client.DrawText(x0 + i, y0 - 10, "-", 24, 0, 0, false, false, false);
            return client;
        }

        /// <summary>
        /// 绘制虚线
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="x0">虚线起始x坐标</param>
        /// <param name="y0">虚线起始y坐标</param>
        public static ZicoxPrintClient DrawDashLine(this ZicoxPrintClient client, int x0, int y0)
        {
            for (int i = 0; i < client.Width; i = ((i + 16) - 1) + 1)
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
        public static ZicoxPrintClient DrawRect(this ZicoxPrintClient client, int x0, int y0, int x1, int y1, int lineWidth) => client.DrawBox(x0, y0, x1, y1, lineWidth);

        /// <summary>
        /// 画文字
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="startX">文字起始x坐标</param>
        /// <param name="startY">文字起始y坐标</param>
        /// <param name="text">内容</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="style">样式</param>
        /// <param name="rotate">旋转角度</param>
        public static ZicoxPrintClient DrawText(this ZicoxPrintClient client, int startX, int startY, string text, int fontSize, int style, int rotate)
        {
            var styleResult = Helper.ConvertStyle(style);
            return client.DrawText(startX, startY, text, fontSize, 0, rotate, styleResult.bold, false, styleResult.underline);
        }

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
        /// 追加
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="value">值</param>
        public static ZicoxPrintClient Append(this ZicoxPrintClient client, byte[] value)
        {
            client.RawWriter.Write(value);
            return client;
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="value">值</param>
        public static ZicoxPrintClient Append(this ZicoxPrintClient client, string value)
        {
            client.RawWriter.Write(value);
            return client;
        }

        /// <summary>
        /// 追加并换行
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="value">值</param>
        public static ZicoxPrintClient AppendLine(this ZicoxPrintClient client, string value)
        {
            client.RawWriter.WriteLine(value);
            return client;
        }
    }
}

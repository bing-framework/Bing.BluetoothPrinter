using Bing.BluetoothPrinter.Abstractions;

namespace Bing.BluetoothPrinter.Core.Extensions
{
    /// <summary>
    /// 蓝牙打印机协议(<see cref="IBluetoothPrinterProtocol"/>) 扩展
    /// </summary>
    public static class BluetoothPrinterProtocolExtensions
    {
        /// <summary>
        /// 设置打印纸张大小
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="width">宽度。单位：像素(Pixcls)</param>
        /// <param name="height">高度。单位：像素(Pixcls)</param>
        public static IBluetoothPrinterProtocol SetPage(this IBluetoothPrinterProtocol protocol, int width, int height) => protocol.SetPage(width, height, PrintOrientation.None);

        /// <summary>
        /// 绘制线条
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="startX">线条起始点x坐标</param>
        /// <param name="startY">线条起始点y坐标</param>
        /// <param name="endX">线条结束点x坐标</param>
        /// <param name="endY">线条结束点y坐标</param>
        /// <param name="lineWidth">线宽</param>
        public static IBluetoothPrinterProtocol DrawLine(this IBluetoothPrinterProtocol protocol, int startX,
            int startY, int endX, int endY, int lineWidth) =>
            protocol.DrawLine(startX, startY, endX, endY, lineWidth, LineStyle.Full);

        /// <summary>
        /// 绘制线条
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="startX">线条起始点x坐标</param>
        /// <param name="startY">线条起始点y坐标</param>
        /// <param name="endX">线条结束点x坐标</param>
        /// <param name="endY">线条结束点y坐标</param>
        public static IBluetoothPrinterProtocol DrawLine(this IBluetoothPrinterProtocol protocol, int startX,
            int startY, int endX, int endY) =>
            protocol.DrawLine(startX, startY, endX, endY, 1, LineStyle.Full);

        /// <summary>
        /// 绘制线条
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="x">线条起始点x坐标</param>
        /// <param name="y">线条起始点y坐标</param>
        public static IBluetoothPrinterProtocol DrawLine(this IBluetoothPrinterProtocol protocol, int x, int y) => protocol.DrawLine(x, y, protocol.Width, y, 1, LineStyle.Full);

        /// <summary>
        /// 绘制线条
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="y">线条起始点y坐标</param>
        public static IBluetoothPrinterProtocol DrawLine(this IBluetoothPrinterProtocol protocol, int y) => protocol.DrawLine(0, y, protocol.Width, y, 1, LineStyle.Full);

        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="leftTopX">矩形框左上角x坐标</param>
        /// <param name="leftTopY">矩形框左上角y坐标</param>
        /// <param name="rightBottomX">矩形框右下角x坐标</param>
        /// <param name="rightBottomY">矩形框右下角y坐标</param>
        /// <param name="lineWidth">线条宽度</param>
        public static IBluetoothPrinterProtocol DrawRect(this IBluetoothPrinterProtocol protocol, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY,
            int lineWidth) =>
            protocol.DrawRect(leftTopX, leftTopY, rightBottomX, rightBottomY, lineWidth, LineStyle.Dotted);

        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="leftTopX">矩形框左上角x坐标</param>
        /// <param name="leftTopY">矩形框左上角y坐标</param>
        /// <param name="rightBottomX">矩形框右下角x坐标</param>
        /// <param name="rightBottomY">矩形框右下角y坐标</param>
        public static IBluetoothPrinterProtocol DrawRect(this IBluetoothPrinterProtocol protocol, int leftTopX,
            int leftTopY, int rightBottomX, int rightBottomY) =>
            protocol.DrawRect(leftTopX, leftTopY, rightBottomX, rightBottomY, 1, LineStyle.Dotted);

        /// <summary>
        /// 画文字
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="startX">文字起始x坐标</param>
        /// <param name="startY">文字起始y坐标</param>
        /// <param name="width">文字绘制区域宽度(可以为0，不为0的时候文字需要根据宽度自动换行)</param>
        /// <param name="height">文字绘制区域高度(可以为0)</param>
        /// <param name="text">内容</param>
        public static IBluetoothPrinterProtocol DrawText(this IBluetoothPrinterProtocol protocol, int startX,
            int startY, int width, int height, string text) =>
            protocol.DrawText(startX, startY, width, height, text, FontSize.Size16, TextStyle.None,
                PrintColor.Black, RotationAngle.None);

        /// <summary>
        /// 画文字
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="startX">文字起始x坐标</param>
        /// <param name="startY">文字起始y坐标</param>
        /// <param name="text">内容</param>
        public static IBluetoothPrinterProtocol DrawText(this IBluetoothPrinterProtocol protocol, int startX,
            int startY, string text) =>
            protocol.DrawText(startX, startY, 0, 0, text, FontSize.Size16, TextStyle.None,
                PrintColor.Black, RotationAngle.None);

        /// <summary>
        /// 画文字
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="startX">文字起始x坐标</param>
        /// <param name="startY">文字起始y坐标</param>
        /// <param name="text">内容</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="textStyle">字体样式</param>
        public static IBluetoothPrinterProtocol DrawText(this IBluetoothPrinterProtocol protocol, int startX,
            int startY, string text, FontSize fontSize, TextStyle textStyle) =>
            protocol.DrawText(startX, startY, 0, 0, text, fontSize, textStyle,
                PrintColor.Black, RotationAngle.None);

        /// <summary>
        /// 画文字
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="startX">文字起始x坐标</param>
        /// <param name="startY">文字起始y坐标</param>
        /// <param name="text">内容</param>
        /// <param name="fontSize">字体大小</param>
        public static IBluetoothPrinterProtocol DrawText(this IBluetoothPrinterProtocol protocol, int startX,
            int startY, string text, FontSize fontSize) =>
            protocol.DrawText(startX, startY, 0, 0, text, fontSize, TextStyle.None,
                PrintColor.Black, RotationAngle.None);
    }
}

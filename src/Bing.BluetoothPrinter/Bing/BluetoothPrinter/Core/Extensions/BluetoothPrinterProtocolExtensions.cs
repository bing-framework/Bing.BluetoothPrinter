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


    }
}

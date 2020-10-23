using System;
using System.Drawing;
using System.Text;
using Bing.BluetoothPrinter.Abstractions;
using Bing.BluetoothPrinter.Zicox.Internal;

namespace Bing.BluetoothPrinter.Zicox
{
    /// <summary>
    /// 芝柯蓝牙打印机
    /// </summary>
    public class ZicoxBluetoothPrinter : IBluetoothPrinterProtocol
    {
        /// <summary>
        /// 初始化一个<see cref="ZicoxBluetoothPrinter"/>类型的实例
        /// </summary>
        public ZicoxBluetoothPrinter() : this(Encoding.GetEncoding("gbk"))
        {
        }

        /// <summary>
        /// 初始化一个<see cref="ZicoxBluetoothPrinter"/>类型的实例
        /// </summary>
        /// <param name="encoding">字符编码</param>
        public ZicoxBluetoothPrinter(Encoding encoding) => Client = new ZicoxPrintClient(encoding);

        /// <summary>
        /// 芝柯打印客户端
        /// </summary>
        internal ZicoxPrintClient Client { get; private set; }

        /// <summary>
        /// 页宽
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// 页高
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// 设置打印纸张大小、旋转角度
        /// </summary>
        /// <param name="width">宽度。单位：像素(Pixcls)</param>
        /// <param name="height">高度。单位：像素(Pixcls)</param>
        /// <param name="orientation">打印方向</param>
        public IBluetoothPrinterProtocol SetPage(int width, int height, PrintOrientation orientation)
        {
            Width = width;
            Height = height;
            Client.SetPage(width, height, (int) orientation);
            return this;
        }

        /// <summary>
        /// 绘制线条
        /// </summary>
        /// <param name="startX">线条起始点x坐标</param>
        /// <param name="startY">线条起始点y坐标</param>
        /// <param name="endX">线条结束点x坐标</param>
        /// <param name="endY">线条结束点y坐标</param>
        /// <param name="lineWidth">线宽</param>
        /// <param name="lineStyle">线条样式</param>
        public IBluetoothPrinterProtocol DrawLine(int startX, int startY, int endX, int endY, int lineWidth, LineStyle lineStyle)
        {
            switch (lineStyle)
            {
                case LineStyle.Full:
                    Client.DrawLine(startX, startY, endX, endY, lineWidth);
                    break;
                case LineStyle.Dotted:
                    Client.DrawDashLine(startX, startY, endX, endY);
                    break;
            }
            return this;
        }

        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="leftTopX">矩形框左上角x坐标</param>
        /// <param name="leftTopY">矩形框左上角y坐标</param>
        /// <param name="rightBottomX">矩形框右下角x坐标</param>
        /// <param name="rightBottomY">矩形框右下角y坐标</param>
        /// <param name="lineWidth">线条宽度</param>
        /// <param name="lineStyle">线条样式</param>
        public IBluetoothPrinterProtocol DrawRect(int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int lineWidth,
            LineStyle lineStyle)
        {
            switch (lineStyle)
            {
                case LineStyle.Full:
                    Client.DrawRectFill(leftTopX, leftTopY, rightBottomX, rightBottomY);
                    break;
                case LineStyle.Dotted:
                    Client.DrawRect(leftTopX, leftTopY, rightBottomX, rightBottomY, lineWidth);
                    break;
            }
            return this;
        }

        /// <summary>
        /// 画文字
        /// </summary>
        /// <param name="startX">文字起始x坐标</param>
        /// <param name="startY">文字起始y坐标</param>
        /// <param name="width">文字绘制区域宽度(可以为0，不为0的时候文字需要根据宽度自动换行)</param>
        /// <param name="height">文字绘制区域高度(可以为0)</param>
        /// <param name="text">内容</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="textStyle">字体样式</param>
        /// <param name="color">文字颜色</param>
        /// <param name="rotation">旋转角度</param>
        public IBluetoothPrinterProtocol DrawText(int startX, int startY, int width, int height, string text, int fontSize,
            int textStyle, int color, int rotation)
        {
            if (string.IsNullOrWhiteSpace(text))
                return this;
            // 不换行
            if (width == 0 || height == 0)
            {
                Client.DrawText(startX, startY, text, fontSize, textStyle, rotation);
                return this;
            }
            // 换行
            var widthTmp = 0;
            var startYTmp = startY;
            var textTmp = "";
            foreach (var c in text.ToCharArray())
            {
                if (Helper.IsChinese(c))
                    widthTmp = widthTmp + fontSize;
                else
                    widthTmp = widthTmp + fontSize / 2;
                if (widthTmp >= width)
                {
                    textTmp += c;
                    Client.DrawText(startX, startYTmp, textTmp, fontSize, textStyle, rotation);
                    widthTmp = 0;
                    startYTmp += fontSize + 2;
                    textTmp = "";
                }
                else
                {
                    textTmp += c;
                }
            }
            if(!string.IsNullOrEmpty(textTmp))
                Client.DrawText(startX, startYTmp, textTmp, fontSize, textStyle, rotation);
            return this;
        }

        /// <summary>
        /// 画文字
        /// </summary>
        /// <param name="startX">文字起始x坐标</param>
        /// <param name="startY">文字起始y坐标</param>
        /// <param name="width">文字绘制区域宽度(可以为0，不为0的时候文字需要根据宽度自动换行)</param>
        /// <param name="height">文字绘制区域高度(可以为0)</param>
        /// <param name="text">内容</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="textStyle">字体样式</param>
        /// <param name="color">文字颜色</param>
        /// <param name="rotation">旋转角度</param>
        public IBluetoothPrinterProtocol DrawText(int startX, int startY, int width, int height, string text, FontSize fontSize,
            TextStyle textStyle, PrintColor color, RotationAngle rotation)
        {
            return DrawText(startX, startY, width, height, text, (int) fontSize, (int) textStyle, (int) color,
                (int) rotation);
        }

        /// <summary>
        /// 打印条码
        /// </summary>
        /// <param name="startX">条码起始x坐标</param>
        /// <param name="startY">条码起始y坐标</param>
        /// <param name="height">条码高度</param>
        /// <param name="lineWidth">条码鲜甜宽度</param>
        /// <param name="text">条码内容</param>
        /// <param name="type">条码类型</param>
        /// <param name="rotation">旋转角度</param>
        public IBluetoothPrinterProtocol DrawBarcode(int startX, int startY, int height, int lineWidth, string text, int type,
            int rotation)
        {
            if (!string.IsNullOrWhiteSpace(text))
                Client.DrawBarcode1D(Helper.ConvertBarcodeType((BarcodeType) type), startX, startY, text, lineWidth,
                    height, rotation, 1);
            return this;
        }

        /// <summary>
        /// 打印条码
        /// </summary>
        /// <param name="startX">条码起始x坐标</param>
        /// <param name="startY">条码起始y坐标</param>
        /// <param name="height">条码高度</param>
        /// <param name="lineWidth">条码线条宽度</param>
        /// <param name="text">条码内容</param>
        /// <param name="type">条码类型</param>
        /// <param name="rotation">旋转角度</param>
        public IBluetoothPrinterProtocol DrawBarcode(int startX, int startY, int height, int lineWidth, string text, BarcodeType type,
            RotationAngle rotation)
        {
            if (!string.IsNullOrWhiteSpace(text))
                Client.DrawBarcode1D(Helper.ConvertBarcodeType((BarcodeType) type), startX, startY, text, lineWidth,
                    height, (int) rotation, 1);
            return this;
        }

        /// <summary>
        /// 打印二维码
        /// </summary>
        /// <param name="startX">二维码起始x坐标</param>
        /// <param name="startY">二维码起始y坐标</param>
        /// <param name="text">二维码内容</param>
        /// <param name="unitWidth">模块的单位宽度。(1-32)</param>
        /// <param name="level">纠错级别</param>
        /// <param name="rotation">旋转角度</param>
        public IBluetoothPrinterProtocol DrawQrCode(int startX, int startY, string text, int unitWidth, int level, int rotation)
        {
            if (!string.IsNullOrWhiteSpace(text))
                Client.DrawQrCode(startX, startY, text, unitWidth, level, rotation);
            return this;
        }

        /// <summary>
        /// 打印二维码
        /// </summary>
        /// <param name="startX">二维码起始x坐标</param>
        /// <param name="startY">二维码起始y坐标</param>
        /// <param name="text">二维码内容</param>
        /// <param name="unitWidth">模块的单位宽度。(1-32)</param>
        /// <param name="level">纠错级别</param>
        /// <param name="rotation">旋转角度</param>
        public IBluetoothPrinterProtocol DrawQrCode(int startX, int startY, string text, QrCodeUnitSize unitWidth,
            QrCodeCorrectionLevel level, RotationAngle rotation)
        {
            if (!string.IsNullOrWhiteSpace(text))
                Client.DrawQrCode(startX, startY, text, (int) unitWidth, (int) level, (int) rotation);
            return this;
        }

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="startX">图片起始x坐标</param>
        /// <param name="startY">图片起始y坐标</param>
        /// <param name="bitmap">图片数据</param>
        /// <param name="width">图片打印宽度(若宽度或高度为0，则取图片宽高，不为0，则自己缩放)</param>
        /// <param name="height">图片打印高度(若宽度或高度为0，则取图片宽高，不为0，则自己缩放)</param>
        public IBluetoothPrinterProtocol DrawImage(int startX, int startY, Bitmap bitmap, int width, int height)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="value">值</param>
        public IBluetoothPrinterProtocol Append(byte[] value)
        {
            Client.Append(value);
            return this;
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="value">值</param>
        public IBluetoothPrinterProtocol Append(string value)
        {
            Client.Append(value);
            return this;
        }

        /// <summary>
        /// 追加并换行
        /// </summary>
        /// <param name="value">值</param>
        public IBluetoothPrinterProtocol AppendLine(string value)
        {
            Client.AppendLine(value);
            return this;
        }

        /// <summary>
        /// 构建
        /// </summary>
        public IBufferWriter Build() => Client.Build();
    }
}

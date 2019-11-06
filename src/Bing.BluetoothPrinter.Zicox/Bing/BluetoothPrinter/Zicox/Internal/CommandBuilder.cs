using Bing.BluetoothPrinter.Abstractions;
using Bing.BluetoothPrinter.Core.Extensions;
using Bing.BluetoothPrinter.Zicox.Metadata;

namespace Bing.BluetoothPrinter.Zicox.Internal
{
    /// <summary>
    /// 命令构建器
    /// </summary>
    internal class CommandBuilder
    {
        /// <summary>
        /// 缓冲区写入器
        /// </summary>
        internal IBufferWriter Writer { get; private set; }

        /// <summary>
        /// 初始化一个<see cref="CommandBuilder"/>类型的实例
        /// </summary>
        /// <param name="writer">缓冲区写入器</param>
        public CommandBuilder(IBufferWriter writer)
        {
            Writer = writer;
        }

        /// <summary>
        /// 画文本
        /// </summary>
        /// <param name="pageWidth">页宽度</param>
        /// <param name="pageHeight">页高度</param>
        /// <param name="item">画文字明细</param>
        public void DrawText(int pageWidth, int pageHeight, DrawTextItem item)
        {
            // 写入下划线
            Writer.WriteLine(item.Underline ? "UNDERLINE ON" : "UNDERLINE OFF");
            // 写入加粗
            Writer.WriteLine(item.Bold ? "SETBOLD 1" : "SETBOLD 0");
            var computeFontSizeResult = Helper.ComputeFontSize(item.FontSize);
            // 设置字体缩放
            Writer.WriteLine($"SETMAG {computeFontSizeResult.scale} {computeFontSizeResult.scale} ");
            // 写入文本
            var cmd = Helper.GetTextRotateCommand(item.Rotate);
            Writer.WriteLine(
                $"{cmd} {computeFontSizeResult.font} {computeFontSizeResult.size} {item.X} {item.Y} {item.Text}");
            // 写入颠倒文本
            if (item.Reverse)
            {
                Inverse(item.X, item.Y, item.X + computeFontSizeResult.size / 2 * item.Text.Length, item.Y,
                    computeFontSizeResult.size);
            }
            Writer.WriteLine("SETMAG 1 1");
        }

        /// <summary>
        /// 黑白反显
        /// </summary>
        /// <param name="x0">文字起始x坐标</param>
        /// <param name="y0">文字起始y坐标</param>
        /// <param name="x1">文字结束x坐标</param>
        /// <param name="y1">文字结束y坐标</param>
        /// <param name="width">反转线的单位宽度</param>
        public void Inverse(int x0, int y0, int x1, int y1, int width) => Writer.WriteLine($"INVERSE-LINE {x0} {y0} {x1} {y1} {width}");

        /// <summary>
        /// 绘制线条
        /// </summary>
        /// <param name="pageWidth">页宽度</param>
        /// <param name="pageHeight">页高度</param>
        /// <param name="item">绘制线条明细</param>
        public void DrawLine(int pageWidth, int pageHeight, DrawLineItem item) => Writer.WriteLine($"LINE {item.X0} {item.Y0} {item.X1} {item.Y1} {item.Width}");

        /// <summary>
        /// 打印矩形
        /// </summary>
        /// <param name="pageWidth">页宽度</param>
        /// <param name="pageHeight">页高度</param>
        /// <param name="item">打印矩形明细</param>
        public void DrawBox(int pageWidth, int pageHeight, DrawBoxItem item) =>
            Writer.WriteLine($"BOX {item.X0} {item.Y0} {item.X1} {item.Y1} {item.Width}");

        /// <summary>
        /// 打印条码
        /// </summary>
        /// <param name="pageWidth">页宽度</param>
        /// <param name="pageHeight">页高度</param>
        /// <param name="item">打印条码明细</param>
        public void DrawBarcode(int pageWidth, int pageHeight, DrawBarcode1DItem item)
        {
            var coordinate = Helper.GetBarcodeCoordinate(item);
            var cmd = Helper.GetBarcodeRotateCommand(item.Rotate);
            Writer.WriteLine(
                $"{cmd} {item.Type} {item.LineWidth} {item.Ratio} {item.Height} {coordinate.x} {coordinate.y} {item.Text}");
        }

        /// <summary>
        /// 打印二维码
        /// </summary>
        /// <param name="pageWidth">页宽度</param>
        /// <param name="pageHeight">页高度</param>
        /// <param name="item">打印二维码明细</param>
        public void DrawQrCode(int pageWidth, int pageHeight, DrawQrCodeItem item)
        {
            var coordinate = Helper.GetBarcodeCoordinate(item);
            var cmd = Helper.GetBarcodeRotateCommand(item.Rotate);
            Writer.WriteLine($"{cmd} QR {coordinate.x} {coordinate.y} M 2 U {item.Size}");
            Writer.WriteLine($"{item.ErrorLevel}A,{item.Text}");
            Writer.WriteLine("ENDQR");
        }

        public void DrawBitmap(int pageWidth, int pageHeight, DrawBitmapItem item)
        {

        }
    }
}

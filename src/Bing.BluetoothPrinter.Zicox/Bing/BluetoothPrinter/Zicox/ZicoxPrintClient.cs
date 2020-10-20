using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Bing.BluetoothPrinter.Abstractions;
using Bing.BluetoothPrinter.Core;
using Bing.BluetoothPrinter.Core.Extensions;
using Bing.BluetoothPrinter.Metadata;
using Bing.BluetoothPrinter.Zicox.Internal;
using Bing.BluetoothPrinter.Zicox.Metadata;

namespace Bing.BluetoothPrinter.Zicox
{
    /// <summary>
    /// 芝柯打印客户端
    /// </summary>
    public class ZicoxPrintClient
    {
        /// <summary>
        /// 字体信息列表
        /// </summary>
        internal static List<FontInfo> FontInfoList { get; set; } = new List<FontInfo>();

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; internal set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; internal set; }

        /// <summary>
        /// 纸张旋转角度
        /// </summary>
        public int PagerRotate { get; internal set; }

        /// <summary>
        /// 绘制列表
        /// </summary>
        internal List<DrawItemBase> Items { get; set; } = new List<DrawItemBase>();

        /// <summary>
        /// 条码列表
        /// </summary>
        internal List<DrawBarcode1DItem> BarcodeList { get; set; } = new List<DrawBarcode1DItem>();

        /// <summary>
        /// 二维码列表
        /// </summary>
        internal List<DrawQrCodeItem> QrCodeList { get; set; } = new List<DrawQrCodeItem>();

        /// <summary>
        /// 图片列表
        /// </summary>
        internal List<DrawBitmapItem> BitmapList { get; set; } = new List<DrawBitmapItem>();

        /// <summary>
        /// 矩形列表
        /// </summary>
        internal List<DrawBoxItem> BoxList { get; set; } = new List<DrawBoxItem>();

        /// <summary>
        /// 线条列表
        /// </summary>
        internal List<DrawLineItem> LineList { get; set; } = new List<DrawLineItem>();

        /// <summary>
        /// 文本列表
        /// </summary>
        internal List<DrawTextItem> TextList { get; set; } = new List<DrawTextItem>();

        /// <summary>
        /// 缓冲区写入器
        /// </summary>
        internal IBufferWriter Writer { get; private set; }

        /// <summary>
        /// 原始缓冲区写入器
        /// </summary>
        internal IBufferWriter RawWriter { get; private set; }

        /// <summary>
        /// 命令构建器
        /// </summary>
        internal CommandBuilder CommandBuilder { get; private set; }

        /// <summary>
        /// 命令行集合元数据
        /// </summary>
        internal CommandCollectionMetadata Metadata { get; private set; }

        /// <summary>
        /// 初始化一个<see cref="ZicoxPrintClient"/>类型的实例
        /// </summary>
        public ZicoxPrintClient()
        {
            Writer = BufferWriterFactory.CreateDefaultWriter();
            RawWriter = BufferWriterFactory.CreateDefaultWriter();
            CommandBuilder = new CommandBuilder(Writer);
            Metadata = new CommandCollectionMetadata();
        }

        /// <summary>
        /// 初始化一个<see cref="ZicoxPrintClient"/>类型的实例
        /// </summary>
        /// <param name="encoding">字符编码</param>
        public ZicoxPrintClient(Encoding encoding)
        {
            Writer = BufferWriterFactory.CreateDefaultWriter(encoding);
            RawWriter = BufferWriterFactory.CreateDefaultWriter(encoding);
            CommandBuilder = new CommandBuilder(Writer);
            Metadata = new CommandCollectionMetadata();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        internal ZicoxPrintClient Create(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Items.Clear();
            this.BarcodeList.Clear();
            this.QrCodeList.Clear();
            this.BitmapList.Clear();
            this.BoxList.Clear();
            this.LineList.Clear();
            this.TextList.Clear();
            this.RawWriter.Clear();
            this.Writer.Clear();
            this.CommandBuilder.Writer.Clear();
            this.Metadata.Clear();
            return this;
        }

        /// <summary>
        /// 画文字
        /// </summary>
        /// <param name="startX">文字起始x坐标</param>
        /// <param name="startY">文字起始y坐标</param>
        /// <param name="text">内容</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontZoom">字体缩放</param>
        /// <param name="rotate">旋转角度</param>
        /// <param name="bold">是否加粗</param>
        /// <param name="reverse">是否颠倒</param>
        /// <param name="underline">是否下划线</param>
        public ZicoxPrintClient DrawText(int startX, int startY, string text, int fontSize, int fontZoom, int rotate,
            bool bold, bool reverse, bool underline)
        {
            var item = new DrawTextItem
            {
                X = startX,
                Y = startY,
                Text = text,
                FontSize = fontSize,
                FontZoom = fontZoom,
                Rotate = rotate,
                Bold = bold,
                Reverse = reverse,
                Underline = underline
            };
            Items.Add(item);
            return this;
        }

        /// <summary>
        /// 绘制线条
        /// </summary>
        /// <param name="x0">线条起始点x坐标</param>
        /// <param name="y0">线条起始点y坐标</param>
        /// <param name="x1">线条结束点x坐标</param>
        /// <param name="y1">线条结束点y坐标</param>
        /// <param name="width">线条宽度</param>
        public ZicoxPrintClient DrawLine(int x0, int y0, int x1, int y1, int width)
        {
            var item = new DrawLineItem
            {
                X0 = x0,
                Y0 = y0,
                X1 = x1,
                Y1 = y1,
                Width = width,
            };
            Items.Add(item);
            return this;
        }

        /// <summary>
        /// 打印矩形
        /// </summary>
        /// <param name="x0">矩形框左上角x坐标</param>
        /// <param name="y0">矩形框左上角y坐标</param>
        /// <param name="x1">矩形框右下角x坐标</param>
        /// <param name="y1">矩形框右下角y坐标</param>
        /// <param name="width">线条宽度</param>
        public ZicoxPrintClient DrawBox(int x0, int y0, int x1, int y1, int width)
        {
            var item = new DrawBoxItem
            {
                X0 = x0,
                Y0 = y0,
                X1 = x1,
                Y1 = y1,
                Width = width,
            };
            Items.Add(item);
            return this;
        }

        /// <summary>
        /// 打印一维条码
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="x">条码起始x坐标</param>
        /// <param name="y">条码起始y坐标</param>
        /// <param name="text">条码内容</param>
        /// <param name="lineWidth">线宽</param>
        /// <param name="height">高度</param>
        /// <param name="rotate">旋转角度</param>
        /// <param name="ratio">宽条与窄条的比率</param>
        public ZicoxPrintClient DrawBarcode1D(string type, int x, int y, string text, int lineWidth, int height, int rotate, int ratio)
        {
            var item = new DrawBarcode1DItem
            {
                Type = type,
                X = x,
                Y = y,
                Text = text,
                LineWidth = lineWidth,
                Height = height,
                Rotate = rotate,
                Ratio = ratio,
            };
            Items.Add(item);
            return this;
        }

        /// <summary>
        /// 打印二维码
        /// </summary>
        /// <param name="x">二维码起始x坐标</param>
        /// <param name="y">二维码起始y坐标</param>
        /// <param name="text">二维码内容</param>
        /// <param name="size">尺寸</param>
        /// <param name="errorLevel">二维码纠错级别</param>
        /// <param name="rotate">旋转角度</param>
        public ZicoxPrintClient DrawQrCode(int x, int y, string text, int size, string errorLevel, int rotate)
        {
            var item = new DrawQrCodeItem
            {
                X = x,
                Y = y,
                Size = size,
                ErrorLevel = errorLevel,
                Rotate = rotate,
                Text = text,
            };
            Items.Add(item);
            return this;
        }

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="bitmap">图片数据</param>
        /// <param name="x">图片起始x坐标</param>
        /// <param name="y">图片起始y坐标</param>
        /// <param name="rotate">是否旋转</param>
        public ZicoxPrintClient DrawBitmap(Bitmap bitmap, int x, int y, bool rotate)
        {
            var item = new DrawBitmapItem
            {
                Bitmap = bitmap,
                X = x,
                Y = y,
                Rotate = rotate
            };
            Items.Add(item);
            return this;
        }

        /// <summary>
        /// 构建文本
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        public ZicoxPrintClient BuildText(int pageWidth, int pageHeight)
        {
            TextList.ForEach(x => CommandBuilder.DrawText(pageWidth, pageHeight, x));
            return this;
        }

        /// <summary>
        /// 构建线条
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        public ZicoxPrintClient BuildLine(int pageWidth, int pageHeight)
        {
            LineList.ForEach(x => CommandBuilder.DrawLine(pageWidth, pageHeight, x));
            return this;
        }

        /// <summary>
        /// 构建矩形
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        public ZicoxPrintClient BuildBox(int pageWidth, int pageHeight)
        {
            BoxList.ForEach(x => CommandBuilder.DrawBox(pageWidth, pageHeight, x));
            return this;
        }

        /// <summary>
        /// 构建条码
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        public ZicoxPrintClient BuildBarcode(int pageWidth, int pageHeight)
        {
            BarcodeList.ForEach(x => CommandBuilder.DrawBarcode(pageWidth, pageHeight, x));
            return this;
        }

        /// <summary>
        /// 构建二维码
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        public ZicoxPrintClient BuildQrCode(int pageWidth, int pageHeight)
        {
            QrCodeList.ForEach(x => CommandBuilder.DrawQrCode(pageWidth, pageHeight, x));
            return this;
        }

        /// <summary>
        /// 构建图片
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        public ZicoxPrintClient BuildBitmap(int pageWidth, int pageHeight)
        {
            BitmapList.ForEach(x => CommandBuilder.DrawBitmap(pageWidth, pageHeight, x));
            return this;
        }

        /// <summary>
        /// 构建
        /// </summary>
        public IBufferWriter Build()
        {
            Writer.WriteLine($"! 0 200 200 {Height} 1");
            Writer.WriteLine($"PAGE-WIDTH {Width}");
            Items.ForEach(x => x.Build(Width, Height, CommandBuilder));
            Writer.Write(RawWriter.GetBytes());
            Writer.WriteLine("PRINT");
            return Writer;
        }
    }
}

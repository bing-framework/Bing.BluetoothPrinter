using Bing.BluetoothPrinter.Zicox.Internal;

namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 线条明细
    /// </summary>
    internal class DrawLineItem : DrawItemBase
    {
        /// <summary>
        /// 线条宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 线条起始点x坐标
        /// </summary>
        public int X0 { get; set; }

        /// <summary>
        /// 线条结束点x坐标
        /// </summary>
        public int X1 { get; set; }

        /// <summary>
        /// 线条起始点y坐标
        /// </summary>
        public int Y0 { get; set; }

        /// <summary>
        /// 线条结束点y坐标
        /// </summary>
        public int Y1 { get; set; }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        /// <param name="builder">命令构建器</param>
        public override void Build(int pageWidth, int pageHeight, CommandBuilder builder) => builder.DrawLine(pageWidth, pageHeight, this);
    }
}

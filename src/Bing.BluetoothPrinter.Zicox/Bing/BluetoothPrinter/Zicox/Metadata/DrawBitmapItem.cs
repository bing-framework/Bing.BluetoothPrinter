using System.Drawing;
using Bing.BluetoothPrinter.Zicox.Internal;

namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 图片明细
    /// </summary>
    internal class DrawBitmapItem: DrawItemBase
    {
        /// <summary>
        /// 图片数据
        /// </summary>
        public Bitmap Bitmap { get; set; }

        /// <summary>
        /// 是否旋转
        /// </summary>
        public bool Rotate { get; set; }

        /// <summary>
        /// 图片起始x坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 图片起始y坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        /// <param name="builder">命令构建器</param>
        public override void Build(int pageWidth, int pageHeight, CommandBuilder builder) => builder.DrawBitmap(pageWidth, pageHeight, this);
    }
}

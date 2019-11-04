using System.Drawing;

namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 图片明细
    /// </summary>
    internal class DrawBitmapItem
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
    }
}

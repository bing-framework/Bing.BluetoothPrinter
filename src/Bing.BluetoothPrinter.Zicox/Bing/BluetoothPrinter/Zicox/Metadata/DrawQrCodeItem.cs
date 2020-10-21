using Bing.BluetoothPrinter.Zicox.Internal;

namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 二维码明细
    /// </summary>
    internal class DrawQrCodeItem : DrawItemBase
    {
        /// <summary>
        /// 元数据类型
        /// </summary>
        public override MetadataType MetadataType => MetadataType.QrCode;

        /// <summary>
        /// 二维码纠错级别
        /// </summary>
        public string ErrorLevel { get; set; }

        /// <summary>
        /// 旋转角度
        /// </summary>
        public int Rotate { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 二维码起始x坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 二维码起始y坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 二维码内容
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        /// <param name="builder">命令构建器</param>
        public override void Build(int pageWidth, int pageHeight, CommandBuilder builder) => builder.DrawQrCode(pageWidth, pageHeight, this);
    }
}

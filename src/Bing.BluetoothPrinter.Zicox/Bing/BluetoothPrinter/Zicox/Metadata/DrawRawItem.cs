using Bing.BluetoothPrinter.Zicox.Internal;

namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 原始数据明细
    /// </summary>
    internal class DrawRawItem : DrawItemBase
    {
        /// <summary>
        /// 元数据类型
        /// </summary>
        public override MetadataType MetadataType => MetadataType.Raw;

        /// <summary>
        /// 原始数据
        /// </summary>
        public string Raw { get; set; }

        /// <summary>
        /// 是否换行
        /// </summary>
        public bool Newline { get; set; }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        /// <param name="builder">命令构建器</param>
        public override void Build(int pageWidth, int pageHeight, CommandBuilder builder) => builder.DrawRaw(pageWidth, pageHeight, this);
    }
}

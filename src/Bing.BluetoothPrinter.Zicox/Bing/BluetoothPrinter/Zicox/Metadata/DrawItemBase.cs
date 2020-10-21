using Bing.BluetoothPrinter.Zicox.Internal;

namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 绘制明细基类
    /// </summary>
    internal abstract class DrawItemBase
    {
        /// <summary>
        /// 元数据类型
        /// </summary>
        public abstract MetadataType MetadataType { get; }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        /// <param name="builder">命令构建器</param>
        public abstract void Build(int pageWidth,int pageHeight,CommandBuilder builder);
    }
}

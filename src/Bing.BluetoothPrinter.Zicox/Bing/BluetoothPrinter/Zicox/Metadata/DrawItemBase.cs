using Bing.BluetoothPrinter.Zicox.Internal;

namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 绘制明细基类
    /// </summary>
    internal abstract class DrawItemBase
    {
        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="pageWidth">页宽</param>
        /// <param name="pageHeight">页高</param>
        /// <param name="builder">命令构建器</param>
        public abstract void Build(int pageWidth,int pageHeight,CommandBuilder builder);
    }
}

namespace Bing.BluetoothPrinter.Zicox.Abstractions.Operations
{
    /// <summary>
    /// 初始化打印操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IInitializePrint<out T>
    {
        /// <summary>
        /// 初始化打印区域
        /// </summary>
        /// <param name="offset">偏移量。该值可以使所有域以指定的单位数量进行横向偏移</param>
        /// <param name="horizontalResolution">横向分辨率(以点/英寸为单位)。默认：200</param>
        /// <param name="verticalResolution">纵向分辨率(以点/英寸为单位)。默认：200</param>
        /// <param name="height">标签的最大高度。
        /// 标签最大高度的计算方法是，先测出从第 1 个黑条（或标签间隙）底部到下一个黑条（或标签间隙）顶部之间的距离。
        /// 然后从中减去 1/16 英寸（1.5 毫米），所得结果即最大高度。（以为单位时：对于203 d.p.i 打印机，减去 12 点；对于 306 d.p.i.打印机，减去 18 点）
        /// </param>
        /// <param name="qty">要打印的标签数量。最大值为1024</param>
        T Initialize(int offset, int horizontalResolution, int verticalResolution, int height, int qty);
    }
}

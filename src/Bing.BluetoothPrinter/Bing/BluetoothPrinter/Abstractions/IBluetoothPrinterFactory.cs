namespace Bing.BluetoothPrinter.Abstractions
{
    /// <summary>
    /// 蓝牙打印机工厂
    /// </summary>
    public interface IBluetoothPrinterFactory
    {
        /// <summary>
        /// 创建蓝牙打印机协议
        /// </summary>
        IBluetoothPrinterProtocol Create();
    }
}

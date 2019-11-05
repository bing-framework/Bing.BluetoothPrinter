using Bing.BluetoothPrinter.Abstractions;

namespace Bing.BluetoothPrinter.Zicox
{
    /// <summary>
    /// 芝柯打印机驱动工厂
    /// </summary>
    public class ZicoxBluetoothPrinterFactory : IBluetoothPrinterFactory
    {
        /// <summary>
        /// 创建蓝牙打印机协议
        /// </summary>
        public IBluetoothPrinterProtocol Create() => new ZicoxBluetoothPrinter();
    }
}

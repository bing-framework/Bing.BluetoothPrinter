using System;
using Xunit;
using Xunit.Abstractions;

namespace Bing.BluetoothPrinter.Tests
{
    public class UsbDeviceTest : TestBase
    {

        /// <summary>
        /// 初始化一个<see cref="TestBase"/>类型的实例
        /// </summary>
        /// <param name="output">输出</param>
        public UsbDeviceTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_PrintUsbDevice()
        {
            var name = "Zicox CS4".Normalize();
            var hPrinter = new IntPtr(0);
            var result = RawPrinterHelper.OpenPrinter(name, out hPrinter, IntPtr.Zero);
            Output.WriteLine($"result: {result}, h: {hPrinter}");
        }
    }
}

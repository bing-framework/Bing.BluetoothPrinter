using Bing.BluetoothPrinter.Zicox;
using Bing.BluetoothPrinter.Zicox.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Bing.BluetoothPrinter.Tests.Zicox
{
    public class ZicoxPrintClientTest : TestBase
    {
        /// <summary>
        /// 客户端
        /// </summary>
        protected ZicoxPrintClient Client { get; set; }

        /// <summary>
        /// 初始化一个<see cref="TestBase"/>类型的实例
        /// </summary>
        /// <param name="output">输出</param>
        public ZicoxPrintClientTest(ITestOutputHelper output) : base(output)
        {
            Client = new ZicoxPrintClient();
        }

        /// <summary>
        /// 测试 - 画文本
        /// </summary>
        [Fact]
        public void Test_DrawText()
        {
            Client.SetPage(400, 240)
                .DrawText(0, 0, "隔壁老王的战斗 with lao wang de zhan dou", 16, 1, 0, false, false, false);
            var result = Client.Build().ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 - 绘制线条
        /// </summary>
        [Fact]
        public void Test_DrawLine()
        {
            Client.SetPage(200, 210)
                .DrawLine(0, 0, 200, 0, 1)
                .DrawLine(0, 0, 200, 200, 2)
                .DrawLine(0, 0, 0, 200, 3);
            var result = Client.Build().ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 - 打印矩形
        /// </summary>
        [Fact]
        public void Test_DrawBox()
        {
            Client.SetPage(400, 210)
                .DrawBox(0, 0, 200, 200, 1)
                .DrawBox(200, 0, 400, 200, 1);
            var result = Client.Build().ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 - 打印条码
        /// </summary>
        [Fact]
        public void Test_DrawBarcode()
        {
            Client.SetPage(400, 210)
                .DrawBarcode1D("128", 150, 10, "HORIZ.", 1, 50, 0, 1)
                .DrawText(210,60,"HORIZ.",16,0,0,false,false,false)
                .DrawBarcode1D("128", 10, 200, "VERT.", 1, 50, 90, 1)
                .DrawText(60, 140, "VERT.", 16, 0, 90, false, false, false);
            var result = Client.Build().ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 - 打印二维码
        /// </summary>
        [Fact]
        public void Test_DrawQrCode()
        {
            Client.SetPage(400, 500)
                .DrawQrCode(10, 100, "ABC123", 10, "M", 0);
            var result = Client.Build().ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 - 打印虚线
        /// </summary>
        [Fact]
        public void Test_DrawDashLine()
        {
            Client.SetPage(400, 500)
                .DrawDashLine(0, 0,400, 0);
            var result = Client.Build().ToHex();
            Output.WriteLine(result);
        }
    }
}

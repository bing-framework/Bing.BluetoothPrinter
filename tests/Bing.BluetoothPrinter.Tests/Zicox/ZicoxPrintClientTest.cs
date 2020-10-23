using System.Drawing;
using Bing.BluetoothPrinter.Zicox;
using Xunit;
using Xunit.Abstractions;

namespace Bing.BluetoothPrinter.Tests.Zicox
{
    public partial class ZicoxPrintClientTest : TestBase
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
        /// 构建
        /// </summary>
        private void Build()
        {
            var result = Client.Build();
            Output.WriteLine("----------------------------- 调试命令 ---------------------------------------");
            Output.WriteLine(result.ToString());
            Output.WriteLine("----------------------------- 调试命令-十六进制 ---------------------------------------");
            Output.WriteLine(result.ToHex());
            Output.WriteLine("----------------------------- 执行命令 ---------------------------------------");
            Print(result.GetBytes());
        }

        /// <summary>
        /// 测试 - 画文本
        /// </summary>
        [Fact]
        public void Test_DrawText()
        {
            Client.SetPage(400, 240)
                .DrawText(0, 0, "隔壁老王的战斗 with lao wang de zhan dou", 16, 1, 0, false, false, false);
            Build();
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
            Build();
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
            Build();
        }

        /// <summary>
        /// 测试 - 打印条码
        /// </summary>
        [Fact]
        public void Test_DrawBarcode()
        {
            Client.SetPage(400, 210)
                .DrawBarcode1D("128", 150, 10, "HORIZ.", 1, 50, 0, 1)
                .DrawText(210, 60, "HORIZ.", 16, 0, 0, false, false, false)
                .DrawBarcode1D("128", 10, 200, "VERT.", 1, 50, 90, 1)
                .DrawText(60, 140, "VERT.", 16, 0, 90, false, false, false);
            Build();
        }

        /// <summary>
        /// 测试 - 打印条码
        /// </summary>
        [Fact]
        public void Test_DrawBarcode_1()
        {
            Client.SetPage(600, 350)
                .DrawBarcode(0, 0, "10000000256", 1, 100)
                .DrawBarcode(0, 150, "10000000257", 2, 100);
            Build();
        }

        /// <summary>
        /// 测试 - 打印二维码
        /// </summary>
        [Fact]
        public void Test_DrawQrCode()
        {
            Client.SetPage(400, 500)
                .DrawQrCode(10, 100, "ABC123", 10, "M", 0);
            var result = Client.Build();
            Output.WriteLine(result.ToString());
            Output.WriteLine(result.ToHex());
            Print(result.GetBytes());
        }

        /// <summary>
        /// 测试 - 打印虚线
        /// </summary>
        [Fact]
        public void Test_DrawDashLine()
        {
            Client.SetPage(600, 200)
                .DrawDashLine(0, 10, 595, 5);
            var result = Client.Build();
            Output.WriteLine(result.ToString());
            Output.WriteLine(result.ToHex());
            Print(result.GetBytes());
        }

        /// <summary>
        /// 测试 - 打印虚线
        /// </summary>
        [Fact]
        public void Test_DrawDashLine_PageWidth()
        {
            Client.SetPage(300, 200)
                .DrawDashLine(0, 10);
            var result = Client.Build();
            Output.WriteLine(result.ToHex());
            Output.WriteLine(result.ToString());
            Print(result.GetBytes());
        }

        /// <summary>
        /// 测试 - 打印图片
        /// </summary>
        [Fact]
        public void Test_DrawBitmap()
        {
            var utopaPath = "D:\\utopa.jpg";
            //var utopaLomPath = "D:\\utopalom.jpg";
            var bmp1 = new Bitmap(Image.FromFile(utopaPath));
            //var bmp2 = new Bitmap(Image.FromFile(utopaLomPath));
            Client.SetPage(600, 400)
                .DrawBitmap(bmp1, 0, 0, false);
            //.DrawBitmap(bmp2, 0, 150, false);
            var result = Client.Build();
            Output.WriteLine(result.ToHex());
            Output.WriteLine(result.ToString());
            Print(result.GetBytes());
        }

        /// <summary>
        /// 测试 - 写入原始命令
        /// </summary>
        [Fact]
        public void Test_WriteRaw()
        {
            Client.WriteRawLine("! 0 200 200 250 1")
                .WriteRawLine("IN-INCHES")
                .WriteRawLine("T 4 0 0 0 1 cm = 0.3937\"")
                .WriteRawLine("IN-DOTS")
                .WriteRawLine("T 4 0 0 48 1 mm = 8 dots")
                .WriteRawLine("B 128 1 1 48 16 112 UNITS")
                .WriteRawLine("T 4 0 48 160 UNITS")
                .WriteRawLine("FROM")
                .WriteRawLine("PRINT");
            var result = Client.Build();
            Output.WriteLine(result.ToHex());
            Output.WriteLine(result.ToString());
            Print(result.GetBytes());
        }

        /// <summary>
        /// 测试 - 写入原始命令
        /// </summary>
        [Fact]
        public void Test_WriteRaw_1()
        {
            Client.WriteRawLine("! 0 200 200 250 1")
                .WriteRawLine("IN-CENTIMETERS")
                .WriteRawLine("T 4 0 1 0 1\" = 2.54 cm")
                .WriteRawLine("IN-MILLIMETERS")
                .WriteRawLine("T 4 0 0 6 203 dots = 25.4 mm")
                .WriteRawLine("B 128 0.125 1 6 12 14 UNITS")
                .WriteRawLine("T 4 0 16 20 UNITS")
                .WriteRawLine("FROM")
                .WriteRawLine("PRINT");
            var result = Client.Build();
            Output.WriteLine(result.ToHex());
            Output.WriteLine(result.ToString());
            Print(result.GetBytes());
        }

        /// <summary>
        /// 测试 - 写入原始命令
        /// </summary>
        [Fact]
        public void Test_WriteRaw_2()
        {
            Client.WriteRawLine("! 0 200 200 250 1")
                .WriteRawLine("IN-DOTS")
                .WriteRawLine("T 4 0 1 0 1\" = 2.54 cm")
                .WriteRawLine("T 4 0 2 15 1\" = 2.54 cm")
                .WriteRawLine("UNITS")
                .WriteRawLine("FROM")
                .WriteRawLine("PRINT");
            var result = Client.Build();
            Output.WriteLine(result.ToHex());
            Output.WriteLine(result.ToString());
            Print(result.GetBytes());
        }

        /// <summary>
        /// 测试 - 写入原始命令 - 多个标签
        /// </summary>
        [Fact]
        public void Test_WriteRaw_3()
        {
            var utopaPath = "D:\\utopa.jpg";
            var bmp1 = new Bitmap(Image.FromFile(utopaPath));
            Client
                .SetPage(600, 180)
                .SetQty(3)
                .WriteRawLine("TEXT 4 0 0 50 1")
                .Count(1)
                .WriteRawLine("TEXT 4 0 20 50 /3")
                .WriteRawLine("CENTER")
                .WriteRawLine("TEXT 4 0 0 50 TESTING 001")
                .Count(2)
                .WriteRawLine("TEXT 7 0 0 100 Barcode Value is 123456789")
                .Count(-10)
                .WriteRawLine("BARCODE 128 1 1 50 0 130 123456789")
                .Count(-10)
                .WriteRawLine("LEFT")
                .DrawBitmap(bmp1, 0, 150, false);
            var result = Client.Build();
            Output.WriteLine(result.ToHex());
            Output.WriteLine(result.ToString());
            Print(result.GetBytes());
        }

        [Fact]
        public void Test_WriteRaw_End()
        {
            Client.WriteRawLine("! 0 200 200 210 1")
                .WriteRawLine("PAGE-WIDTH 240")
                .WriteRawLine("BOX 0 0 200 200 10")
                .WriteRawLine("BOX 50 50 220 220 10")
                //.WriteRawLine("END")
                .WriteRawLine("FROM")
                .WriteRawLine("PRINT");
            Build();
        }

        [Fact]
        public void Test_WriteRaw_MultiLine()
        {
            Client.WriteRawLine("! 0 200 200 210 1")
                .MultiLine(47, "T", "4", 0, 10, 20, "1st line of text", "2nd line of text", ":", "Nth line of text")
                .WriteRawLine("FROM")
                .WriteRawLine("PRINT");
            Build();
        }

        [Fact]
        public void Test_WriteRaw_Concat()
        {
            Client.WriteRawLine("! 0 200 200 210 1")
                .Concat(75, 75, ("4", 2, 5, "$"), ("4", 3, 0, "12"), ("4", 2, 5, "34"))
                .WriteRawLine("FROM")
                .WriteRawLine("PRINT");
            Build();
        }

        [Fact]
        public void Test_WriteRaw_BarcodeRss()
        {
            Client.WriteRawLine("! 0 200 200 300 1")
                .Text("5", 0, 10, 40, "RSS14 Composite")
                .BarcodeRss(10, 110, 2, 25, 3, 22, 5, "1234567890123", "1234567890")
                .WriteRawLine("PRINT");
            Build();
        }

        [Fact]
        public void Test_WriteRaw_Pdf417()
        {
            Client.WriteRawLine("! 0 200 200 300 1")
                .Text("5", 0, 10, 40, "RSS14 Composite")
                .Pdf417(10, 20, 3, 12, 3, 2, "PDF Data", "ABCDE12345")
                .WriteRawLine("PRINT");
            Build();
        }

        [Fact]
        public void Test_WriteRaw_Maxicode()
        {
            Client.WriteRawLine("! 0 200 200 600 1")
                .WriteRawLine("JOURNAL")
                .Maxicode(20, 20, ("CC", "12345"), ("MSG", "This is a MAXICODE low priority message."), ("SC", "12345"), ("POST", "02886"))
                .WriteRawLine("PRINT");
            Build();
        }
    }
}

using System.Text;
using Bing.BluetoothPrinter.Abstractions;
using Bing.BluetoothPrinter.Core.Extensions;
using Bing.BluetoothPrinter.Zicox;
using Xunit;
using Xunit.Abstractions;

namespace Bing.BluetoothPrinter.Tests.Zicox
{
    /// <summary>
    /// 芝柯蓝牙打印机
    /// </summary>
    public class ZicoxBluetoothPrinterTest : TestBase
    {
        /// <summary>
        /// 打印机工厂
        /// </summary>
        protected IBluetoothPrinterFactory Factory { get; set; }

        /// <summary>
        /// 打印机
        /// </summary>
        protected IBluetoothPrinterProtocol Printer { get; set; }

        /// <summary>
        /// 初始化一个<see cref="TestBase"/>类型的实例
        /// </summary>
        /// <param name="output">输出</param>
        public ZicoxBluetoothPrinterTest(ITestOutputHelper output) : base(output)
        {
            Factory = new ZicoxBluetoothPrinterFactory();
            Printer = Factory.Create();
        }

        /// <summary>
        /// 测试 - 商品标签
        /// </summary>
        [Fact]
        public void Test_GoodsLabel()
        {
            Output.WriteLine(BuildGoodsLabel("美国阿拉巴利桑那州缓存地铁站进口毛豆仁 200g/盒",
                "200g",
                "瓶",
                "2019-11-04",
                3,
                "9999999991",
                "隔壁老王的二维码"));
        }

        /// <summary>
        /// 构建商品标签
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="specification">规格</param>
        /// <param name="unit">单位</param>
        /// <param name="packingDate">打包日期</param>
        /// <param name="shelfLife">保质期</param>
        /// <param name="barcode">条形码</param>
        /// <param name="qrCode">二维码</param>
        private string BuildGoodsLabel(string title, string specification, string unit, string packingDate,
            int shelfLife, string barcode, string qrCode)
        {
            var leftMargin = 0;
            Printer.SetPage(560, 420)
                .DrawText(leftMargin, 24, 550, 60, title, FontSize.Size32, TextStyle.Bold, PrintColor.Black,
                    RotationAngle.None)
                .DrawText(leftMargin, 130, $"规格：{specification}", FontSize.Size24)
                .DrawText(leftMargin, 170, $"计价单位：{unit}", FontSize.Size24)
                .DrawText(leftMargin, 210, $"包装日期：{packingDate}", FontSize.Size24)
                .DrawText(leftMargin, 250, $"保质期：{shelfLife}天", FontSize.Size24)
                .DrawText(leftMargin, 290, $"条码：{barcode}", FontSize.Size24)
                .DrawQrCode(358, 160, qrCode, QrCodeUnitSize.Size8, QrCodeCorrectionLevel.L, RotationAngle.None);
            return Printer.Build().ToHex();
        }

        /// <summary>
        /// 测试 - 字体大小
        /// </summary>
        [Fact]
        public void Test_FontSize()
        {
            Printer.SetPage(560, 5000);
            var index = 0;

            // 16点阵
            for (var i = 0; i <= 16; i++)
            {
                AddText(ref index, 55, i, (i + 1) * 16);
                Output.WriteLine($"字号: {(i + 1) * 16}");
            }
            // 24点阵
            for (var i = 0; i <= 16; i++)
            {
                AddText(ref index, 24, i, (i + 1) * 24);
                Output.WriteLine($"字号: {(i + 1) * 24}");
            }
            Output.WriteLine(Printer.Build().ToHex());
        }

        private void AddText(ref int index, int font, int scale, int fontSize)
        {
            Printer.AppendLine($"SETMAG {scale} {scale}");
            Printer.AppendLine($"TEXT {font} 0 0 {fontSize * index} {fontSize} font size 字体大小");
            index++;
        }

        /// <summary>
        /// 测试 - 生成Switch
        /// </summary>
        [Fact]
        public void Test_GenerateSwitch()
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= 408; i++)
            {

                if (i % 24 == 0)
                {
                    var scale = (i / 24);
                    if (scale > 16)
                        continue;

                    sb.AppendLine($"case {i}:");
                    sb.AppendLine($"\treturn (24,0,{scale});");
                    continue;
                }
                if (i % 16 == 0)
                {
                    var scale = (i / 16);
                    if (scale > 16)
                        continue;
                    sb.AppendLine($"case {i}:");
                    sb.AppendLine($"\treturn (55,0,{scale});");
                    continue;
                }
            }
            Output.WriteLine(sb.ToString());
        }

        /// <summary>
        /// 测试 - 生成字体大小枚举
        /// </summary>
        [Fact]
        public void Test_GenerateEnum()
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= 408; i++)
            {
                if (i % 24 == 0)
                {
                    var scale = (i / 24);
                    if (scale > 16)
                        continue;
                    sb.AppendLine($@"/// <summary>
                    /// {i}号字体
                    /// </summary>");
                    sb.AppendLine($"Size{i} = {i},");
                    continue;
                }
                if (i % 16 == 0)
                {
                    var scale = (i / 16);
                    if (scale > 16)
                        continue;
                    sb.AppendLine($@"/// <summary>
                    /// {i}号字体
                    /// </summary>");
                    sb.AppendLine($"Size{i} = {i},");
                }
            }
            Output.WriteLine(sb.ToString());
        }

        /// <summary>
        /// 测试 - 打印价格标签
        /// </summary>
        [Fact]
        public void Test_PriceLabel()
        {
            Output.WriteLine(BuildPriceLabel("美国阿拉巴利桑那州缓存地铁站进口毛豆仁 200g/盒",
                null,
                80.00m,
                "200g",
                "盒",
                "9999999991",
                "4322214847"));
        }

        private string BuildPriceLabel(string title, decimal? originalPrice, decimal actualPrice, string specification,
            string unit, string barcode, string qrCode)
        {
            var leftMargin = 0;
            // 设置打印页
            Printer.SetPage(540, 300);
            // 打印标题
            Printer.DrawText(leftMargin, 24, 520, 60, title, FontSize.Size24, TextStyle.Bold, PrintColor.Black,
                RotationAngle.None);
            // 打印价格
            var price = actualPrice.ToString("F");
            var prices = price.Split('.');
            var integerPrice = prices[0];
            var decimalPrice = prices[1];
            var fontSize = FontSize.Size64;
            Output.WriteLine(integerPrice.Length.ToString());
            var integerPriceWidth = ((int)fontSize * integerPrice.Length) / 2;
            Printer.DrawText(70, 100, 0, 0, "￥", FontSize.Size32, TextStyle.None, PrintColor.Black,
                RotationAngle.None);
            Printer.DrawText(100, 78, 0, 0, integerPrice, fontSize, TextStyle.None, PrintColor.Black,
                RotationAngle.None);
            Printer.DrawText(100 + integerPriceWidth, 80, $".{decimalPrice}", FontSize.Size24);
            Printer.DrawText(100 + integerPriceWidth, 110, $"/{unit}", FontSize.Size24);

            var spacing = 5;
            // 辅助属性
            Printer.DrawText(leftMargin, 155, $"规格：{specification}", FontSize.Size24);
            Printer.DrawText(leftMargin, 179 + spacing, $"SPEC", FontSize.Size16);

            //条码
            Printer.DrawText(leftMargin, 203 + spacing, $"条码：{barcode}", FontSize.Size24);
            Printer.DrawText(leftMargin, 227 + spacing, "Barcode", FontSize.Size16);

            // 二维码
            Printer.DrawQrCode(360, 80, qrCode, QrCodeUnitSize.Size6, QrCodeCorrectionLevel.L, RotationAngle.None);

            // 监管电话
            Printer.DrawText(340, 220, $"监管电话：12358", FontSize.Size24);
            Printer.DrawText(340, 244 + spacing, "Complaints Hotline", FontSize.Size16);
            return Printer.Build().ToHex();
        }
    }
}

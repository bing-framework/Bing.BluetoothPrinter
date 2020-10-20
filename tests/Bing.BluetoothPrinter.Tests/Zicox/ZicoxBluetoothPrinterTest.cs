using System;
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
            var result = BuildGoodsLabel("美国阿拉巴利桑那州缓存地铁站进口毛豆仁 200g/盒",
                "200g",
                "瓶",
                "2019-11-04",
                3,
                "9999999991",
                "隔壁老王的二维码");
            Output.WriteLine(result.ToHex());
            Print(result.GetBytes());
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
        private IBufferWriter BuildGoodsLabel(string title, string specification, string unit, string packingDate,
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
            return Printer.Build();
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

            var result = Printer.Build();
            Output.WriteLine(result.ToHex());
            Print(result.GetBytes());
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
            var result1 = BuildPriceLabel("美国阿拉巴利桑那州缓存地铁站进口毛豆仁 200g/盒",
                null,
                800.00m,
                "200g",
                "盒",
                "9999999991",
                "4322214847");
            Output.WriteLine(result1.ToHex());
            Print(result1.GetBytes());

            var result2 = BuildPriceLabel("非洲阿拉巴利桑那州缓存地铁站进口毛豆仁 200g/盒",
                12663.00m,
                80.00m,
                "200g",
                "盒",
                "9999999991",
                "4322214847隔壁老王的神兽");
            Output.WriteLine(result2.ToHex());
            Print(result2.GetBytes());
        }

        /// <summary>
        /// 构建价格标签
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="originalPrice">来源价格</param>
        /// <param name="actualPrice">真实价格</param>
        /// <param name="specification">分隔符</param>
        /// <param name="unit">单位</param>
        /// <param name="barcode">条形码</param>
        /// <param name="qrCode">二维码</param>
        private IBufferWriter BuildPriceLabel(string title, decimal? originalPrice, decimal actualPrice, string specification,
            string unit, string barcode, string qrCode)
        {
            var leftMargin = 0;
            var xMargin = 30;
            var yMargin = 30;
            // 设置打印页
            Printer.SetPage(540, 300);
            // 打印标题
            Printer.DrawText(30 - xMargin, 49 - yMargin, 480, 66, title, FontSize.Size24, TextStyle.None, PrintColor.Black,
                RotationAngle.None);
            if (originalPrice == null)
            {
                // 打印正价
                Printer.BilingualLabel(30 - xMargin, 116 - yMargin, "售价：", "Price", 6, zhCnFontSize: FontSize.Size16);
                Printer.GoodsPriceLabel(78 - xMargin, 190 - yMargin, actualPrice, unit);
            }
            else
            {
                // 打印特价
                var originalPriceStr = $"原价：{originalPrice.Value:F}";
                var width = ((originalPriceStr.Length + 3) * 16) / 2;
                Printer.DrawLine(30 - xMargin, 110 - yMargin + 8, 30 - xMargin + width, 110 - yMargin + 8);
                Printer.BilingualLabel(30 - xMargin, 110 - yMargin, originalPriceStr, "Price", 6, zhCnFontSize: FontSize.Size16);
                Printer.BilingualLabel(30 - xMargin, 154 - yMargin, $"优惠价：", "On sale", 6, zhCnFontSize: FontSize.Size16);
                Printer.GoodsPriceLabel(98 - xMargin, 199 - yMargin, actualPrice, unit);
            }

            // 辅助属性
            Printer.BilingualLabel(30 - xMargin, 200 - yMargin, $"规格：{specification}", "SPEC", 6);

            //条码
            Printer.BilingualLabel(30 - xMargin, 252 - yMargin, $"条码：{barcode}", "Barcode", 6);

            // 二维码
            Printer.DrawQrCode(390 - xMargin, 115 - yMargin, qrCode, QrCodeUnitSize.Size6, QrCodeCorrectionLevel.L, RotationAngle.None);

            // 监管电话
            Printer.BilingualLabel(358 - xMargin, 251 - yMargin, $"监管电话：12358", "Complaints Hotline", 6);

            return Printer.Build();
        }

        /// <summary>
        /// 测试 - 绘制虚线
        /// </summary>
        [Fact]
        public void Test_WriteDottedLine()
        {
            // 设置打印页
            Printer.SetPage(540, 300);
            var sb = new StringBuilder();
            for (int i = 0; i < 43; i++)
            {
                sb.Append("-");
            }
            Printer.DrawText(0, 10, sb.ToString(), FontSize.Size24, TextStyle.Bold);
            var result = Printer.Build();
            Output.WriteLine(result.ToHex());
            Print(result.GetBytes());
        }
    }

    /// <summary>
    /// 扩展
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// 双语标签
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="startX">标签起始x坐标</param>
        /// <param name="startY">标签起始y坐标</param>
        /// <param name="zhCnLabel">中文标签</param>
        /// <param name="enLabel">英文标签</param>
        /// <param name="lineSpacing">行距</param>
        /// <param name="zhCnFontSize">中文字体大小</param>
        /// <param name="enFontSize">英文字体大小</param>
        public static IBluetoothPrinterProtocol BilingualLabel(this IBluetoothPrinterProtocol protocol, int startX,
            int startY, string zhCnLabel, string enLabel, int lineSpacing = 5, FontSize zhCnFontSize = FontSize.Size24, FontSize enFontSize = FontSize.Size16)
        {
            protocol.DrawText(startX, startY, zhCnLabel, zhCnFontSize);
            protocol.DrawText(startX, startY + (int)zhCnFontSize + lineSpacing, enLabel, enFontSize);
            return protocol;
        }

        public static IBluetoothPrinterProtocol GoodsPriceLabel(this IBluetoothPrinterProtocol protocol, int startX,
            int startY, decimal price, string unit)
        {
            // 获取比例
            var symbolScale = GetScale("symbol");
            var priceScale = GetScale("price");
            var unitScale = GetScale("unit");
            var decimalScale = GetScale("decimal");

            // 获取分离后的价格
            var priceResult = SplitPrice(price);

            // 获取比例结果
            var symbolScaleResult = ComputeScale(symbolScale.widthScale, symbolScale.heightScale, symbolScale.fontSize);
            var priceScaleResult= ComputeScale(priceScale.widthScale, priceScale.heightScale, priceScale.fontSize);
            var unitScaleResult = ComputeScale(unitScale.widthScale, unitScale.heightScale, unitScale.fontSize);
            var decimalScaleResult = ComputeScale(decimalScale.widthScale, decimalScale.heightScale, decimalScale.fontSize);

            // 获取整数价格宽度
            var integerPriceWidth = ComputeWidth(priceScale.widthScale, priceScale.fontSize, priceResult.integerPrice);

            // 设置金钱符号
            protocol.AppendLine($"SETMAG {symbolScale.widthScale} {symbolScale.heightScale}");
            protocol.AppendLine($"T 03 0 {startX} {startY - symbolScaleResult.height} ¥");

            // 设置整数价格
            protocol.AppendLine($"SETMAG {priceScale.widthScale} {priceScale.heightScale}");
            protocol.AppendLine($"T 03 0 {startX + symbolScaleResult.width} {startY - priceScaleResult.height} {priceResult.integerPrice}");

            // 设置小数价格
            protocol.AppendLine($"SETMAG {decimalScale.widthScale} {decimalScale.heightScale}");
            protocol.AppendLine(
                $"T 03 0 {startX + symbolScaleResult.width + integerPriceWidth} {startY - decimalScaleResult.height - unitScaleResult.height - 16} .{priceResult.decimalPrice}");

            // 设置单位
            protocol.AppendLine($"SETMAG {unitScale.widthScale} {unitScale.heightScale}");
            protocol.AppendLine(
                $"T 03 0 {startX + symbolScaleResult.width + integerPriceWidth} {startY - symbolScaleResult.height + 16} /{unit}");
            return protocol;
        }

        /// <summary>
        /// 分隔价格
        /// </summary>
        /// <param name="price">价格</param>
        private static (string integerPrice, string decimalPrice) SplitPrice(decimal price)
        {
            var priceStr = price.ToString("F");
            var prices = priceStr.Split('.');
            return (prices[0], prices[1]);
        }

        private static int ComputeWidth(int scale, int fontSize, string content)
        {
            return ComputeWidth(scale * fontSize, content);
        }

        /// <summary>
        /// 计算宽度
        /// </summary>
        /// <param name="fontSize">字体尺寸</param>
        /// <param name="content">内容</param>
        private static int ComputeWidth(int fontSize, string content) => fontSize * content.Length / 2;

        /// <summary>
        /// 计算比例
        /// </summary>
        /// <param name="widthScale">宽比例</param>
        /// <param name="heightScale">高比例</param>
        /// <param name="fontSize">字体大小</param>
        private static (int width, int height) ComputeScale(int widthScale, int heightScale,int fontSize) => (widthScale * fontSize, heightScale * fontSize);

        /// <summary>
        /// 获取比例
        /// </summary>
        /// <param name="type">类型</param>
        private static (int widthScale, int heightScale,int fontSize) GetScale(string type)
        {
            switch (type)
            {
                case "symbol":
                    return (2, 2, 24);
                case "price":
                    return (2, 3, 24);
                case "unit":
                    return (1, 1, 24);
                case "decimal":
                    return (1, 1, 24);
                default:
                    throw new NotImplementedException($"尚未实现该[{type}]类型的比例");
            }
        }
    }
}

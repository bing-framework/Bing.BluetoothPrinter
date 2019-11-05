namespace Bing.BluetoothPrinter
{
    /// <summary>
    /// 打印方向
    /// </summary>
    public enum PrintOrientation
    {
        /// <summary>
        /// 正常
        /// </summary>
        None = 0,
        /// <summary>
        /// 下
        /// </summary>
        Down = 1,
        /// <summary>
        /// 左
        /// </summary>
        Left = 2,
        /// <summary>
        /// 右
        /// </summary>
        Right = 3
    }

    /// <summary>
    /// 打印颜色
    /// </summary>
    public enum PrintColor
    {
        /// <summary>
        /// 黑字白底
        /// </summary>
        Black = 0,
        /// <summary>
        /// 白字黑底
        /// </summary>
        White = 1
    }

    /// <summary>
    /// 线条样式
    /// </summary>
    public enum LineStyle
    {
        /// <summary>
        /// 实线
        /// </summary>
        Full = 0,
        /// <summary>
        /// 虚线
        /// </summary>
        Dotted = 1
    }

    /// <summary>
    /// 文字样式
    /// </summary>
    public enum TextStyle
    {
        /// <summary>
        /// 正常
        /// </summary>
        None = 0,
        /// <summary>
        /// 粗体
        /// </summary>
        Bold = 1,
        /// <summary>
        /// 斜体
        /// </summary>
        Italic = 2,
        /// <summary>
        /// 下划线
        /// </summary>
        Underline = 4
    }

    /// <summary>
    /// 字体大小
    /// </summary>
    public enum FontSize
    {
        /// <summary>
        /// 16号字体
        /// </summary>
        Size16 = 16,
        /// <summary>
        /// 20号字体
        /// </summary>
        Size20 = 20,
        /// <summary>
        /// 24号字体
        /// </summary>
        Size24 = 24,
        /// <summary>
        /// 28号字体
        /// </summary>
        Size28 = 28,
        /// <summary>
        /// 32号字体
        /// </summary>
        Size32 = 32,
        /// <summary>
        /// 40号字体
        /// </summary>
        Size40 = 40,
        /// <summary>
        /// 48号字体
        /// </summary>
        Size48 = 48,
        /// <summary>
        /// 56号字体
        /// </summary>
        Size56 = 56,
        /// <summary>
        /// 64号字体
        /// </summary>
        Size64 = 64,
        /// <summary>
        /// 72号字体
        /// </summary>
        Size72 = 72,
        /// <summary>
        /// 84号字体
        /// </summary>
        Size84 = 84,
        /// <summary>
        /// 96号字体
        /// </summary>
        Size96 = 96,
        /// <summary>
        /// 128号字体
        /// </summary>
        Size128 = 128,
    }

    /// <summary>
    /// 旋转角度
    /// </summary>
    public enum RotationAngle
    {
        /// <summary>
        /// 正常
        /// </summary>
        None = 0,
        /// <summary>
        /// 旋转90°
        /// </summary>
        Rotate90 = 90,
        /// <summary>
        /// 旋转180°
        /// </summary>
        Rotate180 = 180,
        /// <summary>
        /// 旋转270°
        /// </summary>
        Rotate270 = 270,
    }

    /// <summary>
    /// 条码类型
    /// </summary>
    public enum BarcodeType
    {
        /// <summary>
        /// CODE 128
        /// </summary>
        Code128 = 0,
        /// <summary>
        /// CODE 39
        /// </summary>
        Code39 = 1,
        /// <summary>
        /// CODE 93
        /// </summary>
        Code93 = 2,
        /// <summary>
        /// Codabar
        /// </summary>
        Codabar = 3,
        /// <summary>
        /// EAN-8
        /// </summary>
        Ean8 = 4,
        /// <summary>
        /// EAN-13
        /// </summary>
        Ean13 = 5,

        /// <summary>
        /// UPC-A
        /// </summary>
        UpcA = 6,
        /// <summary>
        /// UPC-E
        /// </summary>
        UpcE = 7,
        /// <summary>
        /// I2OF5
        /// </summary>
        // ReSharper disable once InconsistentNaming
        I2OF5 = 8,
        /// <summary>
        /// I2OF5C
        /// </summary>
        // ReSharper disable once InconsistentNaming
        I2OF5C = 9,
        /// <summary>
        /// I2OF5G
        /// </summary>
        // ReSharper disable once InconsistentNaming
        I2OF5G = 10,
        /// <summary>
        /// UCCEAN128
        /// </summary>
        UccEan128 = 11,
        /// <summary>
        /// MSI
        /// </summary>
        Msi = 12,
        /// <summary>
        /// POSTNET
        /// </summary>
        Postnet = 13,
        /// <summary>
        /// FIM
        /// </summary>
        Fim = 14
    }

    /// <summary>
    /// 二维码纠错级别
    /// </summary>
    public enum QrCodeCorrectionLevel
    {
        /// <summary>
        /// 7%的字码可被修正
        /// </summary>
        L = 0,
        /// <summary>
        /// 15%的字码可被修正
        /// </summary>
        M = 1,
        /// <summary>
        /// 25%的字码可被修正
        /// </summary>
        Q = 2,
        /// <summary>
        /// 30%的字码可被修正
        /// </summary>
        H = 3,
    }

    /// <summary>
    /// 二维码单位尺寸
    /// </summary>
    public enum QrCodeUnitSize
    {
        /// <summary>
        /// 尺寸(1 x 1)
        /// </summary>
        Size1 = 1,
        /// <summary>
        /// 尺寸(2 x 2)
        /// </summary>
        Size2 = 2,
        /// <summary>
        /// 尺寸(3 x 3)
        /// </summary>
        Size3 = 3,
        /// <summary>
        /// 尺寸(4 x 4)
        /// </summary>
        Size4 = 4,
        /// <summary>
        /// 尺寸(5 x 5)
        /// </summary>
        Size5 = 5,
        /// <summary>
        /// 尺寸(6 x 6)
        /// </summary>
        Size6 = 6,
        /// <summary>
        /// 尺寸(7 x 7)
        /// </summary>
        Size7 = 7,
        /// <summary>
        /// 尺寸(8 x 8)
        /// </summary>
        Size8 = 8,
        /// <summary>
        /// 尺寸(9 x 9)
        /// </summary>
        Size9 = 9,
        /// <summary>
        /// 尺寸(10 x 10)
        /// </summary>
        Size10 = 10,
        /// <summary>
        /// 尺寸(11 x 11)
        /// </summary>
        Size11 = 11,
        /// <summary>
        /// 尺寸(12 x 12)
        /// </summary>
        Size12 = 12,
        /// <summary>
        /// 尺寸(13 x 13)
        /// </summary>
        Size13 = 13,
        /// <summary>
        /// 尺寸(14 x 14)
        /// </summary>
        Size14 = 14,
        /// <summary>
        /// 尺寸(15 x 15)
        /// </summary>
        Size15 = 15,
        /// <summary>
        /// 尺寸(16 x 16)
        /// </summary>
        Size16 = 16,
        /// <summary>
        /// 尺寸(17 x 17)
        /// </summary>
        Size17 = 17,
        /// <summary>
        /// 尺寸(18 x 18)
        /// </summary>
        Size18 = 18,
        /// <summary>
        /// 尺寸(19 x 19)
        /// </summary>
        Size19 = 19,
        /// <summary>
        /// 尺寸(20 x 20)
        /// </summary>
        Size20 = 20,
        /// <summary>
        /// 尺寸(21 x 21)
        /// </summary>
        Size21 = 21,
        /// <summary>
        /// 尺寸(22 x 22)
        /// </summary>
        Size22 = 22,
        /// <summary>
        /// 尺寸(23 x 23)
        /// </summary>
        Size23 = 23,
        /// <summary>
        /// 尺寸(24 x 24)
        /// </summary>
        Size24 = 24,
        /// <summary>
        /// 尺寸(25 x 25)
        /// </summary>
        Size25 = 25,
        /// <summary>
        /// 尺寸(26 x 26)
        /// </summary>
        Size26 = 26,
        /// <summary>
        /// 尺寸(27 x 27)
        /// </summary>
        Size27 = 27,
        /// <summary>
        /// 尺寸(28 x 28)
        /// </summary>
        Size28 = 28,
        /// <summary>
        /// 尺寸(29 x 29)
        /// </summary>
        Size29 = 29,
        /// <summary>
        /// 尺寸(30 x 30)
        /// </summary>
        Size30 = 30,
        /// <summary>
        /// 尺寸(31 x 31)
        /// </summary>
        Size31 = 31,
        /// <summary>
        /// 尺寸(32 x 32)
        /// </summary>
        Size32 = 32,
    }
}

namespace Bing.BluetoothPrinter.Zicox.Metadata
{
    /// <summary>
    /// 元数据类型
    /// </summary>
    internal enum MetadataType
    {
        /// <summary>
        /// 原始命令
        /// </summary>
        Raw,
        /// <summary>
        /// 文本
        /// </summary>
        Text,
        /// <summary>
        /// 线
        /// </summary>
        Line,
        /// <summary>
        /// 矩形
        /// </summary>
        Box,
        /// <summary>
        /// 条码
        /// </summary>
        Barcode,
        /// <summary>
        /// 二维码
        /// </summary>
        QrCode,
        /// <summary>
        /// 图片
        /// </summary>
        Bitmap,
    }
}

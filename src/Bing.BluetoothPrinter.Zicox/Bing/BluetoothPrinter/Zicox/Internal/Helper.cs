using System;
using Bing.BluetoothPrinter.Zicox.Metadata;

namespace Bing.BluetoothPrinter.Zicox.Internal
{
    /// <summary>
    /// 命令生成辅助操作
    /// </summary>
    internal static class Helper
    {
        /// <summary>
        /// 获取文本旋转命令
        /// </summary>
        /// <param name="rotate">旋转角度</param>
        public static string GetTextRotateCommand(int rotate)
        {
            switch (rotate)
            {
                case 0:
                    return "T";
                case 90:
                    return "T90";
                case 180:
                    return "T180";
                case 270:
                    return "T270";
                default:
                    return "T";
            }
        }

        /// <summary>
        /// 计算字体大小
        /// </summary>
        /// <param name="fontSize">字体大小</param>
        public static (int font, int size, int scale) ComputeFontSize(int fontSize)
        {
            switch (fontSize)
            {
                case 16:
                    return (55, 0, 0);
                case 20:
                    return (20, 0, 0);
                case 24:
                    return (24, 0, 0);
                case 28:
                    return (28, 0, 0);
                case 32:
                    return (55, 0, 2);
                case 40:
                    return (20, 0, 2);
                case 48:
                    return (24, 0, 2);
                case 56:
                    return (28, 0, 2);
                case 64:
                    return (55, 0, 4);
                case 72:
                    return (24, 0, 3);
                case 84:
                    return (28, 0, 3);
                case 96:
                    return (24, 0, 4);
                default:
                    return (55, 0, 1);
            }
        }

        /// <summary>
        /// 转换样式
        /// </summary>
        /// <param name="style">样式</param>
        public static (bool bold, bool underline) ConvertStyle(int style)
        {
            switch (style)
            {
                case 1:
                case 3:
                    return (true, false);
                case 4:
                case 6:
                    return (false, true);
                case 5:
                case 7:
                    return (true, true);
                default:
                    return (false, false);
            }
        }

        /// <summary>
        /// 获取条码旋转命令
        /// </summary>
        /// <param name="rotate">旋转角度</param>
        public static string GetBarcodeRotateCommand(int rotate)
        {
            switch (rotate)
            {
                case 0:
                case 180:
                    return "B";
                case 90:
                case 270:
                    return "VB";
                default:
                    return "B";
            }
        }

        /// <summary>
        /// 获取条码起始坐标
        /// </summary>
        /// <param name="item">条码明细</param>
        public static (int x, int y) GetBarcodeCoordinate(DrawBarcode1DItem item) => GetBarcodeCoordinate(item.Rotate, item.X, item.Y, 0, item.Height);

        /// <summary>
        /// 获取条码起始坐标
        /// </summary>
        /// <param name="item">二维码明细</param>
        public static (int x, int y) GetBarcodeCoordinate(DrawQrCodeItem item) => GetBarcodeCoordinate(item.Rotate, item.X, item.Y, 0, 0);

        /// <summary>
        /// 获取条码起始坐标
        /// </summary>
        /// <param name="rotate">旋转角度</param>
        /// <param name="x">X轴起始坐标</param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static (int x, int y) GetBarcodeCoordinate(int rotate, int x, int y, int width, int height)
        {
            switch (rotate)
            {
                case 180:
                    x -= width;
                    y -= height;
                    break;
                case 270:
                    x -= height;
                    y += width;
                    break;
            }

            return (x, y);
        }
    }
}

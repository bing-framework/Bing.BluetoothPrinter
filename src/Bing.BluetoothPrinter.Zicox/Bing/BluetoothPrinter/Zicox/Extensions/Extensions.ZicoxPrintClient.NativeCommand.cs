using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Bing.BluetoothPrinter.Zicox
{
    /// <summary>
    /// 芝柯打印客户端(<see cref="ZicoxPrintClient"/>) 扩展
    /// </summary>
    public static partial class ZicoxPrintClientExtensions
    {
        /// <summary>
        /// TEXT 命令
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="font">字体名称/编号</param>
        /// <param name="size">字体的大小标识</param>
        /// <param name="x">横向起始位置</param>
        /// <param name="y">纵向起始位置</param>
        /// <param name="data">要打印的文本</param>
        public static ZicoxPrintClient Text(this ZicoxPrintClient client, string font, int size, int x, int y, string data) => client.WriteRawLine($"T {font} {size} {x} {y} {data}");
    }
}

using System.Text;
using Xunit.Abstractions;

namespace Bing.BluetoothPrinter.Tests
{
    /// <summary>
    /// 测试基类
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// 输出
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// 初始化一个<see cref="TestBase"/>类型的实例
        /// </summary>
        /// <param name="output">输出</param>
        protected TestBase(ITestOutputHelper output)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Output = output;
        }
    }
}

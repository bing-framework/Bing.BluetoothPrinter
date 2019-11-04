using System.Text;
using Xunit.Abstractions;

namespace Bing.BluetoothPrinter.Tests
{
    /// <summary>
    /// ���Ի���
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// ���
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// ��ʼ��һ��<see cref="TestBase"/>���͵�ʵ��
        /// </summary>
        /// <param name="output">���</param>
        protected TestBase(ITestOutputHelper output)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Output = output;
        }
    }
}

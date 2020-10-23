using Xunit;

namespace Bing.BluetoothPrinter.Tests.Zicox
{
    public partial class ZicoxPrintClientTest
    {
        [Fact]
        public void Test_QrCode_1()
        {
            Client.WriteRawLine("! 0 200 200 500 1")
                .QRCode(10, 100, 2, 10, 'M', null, "QR code ABC123")
                .Text(4, 0, 10, 400, "QR code ABC123")
                .Form()
                .Print();
            Build();
        }

        [Fact]
        public void Test_Aztec()
        {
            Client.WriteRawLine("! 0 200 200 600 1")
                .Text(7, 0, 50, 0, "Aztec Code - Label Spec 5-1 EC=47")
                .Aztec(50, 100, 7, 47, "123456789012")
                .Print();
            Build();
        }
    }
}

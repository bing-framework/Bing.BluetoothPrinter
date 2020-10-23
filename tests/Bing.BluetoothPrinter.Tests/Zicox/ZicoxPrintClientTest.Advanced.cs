﻿using Xunit;

namespace Bing.BluetoothPrinter.Tests.Zicox
{
    public partial class ZicoxPrintClientTest
    {
        [Fact]
        public void Test_HorizontalAlignment()
        {
            Client.WriteRawLine("! 0 200 200 210 1")
                .PageWidth(600)
                .Center()
                .Text(4,0,0,75,"C")
                .Left()
                .Text(4,0,0,75,"L")
                .Right()
                .Text(4,0,0,75,"R")
                .Print();
            Build();
        }

        [Fact]
        public void Test_Pace()
        {
            Client.WriteRawLine("! 0 200 200 210 3")
                .Pace()
                .Journal()
                .Text(4, 1, 0, 10, "Print 3 labels")
                .Text(4,1,0,90,"Using PACE")
                .Print();
            Build();
        }

        [Fact]
        public void Test_AutoPace()
        {
            Client.WriteRawLine("! 0 200 200 250 10")
                .Center()
                .Text(7, 0, 0, 10, "AUTO-PACE EXAMPLE")
                .PaceAuto()
                .Form()
                .Print();
            Build();
        }

        [Fact]
        public void Test_NoPace()
        {
            Client.WriteRawLine("! 0 200 200 250 10")
                .Text(7,0,0,10,"AUTO-PACE EXAMPLE")
                .PaceAuto()
                .Form()
                .Print()
                .WriteRawLine("! 0 200 200 250 10")
                .Text(7, 0, 0, 10, "NO-PACE EXAMPLE")
                .PaceNo()
                .Form()
                .Print();
            Build();
        }

        [Fact]
        public void Test_Wait()
        {
            Client.WriteRawLine("! 0 200 200 150 5")
                .Wait(80)
                .Text(5,0,0,20,"DELAY 10 SECONDS")
                .Form()
                .Print();
            Build();
        }

        [Fact]
        public void Test_Tension()
        {
            Client.WriteRawLine("! 0 200 200 150 1")
                .TensionPre(30)
                .Text(5,0,0,20,"ADJUSTS TENSION")
                .Print();
            Build();
        }

        [Fact]
        public void Test_SetSp()
        {
            Client.WriteRawLine("! 0 200 200 250 1")
                .Text(4,0,0,10,"Normal Spacing")
                .SetSp(5)
                .Text(4, 0, 0, 50, "Spread Spacing")
                .SetSp(0)
                .Text(4,0,0,90, "Normal Spacing")
                .Form()
                .Print();
            Build();
        }

        [Fact]
        public void Test_PostFeed()
        {
            Client.WriteRawLine("! 0 200 200 250 1")
                .Text(7, 0, 0, 10, "POSTFEED EXAMPLE")
                .Form()
                .PostFeed(40)
                .Print();
            Build();
        }

        [Fact]
        public void Test_PreSendAt()
        {
            Client.WriteRawLine("! 0 200 200 250 1")
                .Text(7, 0, 0, 10, "PRESENT-AT EXAMPLE")
                .PreSentAt(80, 2)
                .Form()
                .Print();
            Build();
        }

        [Fact]
        public void Test_DefineFormat()
        {
            Client.DefineFormat("SHELF.FMT", "! 0 200 200 210 1", "CENTER", "TEXT 4 3 0 15 \\\\", "TEXT 4 0 0 95 \\\\",
                "BARCODE UPCA 1 1 40 0 145 \\\\", "TEXT 7 0 0 185 \\\\", "FORM", "PRINT");
            Build();
        }

        [Fact]
        public void Test_UseFormat()
        {
            Client.UseFormat("SHELF.FMT", "$22.99", "SWEATSHIRT", "40123456784", "40123456784");
            Build();
        }

        [Fact]
        public void Test_Beep()
        {
            Client.WriteRawLine("! 0 200 200 210 1")
                .Center()
                .Text("5", 0, 0, 10, "beeps for two seconds")
                .Beep(16)
                .Form()
                .Print();
            Build();
        }

        [Fact]
        public void Test_Cut()
        {
            Client.WriteRawLine("! 0 200 200 210 1")
                .Center()
                .Text("4",0,0, 1,".15 CUT COMMAND")
                .Cut()
                .Print();
            Build();
        }
    }
}

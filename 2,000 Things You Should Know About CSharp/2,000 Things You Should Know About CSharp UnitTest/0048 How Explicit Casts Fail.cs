using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/04/48-how-explicit-casts-fail/

    [TestClass]
    public class How_Explicit_Casts_Fail
    {
        /*
         * When doing explicit numeric conversions, it’s possible that the value of the source type cannot be exactly represented in the destination type.
         * When this happens, one of several things may occur:
         *  Integer to integer: extra bits discarded
         *  Decimal to integer: truncates
         *  Float/Double to integer: truncates
         *  Double to float: rounded, or set to “infinity” value if too large
         *  Float/Double to decimal: rounded
         *  Decimal to float/double: loss of precision
         * The checked keyword can be used to throw exception if result is out of range.
         * 
         * 在做數值的明確轉換時，有可能原先的數值無法準確的用目標類型來表示，在這種情況下，可能會發生底下的情況：
         *  Integer to integer：去除額外的位數
         *  Decimal to integer：截短
         *  Float/Double to integer：截短
         *  Double to float：四捨五入，如果過大(設置為 無限 的值)
         *  Float/Double to decimal：四捨五入
         *  Decimal to float/double：精準度損失
         * 有個叫做 checked 的關鍵字可以用來檢查轉換結果，如果超出範圍會丟出例外
         */
        [TestMethod]
        public void How_Explicit_Casts_Fail_Implement()
        {
            long l = (long)int.MaxValue + 1;      // l = 2147483648
            int i = (int)l;                       // i set to -2147483648 (same hex value)
            Assert.AreNotEqual(l, i);
            // TODO checked
            // i = checked((int)l);

            l = 0x2200000005;     // Try larger number
            i = (int)l;           // i set to 5
            Assert.AreNotEqual(l, i);
            // TODO checked
            // i = checked((int)l);

            float f = 4.8f;
            i = (int)f;           // i set to 4 (truncated)
            // TODO checked
            // i = checked((int)f); 
            Assert.AreNotEqual(f, i);

            double d = 1.00000008;
            f = (float)d;         // f rounded to 1.00000012
            Assert.AreNotEqual(d, f);
        }
    }
}
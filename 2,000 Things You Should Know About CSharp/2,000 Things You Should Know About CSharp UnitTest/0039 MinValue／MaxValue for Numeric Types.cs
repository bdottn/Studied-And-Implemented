using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/07/26/39-minvalue-maxvalue-for-numeric-types/

    [TestClass]
    public class MinValue_MaxValue_for_Numeric_Types
    {
        /*
         * You can access minimum and maximum values for the various built-in numeric types from your code by using the MinValue and MaxValue properties of each type.
         * All of the built-in numeric types have MinValue and MaxValue properties.
         * 
         * 所有內建的值類型，都有 MinValue 和 MaxValue 屬性
         * 你可以在程式中直接使用該屬性來取得最大值或最小值
         */
        [TestMethod]
        public void MinValue_MaxValue_for_Numeric_Types_Implement()
        {
            byte bMin = byte.MinValue;
            // the MinValue of byte is 0
            Assert.AreEqual(0, bMin);

            byte bMax = byte.MaxValue;
            // the MaxValue of byte is 255
            Assert.AreEqual(255, bMax);

            int nMin = int.MinValue;
            // the MinValue of int is -2147483648
            Assert.AreEqual(-2147483648, nMin);

            int nMax = int.MaxValue;
            // the MaxValue of int is 2147483647
            Assert.AreEqual(2147483647, nMax);

            char cMin = char.MinValue;
            // the MinValue of char is 0x0000
            Assert.AreEqual(0x0000, cMin);

            char cMax = char.MaxValue;
            // the MaxValue of char is 0xffff
            Assert.AreEqual(0xffff, cMax);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/08/52-arithmetic-operators/

    [TestClass]
    public class Arithmetic_Operators
    {
        /*
         * All numeric types in C# support the following arithmetic operators.
         *  Multiplicative operators
         *  「*」：Multiplication
         *  「/」：Division
         *  「%」：Modulus
         *  Additive operators
         *  「+」：Addition
         *  「-」：Subtraction
         *  
         * 在 C# 中所有數值類型都支援下列算數運算子
         *  「*」：乘
         *  「/」：除
         *  「%」：餘
         *  「+」：加
         *  「-」：減
         */
        [TestMethod]
        public void Arithmetic_Operators_Implement()
        {
            // Multiplication
            int n1 = 12 * 22;       // 264
            double d1 = 2.3 * 4.8;  // 11.04
            double d2 = 6.9 * 2;    // 13.8 (implicit cast)

            // Division
            int n2 = 7 / 5;     // 1  (truncated)
            double d3 = 6 / 8;  // 0  (int division, then cast)
            double d4 = 6.0 / 8;   // 0.75  (8 implicit cast to double)

            // Modulus
            int n3 = 7 % 5;     // 2
            int n4 = 10 % 2;    // 0
            int n5 = 2 % 10;    // 2
            decimal m1 = 2.2m % 1.2m;  // 1

            // Addition
            int n6 = 12 + 15;   // 27
            int n7 = -23 + 12;  // -11
            double d5 = 5.6 + -2.3;   // 3.3
            ushort ul1 = 0x1234 + 0x9999;  // 0xabcd

            // Subtraction
            int n8 = 5 - 12;    // -7
            decimal m2 = 4.24m - 1.01m;   // 3.23
        }
    }
}
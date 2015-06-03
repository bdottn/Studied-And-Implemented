using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/08/52-arithmetic-operators/

    [TestClass]
    public class Modulus
    {
        /*
         * The modulus operator %, used as a binary operator
         *      a % b
         * is defined as the remainder of a (dividend) divided by b (divisor).
         * Also known as “modulo“.
         * The idea is to determine the maximum integer that you can multiply b by to get a result <=a. Let’s call this integer n.
         * Then the remainder is just a – (b * n).
         * If a is equal to b, the remainder is always 0.
         * If a is less than b, the remainder is always equal to a.
         * If either a or b is negative, the result always matches the sign of a.
         * C# also supports the use of the modulus operator for floating point numbers
         * 
         * 餘數的運算符為 %
         * 在 C# 中同時也支援浮點數的運算
         */
        [TestMethod]
        public void Modulus_Implement()
        {
            int n1 = 5 % 2;    // 1  [5-(2*2)]
            int n2 = 39 % 5;   // 4  [39-(5*7)]
            int n3 = 10 % 2;   // 0  [10-(2*5)]

            int n5 = -5 % 2;   // -1
            int n6 = 5 % -2;   //  1
            int n7 = -5 % -2;  // -1

            double d1 = 42.5 % 12.2;  // 5.9 [42.5-(12.2*3)]
        }
    }
}
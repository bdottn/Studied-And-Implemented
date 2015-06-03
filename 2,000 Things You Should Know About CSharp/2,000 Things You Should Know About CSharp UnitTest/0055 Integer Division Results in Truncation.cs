using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/11/55-integer-division-results-in-truncation/

    [TestClass]
    public class Integer_Division_Results_in_Truncation
    {
        /*
         * When dividing one integer by another using the division operator, C# always rounds the result towards 0 — i.e. truncates.
         * If an attempt is made to divide by zero, an exception of type System.DivideByZeroException is thrown.
         * If you try to divide by the literal 0, you’ll get an error at compile time.
         * 
         * 在 C# 除法中會取到該數值類型最後一位後截斷，不會進行四捨五入的動作
         * 當除數為 0 時會得到一個 DivideByZeroException 例外
         * 當直接寫除數為 0 時，編譯時期會發生錯誤
         */
        [TestMethod]
        public void Integer_Division_Results_in_Truncation_Implement()
        {
            int n1 = 7 / 2;       // 3
            long n2 = -7 / 2;     // -3
            short n3 = -11 / -3;  // 3

            double d1 = 7 / 2;
            double d2 = (double)7 / 2;

            // DivideByZeroException
            // TODO try
            // int n4 = 0;
            // int n5 = 7 / n4;

            // 錯誤：除以常數 0
            // TODO try 
            // int n6 = 7 / 0;
        }
    }
}
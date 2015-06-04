using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/12/56-how-to-round-when-converting-float-to-int/

    [TestClass]
    public class How_to_Round_When_Converting_Float_to_Int
    {
        /*
         * When converting from float or double to int, we cannot use an implicit cast, because data would be lost.
         * When casting from float or double to int, the resulting value is truncated (rounded towards 0) to get an integral result.
         * If you want to round to the nearest integer, rather than truncating, you can use one of the methods in System.Convert.
         * The Convert method always rounds to the nearest integer, unless the result is halfway between two integers.
         * 
         * 當從 float 或 double 轉成 int 時，不能使用隱含轉換，因為數據會因此移失
         * 使用明確轉換，結果數據會被截斷
         * 如果不想使用捨去方式截斷，可以使用 convert 來進行轉換，此時數據會轉換成他最靠近的那個整數
         */
        [TestMethod]
        public void How_to_Round_When_Converting_Float_to_Int_Implement()
        {
            float f1 = 4.8f;
            // Compile-time error: cannot implicitly convert
            // TODO try
            // int n1 = f1;        
            int n1 = (int)f1;     // Explicit cast, truncated, n1 = 4

            n1 = Convert.ToInt32(4.8f);   // Rounded, n1 = 5

            n1 = Convert.ToInt32(8.5f);  // Rounded to nearest even, n1 = 8
            n1 = Convert.ToInt32(9.5f);  // Rounded to nearest even, n1 = 10
        }
    }
}
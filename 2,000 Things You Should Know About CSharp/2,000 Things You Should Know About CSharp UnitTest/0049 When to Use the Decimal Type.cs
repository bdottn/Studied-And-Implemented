using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/05/49-when-to-use-the-decimal-type/

    [TestClass]
    public class When_to_Use_the_Decimal_Type
    {
        /*
         * You should use the decimal type (System.Decimal) for monetary calculations, or whenever you want more digits of precision, to avoid round-off error.
         * The decimal type gives you greater precision, but doesn’t support storing numbers as large as float or double.
         * This is because it stores all digits, rather than storing the mantissa and exponent of the number.
         * The decimal type also requires more storage space.
         *  float – 4 bytes  (±1.5e−45 to ±3.4e38, 7 digit precision)
         *  double – 8 bytes  (±5.0e−324 to ±1.7e308, 15-16 digit precision)
         *  decimal – 16 bytes  (±1.0 × 10−28 to ±7.9 × 1028, 28-29 digit precision)
         * 
         * 建議使用 decimal 類型做為貨幣的數值計算，可以擁有較高的精準度並且避免四捨五入的誤差
         * 相較於 float 及 double，decimal 擁有較高的精準度，但同時 decimal 所佔用的記憶體儲存空間也較多
         */
        [TestMethod]
        public void When_to_Use_the_Decimal_Type_Implement()
        {
            float f = 12345678901234567.28f;     // 1.23456784E+16
            double d = 12345678901234567.28d;    // 12345678901234568.0
            decimal dc = 12345678901234567.28m;  // 12345678901234567.28
        }
    }
}
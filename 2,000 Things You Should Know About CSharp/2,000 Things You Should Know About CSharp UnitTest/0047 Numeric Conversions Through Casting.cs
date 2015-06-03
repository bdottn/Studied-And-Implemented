using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/03/47-numeric-conversions-through-casting/

    [TestClass]
    public class Numeric_Conversions_Through_Casting
    {
        /*
         * A conversion needs to happen when assigning a numeric value of one type to a variable of a different type.
         * Data values can be implicitly (automatically) converted whenever the conversion would not result in a loss of data.
         * This is possible if the target type has a wider range of types or greater precision than the source type.
         * 
         * 當一個值類型的變數被給定一個數值，而該數值的類型不同於變數類型的時候，會發生數值轉換
         * 數據值可以是隱含轉換，每當轉換時數值不會遺失(如果目標類型具有更廣泛的類型或比原先類型有高的精確度)
         */
        [TestMethod]
        public void Numeric_Conversions_Through_Casting_Implicit()
        {
            int i = 12;

            // Implicit (int to long)
            long l = i;
            Assert.AreEqual(i, l);

            // Implicit (int to float)
            float f = i;
            Assert.AreEqual(i, f);

            // Implicit (float to double)
            double d = 4.2f;
            Assert.AreEqual(4.2f, d);
            Assert.AreNotEqual(4.2, d);
        }

        /*
         * An explicit conversion is required when the conversion cannot be done without losing data.
         * These conversions require a cast operator that specifies the target type.
         * 
         * 明確轉換無法不移失數值
         * 這些轉換需要強制指定目標類型
         */
        [TestMethod]
        public void Numeric_Conversions_Through_Casting_Explicit()
        {
            long l = 12;

            // TODO：Compiler error--can't implicitly convert
            // int i = l;
            // Explicit (long to int)
            int i = (int)l;

            // Explicit (float to int)
            float f = 4.2f;
            i = (int)f;
            Assert.AreNotEqual(f, i);

            // Implicit (float to double)
            double d = 4.2f;
            // Explicit (double to float)
            f = (float)d;
            Assert.AreEqual(d, f);
        }
    }
}
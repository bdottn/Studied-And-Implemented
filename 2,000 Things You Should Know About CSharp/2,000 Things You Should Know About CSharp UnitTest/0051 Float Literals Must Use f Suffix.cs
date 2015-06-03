using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/07/51-float-literals-must-use-f-suffix/

    [TestClass]
    public class Float_Literals_Must_Use_f_Suffix
    {
        /*
         * When specifying literals of type double, you don’t need a suffix.
         * All floating point literals are by default assumed to be of type double.
         * But when specifying float literals, you need an explicit cast, or the f suffix.
         * 
         * 當使用 double 類型時，所給定的數值不需要加上文字後綴，所有的浮點數數值的類型都被默認為 double
         * 但是當使用 float 類型時，需要使用明確轉換或加上 f 文字後綴
         */
        [TestMethod]
        public void Float_Literals_Must_Use_f_Suffix_Implement()
        {
            double d1 = 4.2;

            // 錯誤：不能隱含將型別 double 的常值轉換為型別 'float'
            // TODO try
            // float f = 4.2;

            // double explicitly cast to float
            float f2 = (float)4.2;

            // 'f' indicates that literal is float
            float f3 = 4.2f;
        }
    }
}
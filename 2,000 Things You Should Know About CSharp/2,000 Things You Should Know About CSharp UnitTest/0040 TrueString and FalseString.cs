using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/07/27/40-truestring-and-falsestring/

    [TestClass]
    public class TrueString_and_FalseString
    {
        /*
         * The System.Boolean type (bool) provides two fields that let you get string representations of the true and false values.
         * 
         * 布林類型提供了兩個字串讓你可以在程式中直接取得值的字串表示
         */
        [TestMethod]
        public void TrueString_and_FalseString_Implement()
        {
            string trueText = bool.TrueString;
            Assert.AreEqual("True", trueText);

            string falseText = bool.FalseString;
            Assert.AreEqual("False", falseText);
        }

        /*
         * These fields return “True” and “False”, regardless of current regional settings or the native language of the operating system.
         * These values are identical to the string values returned from the System.Boolean.ToString() method, which can be called on an instance of bool.
         * 
         * 這些回傳值其實跟直接使用 System.Boolean.ToString() 是相同的
         */
        [TestMethod]
        public void TrueString_and_FalseString_Test()
        {
            bool bTrue = true;
            bool bFalse = false;

            string trueText = bool.TrueString;
            string falseText = bool.FalseString;

            Assert.AreEqual(bTrue.ToString(), trueText);
            Assert.AreEqual(bFalse.ToString(), falseText);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjectForUnitTest
{
    // Reference：https://msdn.microsoft.com/zh-tw/library/microsoft.visualstudio.testtools.unittesting.expectedexceptionattribute.aspx

    [TestClass]
    public class TestForException
    {
        /*
         * 使用 ExpectedExceptionAttribute 表示測試方法執行期間所發生的預期例外狀況
         * 使用方法為在 Method 上加上 [ExpectedException(exceptionType)]
         * 如果擲回預期的 exceptionType，則測試方法將會成功
         */

        class DivisionClass
        {
            public int Divide(int numerator, int denominator)
            {
                return numerator / denominator;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideTest_InputZeroDenominator_ReturnDivideByZeroException()
        {
            DivisionClass target = new DivisionClass();

            int numerator = 4;
            int denominator = 0;
            int actual;

            // throw DivideByZeroException
            actual = target.Divide(numerator, denominator);
        }
    }
}
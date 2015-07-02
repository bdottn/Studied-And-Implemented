using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjectForUnitTest
{
    [TestClass]
    public class TestForException
    {
        class DivisionClass
        {
            public int Divide(int numerator, int denominator)
            {
                return numerator / denominator;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideTest()
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
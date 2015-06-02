using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/07/24/37-all-value-types-have-a-default-constructor/

    [TestClass]
    public class All_Value_Types_Have_a_Default_Constructor
    {
        /*
         * All built-in value types in C# support a default (parameterless) constructor using the new keyword.
         * The default constructor allows you to instantiate an object such that it takes on a default value.
         * You’d normally instantiate one of the built-in types by giving the associated variable a value.
         * But it’s also possible to use the new keyword to cause the variable to take on a default value.
         *
         * 在 C# 中，所有的值類型(value type) 都有預設的默認建構式，這個建構式允許在變數實例化時給定一個預設值
         * 通常會通過給定相關變數的值來實例化該變數，但也可以使用預設建構式來實例化
         */
        [TestMethod]
        public void All_Value_Types_Have_a_Default_Constructor_Implement()
        {
            // 尚未實例化
            int i;

            // 實例化：value of n1 is 12
            int n1 = 12;

            // 實例化：value of n2 is default value
            int n2 = new int();
        }

        /*
         * The default values for the built-in value types are:
         * bool type = false
         * Numeric types (e.g. int, float) = 0 or 0.0
         * char type = single empty character
         * DateTime type = 1/1/0001 12:00:00 AM
         */
        [TestMethod]
        public void All_Value_Types_Have_a_Default_Constructor_Test()
        {
            bool b = new bool();
            Assert.AreEqual(false, b);

            int i = new int();
            Assert.AreEqual(0, i);

            float f = new float();
            Assert.AreEqual(0.0, f);

            char c = new char();
            Assert.AreEqual('\0', c);

            DateTime dt = new DateTime();
            Assert.AreEqual(new DateTime(1, 1, 1, 00, 00, 00), dt);
        }
    }
}
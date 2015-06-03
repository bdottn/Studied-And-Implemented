using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/10/54-increment-and-decrement-operators/

    [TestClass]
    public class Increment_and_Decrement_Operators
    {
        /*
         * The increment operator (++) increments its operand by 1.  It’s a shorthand for using the binary + operator with an operand of 1.
         * You can also use the increment operator on the right-hand side of an expression.  In the example below, n1 is incremented after the expression is evaluated.
         * Placing the ++ operator after the operand is known as postfix notation.  With prefix notation, the operator is placed before the operand, indicating the the variable should be incremented before the expression is evaluated.
         * The decrement operator (- -) works similarly, decrementing the operand by 1.
         * 
         * 遞增運算子(++) 表示遞增1
         * 增量運算符寫在表達式的右邊，表示在進行完陳述式以後進行增量
         * 增量運算符寫在表達式的左邊，表示在進行完陳述式以前進行增量
         * 
         * 遞減運算子(--) 表示遞減1
         * 規則同 遞增運算子
         */
        [TestMethod]
        public void Increment_and_Decrement_Operators_Implement()
        {
            int n1 = 5;

            n1 = n1 + 1;
            Assert.AreEqual(6, n1);

            n1++;
            Assert.AreEqual(7, n1);

            n1 = 5;
            int n2 = 2 * n1++;
            Assert.AreEqual(6, n1);
            Assert.AreEqual(10, n2);

            n1 = 5;
            n2 = 2 * ++n1;
            Assert.AreEqual(6, n1);
            Assert.AreEqual(12, n2);

            n1 = 5;
            n2 = 2 * n1--;
            Assert.AreEqual(4, n1);
            Assert.AreEqual(10, n2);
        }
    }
}
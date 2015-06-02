using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/07/22/35-declaring-variables/

    [TestClass]
    public class Declaring_Variables
    {
        /*
         * In C#, you declare a variable by specifying a type, followed by the name of the new variable.
         * You can also optionally initialize the variable at the time that you declare it.
         * If you initialize a variable at the time that it is declared, the initializer can be a literal value, an expression, or an array initializer.
         * 
         * 在 C# 中，可以通過定義指定一個變數的類型
         * 也可以在定義之後宣告一個類型
         * 也可以選擇在宣告時給定初始值
         * 如果在宣告時給定初始值，初始值可以是字面(Literal)、表達式(Experssion)或是陣列(array)。
         */
        [TestMethod]
        public void Declaring_Variables_Implement()
        {
            float length;
            int age = 46;
            string s = "Sean";
            Person p;
            Person q = new Person("Herman", 12);
            object o = s;
            int yrsLeft = 100 - age;
            int[] nums = { 10, 20, 30 };
            object[] stuff = { nums, age, q };
        }
    }
}
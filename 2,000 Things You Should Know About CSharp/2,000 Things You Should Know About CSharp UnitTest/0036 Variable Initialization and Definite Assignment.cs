using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/07/23/36-variable-initialization/

    [TestClass]
    public class Variable_Initialization_and_Definite_Assignment
    {
        /*
         * Variables must be assigned a value before they can be used.
         * You can declare a variable without initializing it, but attempting to reference the value of the variable before you’ve given it a value will result in a compiler error.
         * 
         * 變數在被使用之前需要給定一個值
         * 如果在宣告一個變數之後在使用該變數之前沒有給定初使值，會在編譯時期發生錯誤
         */
        [TestMethod]
        public void Variable_Initialization_and_Definite_Assignment_Compiler()
        {
            int i;
            // 錯誤：使用未指定的區域變數 'i'
            // TODO try 
            // int j = i + 1;
        }

        /*
         * This requirement of definite assignment before use means that you are never able to reference an unassigned variable in C#.
         * It’s considered good practice to initialize a variable when you declare it.
         * This applies to both built-in types and custom types.
         * When you initialize a variable, the object that it references is said to be instantiated.
         *
         * 這代表在 C# 內未給定值的變數將無法使用
         * 當你給定一個變數初始化的值，該變數所參考的對象稱為實例化(instantiated)
         */
        [TestMethod]
        public void Variable_Initialization_and_Definite_Assignment_Implement()
        {
            Person p = new Person();
            int i = 0;
            int j = i + 1;
        }
    }
}
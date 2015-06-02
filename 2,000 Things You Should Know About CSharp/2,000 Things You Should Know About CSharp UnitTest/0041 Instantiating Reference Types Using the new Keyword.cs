using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/07/28/41-instantiating-reference-types/

    [TestClass]
    public class Instantiating_Reference_Types_Using_the_new_Keyword
    {
        /*
         * To create an object of a particular type, you need to instantiate the type.
         * Value types are instantiated by assigning them a value.
         * Reference types are instantiated using the new keyword.
         * Using new allows us to create a new instance of the type.
         * When new is used to instantiate a type, the type’s constructor is called to perform the initialization.
         * The type may have a default constructor that takes no parameters, or it may have a constructor that takes one or more parameter values.
         * It may also support multiple constructors.
         * Variables declared as instances of reference types will hold the value null until they are instantiated.
         * 
         * 當要使用一個變數時，必須先給定一個值
         * 值類別可以直接指派值
         * 參考類別需要加上關鍵字：new
         * 一般類別若未定義建構式，會自帶一個未帶參數的建構式
         * 但若定義了一個以上建構式時，若要使用未帶參數的建構式，則必須自己再加以定義未帶參數的建構式
         */
        [TestMethod]
        public void Instantiating_Reference_Types_Using_the_new_Keyword_Implement()
        {
            // 尚未實例化，值為 null
            Person p1;

            // 實例化：類別預設建構式，沒有參數
            Person p2 = new Person();

            // 實例化：類別建構式，有兩個參數
            Person p3 = new Person("Sean", 46);
        }
    }
}
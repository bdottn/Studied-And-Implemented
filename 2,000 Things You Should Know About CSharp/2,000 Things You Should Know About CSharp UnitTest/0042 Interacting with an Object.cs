using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/07/29/42-interacting-with-an-object/

    [TestClass]
    public class Interacting_with_an_Object
    {
        /*
         * Once you create an instance of a reference type using the new keyword, you can interact with the new object through the variable that serves as a reference to that object.
         * You can call the object’s methods or read and write its properties.
         * 
         * 當透過使用 new 關鍵字建立一個參考類型的實例，就可以透過該實例取得物件的屬性或使用方法
         * 並可對該實例進行交互作用改變或讀取物件屬性
         */
        [TestMethod]
        public void Interacting_with_an_Object_Implement()
        {
            // Make a new Person object
            Person p1 = new Person("Sean", 46);

            // Read some properties
            string theName = p1.Name;
            Assert.AreEqual("Sean", theName);

            int howOld = p1.Age;
            Assert.AreEqual(46, howOld);

            // Set Age property to new value
            p1.Age = p1.Age - 10;
            int younger = p1.Age;

            // Call method that takes no parameters, returns description
            //   Will return:  Sean is 36 yrs old.
            string describe = p1.Description();
            Assert.AreEqual("Sean is 36 yrs old.", string.Format("{0} is {1} yrs old.", theName, younger));
        }
    }
}
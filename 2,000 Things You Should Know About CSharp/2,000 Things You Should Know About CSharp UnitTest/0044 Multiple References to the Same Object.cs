using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/07/31/44-multiple-references-to-the-same-object/

    [TestClass]
    public class Multiple_References_to_the_Same_Object
    {
        /*
         * If you assign a variable that points to a reference type to another variable of the same type, both variables end up pointing to the same object in memory.
         * This means that changing the contents of the object through the first reference results in changes that are also seen by the second reference.
         * 
         * 如果在指定變數時給定另一個相同參考類型的變量，則兩個變數都會指向記憶體中同一個儲存位置
         * 這代表如果變更了其中一個變數的內容，另一個變數的內容也會同時變更
         */
        [TestMethod]
        public void Multiple_References_to_the_Same_Object_Implement()
        {
            // New Person object
            Person p1 = new Person("Sean", 46);
            // Points to same object
            Person p2 = p1;

            // p1 and p2 is the same
            Assert.AreEqual(p1, p2);
            Assert.AreEqual(p1.Name, p2.Name);
            Assert.AreEqual(p1.Age, p2.Age);

            // Set Age property to new value
            p1.Age = p1.Age - 10;
            int younger = p1.Age;

            Assert.AreEqual(younger, p2.Age);
        }

        [TestMethod]
        public void Multiple_References_to_the_Same_Object_Test()
        {
            Person p1 = new Person("Sean", 46);
            Person p2 = new Person("Sean", 46);

            // p1 and p2 is different
            Assert.AreNotEqual(p1, p2);
            Assert.AreEqual(p1.Name, p2.Name);
            Assert.AreEqual(p1.Age, p2.Age);

            // Set Age property to new value
            p1.Age = p1.Age - 10;
            int younger = p1.Age;

            Assert.AreNotEqual(younger, p2.Age);
        }
    }
}
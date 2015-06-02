using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/01/45-static-members-of-a-class/

    [TestClass]
    public class Static_Members_of_a_Class
    {
        /*
         * When you create a new object and use a reference variable to call methods of a class, you’re using instance members of that class.
         * Instance members interact with just that instance of the class.
         * You can also work with class members without creating an instance of the class.
         * Static class members operate on the class itself, rather than on instances of the class.
         * To invoke static members, you use the name of the class, rather than a variable that points to an instance of the class.
         * In the example below, we create two Person objects and then work with both instance and static methods.
         * 
         * 當建立新的物件並使用其方法時，此時處理的是實例中的成員，為類別實例的操作
         * 可以使用靜態成員，靜態成員為類別本身的操作而不是類別實例的操作
         * 如果要使用靜態成員，請使用類別的名稱，而不是使用關鍵字 new 來指定實例
         */
        [TestMethod]
        public void Static_Members_of_a_Class_Implement()
        {
            // Create 2 new Person objects
            Person p1 = new Person("Sean", 46);
            Person p2 = new Person("Fred", 28);
            // Acts on p1
            string info = p1.Description();
            // p2's Age
            int age = p2.Age;

            // Static property
            Person.PersonCount = 10;
            int numFolks = Person.PersonCount;

            // Static method
            string generalPersonStuff = Person.DoGeneralPersonStuff();
            Assert.AreEqual(string.Format("{0} people.", numFolks), generalPersonStuff);
        }
    }
}
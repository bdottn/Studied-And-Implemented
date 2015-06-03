using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    [TestClass]
    public class There_Is_Only_One_Copy_of_Static_Data
    {
        /*
         * With instance data members of a class, there is a unique set of data that exists for each instance of the class that you create.
         * However, for static data members, there is always just one copy of the static data for that class.
         * Since the data is associated with no particular instance of the class, all references to that static data work with the same copy.
         * 
         * 對於每個所創建的實例，實例成員都有一組數據存在
         * 但是對於靜態成員來說，只是一份對於類別實體的資料存在
         * 所以類別的靜態成員是所有依據此類別所創建的實體所共用的
         */
        [TestMethod]
        public void There_Is_Only_One_Copy_of_Static_Data_Implement()
        {
            // Create two new Person objects--two sets of instance data.
            Person p1 = new Person("Sean", 46);
            Person p2 = new Person("Fred", 28);

            // Change static data--one copy for entire Person class
            Person.Motto = "It's good to be human";

            Assert.AreEqual(Person.Motto, p1.UseMotto());
            Assert.AreEqual(Person.Motto, p2.UseMotto());
        }
    }
}
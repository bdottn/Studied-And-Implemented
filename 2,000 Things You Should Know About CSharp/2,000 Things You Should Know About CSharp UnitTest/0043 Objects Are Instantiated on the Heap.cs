using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/07/30/43-objects-are-instantiated-on-the-heap/

    [TestClass]
    public class Objects_Are_Instantiated_on_the_Heap
    {
        /*
         * When you instantiate a reference type using the new operator, you are creating a new instance of that type.
         * The object is created on what’s known as the managed heap.
         * In other words, memory is allocated to store the member data of the object and that memory is allocated from an area of memory known as the heap.
         * 
         * 當使用參考類型建立一個新的實例時，等於從記憶體中指定一個儲存空間來給這個實例使用
         * 而變數的名稱則是讓記憶體能找到相關儲存位置的進入點
         */
        [TestMethod]
        public void Objects_Are_Instantiated_on_the_Heap_Implement()
        {
            Person p1 = new Person("Sean", 46);

            Person p2 = new Person("Sean", 46);

            // p1 and p2 is different
            Assert.AreNotEqual(p1, p2);
        }
    }
}
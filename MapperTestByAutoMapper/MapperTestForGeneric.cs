﻿using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Open-Generics

    [TestClass]
    public class MapperTestForGeneric
    {
        /*
         * 支援泛型 Mapper
         * 在使用上不用建立所有型別的設定，而可以使用開放式的通用設定
         * 只需要在執行時給定型別即可
         */

        class Source<T>
        {
            public T Value { get; set; }
        }

        class Destination<T>
        {
            public T Value { get; set; }
        }

        [TestMethod]
        public void MapperTestForGeneric_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source<int>()
                {
                    Value = 10,
                };

            // Configure
            Mapper.CreateMap(typeof(Source<>), typeof(Destination<>));

            // Perform mapping
            // var dest = Mapper.Map<Source<int>>(src);
            var dest = Mapper.Map<Source<int>, Destination<int>>(src);

            Assert.AreEqual(src.Value, dest.Value);
        }
    }
}
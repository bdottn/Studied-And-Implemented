﻿using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Before-and-after-map-actions

    [TestClass]
    public class MapperTestForBeforeAndAfterMapAction
    {
        /*
         * BeforeMap 和 AfterMap 兩個方法就如同字面上的意思
         * 可以在 Mapper 前後作相關的處理
         */

        class Source
        {
            public int Value { get; set; }

            public string Name { get; set; }
        }

        class Destination
        {
            public int Value { get; set; }

            public string Name { get; set; }
        }

        [TestMethod]
        public void MapperTestForBeforeAndAfterMapAction_Configure_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = 10,
                    Name = "Echo",
                };

            // Configure
            Mapper.CreateMap<Source, Destination>()
                .BeforeMap((s, d) => s.Value = s.Value + 10)
                .AfterMap((s, d) => d.Name = "Allen");

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination>(src);

            Assert.AreEqual(10 + 10, src.Value);
            Assert.AreEqual(src.Value, dest.Value);
            Assert.AreEqual("Allen", dest.Name);
        }

        [TestMethod]
        public void MapperTestForBeforeAndAfterMapAction_Mapping_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = 10,
                    Name = "Echo",
                };

            // Configure
            Mapper.CreateMap<Source, Destination>();

            int i = 10;

            // Perform mapping
            var dest = Mapper.Map<Source, Destination>(src,
                o =>
                {
                    o.BeforeMap((s, d) => s.Value = s.Value + i);
                    o.AfterMap((s, d) => d.Name = d.Name = "Allen");
                });

            Assert.AreEqual(10 + i, src.Value);
            Assert.AreEqual(src.Value, dest.Value);
            Assert.AreEqual("Allen", dest.Name);
        }

        [TestCleanup]
        public void MapperReset()
        {
            // Configure Reset
            Mapper.Reset();
        }
    }
}
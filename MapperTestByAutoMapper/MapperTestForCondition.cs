﻿using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Conditional-mapping

    [TestClass]
    public class MapperTestForCondition
    {
        /*
         * AutoMapper 提供了 Condition 方法，可以藉由限定來源成員值處理對應成員
         */

        class Source
        {
            public int Value { get; set; }
        }

        class Destination
        {
            public int Value { get; set; }
        }

        [TestMethod]
        public void MapperTestForCondition_InputOutofConditionSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = -1,
                };

            // Configure
            Mapper.CreateMap<Source, Destination>()
                .ForMember(d => d.Value, o => o.Condition(s => s.Value >= 0));

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination>(src);

            Assert.AreEqual(0, dest.Value);
        }

        [TestMethod]
        public void MapperTestForCondition_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = 5,
                };

            // Configure
            Mapper.CreateMap<Source, Destination>()
                .ForMember(d => d.Value, o => o.Condition(s => s.Value >= 0));

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination>(src);

            Assert.AreEqual(src.Value, dest.Value);
        }
    }
}
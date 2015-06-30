using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Nested-mappings

    [TestClass]
    public class MapperTestForNestedMapping
    {
        /*
         * 有時候型別並不是簡單型別，而是由多個型別組合而成的一個複合型別
         * 此時在設定上需要加上其他型別的設定
         * AutoMapper 才能在碰到其他型別時有處理的依據
         */

        class Source
        {
            public int Value { get; set; }

            public InnerSource Inner { get; set; }
        }

        class InnerSource
        {
            public int OtherValue { get; set; }
        }

        class Destination
        {
            public int Value { get; set; }

            public InnerDestination Inner { get; set; }
        }

        class InnerDestination
        {
            public int OtherValue { get; set; }
        }

        [TestMethod]
        public void MapperTestForNestedMapping_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = 5,
                    Inner =
                        new InnerSource()
                        {
                            OtherValue = 15,
                        },
                };

            // Configure
            Mapper.CreateMap<Source, Destination>();
            Mapper.CreateMap<InnerSource, InnerDestination>();

            // Configure Validation
            Mapper.AssertConfigurationIsValid();

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination>(src);

            Assert.AreEqual(src.Value, dest.Value);
            Assert.AreNotEqual(null, dest.Inner);
            Assert.AreEqual(src.Inner.OtherValue, dest.Inner.OtherValue);
        }
    }
}
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Nested-mappings

    [TestClass]
    public class MapperTestForNestedMapping
    {
        /*
         * 有時候型別並不是簡單類型，而是一個複雜類型
         * 此時在設定上需要記得加上其他類型的設定
         * AutoMapper 才能在碰到其他類型時順利的 Mapper
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
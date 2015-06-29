using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Configuration

    [TestClass]
    public class MapperTestForConfiguration
    {
        /*
         * 可以將 Configure 的設定寫在一個繼承自 Profile 的類別中
         * 在 Initialize 時將這些類別加入即可
         */

        class Source
        {
            public int Value { get; set; }
        }

        class Destination
        {
            public int Value { get; set; }
        }

        class TestProfile : Profile
        {
            protected override void Configure()
            {
                // Configure
                Mapper.CreateMap<Source, Destination>();
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Mapper.Initialize(c =>
                {
                    c.AddProfile<TestProfile>();
                });
        }

        [TestMethod]
        public void MapperTestForConfiguration_UseMapperInitializeAddProfile_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = 5,
                };

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source>(src);

            Assert.AreEqual(src.Value, dest.Value);
        }
    }
}
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Null-substitution

    [TestClass]
    public class MapperTestForNullSubstitution
    {
        /*
         * 如果在來源成員的值是 Null 時
         * AutoMapper 提供了 NullSubstitute 來給定目標成員預設值
         */

        class Source
        {
            public string Value { get; set; }
        }

        class Destination
        {
            public string Value { get; set; }
        }

        [TestMethod]
        public void MapperTestForNullSubstitution_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = "This is Value.",
                };

            // Configure
            Mapper.CreateMap<Source, Destination>()
                .ForMember(d => d.Value, o => o.NullSubstitute("Null Value"));

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination>(src);

            Assert.AreEqual(src.Value, dest.Value);
        }

        [TestMethod]
        public void MapperTestForNullSubstitution_InputSourceNullValue_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = null,
                };

            // Configure
            Mapper.CreateMap<Source, Destination>()
                .ForMember(d => d.Value, o => o.NullSubstitute("Null Value"));

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination>(src);

            Assert.AreEqual("Null Value", dest.Value);
        }
    }
}
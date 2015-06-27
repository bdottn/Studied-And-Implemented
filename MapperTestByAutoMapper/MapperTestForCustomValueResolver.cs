using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Custom-value-resolvers

    [TestClass]
    public class MapperTestForCustomValueResolver
    {
        /*
         * 有些時候，目標成員值可能需要透過來源成員進行計算或調整
         * AutoMapper 提供了 ValueResolver 泛型類別
         * 可以藉由繼承 ValueResolver 類別來複寫 ResolveCore 方法
         */

        class Source
        {
            public int Value1 { get; set; }

            public int Value2 { get; set; }
        }

        class Destination
        {
            public int Total { get; set; }
        }

        [TestMethod]
        public void MapperTestForCustomValueResolver_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value1 = 5,
                    Value2 = 7,
                };

            // Configure
            // 　　1. 使用繼承 ValueResolver<Source, int> 的類別進行

            // 　　　　Mapper.CreateMap<Source, Destination>()
            // 　　　　    .ForMember(d => d.Total, o => o.ResolveUsing<CustomResolver>());

            // 　　　　Mapper.CreateMap<Source, Destination>()
            // 　　　　    .ForMember(d => d.Total, o => o.ResolveUsing(typeof(CustomResolver)));

            // 　　2. 提供繼承 ValueResolver<Source, int> 的類別實例進行

            // 　　　　Mapper.CreateMap<Source, Destination>()
            // 　　　　    .ForMember(d => d.Total, o => o.ResolveUsing(new CustomResolver()));

            Mapper.CreateMap<Source, Destination>()
                .ForMember(d => d.Total, o => o.ResolveUsing<CustomResolver>().ConstructedBy(() => new CustomResolver()));

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination>(src);

            Assert.AreEqual(src.Value1 + src.Value2, dest.Total);
        }

        class CustomResolver : ValueResolver<Source, int>
        {
            protected override int ResolveCore(Source source)
            {
                return source.Value1 + source.Value2;
            }
        }
    }
}
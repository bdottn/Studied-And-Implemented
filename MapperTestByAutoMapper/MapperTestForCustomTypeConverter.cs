using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Custom-type-converters

    [TestClass]
    public class MapperTestForCustomTypeConverter
    {
        /*
         * 在種種原因下，可能 Mapper 的時候成員的類型並不相同
         * AutoMapper 提供了 ConvertUsing 來處理這樣的情況
         */

        class Source
        {
            public string Value { get; set; }
        }

        class Destination<T>
        {
            public T Value { get; set; }
        }

        class Destination1 : Destination<int>
        {
        }

        class Destination2 : Destination<DateTime>
        {
        }

        class Destination3 : Destination<Decimal>
        {
        }

        [TestMethod]
        public void MapperTestForCustomTypeConverter_UseBuiltin_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = "5",
                };

            // Configure
            // string → int 的設定：使用內建的轉型進行
            Mapper.CreateMap<string, int>().ConvertUsing(Convert.ToInt32);
            Mapper.CreateMap<Source, Destination1>();

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination1>(src);

            Assert.AreEqual(Convert.ToInt32(src.Value), dest.Value);
        }

        [TestMethod]
        public void MapperTestForCustomTypeConverter_UseNewClassImplement_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = "01/01/2000",
                };

            // Configure
            // string → DateTime 的設定：使用實作 ITypeConverter<string, DateTime> 的類別進行
            Mapper.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
            Mapper.CreateMap<Source, Destination2>();

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination2>(src);

            Assert.AreEqual(Convert.ToDateTime(src.Value), dest.Value);
        }

        class DateTimeTypeConverter : ITypeConverter<string, DateTime>
        {
            #region ITypeConverter<string,DateTime> 成員

            public DateTime Convert(ResolutionContext context)
            {
                return System.Convert.ToDateTime(context.SourceValue);
            }

            #endregion
        }

        [TestMethod]
        public void MapperTestForCustomTypeConverter_UseNewClassGeneric_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = "332.1153",
                };

            // Configure
            // string → Decimal 的設定：使用實作 ITypeConverter<string, Decimal> 的類別進行泛型轉換
            Mapper.CreateMap<string, Decimal>().ConvertUsing<DecimalTypeConverter>();
            Mapper.CreateMap<Source, Destination3>();

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination3>(src);

            Assert.AreEqual(Convert.ToDecimal(src.Value), dest.Value);
        }

        class DecimalTypeConverter : ITypeConverter<string, Decimal>
        {
            #region ITypeConverter<string,Decimal> 成員

            public Decimal Convert(ResolutionContext context)
            {
                return System.Convert.ToDecimal(context.SourceValue);
            }

            #endregion
        }
    }
}
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Configuration-validation

    [TestClass]
    public class MapperTestForConfigurationValidation
    {
        /*
         * 有時候屬性很多很雜，難免會有所遺漏
         * AutoMapper 提供了一個 AssertConfigurationIsValid 的檢查方法
         * 在目標成員有未被設定對應的情況下會產生 AutoMapperConfigurationException
         */

        class Source
        {
            public int Value1 { get; set; }

            public int Value2 { get; set; }

            public int Value3 { get; set; }
        }

        class Destination
        {
            public int Value1 { get; set; }

            public int Value3 { get; set; }

            public int Value4 { get; set; }
        }

        [TestMethod]
        public void MapperTestForConfigurationValidation_ThrowAutoMapperConfigurationException()
        {
            // Configure
            Mapper.CreateMap<Source, Destination>();

            // Throw AutoMapperConfigurationException
            // Unmapped properties: Value4
            Mapper.AssertConfigurationIsValid();
        }
    }
}
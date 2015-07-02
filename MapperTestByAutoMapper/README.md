# Mapper Configuration Validation
  
　　有時候屬性很多很雜，難免會有所遺漏。AutoMapper 提供了一個 AssertConfigurationIsValid 的檢查方法，在目標成員有未被設定對應的情況下會產生 AutoMapperConfigurationException。
  
```
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
[ExpectedException(typeof(AutoMapperConfigurationException))]
public void MapperTestForConfigurationValidation_ThrowAutoMapperConfigurationException()
{
    // Configure
    Mapper.CreateMap<Source, Destination>();

    // Throw AutoMapperConfigurationException
    // Unmapped properties: Value4
    Mapper.AssertConfigurationIsValid();
}
```
  
#### 參考連結：
>1. Configuration Validation：[Configuration Validation]
2. 測試預期中的例外狀況：[測試預期中的例外狀況]

#### My Blog：
>[Mapper Configuration Validation][MapperTestForConfigurationValidation]  

[Configuration Validation]:https://github.com/AutoMapper/AutoMapper/wiki/Configuration-validation
[測試預期中的例外狀況]:https://github.com/bdottn/Studied-And-Implemented/tree/TestForException/ProjectForUnitTest
[MapperTestForConfigurationValidation]:http://bdottn.github.io/2015/06/29/MapperTestForConfigurationValidation/
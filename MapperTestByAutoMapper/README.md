# AutoMapper
　　在應用程式中，Mapping 物件可能會發生在很多地方，最常發生在層級的邊界上，例如：UI / Domain，Service/Domain。如果每次都要寫一次，豈不是很累人？而當有邏輯或者成員變更時，那要改的地方可就多了。
  
　　一般而言，在 .NET 內會使用 AutoMapper 來解決此類問題。AutoMapper 是一個物件到物件的定義工具：當有一個 object A 需要轉換到另一個 object B 時就可以用到，同時提供了許多方法來處理轉換 A → B，只要按照 AutoMapper 既有的方法來規範，轉換兩個型別時，幾乎不需要再作其他的處理。
  
　　AutoMapper 支援的平台如下：
>* .NET 4+
* Silverlight 5
* Windows Phone 8+
* .NET for Windows Store apps (WinRT)
* Windows Universal Apps
* Xamarin.iOS
* Xamarin.Android
  
　　這次稍微花了一點時間把 AutoMapper 的文件看完，並且實作了大部分其中介紹的特點。
>* [Flattening Mapper][MapperTestForFlattening]
* [Projection Mapper][MapperTestForProjection]
* [Mapper Configuration Validation][MapperTestForConfigurationValidation]
* [Mapper Lists And Arrays][MapperTestForListsAndArrays]
* [Nested Mapping][MapperTestForNestedMapping]
* [Mapper For Custom Type Converter][MapperTestForCustomTypeConverter]
* [Use Custom Value Resolver][MapperTestForCustomValueResolver]
* [Null Mapper Default Value][MapperTestForNullSubstitution]
* [BeforeMap And AfterMap][MapperTestForBeforeAndAfterMapAction]
* [Mapping Inheritance And Priority][MapperTestForMappingInheritance]
* [Mapper Initialize][MapperTestForConfiguration]
* [Condition Mapper][MapperTestForCondition]
* [Generic Mapper][MapperTestForGeneric]
  
#### 參考連結
>1. AutoMapper Home：[AutoMapper Home]
2. AutoMapper Getting Started：[AutoMapper Getting Started]
  
#### My Blog
>[AutoMapper][AutoMapper]
  
[MapperTestForFlattening]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForFlattening/MapperTestByAutoMapper
[MapperTestForProjection]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForProjection/MapperTestByAutoMapper
[MapperTestForConfigurationValidation]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForConfigurationValidation/MapperTestByAutoMapper
[MapperTestForListsAndArrays]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForListsAndArrays/MapperTestByAutoMapper
[MapperTestForNestedMapping]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForNestedMapping/MapperTestByAutoMapper
[MapperTestForCustomTypeConverter]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForCustomTypeConverter/MapperTestByAutoMapper
[MapperTestForCustomValueResolver]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForCustomValueResolver/MapperTestByAutoMapper
[MapperTestForNullSubstitution]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForNullSubstitution/MapperTestByAutoMapper
[MapperTestForBeforeAndAfterMapAction]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForBeforeAndAfterMapAction/MapperTestByAutoMapper
[MapperTestForMappingInheritance]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForMappingInheritance/MapperTestByAutoMapper
[MapperTestForConfiguration]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForConfiguration/MapperTestByAutoMapper
[MapperTestForCondition]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForCondition/MapperTestByAutoMapper
[MapperTestForGeneric]:https://github.com/bdottn/Studied-And-Implemented/tree/MapperTestForGeneric/MapperTestByAutoMapper
[AutoMapper Home]:https://github.com/AutoMapper/AutoMapper/wiki
[AutoMapper Getting Started]:https://github.com/AutoMapper/AutoMapper/wiki/Getting-started
[AutoMapper]:http://bdottn.github.io/2015/07/01/AutoMapper/
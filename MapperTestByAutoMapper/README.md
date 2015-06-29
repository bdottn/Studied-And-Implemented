# Projection Mapper
  
　　由於目標型別的成員結構可能不完全等同於來源成員結構，在這種時候需要使用 MapFrom 設定自定義的設定來處理目標成員結構。
  
```
class Source
{
    public DateTime Date { get; set; }

    public string Title { get; set; }
}

class Destination
{
    // only Date
    public DateTime DestinationDate { get; set; }

    public int DestinationHour { get; set; }

    public int DestinationMinute { get; set; }

    public string Title { get; set; }
}

[TestMethod]
public void MapperTestForProjection_InputSource_ReturnDestination()
{
    // Source initial
    var src =
        new Source()
        {
            Date = new DateTime(2008, 12, 15, 20, 30, 0),
            Title = "Company Holiday Party",
        };

    // Configure
    Mapper.CreateMap<Source, Destination>()
        .ForMember(d => d.DestinationDate, o => o.MapFrom(s => s.Date.Date))
        .ForMember(d => d.DestinationHour, o => o.MapFrom(s => s.Date.Hour))
        .ForMember(d => d.DestinationMinute, o => o.MapFrom(s => s.Date.Minute));

    // Perform mapping
    // var dest = Mapper.Map<Source>(src);
    var dest = Mapper.Map<Source, Destination>(src);

    Assert.AreEqual(src.Date.Date, dest.DestinationDate);
    Assert.AreEqual(src.Date.Hour, dest.DestinationHour);
    Assert.AreEqual(src.Date.Minute, dest.DestinationMinute);
    Assert.AreEqual(src.Title, dest.Title);
}
```
  
#### 參考連結：
>1. Projection：[Projection]

#### My Blog：
>[Projection Mapper][Projection Mapper]  

[Projection]:https://github.com/AutoMapper/AutoMapper/wiki/Projection
[Projection Mapper]:http://bdottn.github.io/2015/06/29/MapperTestForProjection/
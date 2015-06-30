# Mapping Inheritance And Priority
  
　　從 AutoMapper 2.0 以後，在繼承設定方面有著一些改善（我開始使用的版本已經是 3.3 了，以下為文件內容）。
> 1. 成員的相關設定，如果已經在父類作設定，不用在子類再次設定
2. 除了從父類指定子類的設定外，也可以從子類指定父類的設定
  
　　由於繼承設定的方式很多，會增加額外的複雜度，一般而言，優先順序如下：
> 1. 明確的指派（使用 MapFrom）
2. 位於繼承設定中明確的指派
3. 設定中忽略的成員（Ignore）
4. 成員中因為公約自動指派的成員
  
```
class Order
{
}

class OnlineOrder : Order
{
    public string Referrer { get; set; }
}

class MailOrder : Order
{
}


class OrderDto
{
    public string Referrer { get; set; }
}

[TestMethod]
public void MapperTestForMappingInheritance_Priority_InputOnlineOrder_ReturnOrderDto()
{
    // Source initial
    var src =
        new OnlineOrder()
        {
            Referrer = "google",
        };

    // Configure
    Mapper.CreateMap<Order, OrderDto>()
          .Include<OnlineOrder, OrderDto>()
          .Include<MailOrder, OrderDto>()
          .ForMember(d => d.Referrer, o => o.Ignore());
    Mapper.CreateMap<OnlineOrder, OrderDto>();
    Mapper.CreateMap<MailOrder, OrderDto>();

    // Perform Mapping
    var dest = Mapper.Map(src, src.GetType(), typeof(OrderDto)) as OrderDto;

    Assert.AreEqual("google", dest.Referrer);
}
```
  
#### 參考連結：
>1. Mapping inheritance：[Mapping inheritance]

#### My Blog：
>[Mapping Inheritance And Priority][Mapping Inheritance And Priority]  

[Mapping inheritance]:https://github.com/AutoMapper/AutoMapper/wiki/Mapping-inheritance
[Mapping Inheritance And Priority]:http://bdottn.github.io/2015/06/30/MapperTestForMappingInheritance/
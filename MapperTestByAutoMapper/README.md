# Mapper Lists And Arrays
  
　　AutoMapper 支援所有基本泛型集合類型，包括了：  
>* IEnumerable
* IEnumerable<T>
* ICollection
* ICollection<T>
* IList
* IList<T>
* List<T>
* Arrays
  
　　在使用的時候，不必為泛型集合類別作特別的設定，只需要對集合的成員作設定即可。
  
```
class Source
{
    public int Value { get; set; }
}

class Destination
{
    public int Value { get; set; }
}

[TestMethod]
public void MapperTestForListsAndArrays_InputSources_ReturnIEnumerableDestinations()
{
    // Source initial
    var srcs =
        new Source[]
        {
            new Source()
            {
                Value = 5
            },
            new Source()
            {
                Value = 6 
            },
            new Source()
            {
                Value = 7 
            },
        };

    // Configure
    Mapper.CreateMap<Source, Destination>();

    // Perform mapping
    IEnumerable<Destination> ienumerableDest = Mapper.Map<Source[], IEnumerable<Destination>>(srcs);

    for (int si = 0; si <= srcs.Length - 1; si++)
    {
        Assert.AreEqual(srcs[si].Value, ienumerableDest.ElementAt(si).Value);
    }
}

[TestMethod]
public void MapperTestForListsAndArrays_InputSources_ReturnICollectionDestinations()
{
    // Source initial
    var srcs =
        new Source[]
        {
            new Source()
            {
                Value = 5
            },
            new Source()
            {
                Value = 6 
            },
            new Source()
            {
                Value = 7 
            },
        };

    // Configure
    Mapper.CreateMap<Source, Destination>();

    // Perform mapping
    ICollection<Destination> icollectionDest = Mapper.Map<Source[], ICollection<Destination>>(srcs);

    for (int si = 0; si <= srcs.Length - 1; si++)
    {
        Assert.AreEqual(srcs[si].Value, icollectionDest.ElementAt(si).Value);
    }
}

[TestMethod]
public void MapperTestForListsAndArrays_InputSources_ReturnIListDestinations()
{
    // Source initial
    var srcs =
        new Source[]
        {
            new Source()
            {
                Value = 5
            },
            new Source()
            {
                Value = 6 
            },
            new Source()
            {
                Value = 7 
            },
        };

    // Configure
    Mapper.CreateMap<Source, Destination>();

    // Perform mapping
    IList<Destination> ilistDest = Mapper.Map<Source[], IList<Destination>>(srcs);

    for (int si = 0; si <= srcs.Length - 1; si++)
    {
        Assert.AreEqual(srcs[si].Value, ilistDest[si].Value);
    }
}

[TestMethod]
public void MapperTestForListsAndArrays_InputSources_ReturnListDestinations()
{
    // Source initial
    var srcs =
        new Source[]
        {
            new Source()
            {
                Value = 5
            },
            new Source()
            {
                Value = 6 
            },
            new Source()
            {
                Value = 7 
            },
        };

    // Configure
    Mapper.CreateMap<Source, Destination>();

    // Perform mapping
    List<Destination> listDest = Mapper.Map<Source[], List<Destination>>(srcs);

    for (int si = 0; si <= srcs.Length - 1; si++)
    {
        Assert.AreEqual(srcs[si].Value, listDest[si].Value);
    }
}

[TestMethod]
public void MapperTestForListsAndArrays_InputSources_ReturnDestinations()
{
    // Source initial
    var srcs =
        new Source[]
        {
            new Source()
            {
                Value = 5
            },
            new Source()
            {
                Value = 6 
            },
            new Source()
            {
                Value = 7 
            },
        };

    // Configure
    Mapper.CreateMap<Source, Destination>();

    // Perform mapping
    Destination[] dests = Mapper.Map<Source[], Destination[]>(srcs);

    for (int si = 0; si <= srcs.Length - 1; si++)
    {
        Assert.AreEqual(srcs[si].Value, dests[si].Value);
    }
}
```
  
　　有時候集合內的成員不僅僅是一種類型，AutoMapper 也支援多組態的集合。除了需要增加子類別的設定外，在父類別設定時需要使用 Include 來包含子類別的設定。
   
```
class Source
{
    public int Value { get; set; }
}

class ChildSource : Source
{
    public int ChildValue { get; set; }
}

class Destination
{
    public int Value { get; set; }
}

class ChildDestination : Destination
{
    public int ChildValue { get; set; }
}

[TestMethod]
public void MapperTestForListsAndArrays_PolymorphicElementTypes_InputSources_ReturnIEnumerableDestinations()
{
    // Source initial
    var srcs =
        new Source[]
        {
            new Source()
            {
                Value = 6,
            },
            new ChildSource()
            {
                Value = 7,
                ChildValue = 72,
            },
            new Source()
            {
                Value = 8,
            },
        };

    // Configure
    Mapper.CreateMap<Source, Destination>()
        .Include<ChildSource, ChildDestination>();
    Mapper.CreateMap<ChildSource, ChildDestination>();

    // Perform mapping
    var dests = Mapper.Map<Source[], Destination[]>(srcs);

    for (int si = 0; si <= srcs.Length - 1; si++)
    {
        Assert.AreEqual(srcs[si].Value, dests[si].Value);
    }

    Assert.AreEqual(typeof(Destination), dests[0].GetType());
    Assert.AreEqual(typeof(ChildDestination), dests[1].GetType());
    Assert.AreEqual(typeof(Destination), dests[2].GetType());
}
```
  
#### 參考連結：
>1. Lists and arrays：[Lists and arrays]

#### My Blog：
>[Mapper Lists And Arrays][Mapper Lists And Arrays]  

[Lists and arrays]:https://github.com/AutoMapper/AutoMapper/wiki/Lists-and-arrays
[Mapper Lists And Arrays]:http://bdottn.github.io/2015/06/29/MapperTestForListsAndArrays/
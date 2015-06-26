using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapperTestByAutoMapper
{
    // Reference：https://github.com/AutoMapper/AutoMapper/wiki/Flattening

    [TestClass]
    public class MapperTestForFlattening
    {
        /*
         * AutoMapper 會嘗試比對來源型別及目標型別，Mapper 的優先順序如下：
         * 　　1. 來源型別成員（屬性、方法）與目標型別成員名稱相同時
         * 　　　　來源型別成員值 → 目標型別成員值
         * 　　2. 來源型別方法名稱移除掉「Get」前綴詞後與目標型別成員名稱相同時
         * 　　　　來源型別方法值 → 目標型別成員值
         * 　　3. 若目標型別成員在來源型別中都不存在
         * 　　　　則會將目標型別成員依據 PascalCase 命名原則拆分成單字後進行比對
         * 　　　　比對的原則為成員名稱向下層型別延伸
         */

        class Source
        {
            public int Value { get; set; }

            public InnerArticle Article { get; set; }


            public int Sum()
            {
                return this.Value + 101;
            }

            public int GetCount()
            {
                return 7;
            }
        }

        class InnerArticle
        {
            public string Title { get; set; }
        }

        class Destination
        {
            public int Value { get; set; }

            public int Sum { get; set; }

            public int Count { get; set; }

            public string ArticleTitle { get; set; }
        }

        [TestMethod]
        public void MapperTestForFlattening_InputSource_ReturnDestination()
        {
            // Source initial
            var src =
                new Source()
                {
                    Value = 1,
                    Article =
                        new InnerArticle()
                        {
                            Title = "This is Title.",
                        },
                };

            // Configure
            Mapper.CreateMap<Source, Destination>();

            // Perform mapping
            // var dest = Mapper.Map<Source>(src);
            var dest = Mapper.Map<Source, Destination>(src);

            Assert.AreEqual(src.Value, dest.Value);
            Assert.AreEqual(src.Sum(), dest.Sum);
            Assert.AreEqual(src.GetCount(), dest.Count);
            Assert.AreEqual(src.Article.Title, dest.ArticleTitle);
        }
    }
}
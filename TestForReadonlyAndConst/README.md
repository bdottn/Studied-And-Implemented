# 常數 [const] 與 [readonly] 差別
  
> [const]
　　可以使用 const 關鍵字來宣告常數欄位或區域常數。常數欄位和區域常數不是變數，無法修改。常數可以是數值、布林值、字串或 null 參考。請勿建立用來表示想隨時變更之資訊的常數。  
  
> [readonly]
　　欄位宣告如果包含 readonly 修飾詞，由宣告引入的欄位設定只能發生在宣告的一部分或者是相同類別裡的建構函式。  
  
　　兩者皆為宣告常數的關鍵字。在效能方面，const 比 static readonly 好一些。而功能方面似乎大同小異，但是有些許的不同：
>1. const 只能用於數值及字串，readonly 可以為任意型態。
2. const 可以在方法內使用。
3. const 在編譯時期產生，readonly 在執行時產生。
  
　　上述第三點，常常會發生一些意料之外的錯誤。今天我有一個主控台的應用程式（ConsoleApplication），引用了另一專案類別庫（ConsoleApplicationClassLibrary），程式內容如下：
```
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int ni = ConstantClass.BeginNumber; ni < ConstantClass.EndNumber; ni++)
            {
                Console.WriteLine(ni);
            }
            Console.ReadKey();
        }
    }
}
　　
namespace ConsoleApplicationClassLibrary
{
    public class ConstantClass
    {
        public static int BeginNumber = 0;

        public const int EndNumber = 10;
    }
}
```
　　執行結果如圖，很順利的產生 0 ~ 9 的數值。

![執行結果01][TestForReadonlyAndConst01]

　　今天突然需求變更，我需要將數值區間變成 9 ~ 19。顯而易見的，我們會嘗試抽換 dll 來進行需求變更。
```
namespace ConsoleApplicationClassLibrary
{
    public class ConstantClass
    {
        public static int BeginNumber = 9;

        public const int EndNumber = 20;
    }
}
```

　　當我們將 ConsoleApplicationClassLibrary.dll 進行替換後，產生的結果卻如下圖。

![執行結果02][TestForReadonlyAndConst02]

　　這中間發生了什麼事情呢？使用 Reflector 查看程式碼，發現 ConsoleApplication.exe 呈現以下狀態。

![Reflector][TestForReadonlyAndConst03]

　　這就是上面第三項的不同之處，const 在編譯時期產生，readonly 在執行時產生。所以在封裝後，const 會直接帶入常數值，而 readonly 仍然需要取值。這也是效能上 const 為什麼會較好的關係。所以不管在怎樣抽換 dll ，只要沒有重新封裝，EndNumber 永遠就會等於 10 。

  
#### 參考連結：
>1. const (C# 參考)：[const]
2. readonly (C# 參考)：[readonly]
3. 余小章 @ 大內殿堂：[定義常數時用 readonly 好? 還是 const 好?]

#### My Blog：
>[常數 const 與 readonly 差別][TestForReadonlyAndConst]  

[const]:https://msdn.microsoft.com/zh-tw/library/e6w8fe1b.aspx
[readonly]:https://msdn.microsoft.com/zh-tw/library/acdd6hb7.aspx
[定義常數時用 readonly 好? 還是 const 好?]:http://www.dotblogs.com.tw/yc421206/archive/2011/06/06/27232.aspx
[TestForReadonlyAndConst]:http://bdottn.github.io/2015/07/03/TestForReadonlyAndConst/
[TestForReadonlyAndConst01]:TestForReadonlyAndConst01.png
[TestForReadonlyAndConst02]:TestForReadonlyAndConst02.png
[TestForReadonlyAndConst03]:TestForReadonlyAndConst03.png
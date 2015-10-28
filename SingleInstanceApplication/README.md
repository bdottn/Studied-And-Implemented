# C# 使用 [Mutex] 建立單一執行個體的應用程式
　　在某些情況之下，可能會需要限制應用程式在同一時間內只能執行一個。在以前，我的做法是使用 Process 取得清單，然後逐一檢查此應用程式是否執行中。
  
　　一直以來，都隱約認為這種方式不夠嚴謹，今天心血來潮又 Google 了一次，發現早在多年前就有人提出了使用 Process 清單的侷限性及錯誤的可能，如：
>1. 可能兩隻應用程式同時間開始執行，同時查到對方的處理程序，然後同時關閉。
2. 當系統中剛好有另一隻應用程式取了相同的名稱，此隻應用程式可能會永遠無法執行。
3. 取得的 Process 清單，是屬於全機器的清單，如果要限制使用者登入執行或是遠端登入執行，需要再加以判斷 session 來處理。
  
　　黑大的文章 [防止程式同時執行多份，比檢查Process清單更好的方法] 就是在講解這種情形該如何解決。而保哥的 [如何避免相同的 ConsoleApp 或 WinForm 同時間重複執行] 這篇文章中，也介紹了該如何使用 Mutex 來處理上面的第三種情況。
  
　　下面的實作練習中，我直接使用專案檔組件資訊的 Guid 當作獨一無二的 key 值，並使用 Mutex 來進行單一執行個體的應用程式建置。
  
```
static class Program
{
    static string assemblyGuid
    {
        get
        {
            object[] attributes =
                Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false);

            if (attributes.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return ((GuidAttribute)attributes[0]).Value;
            }
        }
    }

    [STAThread]
    static void Main()
    {
        // 在同一台主機相同使用者的範圍內進行 Mutex 互斥（採用 Local\名稱）
        // 在同一台主機所有使用者的範圍內進行 Mutex 互斥（採用 Global\名稱）
        using (Mutex mutex = new Mutex(false, @"Global\" + assemblyGuid))
        {
            // 檢查是否有相同名稱 Mutex 已存在
            if (mutex.WaitOne(0, false) == false)
            {
                MessageBox.Show("應用程式正在執行中！");
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
```
  
#### 注意事項
>1. 就算使用了 Guid 或是自定義的名稱，但仍有可能會有極低的機率發生同名的問題，此處命名最好加以規範。
2. Mutex 名稱長度不得大於 260 個字元，不能使用反斜線（\）符號。
3. 使用 using 包住 Mutex，可有效避免 Mutex 意外被 GC 回收，導致應用程式重複執行。
  
#### 參考連結
>1. Mutex 類別：[Mutex]
2. 黑暗執行緒：[防止程式同時執行多份，比檢查Process清單更好的方法]
3. The Will Will Web：[如何避免相同的 ConsoleApp 或 WinForm 同時間重複執行]
4. OdeToCode by K. Scott Allen：[The Misunderstood Mutex]
  
#### My Blog
>[C# 使用 Mutex 建立單一執行個體的應用程式]
  
[Mutex]:https://msdn.microsoft.com/zh-tw/library/System.Threading.Mutex(v=vs.110).aspx
[防止程式同時執行多份，比檢查Process清單更好的方法]:http://blog.darkthread.net/blogs/darkthreadtw/archive/2013/01/15/9952.aspx
[如何避免相同的 ConsoleApp 或 WinForm 同時間重複執行]: http://blog.miniasp.com/post/2009/10/23/How-to-avoid-Console-Application-or-WinForm-being-started-multiple-times.aspx
[The Misunderstood Mutex]:http://odetocode.com/blogs/scott/archive/2004/08/20/the-misunderstood-mutex.aspx
[C# 使用 Mutex 建立單一執行個體的應用程式]:http://bdottn.github.io/2015/05/26/SingleInstanceApplication/
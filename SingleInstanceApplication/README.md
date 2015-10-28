# 顯示正在執行中的應用程式
　　在 [C# 使用 Mutex 建立單一執行個體的應用程式] 這篇中，說到了如何限制應用程式在同一時間內只能執行一個。但是有時候需要做到較友善一點的需求，例如在重複執行時跳出正在執行中的表單視窗。此時可以使用 [RegisterWindowMessage] 並在主要表單上覆寫 [WndProc] 來達到目的。
  
#### Program.cs
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
        using (Mutex mutex = new Mutex(false, @"Local\" + assemblyGuid))
        {
            // 檢查是否有相同名稱 Mutex 已存在
            if (mutex.WaitOne(0, false) == false)
            {
                // MessageBox.Show("應用程式正在執行中！");

                // 發送 message，使要執行的表單成為最上層表單
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.ShowMainForm,
                    IntPtr.Zero,
                    IntPtr.Zero);
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

class NativeMethods
{
    [DllImport("user32")]
    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    [DllImport("user32")]
    public static extern int RegisterWindowMessage(string message);

    public const int HWND_BROADCAST = 0XFFFF;
    public static readonly int ShowMainForm = RegisterWindowMessage("ShowMainForm");
}
```
  
#### MainForm.cs
```
// 覆寫 WndProc
protected override void WndProc(ref Message message)
{
    if (message.Msg == NativeMethods.ShowMainForm)
    {
        // 若表單為最小化視窗，恢復原有大小
        if (WindowState == FormWindowState.Minimized)
        {
            WindowState = FormWindowState.Normal;
        }

        // 使表單成為最上層表單狀態
        this.TopMost = true;

        // 使表單不為最上層表單狀態，避免表單鎖定
        this.TopMost = false;
    }

    base.WndProc(ref message);
}
```
  
#### 參考連結
>1. Registerwindowmessage (user32)：[RegisterWindowMessage]
2. Control.WndProc Method：[WndProc]
3. Sanity Free Coding：[C# .NET Single Instance Application]
  
#### My Blog
>[顯示正在執行中的應用程式]
  
[RegisterWindowMessage]:http://www.pinvoke.net/default.aspx/user32.registerwindowmessage
[WndProc]:https://msdn.microsoft.com/en-us/library/system.windows.forms.control.wndproc%28v=vs.110%29.aspx
[C# .NET Single Instance Application]:http://sanity-free.org/143/csharp_dotnet_single_instance_application.html
[C# 使用 Mutex 建立單一執行個體的應用程式]:http://bdottn.github.io/2015/05/26/SingleInstanceApplication/
[顯示正在執行中的應用程式]:http://bdottn.github.io/2015/05/26/ShowRunningForm/
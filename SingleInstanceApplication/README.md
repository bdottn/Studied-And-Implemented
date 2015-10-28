# 搭配 [NotifyIcon] 建立單一執行個體的應用程式
　　前面說到的 [C# 使用 Mutex 建立單一執行個體的應用程式] 與 [顯示正在執行中的應用程式] 已經可以滿足大部份的狀態。下面的範例搭配 [NotifyIcon] 及 [ContextMenuStrip] 來實作按下最小化或關閉按鈕時縮至系統列，而非真正關閉表單動作。
  
#### Program.cs
```
static class Program
{
    internal static string applicationName
    {
        get
        {
            // 專案檔組件資訊的名稱
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }

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
        using (Mutex mutex = new Mutex(false, @"Global\" + assemblyGuid))
        {
            if (mutex.WaitOne(0, false) == false)
            {
                NativeMethods.PostMessage(
                    NativeMethods.FindWindow(null, applicationName),
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
    public static readonly int ShowMainForm = RegisterWindowMessage("ShowMainForm");

    [DllImport("user32")]
    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    [DllImport("user32")]
    public static extern int RegisterWindowMessage(string message);
    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    public static void ShowToFront(string windowName)
    {
        IntPtr window = FindWindow(null, windowName);
        ShowWindow(window, 1);
        SetForegroundWindow(window);
    }
}
```
  
#### MainForm.cs
```
public MainForm()
{
    InitializeComponent();

    this.Text = Program.applicationName;
    this.ntiMain.Text = Program.applicationName;
    this.ntiMain.Icon = this.Icon;
}

// 覆寫 WndProc
protected override void WndProc(ref Message message)
{
    if (message.Msg == NativeMethods.ShowMainForm)
    {
        this.ShowWindow();
    }

    base.WndProc(ref message);
}

private void MainForm_Resize(object sender, EventArgs e)
{
    if (this.WindowState == FormWindowState.Minimized)
    {
        this.HideWindow();
    }
}

private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
{
    this.HideWindow();

    e.Cancel = true;
}

private void tsmShow_Click(object sender, EventArgs e)
{
    this.ShowWindow();
}

private void tsmClose_Click(object sender, EventArgs e)
{
    Application.Exit();
}

private void ShowWindow()
{
    NativeMethods.ShowToFront(Program.applicationName);
}

private void HideWindow()
{
    this.ntiMain.Visible = true;
    this.ShowInTaskbar = false;
    this.Hide();
}
```
  
#### 參考連結
>1. Registerwindowmessage (user32)：[RegisterWindowMessage]
2. Control.WndProc Method：[WndProc]
3. FindWindow function：[FindWindow]
4. NotifyIcon 類別：[NotifyIcon]
5. ContextMenuStrip 類別：[ContextMenuStrip]
  
#### My Blog
>[搭配 NotifyIcon 建立單一執行個體的應用程式]
  
[RegisterWindowMessage]:http://www.pinvoke.net/default.aspx/user32.registerwindowmessage
[WndProc]:https://msdn.microsoft.com/en-us/library/system.windows.forms.control.wndproc%28v=vs.110%29.aspx
[FindWindow]:https://msdn.microsoft.com/zh-tw/library/windows/desktop/ms633499%28v=vs.85%29.aspx
[C# 使用 Mutex 建立單一執行個體的應用程式]:http://bdottn.github.io/2015/05/26/SingleInstanceApplication/
[顯示正在執行中的應用程式]:http://bdottn.github.io/2015/05/26/ShowRunningForm/
[NotifyIcon]:https://msdn.microsoft.com/zh-tw/library/system.windows.forms.notifyicon%28v=vs.110%29.aspx
[ContextMenuStrip]:https://msdn.microsoft.com/zh-tw/library/system.windows.forms.contextmenustrip%28v=vs.100%29.aspx
[搭配 NotifyIcon 建立單一執行個體的應用程式]:http://bdottn.github.io/2015/06/02/SingleInstanceApplicationUsingNotifyIcon/
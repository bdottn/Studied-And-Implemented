using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SingleInstanceApplication
{
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
}
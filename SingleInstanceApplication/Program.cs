using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SingleInstanceApplication
{
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
}
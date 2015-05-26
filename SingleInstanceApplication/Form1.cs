using System.Windows.Forms;

namespace SingleInstanceApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 覆寫 WndProc
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == NativeMethods.WM_SHOWME)
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
    }
}
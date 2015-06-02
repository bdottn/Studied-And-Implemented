using System.Reflection;
using System.Windows.Forms;

namespace SingleInstanceApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = Program.applicationName;

            this.notifyIcon1.Text = this.Text;
            this.notifyIcon1.Icon = this.Icon;
        }

        // 覆寫 WndProc
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == NativeMethods.WM_SHOWME)
            {
                this.ShowWindow();
            }

            base.WndProc(ref message);
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.HideWindow();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.HideWindow();

            e.Cancel = true;
        }

        private void tsmShow_Click(object sender, System.EventArgs e)
        {
            this.ShowWindow();
        }

        private void tsmClose_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void ShowWindow()
        {
            NativeMethods.ShowToFront(Program.applicationName);
        }

        private void HideWindow()
        {
            this.notifyIcon1.Visible = true;
            this.ShowInTaskbar = false;
            this.Hide();
        }
    }
}
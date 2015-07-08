using System;
using System.Windows.Forms;

namespace SingleInstanceApplication
{
    public partial class MainForm : Form
    {
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
    }
}
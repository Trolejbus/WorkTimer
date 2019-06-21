using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WorkTimer.CustomControls.Browser
{
    public partial class BrowserForm : Form
    {
        public DateTime ClosedTime;
        private Process browser;

        public BrowserForm()
        {
            InitializeComponent();
            ClosedTime = DateTime.Now.AddMinutes(5);
            timer1.Enabled = true;
            browser = Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = e.Url.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                NavigateToUrl();
            }
        }

        private void NavigateToUrl()
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private TimeSpan TimeLeft()
        {
            return ClosedTime - DateTime.Now;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            NavigateToUrl();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text = $"{TimeLeft():mm\\:ss}";
            if(TimeLeft() < TimeSpan.Zero)
            {
                browser.CloseMainWindow();
                Close();
            }
        }
    }
}

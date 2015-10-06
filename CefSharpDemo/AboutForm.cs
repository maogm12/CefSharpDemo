using System.Windows.Forms;
using CefSharp.WinForms;

namespace CefSharpDemo
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            // init the about page
            InitAboutPage();
        }

        private void InitAboutPage()
        {
            var browser = new ChromiumWebBrowser("http://maogm.com")
            {
                Dock = DockStyle.Fill
            };
            browserPanel.Controls.Add(browser);
        }
    }
}

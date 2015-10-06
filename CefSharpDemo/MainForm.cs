using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using System.Threading.Tasks;

namespace CefSharpDemo
{
    public partial class MainForm : Form
    {
        private ChromiumWebBrowser _browser;

        public MainForm()
        {
            InitializeComponent();

            // init editor
            initEditor();
        }

        private void aboutMeMenu_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void initEditor()
        {
            var editorInfo = new FileInfo(@".\static\editor.html");
            _browser = new ChromiumWebBrowser(editorInfo.FullName)
            {
                Dock = DockStyle.Fill
            };

            _browser.RegisterJsObject("cef", new CefCallTest());

            mainPanel.Controls.Add(_browser);
        }

        private void cs2js1Menu_Click(object sender, EventArgs e)
        {
            if (_browser != null && _browser.IsBrowserInitialized)
            {
                _browser.ExecuteScriptAsync("alert('Call JavaScript from C#');");
            }
        }

        private void cs2js2Menu_Click(object sender, EventArgs e)
        {
            if (_browser != null && _browser.IsBrowserInitialized)
            {
                var task = _browser.EvaluateScriptAsync(@"
(function() {
    var body = document.body, html = document.documentElement;
    return Math.max(body.scrollHeight, body.offsetHeight, html.clientHeight,
                    html.scrollHeight, html.offsetHeight);
})();");

                object result;
                task.ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        var response = t.Result;
                        result = response.Success ? (response.Result ?? "null") : response.Message;
                        MessageBox.Show("得到的结果是： " + result);
                    } else
                    {
                        MessageBox.Show("出错了");
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void devToolsMenu_Click(object sender, EventArgs e)
        {
            if (_browser != null)
            {
                _browser.ShowDevTools();
            }
        }

        private void jsCallCsMenu_Click(object sender, EventArgs e)
        {
            if (_browser != null)
            {
                _browser.ExecuteScriptAsync("callCs();");
            }
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }

    internal class CefCallTest
    {
        public string StringProp { get; set; }

        public void ShowHelloCef()
        {
            MessageBox.Show("Hello, Cef!!!!");
        }

        public CefCallTest()
        {
            StringProp = "Hello, Cef";
        }
    }
}

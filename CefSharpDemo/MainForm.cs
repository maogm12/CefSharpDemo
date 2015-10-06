using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using System.Net;
using System.Text;

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
            // cef setting
            var setting = new CefSettings();
            setting.RegisterScheme(new CefCustomScheme()
            {
                SchemeName = LocalSchemeHandler.SchemeName,
                SchemeHandlerFactory = new LocalSchemeHanlderFactory()
            });
            Cef.Initialize(setting);

//            var editorInfo = new FileInfo(@".\static\editor.html");
//            _browser = new ChromiumWebBrowser(editorInfo.FullName)
            _browser = new ChromiumWebBrowser("http://cef/editor.html")
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

        private void openMenu_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fileName = openFileDialog.FileName;
            if (_browser != null)
            {
                // load file
                _browser.ExecuteScriptAsync(string.Format(@"
(function(){{
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open('GET', 'http://cef/file?path={0}&nocache=' + (new Date()).getTime(), false);
    xmlHttp.send(null);
    loadText('{0}', xmlHttp.responseText);
}})();
", HttpUtility.UrlEncode(fileName)));
            }
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

    internal class LocalSchemeHanlderFactory : ISchemeHandlerFactory
    {
        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            if (schemeName == LocalSchemeHandler.SchemeName)
            {
                return new LocalSchemeHandler();
            }

            return null;
        }
    }

    internal class LocalSchemeHandler : IResourceHandler
    {
        public const string SchemeName = "http";
        private string mimeType;
        private MemoryStream stream;
        private int statusCode;
        private string statusText;

        public Stream GetResponse(IResponse response, out long responseLength, out string redirectUrl)
        {
            responseLength = stream.Length;
            redirectUrl = null;

            response.StatusCode = statusCode;
            response.StatusText = statusText;
            response.MimeType = mimeType;

            return stream;
        }

        public bool ProcessRequestAsync(IRequest request, ICallback callback)
        {
            var uri = new Uri(request.Url);
            var fileName = uri.AbsolutePath;

            if (fileName == "/pure-min.css")
            {
                var content = File.ReadAllText(@".\static\pure-min.css");
                stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
                mimeType = "text/css";
                statusText = "OK";
                statusCode = (int)HttpStatusCode.OK;
                callback.Continue();
                return true;
            }

            if (fileName == "/editor.html")
            {
                var content = File.ReadAllText(@".\static\editor.html");
                stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
                mimeType = "text/html";
                statusText = "OK";
                statusCode = (int)HttpStatusCode.OK;
                callback.Continue();
                return true;
            }

            if (fileName == "/file")
            {
                if (request.Method == "GET")
                {
                    var param = HttpUtility.ParseQueryString(uri.Query);
                    var path = param["path"];
                    if (File.Exists(path))
                    {
                        var content = File.ReadAllText(path);
                        stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
                        mimeType = "text/plain";
                        statusText = "OK";
                        statusCode = (int)HttpStatusCode.OK;
                        callback.Continue();
                        return true;
                    }
                }
                else if (request.Method == "POST")
                {
                    var elems = request.PostData.Elements;
                    if (elems != null && elems.Count > 0)
                    {
                        var data = elems[0].GetBody("utf8");
                        MessageBox.Show(data);

                        // @todo
                    }
                }
            }

            stream = new MemoryStream();
            statusText = "404 error";
            statusCode = (int)HttpStatusCode.NotFound;
            callback.Continue();
            return true;
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.IO.Compression;
using System.Web;
using System.Web.WebPages;

namespace WebEngine
{
    public class Global : System.Web.HttpApplication
    {
        public static string ConnectionString { get; set; }

        public static bool IsCompress { get; set; } = false;

        public static ConcurrentDictionary<string, string> Collection { get; set; } = new ConcurrentDictionary<string, string>();

        public static ConcurrentDictionary<string, string> XmlData { get; set; } = new ConcurrentDictionary<string, string>();

        public static bool IsExists(string key)
        {
            bool result = false;

            if (Collection.ContainsKey(key))
            {
                string tmp = Get(key);
                if (!string.IsNullOrWhiteSpace(tmp))
                {
                    result = true;
                }
            }

            return result;
        }

        public static string Get(string key)
        {
            string result = string.Empty;

            if (Collection.TryGetValue(key, out result))
            {
                if (string.IsNullOrWhiteSpace(result))
                {
                    if (key.Equals("url", StringComparison.OrdinalIgnoreCase))
                    {
                        result = HttpContext.Current.Request.Url.AbsoluteUri;
                    }
                    else
                    {

                    }
                }
                return result;
            }
            else
            {
                if (key.Equals("url", StringComparison.OrdinalIgnoreCase))
                {
                    result = HttpContext.Current.Request.Url.AbsoluteUri;
                }
                else
                {

                }
            }

            return result;
        }

        public static void Set(string key, string value)
        {
            Collection.AddOrUpdate(key, value, (oldkey, oldvalue) => value);
        }

        public static void Init(WebPage page)
        {
            Init(page, "");
        }

        public static void Init(WebPage page, string mode)
        {
            string acceptEncoding = string.Empty;

            if (!string.IsNullOrWhiteSpace(mode))
            {
                if (mode.Equals("json", StringComparison.OrdinalIgnoreCase))
                {
                    page.Context.Response.ContentType = "application/json";
                    page.Layout = null;
                }
                else if (mode.Equals("xml", StringComparison.OrdinalIgnoreCase))
                {
                    page.Context.Response.ContentType = "application/xml";
                    page.Layout = null;
                }
                else
                {
                    if (IsCompress)
                    {
                        acceptEncoding = page.Context.Request.Headers["Accept-Encoding"];
                        if (!string.IsNullOrWhiteSpace(acceptEncoding))
                        {
                            if (acceptEncoding.Contains("GZIP"))
                            {
                                page.Context.Response.AppendHeader("Content-Encoding", "gzip");
                                page.Context.Response.Filter = new GZipStream(HttpContext.Current.Response.Filter, CompressionMode.Compress);
                            }
                            else if (acceptEncoding.Contains("DEFLATE"))
                            {
                                page.Context.Response.AppendHeader("Content-Encoding", "deflate");
                                page.Context.Response.Filter = new DeflateStream(HttpContext.Current.Response.Filter, CompressionMode.Compress);
                            }

                        }
                    }
                }
            }
            else
            {
                if (IsCompress)
                {
                    acceptEncoding = page.Context.Request.Headers["Accept-Encoding"];
                    if (!string.IsNullOrWhiteSpace(acceptEncoding))
                    {
                        if (acceptEncoding.Contains("GZIP"))
                        {
                            page.Context.Response.AppendHeader("Content-Encoding", "gzip");
                            page.Context.Response.Filter = new GZipStream(HttpContext.Current.Response.Filter, CompressionMode.Compress);
                        }
                        else if (acceptEncoding.Contains("DEFLATE"))
                        {
                            page.Context.Response.AppendHeader("Content-Encoding", "deflate");
                            page.Context.Response.Filter = new DeflateStream(HttpContext.Current.Response.Filter, CompressionMode.Compress);
                        }

                    }
                }
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            ConnectionString = SimpleConfig.Global.GetConnection("DBConn");
            IsCompress = SimpleConfig.Global.GetBoolean("IsCompress");
            Set("title", SimpleConfig.Global.GetString("title"));
            Set("siteurl", SimpleConfig.Global.GetString("siteurl"));
            Set("mobileurl", SimpleConfig.Global.GetString("mobileurl"));
            Set("description", SimpleConfig.Global.GetString("description"));
            Set("keywords", SimpleConfig.Global.GetString("keywords"));
            Set("image", SimpleConfig.Global.GetString("image"));

            string xml = SimpleConfig.Global.GetString("XML");
            if (!string.IsNullOrWhiteSpace(xml))
            {
                string[] xmls = xml.Split(',');
                foreach(var file in xmls)
                {
                    if (!string.IsNullOrWhiteSpace(file))
                    {
                        XmlData.AddOrUpdate(file, Server.MapPath($"~/App_Data/{file}"), (oldKey, oldValue) => Server.MapPath($"~/App_Data/{file}"));
                    }
                }
            }

            AppData.Current.Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
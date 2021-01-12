using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Web;

namespace WebEngine
{
    public class Global : System.Web.HttpApplication
    {
        public static string ConnectionString { get; set; }

        public static ConcurrentDictionary<string, string> Collection { get; set; } = new ConcurrentDictionary<string, string>();

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

        protected void Application_Start(object sender, EventArgs e)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DBConn"].ToString();
            Set("title", SimpleConfig.Global.GetString("title"));
            Set("siteurl", SimpleConfig.Global.GetString("siteurl"));
            Set("mobileurl", SimpleConfig.Global.GetString("mobileurl"));
            Set("description", SimpleConfig.Global.GetString("description"));
            Set("keywords", SimpleConfig.Global.GetString("keywords"));
            Set("image", SimpleConfig.Global.GetString("image"));
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
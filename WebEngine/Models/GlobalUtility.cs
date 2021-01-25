using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.WebPages.Html;
using OctopusV3.DynamicHTML;

namespace WebEngine
{
    public class GlobalUtility
    {
        private JavaScriptSerializer jsonHandler = new JavaScriptSerializer();

        public enum TextType
        {
            Longest, Shortest
        }

        public GlobalUtility()
        {
        }

        public string Serialize(object obj)
        {
            return jsonHandler.Serialize(obj);
        }

        public string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public string Encrypt(string txt)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(txt))
            {
                try
                {
                    result = CryptoHelper.AES256.Encrypt(txt);
                }
                catch
                {
                    result = string.Empty;
                }
            }

            return result;
        }

        public string Decrypt(string txt)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(txt))
            {
                try
                {
                    result = CryptoHelper.AES256.Decrypt(txt);
                }
                catch
                {
                    result = string.Empty;
                }
            }

            return result;
        }

        public bool SHA512ValidateCheck(string AccountPassword, string Password)
        {
            return CryptoHelper.SHA512.ValidateCheck(AccountPassword, Password);
        }

        public void CookieSet(string CookieName, string CookieValue)
        {
            HttpContext.Current.Response.Cookies[CookieName].Value = CookieValue;
        }

        public string CookieGet(string CookieName)
        {
            string result = string.Empty;

            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(CookieName);

                if (cookie != null)
                {
                    result = cookie.Value;
                }
            }
            catch
            {

            }

            return result;
        }


        public void CookieSet(string CookieName, string CookieValue, DateTime ExpiredDate)
        {
            HttpContext.Current.Response.Cookies[CookieName].Value = CookieValue;
            HttpContext.Current.Response.Cookies[CookieName].Expires = ExpiredDate;
        }

        public void CookieRemove(string CookieName)
        {
            HttpContext.Current.Response.Cookies[CookieName].Value = null;
            HttpContext.Current.Response.Cookies[CookieName].Expires = DateTime.Now.AddDays(-1);
        }

        public HtmlString TagWrite(string str)
        {
            return new HtmlString(HttpUtility.UrlDecode(str));
        }

        public string TagRemove(string str)
        {
            return HttpUtility.UrlDecode(str).RemoveTag();
        }

    }

    public static class ExtendGlobalUtility
    {
        public static string GetFolderName(this HtmlHelper html, int depth = 0)
        {
            string result = string.Empty;

            result = HttpContext.Current.Request.Url.AbsolutePath;
            if (!string.IsNullOrWhiteSpace(result))
            {
                if (result.Substring(0, 1) == "/")
                {
                    result = result.Substring(1);
                }

                if (result.IndexOf("/") > -1)
                {
                    string[] tmp = result.Split('/');
                    if (tmp.Length > depth)
                    {
                        result = tmp[depth];
                    }
                }
            }


            return result.Trim();
        }

        public static HtmlString GetText(this string str, GlobalUtility.TextType type = GlobalUtility.TextType.Longest)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(str))
            {
                List<string> list = HttpUtility.UrlDecode(str).toTagList();
                if (list != null && list.Count > 0)
                {
                    string tmp = string.Empty;

                    switch (type)
                    {
                        case GlobalUtility.TextType.Longest:
                            foreach(string item in list)
                            {
                                tmp = HttpUtility.UrlDecode(item.RemoveTag().Trim());
                                if (!string.IsNullOrWhiteSpace(tmp))
                                {
                                    if (tmp.Length >  result.Length)
                                    {
                                        result = tmp;
                                    }
                                }
                            }
                            break;
                        case GlobalUtility.TextType.Shortest:
                            foreach (string item in list)
                            {
                                tmp = HttpUtility.UrlDecode(item.RemoveTag().Trim());
                                if (!string.IsNullOrWhiteSpace(tmp))
                                {
                                    if (tmp.Length < result.Length)
                                    {
                                        result = tmp;
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            return new HtmlString(result);
        }
    }
}
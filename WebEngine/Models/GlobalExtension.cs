using System;
using System.IO;
using System.Web;

namespace WebEngine
{
    public class GlobalSite
    {

        private static readonly Lazy<GlobalUtility> lazy = new Lazy<GlobalUtility>(() => new GlobalUtility());
        public static GlobalUtility Utility { get { return lazy.Value; } }

    }

    public static class GlobalExtension
    {
        public static void SetHeader(this HttpResponseBase response, string name, string value)
        {
            response.Headers.Add(name, value);
        }

        public static void JsonHeader(this HttpResponseBase response)
        {
            response.ContentType = "application/json";
        }

        public static HtmlString Json(this HttpResponseBase response, object obj)
        {
            response.ContentType = "application/json";
            return new HtmlString(GlobalSite.Utility.Serialize(obj));
        }

        public static ReturnValue GetFile(this HttpRequestBase request, string Name, string Root = "/UploadFiles")
        {
            ReturnValue result = new ReturnValue();
            HttpPostedFileBase upload = request.Files[Name];
            string uploadFolder = HttpContext.Current.Server.MapPath(Root);
            DirectoryInfo di = new DirectoryInfo(uploadFolder);
            if (!di.Exists) di.Create();

            if (upload != null)
            {
                try
                {
                    string path = Path.Combine(uploadFolder, Path.GetFileName(upload.FileName));
                    FileInfo fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        path = GlobalSite.Utility.GetUniqueFileName(path);
                        fi = new FileInfo(path);
                    }

                    upload.SaveAs(path);
                    result.Success(upload.ContentLength);
                    result.Value = (Root.Substring(Root.Length - 1, 1) == "/") ? $"{Root}{fi.Name}" : $"{Root}/{fi.Name}";
                }
                catch (Exception ex)
                {
                    result.Error(ex);
                    Logger.Current.Error(ex);
                }
            }

            return result;
        }

        public static ReturnValue GetThumbnail(this HttpRequestBase request, string Name, int width, int height, string Root = "/UploadFiles")
        {
            ReturnValue result = new ReturnValue();
            HttpPostedFileBase upload = request.Files[Name];
            string uploadFolder = HttpContext.Current.Server.MapPath(Root);
            DirectoryInfo di = new DirectoryInfo(uploadFolder);
            if (!di.Exists) di.Create();

            if (upload != null)
            {
                try
                {
                    string path = Path.Combine(uploadFolder, Path.GetFileName(upload.FileName));
                    FileInfo fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        path = GlobalSite.Utility.GetUniqueFileName(path);
                        fi = new FileInfo(path);
                    }

                    result = upload.SaveThumbnail(path, width, height);
                    result.Value = (Root.Substring(Root.Length - 1, 1) == "/") ? $"{Root}{fi.Name}" : $"{Root}/{fi.Name}";
                }
                catch (Exception ex)
                {
                    result.Error(ex);
                    Logger.Current.Error(ex);
                }
            }

            return result;
        }

        public static ReturnValue GetCrop(this HttpRequestBase request, string Name, int width, int height, string Root = "/UploadFiles")
        {
            ReturnValue result = new ReturnValue();
            HttpPostedFileBase upload = request.Files[Name];
            string uploadFolder = HttpContext.Current.Server.MapPath(Root);
            DirectoryInfo di = new DirectoryInfo(uploadFolder);
            if (!di.Exists) di.Create();

            if (upload != null)
            {
                try
                {
                    string path = Path.Combine(uploadFolder, Path.GetFileName(upload.FileName));
                    FileInfo fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        path = GlobalSite.Utility.GetUniqueFileName(path);
                        fi = new FileInfo(path);
                    }

                    result = upload.SaveCrop(path, width, height);
                    result.Value = (Root.Substring(Root.Length - 1, 1) == "/") ? $"{Root}{fi.Name}" : $"{Root}/{fi.Name}";
                }
                catch (Exception ex)
                {
                    result.Error(ex);
                    Logger.Current.Error(ex);
                }
            }

            return result;
        }

        public static string GetString(this HttpRequestBase request, string Name, string DefaultValue = "")
        {
            string result = string.Empty;

            if (request[Name] != null)
            {
                result = Convert.ToString(request[Name]);
            }
            else
            {
                result = DefaultValue;
            }

            return result;
        }

        public static int GetInt(this HttpRequestBase request, string Name, int DefaultValue = -1)
        {
            int result = default(int);

            if (int.TryParse(request.GetString(Name), out result))
            {
                return result;
            }
            else
            {
                return DefaultValue;
            }
        }

        public static float GetFloat(this HttpRequestBase request, string Name, float DefaultValue = -1)
        {
            float result = default(float);

            if (float.TryParse(request.GetString(Name), out result))
            {
                return result;
            }
            else
            {
                return DefaultValue;
            }
        }

        public static long GetLong(this HttpRequestBase request, string Name, long DefaultValue = -1)
        {
            long result = default(long);

            if (long.TryParse(request.GetString(Name), out result))
            {
                return result;
            }
            else
            {
                return DefaultValue;
            }
        }

        public static bool GetBoolean(this HttpRequestBase request, string Name, bool DefaultValue = false)
        {
            bool result = default(bool);

            if (bool.TryParse(request.GetString(Name), out result))
            {
                return result;
            }
            else
            {
                return DefaultValue;
            }
        }

        public static DateTime GetDateTime(this HttpRequestBase request, string Name, DateTime DefaultValue = new DateTime())
        {
            DateTime result = default(DateTime);

            if (DateTime.TryParse(request.GetString(Name), out result))
            {
                return result;
            }
            else
            {
                return DefaultValue;
            }
        }
    }
}
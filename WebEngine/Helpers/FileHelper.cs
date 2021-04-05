using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebEngine
{
    public class FileHelper : OctopusV3.Core.FileHelper
    {
        public FileHelper()
        {
        }


        public static List<FileInfo> GetAllFiles(string path)
        {
            var result = new List<FileInfo>();

            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                foreach(FileInfo fi in di.GetFiles())
                {
                    result.Add(fi);
                }

                foreach(DirectoryInfo ddi in di.GetDirectories())
                {
                    result.AddRange(GetAllFiles(ddi.FullName));
                }
            }

            return result;
        }

        public static string PathinRoot(string path, string Target)
        {
            StringBuilder builder = new StringBuilder(Target);
            builder.Replace(path, "");
            builder.Replace("\\", "/");
            if (builder.ToString().Substring(0, 1).Equals("/"))
            {
                return builder.ToString().Substring(1);
            }
            else
            {
                return builder.ToString();
            }
        }

        public static string LastFolder(string path)
        {
            string result = string.Empty;

            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists && di.FullName.IndexOf("\\") > -1)
            {
                string[] arr = di.FullName.Split('\\');
                if (arr != null && arr.Length > 0)
                {
                    for(int i = arr.Length - 1; i >= 0; i--)
                    {
                        result = arr[i].Trim();
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }

    public static class ExFileHelper
    {
        public static string ToRootPath(this string path, string root)
        {
            return FileHelper.PathinRoot(root, path);
        }
    }
}
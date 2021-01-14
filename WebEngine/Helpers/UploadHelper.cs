using OctopusV3.Core;
using System;
using System.IO;
using System.Web;

namespace WebEngine
{
    public class UploadHelper : IDisposable
    {
        protected string path { get; set; } = string.Empty;

        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;
                this.AbsolutePath = HttpContext.Current.Server.MapPath(this.path);

                DirectoryInfo di = new DirectoryInfo(this.AbsolutePath);
                if (!di.Exists) di.Create();
            }
        }

        public string AbsolutePath { get; set; } = string.Empty;

        public string Ext { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        private int num = 0;

        public UploadHelper()
        {
        }

        public UploadHelper(string _path)
        {
            this.Path = _path;
            this.AbsolutePath = HttpContext.Current.Server.MapPath(_path);

            DirectoryInfo di = new DirectoryInfo(this.AbsolutePath);
            if (!di.Exists) di.Create();
        }

        protected virtual void SplitExtFileName(string FileName)
        {
            this.Ext = System.IO.Path.GetExtension(FileName);
            this.FileName = System.IO.Path.GetFileName(FileName);
            this.FileName = this.FileName.Replace(this.Ext, "").Trim();
            this.Ext = this.Ext.Replace(".", "").Trim();
        }

        public string UploadPath
        {
            get
            {
                return System.IO.Path.Combine(this.Path, $"{this.FileName}.{this.Ext}");
            }
        }

        public string UploadURL
        {
            get
            {
                return $"{this.Path}/{this.FileName}.{this.Ext}";
            }
        }

        public virtual ReturnValue Save(HttpPostedFileBase file)
        {
            var result = new ReturnValue();

            try
            {
                this.SplitExtFileName(file.FileName);
                FileInfo fi = new FileInfo(UploadPath);
                num = 0;
                while (fi.Exists)
                {
                    this.FileName = $"{this.FileName}[{num++}]";
                    fi = new FileInfo(UploadPath);
                }
                file.SaveAs(fi.FullName);
                result.Success(file.ContentLength, UploadURL);
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }

        public virtual ReturnValue SaveAs(HttpPostedFileBase file, string NewFileName)
        {
            var result = new ReturnValue();

            try
            {
                this.SplitExtFileName(file.FileName);
                this.FileName = NewFileName;

                FileInfo fi = new FileInfo(UploadPath);
                num = 0;
                while (fi.Exists)
                {
                    this.FileName = $"{this.FileName}[{num++}]";
                    fi = new FileInfo(UploadPath);
                }
                file.SaveAs(fi.FullName);
                result.Success(file.ContentLength, UploadURL);
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }

        public virtual ReturnValue SaveAsUnique(HttpPostedFileBase file)
        {
            return SaveAs(file, GetUniqueFileName());
        }

        public virtual string GetUniqueFileName()
        {
            return $"{Guid.NewGuid().ToString().Replace("-", "")}_{DateTime.Now.ToString("yyyyMMddHHmmss")}_{RandomHelper.RandomString(6)}";
        }

        public void Dispose()
        {

        }
    }

    public static class ExtendUploadHelper 
    {

    }
}
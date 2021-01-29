using System;
using System.Drawing;
using System.IO;
using System.Web;


namespace WebEngine
{
    public class ImageHelper
    {
        public static ReturnValues<Image> CreateThumbnail(string filePath, int width, int height)
        {
            var result = new ReturnValues<Image>();

            try
            {
                FileInfo fi = new FileInfo(filePath);
                if (fi.Exists)
                {
                    using (FileStream fs = File.OpenRead(fi.FullName))
                    using (Image image = Image.FromStream(fs, false, false))
                    using (Image pThumbnail = image.GetThumbnailImage(width, height, delegate { return false; }, IntPtr.Zero))
                    {
                        result.Success(fi.Length, pThumbnail);
                    }
                }
                else
                {
                    result.Error("대상 파일이 존재하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }


            return result;
        }

        public static ReturnValues<Image> CreateCrop(string filePath, int width, int height)
        {
            var result = new ReturnValues<Image>();

            try
            {
                FileInfo fi = new FileInfo(filePath);
                if (fi.Exists)
                {
                    using (FileStream fs = File.OpenRead(fi.FullName))
                    using (Image image = Image.FromStream(fs, false, false))
                    {
                        if (image.Width > width && image.Height > height)
                        {
                            Point point = new Point();
                            point.X = (image.Width - width) / 2;
                            if (height > (image.Height * 2))
                            {
                                point.Y = height / 2;
                            }
                            else
                            {
                                point.Y = (image.Height - height) / 2;
                            }
                            Rectangle cropRect = new Rectangle(point, new Size(width, height));
                            Bitmap src = image as Bitmap;
                            result.Data = src.Clone(cropRect, image.PixelFormat);
                            result.Check = true;
                            result.Value = "Crop";
                            result.Code = fi.Length;
                        }
                        else
                        {
                            result.Data = image.GetThumbnailImage(width, height, delegate { return false; }, IntPtr.Zero);
                            result.Check = true;
                            result.Value = "Thumbnail";
                            result.Code = fi.Length;
                        }
                    }
                }
                else
                {
                    result.Error("대상 파일이 존재하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }


            return result;
        }
    }

    public static class ExtendImageHelper
    {
        public static ReturnValue SaveThumbnail(this HttpPostedFileBase upload, string SavePath, int width, int height)
        {
            var result = new ReturnValue();

            if (upload != null)
            {
                try
                {
                    using (var tempStream = new MemoryStream())
                    {
                        upload.InputStream.CopyTo(tempStream);
                        tempStream.Position = 0;
                        using (Image image = Image.FromStream(tempStream, false, false))
                        using (Image pThumbnail = image.GetThumbnailImage(width, height, delegate { return false; }, IntPtr.Zero))
                        {
                            pThumbnail.Save(SavePath);
                            result.Success(tempStream.Length, SavePath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Error(ex);
                }
            }
            else
            {
                result.Error(new NullReferenceException("upload is null"));
            }

            return result;
        }

        public static ReturnValue SaveCrop(this HttpPostedFileBase upload, string SavePath, int width, int height)
        {
            var result = new ReturnValue();

            if (upload != null)
            {
                try
                {
                    using (var tempStream = new MemoryStream())
                    {
                        upload.InputStream.CopyTo(tempStream);
                        tempStream.Position = 0;
                        using (Image image = Image.FromStream(tempStream, false, false))
                        {
                            if (image.Width > width && image.Height > height)
                            {
                                Point point = new Point();
                                point.X = (image.Width - width) / 2;
                                if (height > (image.Height * 2))
                                {
                                    point.Y = height / 2;
                                }
                                else
                                {
                                    point.Y = (image.Height - height) / 2;
                                }
                                Rectangle cropRect = new Rectangle(point, new Size(width, height));
                                Bitmap src = image as Bitmap;
                                var tmp = src.Clone(cropRect, image.PixelFormat);
                                tmp.Save(SavePath);
                                result.Success(tempStream.Length, SavePath);
                            }
                            else
                            {
                                var tmp2 = image.GetThumbnailImage(width, height, delegate { return false; }, IntPtr.Zero);
                                tmp2.Save(SavePath);
                                result.Success(tempStream.Length, SavePath);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Error(ex);
                }
            }
            else
            {
                result.Error(new NullReferenceException("upload is null"));
            }

            return result;
        }
    }
}
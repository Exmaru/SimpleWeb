using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace WebEngine
{
    public class ImageHelper
    {
        public static ReturnValues<Image> CreateThumbnail(string filePath, int width, int height)
        {
            var result = new ReturnValues<Image>();

            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                using (FileStream fs = File.OpenRead(fi.FullName))
                {
                    using (Image image = Image.FromStream(fs, false, false))
                    {
                        using (Image pThumbnail = image.GetThumbnailImage(width, height, delegate { return false; }, IntPtr.Zero))
                        {
                            result.Success(fi.Length, pThumbnail);
                        }
                    }
                }
            }
            else
            {
                result.Error("대상 파일이 존재하지 않습니다.");
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

        public static ReturnValue Resize(string importPath, string exportPath, int targetX, int targetY)
        {
            var result = new ReturnValue();

            try
            {
                System.Drawing.Image originalImage = System.Drawing.Image.FromFile(importPath);


                double ratioX = targetX / (double)originalImage.Width;
                double ratioY = targetY / (double)originalImage.Height;

                double ratio = Math.Min(ratioX, ratioY);

                int newWidth = (int)(originalImage.Width * ratio);
                int newHeight = (int)(originalImage.Height * ratio);

                Bitmap newImage = new Bitmap(targetX, targetY);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
                    g.DrawImage(originalImage, (targetX - newWidth) / 2, (targetY - newHeight) / 2, newWidth, newHeight);
                }

                newImage.Save(exportPath);
                FileInfo fi = new FileInfo(exportPath);
                if (fi.Exists)
                {
                    result.Success(fi.Length, exportPath);
                }
                else
                {
                    result.Error("File Save Fail.");
                }

                originalImage.Dispose();
                newImage.Dispose();
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }

        public static ReturnValue Crop(string importPath, string exportPath, int targetX, int targetY)
        {
            var result = new ReturnValue();

            try
            {
                System.Drawing.Image originalImage = System.Drawing.Image.FromFile(importPath);


                double ratioX = targetX / (double)originalImage.Width;
                double ratioY = targetY / (double)originalImage.Height;

                double ratio = Math.Max(ratioX, ratioY);

                int newWidth = (int)(originalImage.Width * ratio);
                int newHeight = (int)(originalImage.Height * ratio);

                Bitmap newImage = new Bitmap(targetX, targetY);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    //g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
                    g.DrawImage(originalImage, (targetX - newWidth) / 2, (targetY - newHeight) / 2, newWidth, newHeight);
                }

                newImage.Save(exportPath);
                FileInfo fi = new FileInfo(exportPath);
                if (fi.Exists)
                {
                    result.Success(fi.Length, exportPath);
                }
                else
                {
                    result.Error("File Save Fail.");
                }

                originalImage.Dispose();
                newImage.Dispose();
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }

        public static ReturnValue Resize(MemoryStream memory, string exportPath, int targetX, int targetY)
        {
            var result = new ReturnValue();

            try
            {
                System.Drawing.Image originalImage = System.Drawing.Image.FromStream(memory, false, false);


                double ratioX = targetX / (double)originalImage.Width;
                double ratioY = targetY / (double)originalImage.Height;

                double ratio = Math.Min(ratioX, ratioY);

                int newWidth = (int)(originalImage.Width * ratio);
                int newHeight = (int)(originalImage.Height * ratio);

                Bitmap newImage = new Bitmap(targetX, targetY);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
                    g.DrawImage(originalImage, (targetX - newWidth) / 2, (targetY - newHeight) / 2, newWidth, newHeight);
                }

                newImage.Save(exportPath);
                FileInfo fi = new FileInfo(exportPath);
                if (fi.Exists)
                {
                    result.Success(fi.Length, exportPath);
                }
                else
                {
                    result.Error("File Save Fail.");
                }

                originalImage.Dispose();
                newImage.Dispose();
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }

        public static ReturnValue Crop(MemoryStream memory, string exportPath, int targetX, int targetY)
        {
            var result = new ReturnValue();

            try
            {
                System.Drawing.Image originalImage = System.Drawing.Image.FromStream(memory, false, false);


                double ratioX = targetX / (double)originalImage.Width;
                double ratioY = targetY / (double)originalImage.Height;

                double ratio = Math.Max(ratioX, ratioY);

                int newWidth = (int)(originalImage.Width * ratio);
                int newHeight = (int)(originalImage.Height * ratio);

                Bitmap newImage = new Bitmap(targetX, targetY);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    //g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
                    g.DrawImage(originalImage, (targetX - newWidth) / 2, (targetY - newHeight) / 2, newWidth, newHeight);
                }

                newImage.Save(exportPath);
                FileInfo fi = new FileInfo(exportPath);
                if (fi.Exists)
                {
                    result.Success(fi.Length, exportPath);
                }
                else
                {
                    result.Error("File Save Fail.");
                }

                originalImage.Dispose();
                newImage.Dispose();
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }

        public static Task<ReturnValue> ResizeAsync(string importPath, string exportPath, int targetX, int targetY)
        {
            return Task.Factory.StartNew(() => Resize(importPath, exportPath, targetX, targetY));
        }

        public static Task<ReturnValue> CropAsync(string importPath, string exportPath, int targetX, int targetY)
        {
            return Task.Factory.StartNew(() => Crop(importPath, exportPath, targetX, targetY));
        }

        public static Task<ReturnValue> ResizeAsync(MemoryStream memory, string exportPath, int targetX, int targetY)
        {
            return Task.Factory.StartNew(() => Resize(memory, exportPath, targetX, targetY));
        }

        public static Task<ReturnValue> CropAsync(MemoryStream memory, string exportPath, int targetX, int targetY)
        {
            return Task.Factory.StartNew(() => Crop(memory, exportPath, targetX, targetY));
        }


        public static string ThumbnailPath(string FilePath, int width, int height)
        {
            string result = "#";

     
            FileInfo fi = new FileInfo(HttpContext.Current.Server.MapPath(FilePath));
            if (fi.Exists)
            {
                string Path = $"~/UploadFiles/Thumbnails/{width}x{height}";
                string PathFile = $"/UploadFiles/Thumbnails/{width}x{height}/{fi.Name}";
                string PyPath = HttpContext.Current.Server.MapPath(Path);
                string PyFile = System.IO.Path.Combine(PyPath, fi.Name);

                FileInfo Target = new FileInfo(PyFile);
                if (Target.Exists)
                {
                    result = PathFile;
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(PyPath);
                    if (!di.Exists) di.Create();

                    using (FileStream fs = File.OpenRead(fi.FullName))
                    using (Image image = Image.FromStream(fs, false, false))
                    using (Image pThumbnail = image.GetThumbnailImage(width, height, delegate { return false; }, IntPtr.Zero))
                    {
                        pThumbnail.Save(PyFile);
                        result = PathFile;
                    }
                }
            }


            return result;
        }

        public static string CropPath(string FilePath, int width, int height)
        {
            string result = "#";


            FileInfo fi = new FileInfo(HttpContext.Current.Server.MapPath(FilePath));
            if (fi.Exists)
            {
                string Path = $"~/UploadFiles/Crop/{width}x{height}";
                string PathFile = $"/UploadFiles/Crop/{width}x{height}/{fi.Name}";
                string PyPath = HttpContext.Current.Server.MapPath(Path);
                string PyFile = System.IO.Path.Combine(PyPath, fi.Name);

                FileInfo Target = new FileInfo(PyFile);
                if (Target.Exists)
                {
                    result = PathFile;
                }
                else
                {
                    var rtn = CreateCrop(fi.FullName, width, height);
                    if (rtn.Check)
                    {
                        DirectoryInfo di = new DirectoryInfo(PyPath);
                        if (!di.Exists) di.Create();
                        using (Image img = rtn.Data)
                        {
                            img.Save(PyFile);
                            result = PathFile;
                        }
                    }
                }
            }


            return result;
        }

        public static string ThumbnailView(string FilePath, int width, int height)
        {
            FileInfo fi = new FileInfo(HttpContext.Current.Server.MapPath(FilePath));

            if (fi.Exists)
            {
                try
                {
                    var rtn = CreateThumbnail(fi.FullName, width, height);
                    if (rtn.Check)
                    {
                        byte[] arr = null;
                        if (FilePath.EndsWith("gif", StringComparison.OrdinalIgnoreCase))
                        {
                            Logger.Current.Debug($"gif");
                            arr = imageToByteArray(rtn.Data, System.Drawing.Imaging.ImageFormat.Gif);
                        }
                        else if (FilePath.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                        {
                            Logger.Current.Debug($"png");
                            arr = imageToByteArray(rtn.Data, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        else
                        {
                            Logger.Current.Debug($"jpg");
                            arr = imageToByteArray(rtn.Data, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }

                        if (arr != null)
                        {
                            return "data:image/png;base64," + Convert.ToBase64String(arr, Base64FormattingOptions.None);
                        }
                        else
                        {
                            arr = System.IO.File.ReadAllBytes(fi.FullName);
                            return "data:image/png;base64," + Convert.ToBase64String(arr, Base64FormattingOptions.None);
                        }
                    }
                    else
                    {
                        throw new Exception(rtn.Message);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Current.Error(ex);
                    byte[] filebytes = System.IO.File.ReadAllBytes(fi.FullName);
                    return "data:image/png;base64," + Convert.ToBase64String(filebytes, Base64FormattingOptions.None);
                }
            }
            else
            {
                throw new FileNotFoundException("대상 이미지가 존재하지 않습니다.");
            }
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn, System.Drawing.Imaging.ImageFormat format)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, format);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                Logger.Current.Error(ex);
                return null;
            }
        }

        public static Image ByteArrayToImage(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            Image recImg = Image.FromStream(ms);
            return recImg;
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
                        {
                            var chk = ImageHelper.Resize(tempStream, SavePath, width, height);
                            result.Check = chk.Check;
                            result.Value = chk.Value;
                            result.Message = chk.Message;
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
                result.Error("upload is null");
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
                            var chk = ImageHelper.Crop(tempStream, SavePath, width, height);
                            result.Check = chk.Check;
                            result.Value = chk.Value;
                            result.Message = chk.Message;
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
                result.Error("upload is null");
            }

            return result;
        }

        [Obsolete("지원이 중단되었습니다", false)]
        public static ReturnValue LegacySaveThumbnail(this HttpPostedFileBase upload, string SavePath, int width, int height)
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
                            Logger.Current.Debug($"width : {width}");
                            Logger.Current.Debug($"height : {height}");
                            Logger.Current.Debug($"image.Width : {image.Width}");
                            Logger.Current.Debug($"image.Height : {image.Height}");



                            Image target = null;
                            int targetWidth = 0;
                            int targetHeight = 0;
                            double gapWidth = 0.0;
                            double gapHeight = 0.0;
                            int x = 0;
                            int y = 0;

                            if (image.Width > width && image.Height > height)
                            {
                                Logger.Current.Debug("둘 다 큰 경우");
                                gapWidth = ((double)image.Width - (double)width) / (double)image.Width;
                                gapHeight = ((double)image.Height - (double)height) / (double)image.Height;

                                if (gapWidth > gapHeight) //가로로 긴 이미지
                                {
                                    Logger.Current.Debug("가로로 긴");
                                    if ((image.Height - height) > height)
                                    {
                                        targetWidth = width;
                                        targetHeight = Convert.ToInt32(height * gapWidth);
                                        y = (height - targetHeight) / 2;
                                    }
                                    else
                                    {
                                        targetWidth = width;
                                        targetHeight = Convert.ToInt32((image.Height - height) * gapWidth);
                                        y = (height - targetHeight) / 2;
                                    }

                                }
                                else if (gapHeight > gapWidth) //세로로 긴 이미지
                                {
                                    Logger.Current.Debug("세로로 긴");
                                    if ((image.Width - width) > width)
                                    {
                                        targetHeight = height;
                                        targetWidth = Convert.ToInt32(width * (gapHeight));
                                        x = (width - targetWidth) / 2;
                                    }
                                    else
                                    {
                                        targetHeight = height;
                                        targetWidth = Convert.ToInt32((image.Width - width) * (gapHeight));
                                        x = (width - targetWidth) / 2;
                                    }

                                }
                                else //같은 비율
                                {
                                    Logger.Current.Debug("정사각");
                                    targetWidth = width;
                                    targetHeight = height;
                                }
                            }
                            else if (image.Width > width && image.Height < height)
                            {
                                Logger.Current.Debug("Width가 큰 경우");
                                gapWidth = ((double)image.Width - (double)width) / (double)image.Width;
                                targetWidth = width;
                                targetHeight = Convert.ToInt32(image.Height * gapWidth);
                            }
                            else if (image.Width < width && image.Height > height)
                            {
                                Logger.Current.Debug("Height가 큰 경우");
                                gapHeight = ((double)image.Height - (double)height) / (double)image.Height;
                                targetHeight = height;
                                targetWidth = Convert.ToInt32(image.Width * gapHeight);
                            }
                            else if (image.Width < width && image.Height < height)
                            {
                                Logger.Current.Debug("둘 다 작은 경우");
                                gapWidth = ((double)width - (double)image.Width) / (double)width;
                                gapHeight = ((double)height - (double)image.Height) / (double)height;

                                if (gapWidth > gapHeight) //가로로 긴 이미지
                                {
                                    targetWidth = width;
                                    targetHeight = Convert.ToInt32(image.Height * gapWidth);
                                }
                                else if (gapHeight > gapWidth) //세로로 긴 이미지
                                {
                                    targetHeight = height;
                                    targetWidth = Convert.ToInt32(image.Width * gapHeight);
                                }
                                else //같은 비율
                                {
                                    targetWidth = width;
                                    targetHeight = height;
                                }
                            }
                            else
                            {
                                Logger.Current.Debug("동일한 경우");
                                targetWidth = width;
                                targetHeight = height;
                            }

                            Logger.Current.Debug($"gapWidth : {gapWidth}");
                            Logger.Current.Debug($"gapHeight : {gapHeight}");
                            Logger.Current.Debug($"targetWidth : {targetWidth}");
                            Logger.Current.Debug($"targetHeight : {targetHeight}");

                            if (targetHeight > 0 && targetWidth > 0)
                            {
                                target = image.GetThumbnailImage(targetWidth, targetHeight, delegate { return false; }, IntPtr.Zero);
                            }
                            else
                            {
                                target = image;
                            }

                            Bitmap origin = DrawFilledRectangle(width, height);
                            Rectangle ImageSize = new Rectangle(0, 0, width, height);
                            using (Graphics grp = Graphics.FromImage(origin))
                            {
                                grp.DrawImage(target, x, y, ImageSize, GraphicsUnit.Pixel);
                            }
                            origin.Save(SavePath);
                            result.Success(tempStream.Length, SavePath);

                            /*
                            using (Image pThumbnail = image.GetThumbnailImage(width, height, delegate { return false; }, IntPtr.Zero))
                            {
                                
                            }
                            */
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

        [Obsolete("지원이 중단되었습니다", false)]
        public static ReturnValue LegacySaveCrop(this HttpPostedFileBase upload, string SavePath, int width, int height)
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
                                Image tmp3 = null;
                                double persent = 0.0;
                                int targetWidth = 0;
                                int targetHeight = 0;

                                Logger.Current.Debug($"width : {width}");
                                Logger.Current.Debug($"height : {height}");
                                Logger.Current.Debug($"image.Width : {image.Width}");
                                Logger.Current.Debug($"image.Height : {image.Height}");


                                if ((image.Width - width) > (image.Height - height))
                                {

                                    persent = (double)height / (double)image.Height;
                                    Logger.Current.Debug($"height persent : {persent}");
                                    Logger.Current.Debug($"height persent : {persent}");
                                    targetWidth = Convert.ToInt32(image.Width * persent);
                                    Logger.Current.Debug($"targetWidth : {targetWidth}");
                                    tmp3 = image.GetThumbnailImage(targetWidth, height, delegate { return false; }, IntPtr.Zero);
                                }
                                else if ((image.Width - width) < (image.Height - height))
                                {
                                    persent = (double)width / (double)image.Width;
                                    Logger.Current.Debug($"width persent : {persent}");
                                    targetHeight = Convert.ToInt32(image.Height * persent);
                                    Logger.Current.Debug($"targetHeight : {targetHeight}");
                                    tmp3 = image.GetThumbnailImage(width, targetHeight, delegate { return false; }, IntPtr.Zero);
                                }
                                else
                                {
                                    tmp3 = image.GetThumbnailImage(width, height, delegate { return false; }, IntPtr.Zero);
                                }

                                point.X = (tmp3.Width - width) / 2;
                                if (height > (tmp3.Height * 2))
                                {
                                    point.Y = height / 2;
                                }
                                else
                                {
                                    point.Y = (tmp3.Height - height) / 2;
                                }

                                Logger.Current.Debug($"point.X : {point.X}");
                                Logger.Current.Debug($"point.Y : {point.Y}");

                                Rectangle cropRect = new Rectangle(point, new Size(width, height));
                                Bitmap src = tmp3 as Bitmap;
                                var tmp = src.Clone(cropRect, tmp3.PixelFormat);
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

        public static Bitmap DrawFilledRectangle(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.White, ImageSize);
            }
            return bmp;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgCompresser.Classess
{
    public static class CompressionCore
    {
        private static readonly ImageCodecInfo jpgEncoder;
        static CompressionCore()
        {
            /*获取jpg编码器*/
            foreach (var item in ImageCodecInfo.GetImageEncoders())
            {
                if (item.FormatDescription.Equals("JPEG"))
                {
                    jpgEncoder = item; break;
                }
            }
        }

        /// <summary>
        /// 无损压缩图片（递归）
        /// </summary>
        /// <param name="sFile">原图片地址</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小 - 单位KB</param>
        /// <param name="sfsc">是否是第一次调用</param>
        /// <returns></returns>
        public static bool CompressImageRec(string sFile, string dFile, int flag = 90, int size = 300, bool sfsc = true)
        {
            Image imgSource = Image.FromFile(sFile);
            ImageFormat imgFormat = imgSource.RawFormat;

            //如果是第一次调用，原始图像的大小小于要压缩的大小，则返回false
            if (sfsc == true && new FileInfo(sFile).Length < size * 1024) return false;

            /*设置尺寸*/
            int sW, sH;
            int dHeight = imgSource.Height / 2;
            int dWidth = imgSource.Width / 2;
            Size temp_size = new Size(imgSource.Width, imgSource.Height);
            if (temp_size.Width > dHeight || temp_size.Width > dWidth)
            {
                if ((temp_size.Width * dHeight) > (temp_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * temp_size.Height) / temp_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (temp_size.Width * dHeight) / temp_size.Height;
                }
            }
            else
            {
                sW = temp_size.Width;
                sH = temp_size.Height;
            }

            /*GDI绘图*/
            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics gdi = Graphics.FromImage(ob);
            gdi.Clear(Color.WhiteSmoke);
            gdi.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gdi.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gdi.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gdi.DrawImage(imgSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0,
                imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            gdi.Dispose();

            //设置压缩质量
            long[] qy = new long[1] { flag };  //设置压缩的比例1-100
            EncoderParameters epArr = new EncoderParameters();
            epArr.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);

            /*压缩保存图片*/
            try
            {
                if (jpgEncoder != null)
                {
                    ob.Save(dFile, jpgEncoder, epArr);  //dFile是压缩后的新路径
                    FileInfo fi = new FileInfo(dFile);
                    if (fi.Length > 1024 * size)
                    {
                        flag -= 5;
                        CompressImageRec(sFile, dFile, flag, size, false);
                    }
                }
                else
                {
                    ob.Save(dFile, imgFormat);
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                imgSource.Dispose();
                ob.Dispose();
            }
        }


        public static bool CompressImage(string sFile, string dFile, int flag = 90)
        {
            Image imgSource = Image.FromFile(sFile);
            ImageFormat imgFormat = imgSource.RawFormat;

            /*设置尺寸*/
            int sW, sH;
            int dHeight = imgSource.Height / 2;
            int dWidth = imgSource.Width / 2;
            Size temp_size = new Size(imgSource.Width, imgSource.Height);
            if (temp_size.Width > dHeight || temp_size.Width > dWidth)
            {
                if ((temp_size.Width * dHeight) > (temp_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * temp_size.Height) / temp_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (temp_size.Width * dHeight) / temp_size.Height;
                }
            }
            else
            {
                sW = temp_size.Width;
                sH = temp_size.Height;
            }

            /*GDI绘图*/
            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics gdi = Graphics.FromImage(ob);
            gdi.Clear(Color.WhiteSmoke);
            gdi.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gdi.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gdi.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gdi.DrawImage(imgSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0,
                imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            gdi.Dispose();

            //设置压缩质量
            long[] qy = new long[1] { flag };  //设置压缩的比例1-100
            EncoderParameters epArr = new EncoderParameters();
            epArr.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);

            /*压缩保存图片*/
            try
            {
                if (jpgEncoder != null)
                {
                    ob.Save(dFile, jpgEncoder, epArr);  //dFile是压缩后的新路径
                }
                else
                {
                    ob.Save(dFile, imgFormat);
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                imgSource.Dispose();
                ob.Dispose();
            }
        }
    }
}

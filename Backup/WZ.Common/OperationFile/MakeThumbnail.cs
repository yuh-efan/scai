using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Common.OperationFile
{
    /// <summary>
    /// 上传缩略图
    /// </summary>
    public class MakeThumbnail
    {
        //private string OriginalImagePath;
        private string ThumbnailPath;
        private int Width;
        private int Height;
        private PFileVar.ThumPicType ThumPicMode;
        private System.IO.Stream FileLiu;
        public System.IO.Stream FileLiuNew;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pThumbnailPath">保存绝对路径</param>
        /// <param name="pWidth"></param>
        /// <param name="pHeight"></param>
        /// <param name="pThumPicMode">按比例缩放类型</param>
        /// <param name="pFileStream">图片流</param>
        public MakeThumbnail(string pThumbnailPath, int pWidth, int pHeight, PFileVar.ThumPicType pThumPicMode, System.IO.Stream pFileStream)
        {
            //this.OriginalImagePath = pOriginalImagePath;
            this.ThumbnailPath = pThumbnailPath;
            this.Width = pWidth;
            this.Height = pHeight;
            this.ThumPicMode = pThumPicMode;
            this.FileLiu = pFileStream;
        }

        public string StartMake()
        {
            string sMsg = string.Empty;
            System.Drawing.Bitmap originalImage = new System.Drawing.Bitmap(FileLiu);

            int towidth = this.Width;
            int toheight = this.Height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (ThumPicMode)
            {
                case PFileVar.ThumPicType.限制宽和高:
                    break;
                case PFileVar.ThumPicType.限制宽:
                    toheight = originalImage.Height * this.Width / originalImage.Width;
                    break;
                case PFileVar.ThumPicType.限制高:
                    towidth = originalImage.Width * this.Height / originalImage.Height;
                    break;
                case PFileVar.ThumPicType.剪切:
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * this.Height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(
                originalImage,
                new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(this.ThumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception ex)
            {
                return "MakeThumbnail Exception " + ex.Message;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }

            return sMsg;
        }
    }
}

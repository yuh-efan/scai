using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Web;
using System.Drawing.Imaging;

namespace WZ.Common.OperationFile
{
    public class MakeWatermark
    {
        private System.Drawing.Image watermark;//水印
        private string watermarkPath;//水印绝对路径
        public double topPG = -1;//上边距百分比 0:自动
        public double leftPG = -1;//左边距百分比 0:自动

        private System.IO.Stream fileStream;//被添加水印图片流

        private bool IsHasW = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pWatermarkPath">水印绝对路径</param>
        /// <param name="pFileStream">被添加水印图片流</param>
        public MakeWatermark(string pWatermarkPath, System.IO.Stream pFileStream)
        {
            this.watermarkPath = pWatermarkPath;
            this.fileStream = pFileStream;

            if (System.IO.File.Exists(this.watermarkPath))
            {
                watermark = System.Drawing.Image.FromFile(this.watermarkPath);
            }
            else
            {
                IsHasW = false;
            }
        }

        private static PixelFormat[] indexedPixelFormats = { 
                                                                PixelFormat.Undefined, 
                                                                PixelFormat.DontCare,
                                                                PixelFormat.Format16bppArgb1555, 
                                                                PixelFormat.Format1bppIndexed, 
                                                                PixelFormat.Format4bppIndexed,
                                                                PixelFormat.Format8bppIndexed
                                                           };

        private static bool IsPixelFormatIndexed(PixelFormat imgPixelFormat)
        {
            foreach (PixelFormat pf in indexedPixelFormats)
            {
                if (pf.Equals(imgPixelFormat)) 
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 生成水印
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Image GetWatermark()
        {
            System.Drawing.Image image = new System.Drawing.Bitmap(this.fileStream);

            Bitmap bmp;

            //判断是否 "无法从带有索引像素格式的图像创建 Graphics 对象"
            if (IsPixelFormatIndexed(image.PixelFormat))
            {
                bmp = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.DrawImage(image, 0, 0);
                }
            }
            else
            {
                bmp = (Bitmap)image;
            }

            if (!IsHasW)//如果水印图片不存在
                return image;

            using (watermark)
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

                    int topMargin;//上边距
                    int leftMargin;//左边距

                    if (topPG == -1)
                        topMargin = Convert.ToInt32((image.Height - watermark.Height) / 2);
                    else
                        topMargin = Convert.ToInt32(image.Height * topPG);

                    if (leftPG == -1)
                        leftMargin = Convert.ToInt32((image.Width - watermark.Width) / 2);
                    else
                        leftMargin = Convert.ToInt32(image.Width * leftPG);

                    //若右侧超出边界
                    if ((watermark.Width + leftMargin) > image.Width)
                    {
                        //放置最左侧
                        leftMargin = 0;
                    }

                    //若下面超出边界
                    if ((watermark.Height + topMargin) > image.Height)
                    {
                        if (image.Height > watermark.Height)
                        {
                            //放置最下面
                            topMargin -= (watermark.Height + topMargin) - image.Height;
                        }
                        else
                        {

                            //放置最上面
                            topMargin = 0;
                        }
                    }

                    Rectangle rect = new Rectangle(leftMargin, topMargin, watermark.Width, watermark.Height);

                    g.DrawImage(
                        watermark,
                        rect,
                        0,
                        0,
                        watermark.Width,
                        watermark.Height,
                        GraphicsUnit.Pixel
                        );

                    return bmp;
                }
            }
        }
    }
}

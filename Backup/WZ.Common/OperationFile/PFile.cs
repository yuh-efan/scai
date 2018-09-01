using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Data;

namespace WZ.Common.OperationFile
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public class PFile
    {
        #region
        private PFileVar vp;
        private string _SaveAllPath;//服务器端保存全路径
        private string _AbsolutePath;//服务器端相对路径
        private string _NewFileName;//新文件名


        private string _ReturnMessage;

        private string _SaveAllPathThum;//服务器端保存全路径 缩略图
        private string _NewFileNameThum;//新文件名 缩略图
        private string _AbsolutePathThum;//服务器端相对路径 缩略图


        /// <summary>
        /// 文件全路径
        /// </summary>
        public string SaveAllPath
        {
            get { return this._SaveAllPath; }
        }

        public string AbsolutePath
        {
            get { return this._AbsolutePath; }
        }

        public string NewFileName
        {
            get { return this._NewFileName; }
        }

        public string ReturnMessage
        {
            get { return this._ReturnMessage; }
        }

        public string SaveAllPathThum
        {
            get { return this._SaveAllPathThum; }
        }

        public string NewFileNameThum
        {
            get { return this._NewFileNameThum; }
        }

        public string AbsolutePathThum
        {
            get { return this._AbsolutePathThum; }
        }

        /// <summary>
        /// 需要保存到数据库的路径
        /// </summary>
        public string GetRelativeAllPath
        {
            get { return (vp.MidFilePath + this.NewFileName).Replace('\\', '/'); }
        }

        /// <summary>
        /// 需要保存到数据库的路径 缩略图
        /// </summary>
        public string GetRelativeAllPathThum
        {
            get { return (vp.MidFilePathThum + this.NewFileNameThum).Replace('\\', '/'); }
        }

        public PFile(PFileVar _vp)
        {
            vp = _vp;
        }
        #endregion

        #region 上传图片
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        public bool Upload_File()
        {
            if (vp.File_Upload.FileName.Length == 0)
            {
                this._ReturnMessage = "请先选择文件.";
                return false;
            }

            if (vp.File_Upload.ContentLength > vp.Size)
            {
                this._ReturnMessage = "文件大小超出 " + vp.Size / 1024 + "K 字节.";
                return false;
            }

            if (vp.File_Upload.ContentLength <= 0)
            {
                this._ReturnMessage = "没有文件.";
                return false;
            }

            string[] aTypeFile = vp.AllowFileType.Split('|');
            string type = System.IO.Path.GetExtension(vp.File_Upload.FileName).ToLower();

            if (!isArr(type, aTypeFile))
            {
                this._ReturnMessage = "该文件类型不允许上传";
                return false;
            }

            //绝对路径 
            this._AbsolutePath = HttpContext.Current.Request.MapPath(vp.PathRelative);

            //按目录存储
            vp.MidFilePath = DateTime.Now.ToString("yyMM") + "\\";

            this._AbsolutePath = System.IO.Path.Combine(this._AbsolutePath, vp.MidFilePath);

            FileCommon.IsSameFloder(this.AbsolutePath, true);//生成文件夹

            //生成文件名
            string sGuid = GetGuid();
            this._NewFileName = sGuid + type;
            this._SaveAllPath = System.IO.Path.Combine(this.AbsolutePath, this.NewFileName);// this.AbsolutePath + this.NewFileName;

            try
            {
                if (vp.PostTypeFile == PFileVar.UpType.图片)
                {
                    if (vp.IsWatermark)//上传水印
                    {
                        MakeWatermark makeW = new MakeWatermark(vp.WatermarkPath, vp.File_Upload.InputStream);
                        makeW.topPG = vp.WatermarkTopPG;
                        makeW.leftPG = vp.WatermarkLeftPG;

                        //保存水印图片
                        makeW.GetWatermark().Save(this.SaveAllPath);
                        
                        if (vp.IsSaveOld)//是否保存原图
                        {
                            //获取原图路径
                            string s1 = System.IO.Path.Combine(vp.SaveOldPathPrefix + vp.PathRelative, vp.MidFilePath);
                            s1 = HttpContext.Current.Request.MapPath(s1);

                            FileCommon.IsSameFloder(s1, true);//生成文件夹
                            s1 = System.IO.Path.Combine(s1, this.NewFileName);

                            vp.File_Upload.SaveAs(s1);
                        }
                    }
                    else
                    {
                        //保存
                        vp.File_Upload.SaveAs(this.SaveAllPath);
                    }
                }
                else
                {
                    //保存
                    vp.File_Upload.SaveAs(this.SaveAllPath);
                }
            }
            catch (Exception ex)
            {
                this._ReturnMessage = ex.Message;
                return false;
            }

            //try
            //{
                //上传缩略图
                if (vp.IsThumbnail && vp.PostTypeFile == PFileVar.UpType.图片)
                {
                    vp.MidFilePathThum = vp.MidFilePath;//暂时保留
                    this._AbsolutePathThum = this._AbsolutePath;
                    FileCommon.IsSameFloder(this.AbsolutePathThum, true);

                    this._NewFileNameThum = sGuid + "_s" + type;

                    this._SaveAllPathThum = System.IO.Path.Combine(this.AbsolutePathThum, this.NewFileNameThum);

                    System.IO.Stream imgStream = new System.IO.MemoryStream();
                    if (vp.IsWatermarkThum)
                    {
                        MakeWatermark makeW = new MakeWatermark(vp.WatermarkPathThum, vp.File_Upload.InputStream);
                        makeW.topPG = vp.WatermarkTopPG;
                        makeW.leftPG = vp.WatermarkLeftPG;

                        //保存水印图片
                        System.Drawing.Image img = makeW.GetWatermark();
                        img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    else
                    {
                        imgStream = vp.File_Upload.InputStream;
                    }
                   

                    MakeThumbnail mt = new MakeThumbnail(this._SaveAllPathThum, vp.ThumbnailWith, vp.ThumbnailHight, vp.XLType, imgStream);

                    this._ReturnMessage = mt.StartMake();
                    if (this._ReturnMessage.Length > 0)
                        return false;
                }
            //}
            //catch (Exception ex)
            //{
            //    this._ReturnMessage = "PFile Exception " + ex.Message;
            //    return false;
            //}

            this._ReturnMessage = "上传成功";
            return true;
        }
        #endregion

        private string GetGuid()
        {
            string s = Guid.NewGuid().ToString();
            return s.Substring(0, 8) + s.Substring(24, 12);
        }

        /// <summary>
        /// 判断某字符是否在某数据里
        /// </summary>
        /// <param name="str1">判断字符串</param>
        /// <param name="arr1">数组</param>
        /// <returns></returns>
        public bool isArr(string str1, string[] arr1)
        {
            if (arr1.Length > 0)
            {
                if (arr1[0] == "*")
                    return true;
            }
            else
                return false;

            bool b = false;
            foreach (string s in arr1)
            {
                if (s == str1)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }


    }
}

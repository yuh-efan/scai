using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Common.OperationFile
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public class PFileVar
    {
        /// <summary>
        /// 文件格式
        /// </summary>
        public enum UpType
        {
            图片,
            文件
        }

        /// <summary>
        /// 上传图片指定按哪种类型上传
        /// </summary>
        public enum ThumPicType
        {
            限制宽和高,
            限制高,
            限制宽,
            剪切
        }

        public string PathRelative = "/pf/current/";//默认 相对上传目录 如../upFile/
        public string MidFilePath = string.Empty;//文件上传目录 (即/upFile/0909/中的/0909/目录)
        public UpType PostTypeFile = UpType.图片;//默认 上传类型 如图片,或办公文件
        public decimal Size = 500000;//默认 上传图片的大小

        public string AllowFileType = ".jpg|.gif|.bmp|.png|.jpeg";//允许上传的类型
        public HttpPostedFile File_Upload = null;

        public string return_file_name = string.Empty;//上传后返回的图片名称
        public string ReturnMessage = string.Empty;//上传后返回的提示信息

        public string WatermarkPath;//水印路路径
        public bool IsWatermark=false;//是否生成水印
        public double WatermarkTopPG = -1;//水印上边距百分比
        public double WatermarkLeftPG = -1;//水印下边距百分比

        public string SaveOldPathPrefix = string.Empty;//原图保存前缀
        public bool IsSaveOld = false;//是否保存原图

        public string WatermarkPathThum;//水印路路径 预览图
        public bool IsWatermarkThum = false;//是否生成水印 预览图
        public string SaveOldPathPrefixThum = string.Empty;//原图保存前缀 预览图
        public bool IsSaveOldThum = false;//是否保存原图 预览图

        #region 生成预览图
        public string MidFilePathThum = string.Empty;//文件上传目录 (即/upFile/0909/中的/0909/目录)

        public bool IsThumbnail = false;
        public int ThumbnailWith = 100;//预览图 宽
        public int ThumbnailHight = 100;//预览图 高
        public ThumPicType XLType = ThumPicType.限制宽和高;

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Data;

namespace WZ.Common.OperationFile
{
    /// <summary>
    /// 文件基本操作
    /// </summary>
    public class FileCommon
    {
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="pPath">相对路径如:/pic/a.jpg</param>
        public static void Delete(string pPath)
        {
            if (pPath.Length > 0)
            {
                pPath = HttpContext.Current.Request.MapPath(pPath);
                if (System.IO.File.Exists(pPath))
                    System.IO.File.Delete(pPath);
            }
        }

        /// <summary>
        /// 删除目录,包括子目录及文件
        /// </summary>
        /// <param name="pPath">相对路径如:/pic/a.jpg</param>
        public static void DeleteFolder(string pPath)
        {
            if (pPath.Length > 0)
            {
                pPath = HttpContext.Current.Server.MapPath(pPath);
                if (System.IO.Directory.Exists(pPath))
                    System.IO.Directory.Delete(pPath, true);
            }

        }

        /// <summary>
        /// 判断文件夹是否存在
        /// </summary>
        /// <param name="pAbsolutePath">绝对路径</param>
        /// <param name="pB">文件夹不存在时,是否创建 True:创建</param>
        /// <returns>bool</returns>
        public static bool IsSameFloder(string pAbsolutePath, bool pB)
        {
            bool b = System.IO.Directory.Exists(pAbsolutePath);
            if (pB && !b)//不存在文夹时是否创建文件夹
                System.IO.Directory.CreateDirectory(pAbsolutePath);//创建文件夹
            return b;
        }

        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="pAbsolutePath">绝对路径</param>
        /// <param name="fm">FileMode</param>
        /// <param name="fa">FileAccess</param>
        /// <returns>返回文件中的内容</returns>
        public static string ReadFile(string pAbsolutePath, FileMode fm, FileAccess fa)
        {
            FileStream fs = new FileStream(pAbsolutePath, fm, fa);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadToEnd();

            sr.Close();
            sr.Dispose();

            fs.Close();
            fs.Dispose();

            return str;
        }

        /// <summary>
        /// 删除原图片 修改时
        /// </summary>
        /// <param name="pOldPic"></param>
        /// <param name="pNewPic"></param>
        /// <param name="pPath"></param>
        public static void DeleteOldPic(string pOldPic, string pNewPic, string pPath)
        {
            if (pOldPic.Length > 0)
            {
                if (pOldPic != pNewPic)
                {
                    Delete(pPath + pOldPic);
                }
            }
        }

        /// <summary>
        /// 从数据库删除原图片 修改时
        /// </summary>
        /// <param name="pSql">sql 一个图片字段</param>
        /// <param name="pNewPic">新图片名称</param>
        /// <param name="pPath">相对路径 /uploadfile/ </param>
        public static void DeletePicData(string pSql, string pNewPic, string pPath)
        {
            string sOldPic = DbHelp.First(pSql, "-1");
            sOldPic = DbHelp.First(pSql, "-1");
            if (pNewPic != sOldPic)
                Delete(pPath + sOldPic);
        }

        /// <summary>
        /// 列表页删除图片时
        /// </summary>
        /// <param name="pSql">sql 词句 第一个字段为图片字段名</param>
        /// <param name="pPath">相对路径 /abc/</param>
        public static void DeletePicDataList(string pSql, string pPath)
        {
            using (IDataReader dr = DbHelp.Read(pSql))
            {
                while (dr.Read())
                    Delete(pPath + dr[0].ToString());

                dr.Close();
            }
        }

        /// <summary>
        /// 判断服务器上是否有重复文件,如有,则改变图片文件名
        /// </summary>
        /// <param name="cf_path">绝对路径</param>
        /// <param name="cf_file_name">文件名</param>
        /// <returns>返回文件名</returns>
        public static string IsSameFileName(string cf_path, string cf_file_name)
        {
            string all_path_name = cf_path + cf_file_name;//全名

            string tempfileName = string.Empty;
            if (System.IO.File.Exists(all_path_name))
            {
                int counter = 2;
                while (System.IO.File.Exists(all_path_name))
                {
                    tempfileName = counter.ToString() + cf_file_name;
                    all_path_name = cf_path + tempfileName;
                    counter++;
                }
            }
            else
            {
                tempfileName = cf_file_name;
            }

            return tempfileName;
        }
    }
}

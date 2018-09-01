using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using System.Reflection;
using Newtonsoft.Json;
using System.Web;
using WZ.Common.ICommon;

namespace WZ.Data
{
    /// <summary>
    /// 增,删,改
    /// </summary>
    public class SqlData
    {
        #region 添加单条记录
        /// <summary>
        /// 添加单条记录
        /// </summary>
        /// <param name="pMod"></param>
        /// <param name="pFields"></param>
        /// <returns></returns>
        public static bool Add(object pMod, string pFields)
        {
            string tableName = GetTableName(pMod);

            if (pFields == null || pFields.Length == 0)
                throw new Exception("字段 " + pFields + " 不能为空");

            string[] aFields = pFields.Split(',');
            int arrN = aFields.Length;

            IDataParameter[] aDp = DbHelp.Def.GetArrParam(arrN);

            string str = string.Empty;
            string str1 = string.Empty;
            string s;
            for (int i = 0; i < arrN; i++)
            {
                s = aFields[i];

                str += s + ",";
                str1 += "@" + s + ",";

                aDp[i] = DbHelp.Def.AddParam("@" + s, GetModelFieldValue(s, pMod));
            }

            str = str.TrimEnd(',');
            str1 = str1.TrimEnd(',');
            string sSQL = "insert into  " + tableName + "(" + str + ") values(" + str1 + ")";

            return DbHelp.Update(sSQL, aDp) > 0;
        }
        #endregion

        #region 添加单条记录并返回ID
        /// <summary>
        /// 添加单条记录并返回ID
        /// </summary>
        /// <param name="pMod"></param>
        /// <param name="pFields"></param>
        /// <returns></returns>
        public static int AddReturnID(object pMod, string pFields)
        {
            string tableName = GetTableName(pMod);

            if (pFields == null || pFields.Length == 0)
                throw new Exception("字段 " + pFields + " 不能为空");

            string[] aFields = pFields.Split(',');
            int arrN = aFields.Length;

            IDataParameter[] aDp = DbHelp.Def.GetArrParam(arrN);

            string str = string.Empty;
            string str1 = string.Empty;
            string s;
            for (int i = 0; i < arrN; i++)
            {
                s = aFields[i];

                str += s + ",";
                str1 += "@" + s + ",";

                aDp[i] = DbHelp.Def.AddParam("@" + s, GetModelFieldValue(s, pMod));
            }

            str = str.TrimEnd(',');
            str1 = str1.TrimEnd(',');
            string sSQL = "insert into  " + tableName + "(" + str + ") values(" + str1 + ");select SCOPE_IDENTITY()";

            return Convert.ToInt32(DbHelp.Scalar(sSQL, aDp));
        }
        #endregion

        #region 修改单条记录
        /// <summary>
        /// 修改单条记录
        /// </summary>
        /// <param name="pMod"></param>
        /// <param name="pFields"></param>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public static bool Edit(object pMod, string pFields, string pWhere)
        {
            string tableName = GetTableName(pMod);
            if (pMod == null)
                throw new Exception("IModel对象 不能为null");

            if (pFields == null || pFields.Length == 0)
                throw new Exception("字段不能为空");

            if (pWhere == null || pWhere.Length == 0)
                throw new Exception("where 条件不能为空");

            string[] aFields = pFields.Split(',');
            int arrN = aFields.Length;

            IDataParameter[] aDp = DbHelp.Def.GetArrParam(arrN);

            string str = string.Empty;
            string s;
            for (int i = 0; i < arrN; i++)
            {
                s = aFields[i];

                str += s + "=" + "@" + s + ",";

                aDp[i] = DbHelp.Def.AddParam("@" + s, GetModelFieldValue(s, pMod));
            }

            str = str.TrimEnd(',');
            string sSQL = "update  " + tableName + " set " + str + " where " + pWhere;

            return DbHelp.Update(sSQL, aDp) > 0;
        }
        #endregion

        #region 获取表名
        public static string GetTableName(object pObj)
        {
            string s = pObj.GetType().Name;
            s = s.Substring(0, s.Length - 1);
            return s;
        }
        #endregion

        #region 获取对象属性值
        /// <summary>
        /// 获取对象属性值
        /// </summary>
        /// <param name="pFieldName"></param>
        /// <param name="pMod"></param>
        /// <returns></returns>
        public static object GetModelFieldValue(string pFieldName, object pMod)
        {
            string tableName = GetTableName(pMod);
            Type type = pMod.GetType();
            PropertyInfo[] arrPi = type.GetProperties();
            bool b = true;
            object o = string.Empty;
            foreach (PropertyInfo pi in arrPi)
            {
                //判断字段时不区分大小写
                if (string.Compare(pi.Name, pFieldName, true) == 0)
                {
                    o = pi.GetValue(pMod, null);

                    if (o == null)
                        throw new Exception("系统异常提示:字段 " + pi.Name + " 不能为null,是否 " + tableName + "M." + pi.Name + " 未赋值 ?");

                    b = false;
                    break;
                }
            }
            //提前提示错误信息,不必连接数据后再自动系统提示错误
            if (b)
            {
                throw new Exception("系统异常提示:字段中的 " + pFieldName + " 在 Model 中不存在,是否输写错误,若不是请检查 数据库表" + tableName + " 与 " + tableName + "M 的字段是否保持一致 ?");
            }

            return o;
        }
        #endregion

        #region 删除多条
        /// <summary>
        /// 删除多条 复选框名为IsSel
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pPKName">主键字段名(根据此字段删除记录)</param>
        public static int DeleteMore(string pTableName, string pPKName)
        {
            IMessage MessageG = new MessageGeneral();

            string sArrStr = Req.GetForm("IsSel");

            if (!Fn.IsIntArrBool(sArrStr))
                MessageG.Error("请选择要删除的记录.");

            string sSQL = "delete from " + pTableName + " where " + pPKName + " in(" + sArrStr + ")";
            return DbHelp.Update(sSQL);

            //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        public static int DeleteMore(string pTableName, string pPKName, string pHtmlID)
        {
            IMessage MessageG = new MessageGeneral();

            string sArrStr = Req.GetForm(pHtmlID);

            if (!Fn.IsIntArrBool(sArrStr))
                MessageG.Error("请选择要删除的记录.");

            string sSQL = "delete from " + pTableName + " where " + pPKName + " in(" + sArrStr + ")";
            return DbHelp.Update(sSQL);

            //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// 删除多条(包括删除文件) 复选框名为IsSel
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pPKName">主键字段名(根据此字段删除记录)</param>
        /// <param name="pDeleteFields">文件字段名 一条记录需要删除多个文件 用字段名并逗号隔开 如 PicS,PicB</param>
        /// <param name="pPathFormat">文件相对路径 如 /upload_file/pic/ 必需以/开始 以/结束</param>
        public static int DeleteMore(string pTableName, string pPKName, string pDeleteFields, string pPathFormat)
        {
            IMessage MessageG = new MessageGeneral();
            string[] aSel = pDeleteFields.Split(',');
            int aSelN = aSel.Length;

            string sArrStr = Req.GetForm("IsSel");

            if (!Fn.IsIntArrBool(sArrStr))
                MessageG.Error("请选择要删除的记录.");

            string sSQL = "select " + pDeleteFields + " from " + pTableName + " where " + pPKName + " in(" + sArrStr + ")";
            DataTable dt = DbHelp.GetDataTable(sSQL);

            foreach (DataRow drw in dt.Rows)
            {
                foreach (string s in aSel)
                {
                    WZ.Common.OperationFile.FileCommon.Delete(string.Format(pPathFormat, drw[s]));
                }
            }

            sSQL = "delete from " + pTableName + " where " + pPKName + " in(" + sArrStr + ")";

            return DbHelp.Update(sSQL);
            //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
        #endregion

        #region 删除单条
        /// <summary>
        /// 删除单条
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pPKName">主键字段名(根据此字段删除记录)</param>
        /// <param name="pID">要删除的对应主键值</param>
        public static int Delete(string pTableName, string pPKName, int pID)
        {
            string sSQL = "delete from " + pTableName + " where " + pPKName + "=" + pID;
            return DbHelp.Update(sSQL);
            //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// 删除单条(包括删除文件)
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pPKName">主键字段名(根据此字段删除记录)</param>
        /// <param name="pDeleteFields">文件字段名 一条记录需要删除多个文件 用字段名并逗号隔开 如 PicS,PicB</param>
        /// <param name="pPathFormat">文件相对路径 如 /upload_file/pic/ 必需以/开始 以/结束</param>
        /// <param name="pID">要删除的对应主键值</param>
        public static int Delete(string pTableName, string pPKName, string pDeleteFields, string pPathFormat, int pID)
        {
            string[] aSel = pDeleteFields.Split(',');
            int aSelN = aSel.Length;

            string sSQL = "select " + pDeleteFields + " from " + pTableName + " where " + pPKName + "=" + pID;
            DataTable dt = DbHelp.GetDataTable(sSQL);

            foreach (DataRow drw in dt.Rows)
            {
                foreach (string s in aSel)
                {
                    WZ.Common.OperationFile.FileCommon.Delete(string.Format(pPathFormat, drw[s]));
                }
            }

            sSQL = "delete from " + pTableName + " where " + pPKName + "=" + pID;
            return DbHelp.Update(sSQL);
            //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
        #endregion
    }
}

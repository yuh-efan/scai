using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;
using WZ.Common.CacheData;
using System.Data;
using System.Web;
using WZ.Common.ICommon;

namespace WZ.Data
{
    public class FnData
    {
        #region 某字段最大值+1
        /// <summary>
        /// 某字段最大值+1
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pFieldID">字段名</param>
        /// <returns></returns>
        public static int GetAddRowID(string pTableName, string pFieldID)
        {
            return Convert.ToInt32(DbHelp.First("select max(" + pFieldID + ")+1 from " + pTableName, "1"));
        }

        /// <summary>
        /// 某字段最大值+1
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pFieldID">字段名</param>
        /// <param name="pWhere">where条件</param>
        /// <returns></returns>
        public static int GetAddRowID(string pTableName, string pFieldID, string pWhere)
        {
            return Convert.ToInt32(DbHelp.First("select max(" + pFieldID + ")+1 from " + pTableName + " " + pWhere, "1"));
        }
        #endregion

        #region 获取表中某字段具有相同值的记录数
        /// <summary>
        /// 获取表中某字段具有相同值的记录数
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pFieldName">字段名</param>
        /// <param name="pFieldValue">字段值</param>
        /// <returns></returns>
        public static int GetSameFieldN(string pTableName, string pFieldName, object pFieldValue)
        {
            string sSQL = "select count(0) from " + pTableName + " where " + pFieldName + "=@" + pFieldName;
            IDataParameter[] dp = { 
                                      DbHelp.Def.AddParam("@"+pFieldName, pFieldValue)
                                  };
            return Convert.ToInt32(DbHelp.Scalar(sSQL, dp));
        }
        #endregion

        #region 获取表中某字段具有相同值的记录数 具有排功能
        /// <summary>
        /// 获取表中某字段具有相同值的记录数 
        /// 具有排功能
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pFieldName">字段名</param>
        /// <param name="pFieldValue">字段值</param>
        /// <param name="pAndWhere">可以指定增加where语句,如 id>2</param>
        /// <returns></returns>
        public static int GetSameFieldN(string pTableName, string pFieldName, object pFieldValue, string pAndWhere)
        {
            string sSQL = "select count(0) from " + pTableName + " where " + pFieldName + "=@" + pFieldName + " and " + pAndWhere;
            IDataParameter[] dp = { 
                                      DbHelp.Def.AddParam("@"+pFieldName, pFieldValue)
                                  };
            return Convert.ToInt32(DbHelp.Scalar(sSQL, dp));
        }
        #endregion

        #region 通过索引号 获取表字段名
        /// <summary>
        /// 通过索引号 获取表字段名
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pIndex">字段索引</param>
        /// <returns></returns>
        public static string GetTableFieldName(string pTableName, int pIndex)
        {
            DataTable dt = DbHelp.GetDataTable("select top 1 * from " + pTableName);
            return dt.Columns[pIndex].ColumnName;
        }
        #endregion

        #region 通过字段名 获取索引号
        /// <summary>
        /// 通过字段名 获取索引号
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pFieldName">字段名</param>
        /// <returns></returns>
        public static int GetTableFieldIndex(string pTableName, string pFieldName)
        {
            DataTable dt = DbHelp.GetDataTable("select top 1 * from " + pTableName);
            return GetTableFieldIndex(dt, pFieldName);
        }

        /// <summary>
        /// 通过字段名 获取索引号
        /// </summary>
        /// <param name="pDt">DataTable</param>
        /// <param name="pFieldName">字段名</param>
        /// <returns></returns>
        public static int GetTableFieldIndex(DataTable pDt, string pFieldName)
        {
            int i = 0;
            foreach (DataColumn s in pDt.Columns)
            {
                if (string.Compare(s.ColumnName, pFieldName, true) == 0)
                    break;
                i++;
            }
            return i;
        }
        #endregion

        #region 新闻相关
        /// <summary>
        /// 获取新闻前缀图片
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static string GetNewsImg(object pObj)
        {
            string str = string.Empty;
            DataRowView drv = (DataRowView)pObj;
            int iItem = Fn.IsInt(drv["Item"].ToString(), 0);
            if ((iItem & 16) == 16)//活动
                str = "3";
            else
                str = "1";

            return str;
        }

        public static string GetNewsImg(DataRow drw)
        {
            string str = string.Empty;
            int iItem = Fn.IsInt(drw["Item"].ToString(), 0);
            if ((iItem & 16) == 16)//活动
                str = "3";
            else
                str = "1";

            return str;
        }

        /// <summary>
        /// 获取新闻标题
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static string GetNewsTitle(object pObj)
        {
            DataRowView drv = (DataRowView)pObj;
            string title = drv["Title1"].ToString();
            if (title.Length == 0)
                title = drv["Title"].ToString();

            return title;
        }

        public static string GetNewsTitle(DataRow drw)
        {
            string title = drw["Title1"].ToString();
            if (title.Length == 0)
                title = drw["Title"].ToString();

            return title;
        }
        #endregion

        #region 获取商家名称
        /// <summary>
        /// 获取商家名称
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public static object GetJoinName(int pID)
        {
            return Fn.GetDataTableFind(PubData.GetDataTable("join_info"), pID, "JoinName");
        }
        #endregion

        #region 设置历史记录cookie
        /// <summary>
        /// 设置历史记录cookie
        /// </summary>
        /// <param name="cookName"></param>
        /// <param name="id"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string SetHistory(string cookName, int id, int max)
        {
            HistoryData hd = new HistoryData(cookName, max);
            return hd.Add(id);
        }
        #endregion
    }
}

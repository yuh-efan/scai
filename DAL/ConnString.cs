using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace WZ.Common
{
    /// <summary>
    /// 数据库链接字符串
    /// </summary>
    public class ConnString
    {
        #region OleDb
        /// <summary>
        /// OleDb
        /// </summary>
        //public static readonly string DefaultStr = ConfigurationManager.ConnectionStrings["OleDbPath"].ConnectionString +
        //System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["OleDbName"].ConnectionString);
        #endregion

        #region OleDb
        /// <summary>
        /// OleDb链接sql server数据库
        /// </summary>
        //public static readonly string Access = ConfigurationManager.ConnectionStrings["Access"].ConnectionString;

        //public static readonly string Access = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source="
        //  + System.Web.HttpContext.Current.Request.MapPath(ConfigurationManager.ConnectionStrings["Access"].ConnectionString);
        #endregion

        #region SqlServer
        /// <summary>
        /// SqlServer
        /// </summary>
        public static readonly string SqlServer = string.Format(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString, GetStr("dbUserName"), GetStr("dbUserPwd"));
        #endregion

        private static string GetStr(string pStr)
        { 
            return DESEncrypt_DbHelp.Decrypt(DESEncrypt_DbHelp.Decrypt(ConfigurationManager.AppSettings[pStr]));
        }
    }
}

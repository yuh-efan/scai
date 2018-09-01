using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Data
{
    public class PubSQL
    {
        /// <summary>
        /// 管理员与功能关联 判断管理员是否有此功能需要自定义 
        /// 如(找出有此功能的所有管理员): select * from A_Admin_User au where PubSQL.HasFun_InAdmin('功能标识符')
        /// </summary>
        /// <param name="arrSoleIdentifier"></param>
        /// <param name="pAdminID"></param>
        /// <returns></returns>
        public static string HasFun_InAdmin(string[] arrSoleIdentifier)
        {
            if (arrSoleIdentifier == null || arrSoleIdentifier.Length == 0)
            {
                return null;
            }

            string str = string.Empty;
            int n = arrSoleIdentifier.Length;

            foreach (string s in arrSoleIdentifier)
            {
                str += "'" + s + "',";
            }
            str = str.TrimEnd(',');

            string sql = "(select count(0) from"
    + "("
        + "select 1 as static1"
        + " from A_Group__Fun "
        + " where FK_A_Fun__SoleIdentifier in (" + str + ") and FK_A_Group__SoleIdentifier in "
        + "("
            + " select FK_A_Group__SoleIdentifier from A_Admin_User__Group where FK_A_Admin_User=au.au_ID"
        + ")"
        + " group by FK_A_Fun__SoleIdentifier"
    + ") hasCou)"
    + "=" + n;
            return sql;
        }

        public static string HasFun_InAdmin(string pSoleIdentifier)
        {
            return HasFun_InAdmin(new string[] { pSoleIdentifier });
        }

        /// <summary>
        /// 是否有此区域权限
        /// </summary>
        /// <param name="pAreaID"></param>
        /// <returns></returns>
        public static string HasArea_InAdmin(int pAreaID)
        {
            string sql = "exists (select top 1 1 from A_Admin_User__Pub_Area where FK_Pub_Area=" + pAreaID + " and FK_A_Admin_User=au.au_ID)";
            return sql;
        }

        /// <summary>
        /// 是否有此产品分类权限
        /// </summary>
        /// <param name="pClassID"></param>
        /// <returns></returns>
        public static string HasPro_Class_InAdmin(int pClassID)
        {
            string sql = "exists (select top 1 1 from A_Admin_User__Pro_Class where FK_Pro_Class=" + pClassID + " and FK_A_Admin_User=au.au_ID)";
            return sql;
        }
    }
}

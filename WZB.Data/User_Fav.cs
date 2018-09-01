using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using WZ.Model;

namespace WZ.Client.Data
{
    public class User_Fav
    {
        #region 列表
        //列表
        //public static Paging List(int pUserId)
        //{
        //    string sOrder = " order by a.AddDate desc";
        //    string sWhere = " where a.FK_User=" + pUserId;

        //    PagingVar pv = new PagingVar();
        //    pv.SQLCount = "select count(0) from User_Fav a" + sWhere;
        //    pv.SQLRead = "select FavSN from User_Fav a" + sWhere + sOrder;
        //    pv.SQL = "select FavSN,FK_All,FK_User,ProName,Price,PicS,Item,a.AddDate from User_Fav a left join Pro_Info b on a.FK_All=b.ProSN where FavSN in({0})" + sOrder;

        //    Paging pg = new Paging(pv, new PagingUrlVar(10));
        //    pg.load();
        //    return pg;
        //}

        //列表
        //public static DataTable List(int pUserID)
        //{
        //    string sSQL = "select FavSN,FK_All,FK_User,ProName,Price,PicS,Item from User_Fav left join Pro_Info on User_Fav.FK_All=Pro_Info.ProSN where FK_User=" + pUserID + " order by AddDate desc";

        //    return DbHelp.GetDataTable(sSQL);
        //}
        #endregion

        #region 添加
        public static bool Add(User_FavM pMod)
        {
            string sSQL = "insert into User_Fav(FK_All,FK_User,InfoType) values(@FK_All,@FK_User,@InfoType)";

            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@FK_All",pMod.FK_All),
                                DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
                                DbHelp.Def.AddParam("@InfoType",pMod.InfoType),
                                  };
            return (DbHelp.Update(sSQL, dp) > 0);
        }
        #endregion

        #region 删除
        //删除
        public static bool Delelte(int pID, int pUserID)
        {
            string sSQL = "delete from User_Fav where FK_User=" + pUserID + " and FavSN = " + pID;
            return (DbHelp.Update(sSQL) > 0);
        }
        #endregion

        #region 清空
        //清空
        public static bool DeleteAll(int pUserID)
        {
            string sSQL = "delete from User_Fav where FK_User=" + pUserID;
            return (Convert.ToInt32(DbHelp.Update(sSQL)) > 0);
        }
        #endregion

        #region 添加 单个产品
        /// <summary>
        /// 添加到购物车 单个产品
        /// </summary>
        /// <param name="pUserID">用户ID</param>
        /// <param name="pID">产品ID</param>
        /// <returns></returns>
        public static string Add(int pUserID, int pID, byte pType, int pMaxN)
        {
            string sMsg = string.Empty;
            string sSql = "select FK_All,InfoType from User_Fav where FK_User=" + pUserID;
            DataTable dt = DbHelp.GetDataTable(sSql);

            //int cou = int.Parse(DbHelp.Scalar(sSql).ToString());

            if (dt.Rows.Count >= pMaxN)
            {
                sMsg = "商品收藏最多 " + pMaxN + " 个";
                return sMsg;
            }

            foreach(DataRow drw in dt.Rows)
            {
                if (int.Parse(drw["FK_All"].ToString()) == pID && byte.Parse(drw["InfoType"].ToString())==pType)
                    return sMsg;
            }

            User_FavM mod = new User_FavM
            {
                FK_User = pUserID,
                FK_All = pID,
                InfoType = pType,
            };

            Add(mod);

            return sMsg;
        }
        #endregion

        #region 添加到购物车 多个产品
        /// <summary>
        /// 添加到购物车 多个产品
        /// </summary>
        /// <param name="pS">产品id数组</param>
        public static string Add(int pUserID, string pS, byte pType, int pMax)
        {
            string str = pS;
            //若无 参数 s
            if (str.Length == 0)
                return "请先选择商品";

            string sMsg = string.Empty;
            string[] arr_str = str.Split(',');
            foreach (string s in arr_str)
            {
                //若不是数字
                if (!Fn.IsIntBool(s))
                    continue;

                int pid = Convert.ToInt32(s);
                sMsg = Add(pUserID, pid, pType, pMax);
                if (sMsg.Length > 0)
                    break;
            }

            return sMsg;
        }
        #endregion
    }
}

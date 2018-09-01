using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;

namespace WZ.Data
{
    public class User_CartL
    {
        #region help
        protected IDbHelp curHelp;

        public User_CartL()
        {
            this.curHelp = new DefaultHelp();
        }

        public User_CartL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        #region 清空购物车
        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="pUserID"></param>
        /// <returns></returns>
        public bool DeleteAll(int pUserID)
        {
            string sSQL = "delete from User_Cart where FK_User=" + pUserID;
            return curHelp.Update(sSQL) > 0;
        }
        #endregion

        #region 根据不同类型产品进行拆分
        /// <summary>
        /// 根据不同类型产品进行拆分 
        /// 必须字段 CartType
        /// </summary>
        /// <param name="pDt"></param>
        /// <returns></returns>
        public static Dictionary<string, DataTable> GetPro_SplitType(DataTable pDt)
        {
            DataTable dtPro = pDt.Clone();
            DataTable dtGift = pDt.Clone();
            foreach (DataRow drw in pDt.Rows)
            {
                switch (drw["CartType"].ToString())
                {
                    case "0"://产品
                        dtPro.Rows.Add(drw);
                        //dt.ImportRow(drw);
                        break;

                    case "1"://礼品
                        dtGift.Rows.Add(drw);
                        break;
                }
            }

            Dictionary<string, DataTable> dict = new Dictionary<string, DataTable>();
            dict.Add("pro",dtPro);
            dict.Add("gift",dtGift);
            return dict;
        }
        #endregion
    }
}
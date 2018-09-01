using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using WZ.Common.Config;

namespace WZ.Client.Data
{
    public class Pro_Info
    {
        #region help
        protected IDbHelp curHelp;

        public Pro_Info()
        {
            this.curHelp = new DefaultHelp();
        }

        public Pro_Info(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        /// <summary>
        /// 设置产品库存 DataTable需要Num,FK_All
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="operating"></param>
        /// <returns></returns>
        //public void SetProStock(DataTable dt, string operating)
        //{
        //    switch (operating)
        //    {
        //        case "+":
        //            break;
        //        case "-":
        //            break;
        //        default:
        //            return;
        //    }

        //    foreach (DataRow drw in dt.Rows)
        //    {
        //        string sql = "update Pro_Info set StockN=StockN" + operating + drw["Num"] + " where ProSN=" + drw["FK_All"];
        //        curHelp.Update(sql);
        //    }
        //}

        //public static IDataReader GetPro(int proId)
        //{
        //    string sql = "select FK_Pro_Class,FK_Join,ProName,Number,PicS,PicB,Price,PriceMarket,PriceCost,Unit,StockN,SellN,SellN1,hit,Detail,AddDate,EditDate,ProIsHas,Item from vgPro_Info where ProSN=" + proId;
        //    return DbHelp.Read(sql);
        //}

        public static double GetProPrice(object pObj, string pReturnPrice)
        {
            DataRowView drv = (DataRowView)pObj;
            int item = int.Parse(drv["Item"].ToString());

            if (((item & 4) == 4) || ((item & 16) == 16))
                return double.Parse(drv["Price1"].ToString());

            return double.Parse(drv[pReturnPrice].ToString());
        }

        /// <summary>
        /// 是否是促销,秒杀 中的其中一种
        /// </summary>
        /// <param name="pItem">状态值 Item</param>
        /// <returns></returns>
        //public static bool IsItem1(int pItem)
        //{
        //    return (((pItem & 4) == 4) || ((pItem & 16) == 16));
        //}

        

       
    }
}
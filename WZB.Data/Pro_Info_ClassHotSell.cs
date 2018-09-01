using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using WZ.Common.CacheData;

namespace WZ.Client.Data
{
    /// <summary>
    /// 商品分类热销排行
    /// </summary>
    public class Pro_Info_ClassHotSell : ABSDataTableCache
    {
        private DateTime time;
        private int classID;

        /// <summary>
        /// 商品分类热销排行
        /// </summary>
        /// <param name="pKeyName">缓存名</param>
        /// <param name="pTime">时间</param>
        public Pro_Info_ClassHotSell(string pKeyName,int pClassID, DateTime pTime)
            : base(pKeyName + pClassID)
        {
            this.time = pTime;
            this.classID = pClassID;
        }

        /// <summary>
        /// 此方法由 DbCache 调用
        /// </summary>
        /// <returns></returns>
        public override DataTable GetDataTable()
        {
            string sSQL = "select cou,FK_Pro as ProSN,ProName,PicS,Price from (select top 10 sum(SellN) as cou,FK_Pro from Log_ProSell where AddDate>=@AddDate group by FK_Pro) p1 left join Pro_info p2 on p1.FK_Pro=p2.ProSN where p2.FK_Pro_Class=" + classID + " order by cou desc";

            IDataParameter[] dp = {
                                  DbHelp.Def.AddParam("@AddDate",this.time),
                                  };
            return DbHelp.GetDataTable(sSQL, dp);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WZ.Model;
using System.Data;
using WZ.Common;

namespace WZ.Client.Data
{
    public class Ord_Pro
    {
        public static DataTable List(int pOrdID)
        {
            // op left join Pro_Info pi on op.FK_All=pi.ProSN
            string sql = "select op_ID,FK_Pro,op_UserPrice,op_UserTotalPrice,op_ProName,op_ProNumber,op_ProUnit,op_ProUnitNum,op_Num from Ord_Pro where FK_Order=" + pOrdID;
            DataTable dt = DbHelp.GetDataTable(sql);
            return dt;
            
        }
    }
}

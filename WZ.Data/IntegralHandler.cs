using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;

namespace WZ.Data
{
    public class IntegralHandler
    {
        private DataTable proDt;

        public IntegralHandler(DataTable pProDt)
        {
            this.proDt = pProDt;
        }

        public Dictionary<int, DataTable> Change()
        {
            Type T_Int = Type.GetType("System.Int32");

            this.proDt.Columns.Add(new DataColumn("dt_UserIntegral", T_Int));//用户实际积分
            this.proDt.Columns.Add(new DataColumn("dt_TotalIntegral", T_Int));//用户小计

            double num;
            int Integral;
            int smallTotal;//列的小计

            int total = 0;

            foreach (DataRow drw in this.proDt.Rows)
            {
                string proID = drw["GiftSN"].ToString();

                //若id不合法
                if (Fn.IsInt(proID, 0) <= 0)
                    continue;

                Integral = int.Parse(drw["Integral"].ToString());
                drw["dt_UserIntegral"] = Integral;
                num = double.Parse(drw["Num"].ToString());

                smallTotal = Convert.ToInt32(Integral * num);//小计
                drw["dt_TotalIntegral"] = smallTotal;
                total += smallTotal;//总计
            }

            #region 总的统计
            //总的统计
            DataTable dtTotal = new DataTable();
            dtTotal.Columns.Add(new DataColumn("TotalIntegral", T_Int));

            DataRow drwTotal = dtTotal.NewRow();
            drwTotal[0] = total;
            dtTotal.Rows.Add(drwTotal);
            #endregion

            Dictionary<int, DataTable> dic = new Dictionary<int, DataTable>();
            dic.Add(0, dtTotal);//总的统计
            dic.Add(10, this.proDt);//礼品列表

            return dic;
        }
    }
}

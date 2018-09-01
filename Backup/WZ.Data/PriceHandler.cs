using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using System.Web;

namespace WZ.Data
{
    /// <summary>
    /// 价格处理
    /// </summary>
    public class PriceHandler
    {
        private DataTable proDt;
        private int userLevel;//等级 0级:未登录
        private int userIdentity;//身份

        public PriceHandler(DataTable pProDt, int pUserLevel, int pUserIdentity)
        {
            this.proDt = pProDt;
            this.userLevel = pUserLevel;
            this.userIdentity = pUserIdentity;
        }

        public Dictionary<int, DataTable> Change()
        {
            Type T_Double = Type.GetType("System.Double");

            this.proDt.Columns.Add(new DataColumn("dt_UserPrice", T_Double));//用户实际价格
            this.proDt.Columns.Add(new DataColumn("dt_TotalPrice", T_Double));//用户小计

            double num;
            double Price;
            double smallTotal;//列的小计

            double total = 0;

            foreach (DataRow drw in this.proDt.Rows)
            {
                string proID = drw["ProSN"].ToString();

                //若id不合法
                if (Fn.IsInt(proID, 0) <= 0)
                    continue;

                Price = double.Parse(GetUserPrice(drw));
                drw["dt_UserPrice"] = Price;
                num = double.Parse(drw["Num"].ToString());

                smallTotal = Price * num;//小计
                drw["dt_TotalPrice"] = smallTotal;
                total += smallTotal;//总计
            }

            #region 总的统计
            //总的统计
            DataTable dtTotal = new DataTable();
            dtTotal.Columns.Add(new DataColumn("TotalPrice", T_Double));

            DataRow drwTotal = dtTotal.NewRow();
            drwTotal[0] = total;
            dtTotal.Rows.Add(drwTotal);
            #endregion

            Dictionary<int, DataTable> dic = new Dictionary<int, DataTable>();
            dic.Add(0, dtTotal);//总的统计
            dic.Add(10, this.proDt);//产品列表

            return dic;
        }

        #region 获取实际用户价格
        /// <summary>
        /// 获取实际用户价格
        /// </summary>
        /// <param name="drw"></param>
        /// <returns></returns>
        private string GetUserPrice(DataRow drw)
        {
            int item = int.Parse(drw["Item"].ToString());
            string price = drw["Price"].ToString();
            if (this.userLevel == 0)
            {
                return price;
            }

            if (User_InfoL.IsTeam(this.userIdentity))
            {
                if ((item & 2048) == 2048)//企业价
                {
                    price = drw["Price2"].ToString();
                }
            }
            else
            {
                if ((item & 4) == 4)//促销
                {
                    price = drw["Price1"].ToString();
                }
                else if ((item & 16) == 16)//秒杀
                {
                    DateTime MS_StartTime = Fn.IsDate(drw["MS_StartTime"].ToString(), DateTime.Now.AddDays(-1));
                    DateTime MS_EndTime = Fn.IsDate(drw["MS_EndTime"].ToString(), DateTime.Now.AddDays(-1));
                    DateTime now = DateTime.Now;

                    if (MS_StartTime > now || MS_EndTime < now)
                    { }
                    else
                        price = drw["Price1"].ToString();
                }
                else//获取会员价
                {
                    string levelPrice = drw["LevelPrice"].ToString();//自定义会员价格
                    //若有自定义会员价格
                    if (levelPrice.Length > 0)
                    {
                        if (Fn.IsDoubleBool(levelPrice))
                        {
                            price = levelPrice;//按自定义会员价格
                        }
                    }
                    else//按会员折扣价
                    {
                        if (!Fn.IsDoubleBool(price))
                            return "0";
                        double userDiscount = User_LevelL.GetLevelDiscount(this.userLevel);

                        return (Fn.IsDouble(price, 0) * userDiscount).ToString();
                    }
                }
            }

            if (!Fn.IsDoubleBool(price))
                return "0";
            else
                return price;
        }
        #endregion

        #region 计算产品总额(+=价格)
        /// <summary>
        /// 计算产品总额(+=价格)
        /// </summary>
        /// <param name="pDt">表格</param>
        /// <param name="pFieldPrice">价格字段名</param>
        /// <returns></returns>
        public static double GetTotalPrice(DataTable pDt, string pFieldPrice)
        {
            double TotPrice = 0d;

            if (pDt == null)
                return TotPrice;

            foreach (DataRow drw in pDt.Rows)
            {
                double Price = Convert.ToDouble(drw[pFieldPrice]);
                TotPrice += Price;
            }

            return TotPrice;
        }


        #endregion

        #region 加一列小计(dt_TotalPrice)
        /// <summary>
        /// 加一列小计(dt_TotalPrice)
        /// </summary>
        /// <param name="pDt">表格</param>
        /// <param name="pFieldNum">数量字段名</param>
        /// <param name="pFieldPrice">价格字段名</param>
        public static void SetDataTableTotalPrice(DataTable pDt, string pFieldNum, string pFieldPrice)
        {
            DataColumn dc = new DataColumn("dt_TotalPrice", Type.GetType("System.Double"));
            pDt.Columns.Add(dc);

            int num;
            double Price;
            foreach (DataRow drw in pDt.Rows)
            {
                num = Convert.ToInt32(drw[pFieldNum]);
                Price = Convert.ToDouble(drw[pFieldPrice]);
                drw["dt_TotalPrice"] = Price * num;
            }
        }
        #endregion

        #region 获取产品总额(+=(数量*价格)),加一列小计(dt_TotalPrice)
        /// <summary>
        /// 获取产品总额(+=(数量*价格)),加一列小计(dt_TotalPrice)
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pFieldNum"></param>
        /// <param name="pFieldPrice"></param>
        /// <returns></returns>
        public static double GetTotalPrice(DataTable pDt, string pFieldNum, string pFieldPrice)
        {
            DataColumn dc = new DataColumn("dt_TotalPrice", Type.GetType("System.Double"));
            pDt.Columns.Add(dc);

            double TotPrice = 0d;

            if (pDt == null) return TotPrice;

            int num;
            double Price;
            double smallTotal;
            foreach (DataRow drw in pDt.Rows)
            {
                num = Convert.ToInt32(drw[pFieldNum]);
                Price = Convert.ToDouble(drw[pFieldPrice]);
                smallTotal = Price * num;
                drw["dt_TotalPrice"] = smallTotal;
                TotPrice += smallTotal;
            }

            return TotPrice;
        }
        #endregion
    }
}

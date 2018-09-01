using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using WZ.Common.Control;
using WZ.Model;
using WZ.Data;
using WZ.Common.Config;

namespace WZ.Client.Data
{
    public class User_Cart
    {
        #region 列表
        /// <summary>
        /// 产品列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, DataTable> List(int pUserID, int pUserLevel, int pUserIdentity)
        {
            string sSQL = "select CartSN,Num,FK_All,ProSN,ProIsHas,ProName,Number,Price,Price1,Price2,MS_StartTime,MS_EndTime,PicS,LevelPrice,Item,StockN,Unit,UnitNum from "
                + "User_Cart uc left join Pro_Info pi on uc.FK_All=pi.ProSN "
                + "left join (select LevelPrice,Fk_Pro from Pro_LevelPrice where FK_User_Level=" + pUserLevel + ") lp on lp.Fk_Pro=pi.ProSN "
                + "where FK_User=" + pUserID + " and CartType=0";

            DataTable dt = DbHelp.GetDataTable(sSQL);

            PriceHandler ph = new PriceHandler(dt, pUserLevel, pUserIdentity);

            return ph.Change();
        }

        /// <summary>
        /// 获取其它价格
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static string GetOtherPrice(object pObj)
        {
            string str = string.Empty;
            DataRowView drv = (DataRowView)pObj;
            string sitem = drv["Item"].ToString();
            int item;
            if (!int.TryParse(sitem, out item))
            {
                return str;
            }

            if ((item & 4) == 4)
            {
                str = "<br />促销：￥" + double.Parse(drv["Price1"].ToString());
            }
            else if ((item & 16) == 16)
            {
                DateTime MS_StartTime = DateTime.Parse(drv["MS_StartTime"].ToString());
                DateTime MS_EndTime = DateTime.Parse(drv["MS_EndTime"].ToString());
                DateTime now = DateTime.Now;

                if (MS_StartTime > now || MS_EndTime < now)
                { }
                else
                    str = "<br />秒杀：￥" + double.Parse(drv["Price1"].ToString());
            }

            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public static Dictionary<int, DataTable> List_EditNum()
        //{
        //    string sSQL = "select CartSN,Num,FK_All,Price,LevelPrice,ProSN,Item,Price1,MS_StartTime,MS_EndTime from User_Cart left join Pro_Info on User_Cart.FK_All=Pro_Info.ProSN left join (select LevelPrice,Fk_Pro from Pro_LevelPrice where FK_User_Level=" + LoginInfo.UserLevel + ") Pro_LevelPrice1 on Pro_LevelPrice1.Fk_Pro=Pro_Info.ProSN where FK_User=" + LoginInfo.UserID;

        //    DataTable dt = DbHelp.GetDataTable(sSQL);

        //    return HandleActive(dt, LoginInfo.UserLevel);
        //}
        #endregion

        #region 删除
        //删除
        public static bool Delelte(int pUserID, int pID)
        {
            string sSQL = "delete from User_Cart where FK_User=" + pUserID + " and CartSN = " + pID;
            return (DbHelp.Update(sSQL) > 0);
        }
        #endregion

        #region 添加到购物车
        public class MsgAdd
        {
            public int userID;
            public int proID;
            public double num;
            public string msg = "";
        }

        public static string Add(int pUserID, int pID, double pN)
        {
            IDataParameter[] dp = { 
                                          DbHelp.Def.AddParam("@FK_User",pUserID),
                                          DbHelp.Def.AddParam("@FK_All",pID),
                                          DbHelp.Def.AddParam("@Num",pN),
                                          DbHelp.Def.AddParam("@MaxCount",Constant.MaxCount_Cart),
                                          };
            string s = DbHelp.First("sp_User_Cart_Add", CommandType.StoredProcedure, dp, "0");

            return s;
        }

        public static IList<MsgAdd> Add(int pUserID, int[] pArrID, double pCount)
        {
            IList<MsgAdd> l = new List<MsgAdd>();
            foreach (int i in pArrID)
            {
                string s = User_Cart.Add(pUserID, i, pCount);

                MsgAdd m = new MsgAdd();
                m.userID = pUserID;
                m.proID = i;
                m.num = pCount;
                m.msg = s;
                l.Add(m);

                if (s == "2")
                {
                    continue;
                }

            }
            return l;
        }
        #endregion

        #region 修改产品数量
        public static string EditNum(int pUserID, int pProID, double pN)
        {
            string sql = "update User_Cart set Num=" + pN + " where FK_User=" + pUserID + " and FK_All=" + pProID;

            if (DbHelp.Update(sql) > 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        #endregion

        #region 获取用户购物车商品数量
        public static int GetUserCartN(int pUserID)
        {
            string sSQL = "select count(0) from User_Cart where FK_User=" + pUserID;
            return Convert.ToInt32(DbHelp.Scalar(sSQL));
        }
        #endregion

        #region 处理活动(购买促销,秒杀等),把各功能表拆分成多张表,返回DataSet
        /// <summary>
        /// 处理活动(购买普通促销,秒杀等),把各功能表拆分成多张表,Dictionary
        /// 必须字段:ProSN,Pro_LevelPrice.LevelPrice,Pro_Info.Price,Price1,Item,User_Cart.Num
        /// 0:总的统计 TotalPrice
        /// 10:产品列表 增加列 dt_UserPrice:当前等级会员价  dt_TotalPrice:前当产品小计金额
        /// </summary>
        /// <returns></returns>
        //public static Dictionary<int, DataTable> HandleActive(DataTable pDt, int pUserLevel)
        //{
        //    Type T_Double = Type.GetType("System.Double");

        //    DataTable dtProList = pDt;
        //    dtProList.Columns.Add(new DataColumn("dt_UserPrice", T_Double));
        //    dtProList.Columns.Add(new DataColumn("dt_TotalPrice", T_Double));

        //    double userDiscount;

        //    //
        //    if (pUserLevel < 1)
        //        userDiscount = 1d;
        //    else
        //        userDiscount = User_Level.GetLevelDiscount(pUserLevel);

        //    double num;
        //    double Price;
        //    double smallTotal;//列的小计

        //    double total = 0;

        //    foreach (DataRow drw in dtProList.Rows)
        //    {

        //        string proID = drw["ProSN"].ToString();
        //        //如果不存在此产品
        //        if (proID.Length == 0)
        //            continue;

        //        int item = int.Parse(drw["Item"].ToString());
        //        bool isItem = true;


        //        if ((item & 4) == 4)//促销
        //        {
        //            drw["dt_UserPrice"] = drw["Price1"];
        //        }
        //        else if ((item & 16) == 16)//秒杀
        //        {
        //            DateTime MS_StartTime = Fn.IsDate(drw["MS_StartTime"].ToString(), DateTime.Now.AddDays(-1));
        //            DateTime MS_EndTime = Fn.IsDate(drw["MS_EndTime"].ToString(), DateTime.Now.AddDays(-1));
        //            DateTime now = DateTime.Now;

        //            if (MS_StartTime > now || MS_EndTime < now)
        //                isItem = false;
        //            else
        //                drw["dt_UserPrice"] = drw["Price1"];
        //        }
        //        else
        //        { 
        //            isItem = false; 
        //        }

        //        //if ((item & 2048) == 2048)//企业价
        //        //{
        //        //    drw["dt_UserPrice"] = drw["Price1"];
        //        //}
        //        //else
        //        //{
        //        //    isItem = false;
        //        //}






        //        if (!isItem)//若没有活动价
        //        {
        //            string proPrice = drw["Price"].ToString();
        //            string levelPrice = drw["LevelPrice"].ToString();

        //            #region 会员价格
        //            if (levelPrice.Length < 1)//若指定价格为空
        //                drw["dt_UserPrice"] = Fn.IsDouble(proPrice, 0) * userDiscount;//按默认折扣价
        //            else
        //                drw["dt_UserPrice"] = levelPrice;////按自定义会员价格
        //            #endregion
        //        }

        //        #region 小计

        //        num = double.Parse(drw["Num"].ToString());
        //        Price = double.Parse(drw["dt_UserPrice"].ToString());

        //        smallTotal = Price * num;//小计
        //        drw["dt_TotalPrice"] = smallTotal;
        //        total += smallTotal;
        //        #endregion
        //    }

        //    #region 总的统计
        //    //总的统计
        //    DataTable dtTotal = new DataTable();
        //    dtTotal.Columns.Add(new DataColumn("TotalPrice", T_Double));
        //    DataRow drwTotal = dtTotal.NewRow();
        //    drwTotal[0] = total;
        //    dtTotal.Rows.Add(drwTotal);
        //    #endregion

        //    Dictionary<int, DataTable> dic = new Dictionary<int, DataTable>();
        //    dic.Add(0, dtTotal);//总的统计
        //    dic.Add(10, dtProList);//产品列表

        //    return dic;
        //}
        #endregion

        /// <summary>
        /// 显示购物车产品库存状态
        /// 必须字段 ProSN,StockN,Num,ProIsHas
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static string GetCartProStatus(object pObj)
        {
            int proStatus = 0;
            DataRowView drv = (DataRowView)pObj;

            string proName = drv["ProSN"].ToString();
            if (proName.Length == 0)
                proStatus = (int)PubEnum.CurrentProStatus.不存在此商品;
            else
            {
                //double StockN = double.Parse(drv["StockN"].ToString());

                //if (StockN > 0)
                //{
                //    double Num = Fn.IsDouble(drv["Num"].ToString(), 0);
                //    if (StockN < Num)
                //        proStatus = proStatus | (int)PubEnum.CurrentProStatus.库存不足;
                //}
                //else
                //    proStatus = proStatus | (int)PubEnum.CurrentProStatus.库存不足;

                int ProIsHas = int.Parse(drv["ProIsHas"].ToString());
                if (ProIsHas == 1)
                    proStatus = proStatus | (int)PubEnum.CurrentProStatus.已下架;
            }

            string str = string.Empty;
            if (proStatus > 0)
                str = ((PubEnum.CurrentProStatus)proStatus).ToString();

            return str;
        }

        /// <summary>
        /// 显示购物车产品库存状态
        /// 必须字段 ProSN,StockN,Num,ProIsHas
        /// </summary>
        /// <param name="pDrw"></param>
        /// <returns></returns>
        public static string GetCartProStatus(DataRow pDrw)
        {
            int proStatus = 0;
            DataRow drv = pDrw;

            string proName = drv["ProSN"].ToString();
            if (proName.Length == 0)
                proStatus = (int)PubEnum.CurrentProStatus.不存在此商品;
            else
            {
                //double StockN = double.Parse(drv["StockN"].ToString());

                //if (StockN > 0)
                //{
                //    double Num = Fn.IsDouble(drv["Num"].ToString(), 0);
                //    if (StockN < Num)
                //        proStatus = proStatus | (int)PubEnum.CurrentProStatus.库存不足;
                //}
                //else
                //    proStatus = proStatus | (int)PubEnum.CurrentProStatus.库存不足;

                int ProIsHas = int.Parse(drv["ProIsHas"].ToString());
                if (ProIsHas == 1)
                    proStatus = proStatus | (int)PubEnum.CurrentProStatus.已下架;
            }

            string str = string.Empty;
            if (proStatus > 0)
                str = ((PubEnum.CurrentProStatus)proStatus).ToString();

            return str;
        }

        //public static string GetCartProStatus(DataRow pDrw, double pNum)
        //{
        //    int proStatus = 0;
        //    DataRow drv = pDrw;

        //    string proName = drv["ProSN"].ToString();
        //    if (proName.Length == 0)
        //        proStatus = (int)PubEnum.CurrentProStatus.不存在此商品;
        //    else
        //    {
        //        double StockN = double.Parse(drv["StockN"].ToString());

        //        if (StockN > 0)
        //        {
        //            double Num = Fn.IsDouble(drv["Num"].ToString(), 0) + pNum;
        //            if (StockN < Num)
        //                proStatus = proStatus | (int)PubEnum.CurrentProStatus.库存不足;
        //        }
        //        else
        //            proStatus = proStatus | (int)PubEnum.CurrentProStatus.库存不足;

        //        int ProIsHas = int.Parse(drv["ProIsHas"].ToString());
        //        if (ProIsHas == 1)
        //            proStatus = proStatus | (int)PubEnum.CurrentProStatus.已下架;
        //    }

        //    string str = string.Empty;
        //    if (proStatus > 0)
        //        str = ((PubEnum.CurrentProStatus)proStatus).ToString();

        //    return str;
        //}
    }
}
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using WZ.Common;
using WZ.Client.Data;
using WZ.Model;
using System.Collections.Generic;
using WZ.Data;
using System.Text;
using WZ.Common.CacheData;
using WZ.Common.Config;
using Newtonsoft.Json;
using WZ.Common.ICommon;
using WZ.Data.DataItem;

namespace WZ.Web.user
{
    public partial class orderConfirm : Page
    {
        private GetClassPath1 gcp;
        private ClassPath cp;
        private IMessage msgAjax = new MessageAjax();
        private int hid;
        private int userID;
        private ItemHandler itemOrdAreaTime = new ItemHandler("OrdAreaTime");

        protected string pageOrdAreaTime;
        protected string pageUserMoney = "0";//预存款
        //protected ItemHandler kpProAttr = new ItemHandler("ProItem");
        protected string sTime1;
        protected string sTime2;

        protected string pageRealName;
        protected string pageArea;
        protected string pageAddress;
        protected string pageTel;
        protected string pageFixTel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Fn.GetAppSettings("IsOrd") == "1")
            {
                Response.Redirect("/default.aspx");
            }

            if (LoginInfo.NoLogin(msgAjax))
            {
                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }
            else
            {
                userID = LoginInfo.UserID;
            }

            hid = Fn.IsInt(Req.GetForm("hid"), 0);
            if (hid > 0)
            {
                switch (hid)
                {
                    case 1://提交
                        buy_click();
                        break;
                }

                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }

            LL();
        }

        private void LL()
        {
            gcp = new GetClassPath1();
            cp = new ClassPath(PubData.GetDataTable("pub_area"), gcp);

            pageOrdAreaTime = Bind.GetHtmlSelectOptgroup(itemOrdAreaTime.GetItemList(), "cAreaTime", "", "0", "选择配送时间");

            DateTime curTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            sTime1 = curTime.Add(new TimeSpan(1, 10, 30, 0)).ToString("yyyy-MM-dd HH:mm");
            sTime2 = curTime.Add(new TimeSpan(1, 11, 00, 0)).ToString("yyyy-MM-dd HH:mm");

            //获取用户收货方式列表
            string sSQL = "select ConSN,Name,Address,FK_Area from User_Contact where FK_User=" + userID;
            DataTable dtAddress = DbHelp.GetDataTable(sSQL);

            if (dtAddress.Rows.Count > 0)
            {
                this.cIsDivAdd.Text = "0";//0:有收货地址 

                Bind.BGRepeater(dtAddress, this.rpAddress);
            }
            else
            {
                this.cIsDivAdd.Text = "1";//1:没有收货地址

                string sql = "select RealName,Area,Address,Tel,FixTel from User_Personal where FK_User=" + userID;
                using (IDataReader dr = DbHelp.Read(sql))
                {
                    if (dr.Read())
                    {
                        pageRealName = dr["RealName"].ToString();
                        pageArea = dr["Area"].ToString();
                        pageAddress = dr["Address"].ToString();
                        pageTel = dr["Tel"].ToString();
                        pageFixTel = dr["FixTel"].ToString();
                    }
                }
            }

            #region 显示购物信息

            Dictionary<int, DataTable> dic = User_Cart.List(userID, LoginInfo.UserLevel, LoginInfo.UserIdentity);
            DataTable dtTotal = dic[0];
            DataTable dtProList = dic[10];

            this.txtTotalPriceAll.Text = dtTotal.Rows[0][0].ToString();
            this.txtProN.Text = dtProList.Rows.Count.ToString();

            Bind.BGRepeater(dtProList, this.rpList);
            #endregion

            PayList();

            DataTable dtUser = User_InfoL.GetUserCanMoney(userID);
            if (dtUser.Rows.Count > 0)
            {
                this.pageUserMoney = dtUser.Rows[0]["UserCanMoney"].ToString();
            }
        }

        #region 支付方式
        private DataTable dtPayAttr;
        private void PayList()
        {
            string sSQL = "select FK_Pay,AttrStr,AttrValue from Pay_Attr";
            dtPayAttr = DbHelp.GetDataTable(sSQL);

            sSQL = "select PaySN,PayType,PayName,Detail from Pay_Info order by Taxis asc";
            DataTable dt = DbHelp.GetDataTable(sSQL);
            Bind.BGRepeater(dt, this.rpPay);
        }

        protected string GetPayAttr(object pPayID, object pPayType)
        {
            Pay_AttrL pal = new Pay_AttrL(pPayType.ToString());

            string payID = pPayID.ToString();
            DataRow[] aDrw = dtPayAttr.Select("FK_Pay=" + payID);

            DataTable lsDt = pal.GetAttr(aDrw);

            StringBuilder sb = new StringBuilder();

            sb.Append("<div>");
            foreach (DataRow drw in lsDt.Rows)
            {
                sb.Append(drw["AttrName"].ToString() + "：" + drw["AttrValue"].ToString() + " ");
            }
            sb.Append("</div>");
            return sb.ToString();
        }
        #endregion

        #region 添加联系方式
        //添加联系方式
        private User_ContactM AddContact(ref string pMsg)
        {
            //获取数据及验证
            User_ContactM mod = User_ContactL.GetData(ref pMsg);
            if (pMsg.Length > 0)
                return new User_ContactM();

            mod.FK_User = LoginInfo.UserID;

            if (!new User_ContactL().Add(mod, ref pMsg))
            {
                pMsg += "收货方式添加失败;";
            }
            return mod;
        }
        #endregion

        #region 提交订单
        private static object lockCreateOrder = new object();
        protected void bBuy_Click(object sender, EventArgs e)
        {
            lock (lockCreateOrder)
            {
                cb_ok();
            }
        }

        private void buy_click()
        {
            lock (lockCreateOrder)
            {
                cb_ok();
            }
        }

        //购买 提交订单 程序流程需要优化
        private void cb_ok()
        {
            int userIdentity = LoginInfo.UserIdentity;

            string sCaption = Req.GetForm("cInfo");//符加信息
            string sContact = Req.GetForm("cConAdd");//联系方式
            string sSaveContact = Req.GetForm("cSaveContact");
            string sPay = Req.GetForm("pay");
            string sToMinTime = Req.GetForm("startTime");//要求配送开始时间
            string sToMaxTime = Req.GetForm("endTime");//要求配送最晚时间
            string sAreaDate = Req.GetForm("cAreaDate");
            string sAreaTime = Req.GetForm("cAreaTime");
            string sActNumber_1 = Req.GetForm("cActNumber_1").Trim();//抵金券编号

            DateTime ToMinTime;
            DateTime ToMaxTime = DateTime.Now;

            if (!Fn.IsIntBool(sContact))
                msgAjax.Error("请选择或填写收货地址;");

            if (sCaption.Length >= 600)
                msgAjax.Error("附加信息不能超过600字;");

            if (!Fn.IsIntBool(sPay))
                msgAjax.Error("请选择支付方式;");

            #region 配送日期 验证
            if (!DateTime.TryParse(sAreaDate, out ToMinTime))
                msgAjax.Error("配送日期格式错误;");

            if (!DateTime.TryParse(sAreaDate, out ToMaxTime))
                msgAjax.Error("配送日期格式错误;");

            string lsAreaTime = string.Empty;
            if (!Fn.IsIntBool(sAreaTime))
            {
                msgAjax.Error("请选择配送时间1;");
            }
            else
            {
                lsAreaTime = itemOrdAreaTime.GetDirc(sAreaTime).name;
                if (lsAreaTime == null)
                {
                    msgAjax.Error("请选择配送时间;");
                    return;//以下需要用到配送时间,所以这里要返回
                }
            }
            string[] arrTime = System.Text.RegularExpressions.Regex.Split(lsAreaTime, @"[ ~ ]+");
            //msgAjax.Error(arrTime[0] + ";");
            //msgAjax.Error(arrTime[1] + ";");


            DateTime sTime1 = DateTime.Parse(arrTime[0]);
            ToMinTime = ToMinTime.Add(new TimeSpan(0, sTime1.Hour, sTime1.Minute, sTime1.Second));

            DateTime sTime2 = DateTime.Parse(arrTime[1]);
            ToMaxTime = ToMaxTime.Add(new TimeSpan(0, sTime2.Hour, sTime2.Minute, sTime2.Second));

            //msgAjax.Error(ToMinTime.ToString() + ";");
            //msgAjax.Error(ToMaxTime.ToString() + ";");

            //if (!DateTime.TryParse(sToMinTime, out ToMinTime))
            //    msgAjax.Error("配送开始时间格式错误;");

            //if (!DateTime.TryParse(sToMaxTime, out ToMaxTime))
            //    msgAjax.Error("最晚时间格式错误;");

            DateTime curTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime curTime1 = curTime.Add(new TimeSpan(1, 9, 0, 0));//最早配送时间
            DateTime curTime2 = curTime.Add(new TimeSpan(7, 19, 0, 0));//最迟不能超过一个星期
            TimeSpan tsTime = ToMaxTime - ToMinTime;
            //在当日之后 09：00—19：00,间不能小于20分钟,最大7天

            TimeSpan ts1 = new TimeSpan(0, 9, 0, 0);
            TimeSpan ts2 = new TimeSpan(0, 19, 0, 0);
            bool timeB = Fn.IsDateDayArea(ToMinTime, ts1, ts2) && Fn.IsDateDayArea(ToMaxTime, ts1, ts2);

            if ((ToMinTime < curTime1) || (ToMaxTime > curTime2) || (tsTime.TotalMinutes < 20) || (!timeB))
            {
                msgAjax.Error("配送时间范围必须在购订当天后的 09：00—19：00，最迟不超过一个星期，间隔不能小于30分钟。");
            }

            if (msgAjax.IsError)
                return;
            #endregion

            #region 商品　验证
            Dictionary<int, DataTable> dic = User_Cart.List(userID, LoginInfo.UserLevel, userIdentity);
            foreach (DataRow drw in dic[10].Rows)
            {
                if (User_Cart.GetCartProStatus(drw).Length > 0)
                {
                    msgAjax.Error("有不存在或已下架的商品，不能提交订单，<a href=\"cart.aspx\"><span style=\"color:#900\">点击这里返回购物车修改</span></a>;");
                    return;
                }
            }
            #endregion

            #region 预存款验证
            double TotalPrice = Convert.ToDouble(dic[0].Rows[0][0]);
            if (TotalPrice < 30)
            {
                msgAjax.Error("订单总额必须大于30元，还差" + (30 - TotalPrice) + "元");
                return;
            }

            string payStr = string.Empty;
            string sSQL = "select PayType from Pay_Info where PaySN=" + sPay;
            using (IDataReader dr = DbHelp.Read(sSQL))
            {
                if (dr.Read())
                {
                    payStr = dr[0].ToString();
                    //若用户选择预存款
                    if (payStr == "yck")
                    {
                        DataTable dtUser = User_InfoL.GetUserCanMoney(userID);

                        if (dtUser.Rows.Count > 0)
                        {
                            double d = Convert.ToDouble(dtUser.Rows[0]["UserCanMoney"]);
                            if (TotalPrice > d)
                            {
                                msgAjax.Error("您的预存款不足;");
                            }
                        }
                        else
                        {
                            msgAjax.Error("不存在此用户;");
                        }
                    }
                }
                else
                {
                    msgAjax.Error("不存的支付方式;");
                }
            }

            if (msgAjax.IsError)
                return;
            #endregion

            #region 获取联系方式
            string sRealName = string.Empty;
            string sAddress = string.Empty;
            string sFixTel = string.Empty;
            string sTel = string.Empty;
            string sArea = string.Empty;

            //是否选择了 其它联系方式
            if (sContact == "-1")
            {
                User_ContactM modContact;
                //是否添加到收货地址
                if (sSaveContact == "1")
                {
                    string sMsg = string.Empty;
                    modContact = AddContact(ref sMsg);

                    if (sMsg.Length > 0)
                    {
                        msgAjax.Error(sMsg);
                    }
                }
                else
                {
                    string sMsg = string.Empty;
                    modContact = User_ContactL.GetData(ref sMsg);
                    if (sMsg.Length > 0)
                    {
                        msgAjax.Error(sMsg);
                    }
                }
                sRealName = modContact.Name;
                sAddress = modContact.Address;
                sFixTel = modContact.FixTel;
                sTel = modContact.Tel;
                sArea = modContact.FK_Area.ToString();
            }
            else
            {
                int iContactID = Convert.ToInt32(sContact);
                sSQL = "select Name,Address,FixTel,Tel,FK_Area from User_Contact where ConSN=" + iContactID + " and FK_User=" + userID;
                DataTable dtContact = DbHelp.GetDataTable(sSQL);
                if (dtContact.Rows.Count > 0)
                {
                    sRealName = dtContact.Rows[0]["Name"].ToString();
                    sAddress = dtContact.Rows[0]["Address"].ToString();
                    sFixTel = dtContact.Rows[0]["FixTel"].ToString();
                    sTel = dtContact.Rows[0]["Tel"].ToString();
                    sArea = dtContact.Rows[0]["FK_Area"].ToString();

                    sSQL = "update User_Contact set UseTime=getdate() where ConSN=" + iContactID + " and FK_User=" + userID;
                    DbHelp.Update(sSQL);
                }
                else
                {
                    msgAjax.Error("您还未添加 收货地址;");
                }
            }

            if (msgAjax.IsError)
                return;
            #endregion

            #region 抵金券
            double ActNumber_1_Price = 0;//1号活动优惠价格
            if (sActNumber_1.Length > 0)
            {
                if (sActNumber_1.Length > 30)
                {
                    msgAjax.Error("抵金券号码错误1;");
                    return;
                }

                if (!Activity_InfoL.IsOpen("user_ticket_1"))
                {
                    msgAjax.Error("使用抵金券活动已关闭;");
                    return;
                }

                if (User_Ticket_1L.IsUse(sActNumber_1, out ActNumber_1_Price))
                {
                    if (ActNumber_1_Price <= 0)
                    {
                        msgAjax.Error("抵金券号码错误2;");
                        return;
                    }
                }
                else
                {
                    msgAjax.Error("抵金券号码错误;");
                    return;
                }
            }
            #endregion

            #region 订单model
            Ord_InfoM Mod = new Ord_InfoM();
            Mod.Ticket_1_Number = sActNumber_1;
            Mod.Ticket_1_Price = ActNumber_1_Price;
            Mod.UserCard = User_InfoL.GetUserField_Info(userID, "UserCard");

            Mod.OrdNumber = new Pub_Number("ord").GenerateNumber();
            Mod.FK_User = userID;
            Mod.UserIdentity = userIdentity;
            //若是企业用户
            if (User_InfoL.IsTeam(userIdentity))
            {
                Mod.TeamName = User_InfoL.GetUserField_Team(userID, "TeamName");
            }

            Mod.Caption = sCaption;
            Mod.FixTel = sFixTel;
            Mod.Tel = sTel;
            Mod.Address = sAddress;
            Mod.RealName = sRealName;
            Mod.UserName = LoginInfo.UserName;
            Mod.TotalPrice = TotalPrice;

            Mod.AreaTime = int.Parse(sAreaTime);
            Mod.ToMinTime = ToMinTime;
            Mod.ToMaxTime = ToMaxTime;

            Mod.Status = 10;//已结算
            Mod.Area = Convert.ToInt32(sArea);

            #region 支付状态,方式
            Mod.FK_Pay = Convert.ToInt32(sPay);
            Mod.PayType = payStr;
            if (payStr == "yck")
            {
                Mod.StatusPay = 2;// 已预付;
            }
            else
            {
                Mod.StatusPay = 0;// 已结算;
            }
            #endregion

            #region 出库人员,配送人员
            //工作状态:ThingStatus=0(正常):
            //区域:FK_Pub_Area(配送区域为后台指定人员(AdminAreaAuthority表)):

            //sSQL = "select top 1 au.au_ID from A_Admin_User__Pub_Area aaa left join A_Admin_User au on aaa.FK_A_Admin_User=au.au_ID where au.au_ThingStatus=0 and (aaa.FK_Pub_Area={0} or " + PubSQL.HasFun_InAdmin("'manage_areaALL'") + ") and " + PubSQL.HasFun_InAdmin("'{1}'") + " order by au.au_Level desc";

            //Mod.FK_AdminUser_PeiSong = int.Parse(DbHelp.First(string.Format(sSQL, sArea, "manage_peiSong"), "0"));

            //Mod.FK_AdminUser_ChuKu = int.Parse(DbHelp.First(string.Format(sSQL, sArea, "manage_chuKu"), "0"));

            Mod.FK_AdminUser_PeiSong = 0;
            Mod.FK_AdminUser_ChuKu = 0;
            #endregion

            #region 用户类型(A,B,C...),用户等级
            sSQL = "select UserType,FK_User_Level from User_Info where UserSN=" + userID;
            using (IDataReader uDr = DbHelp.Read(sSQL))
            {
                if (uDr.Read())
                {
                    Mod.UserType = byte.Parse(uDr["UserType"].ToString());
                    Mod.UserLevel = int.Parse(uDr["FK_User_Level"].ToString());
                }
                else
                {
                    msgAjax.Error("您的账户已丢失");//根据userID找不到此用户
                    return;
                }
            }
            #endregion
            #endregion

            #region 获取购物车产品,准备添加到订单产品列表里
            IList<Ord_ProM> IMod = new List<Ord_ProM>();

            //将购物车内容添加到List<Ord_ProM>
            AddItem(dic[10], IMod);//10:产品列表

            if (IMod.Count == 0)
            {
                msgAjax.Error("购物车里没有商品");
                return;
            }
            #endregion

            Ord_InfoL.LS_TransM transMod = new Ord_InfoL.LS_TransM();
            transMod.Mod = Mod;
            transMod.IMod = IMod;
            transMod.msgAjax = msgAjax;

            DbHelp.ExecuteTrans(new DbHelpParam(), Ord_InfoL.AddOrder_Trans, transMod);
        }

        #region 将表格内容添加到List<Ord_ProM>
        //将表格内容添加到List<Ord_ProM>
        private void AddItem(DataTable pDt, IList<Ord_ProM> pL)
        {
            foreach (DataRow drw in pDt.Rows)
            {
                string proPrice = drw["Price"].ToString();
                //如果产品的价格字段为空,则表示该产品不在或已下架
                if (proPrice.Length == 0)
                    continue;

                Ord_ProM pMod = new Ord_ProM();
                //pMod.FK_Order = iOrdID;

                pMod.FK_Pro = Convert.ToInt32(drw["FK_All"]);
                pMod.FK_User = userID;
                pMod.op_ProName = drw["ProName"].ToString();
                pMod.op_ProNumber = drw["Number"].ToString();
                pMod.op_ProPrice = Convert.ToDouble(drw["Price"]);
                pMod.op_UserPrice = Convert.ToDouble(drw["dt_UserPrice"]);
                pMod.op_Num = Convert.ToInt32(drw["Num"]);
                pMod.op_UserTotalPrice = Convert.ToDouble(drw["dt_TotalPrice"]);
                pMod.op_ProUnit = drw["Unit"].ToString();
                pMod.op_ProUnitNum = double.Parse(drw["UnitNum"].ToString());
                pMod.op_CurProStock = double.Parse(drw["StockN"].ToString());

                pL.Add(pMod);
            }
        }
        #endregion
        #endregion

        //区域路径
        protected string GetAreaPath(object pClassID)
        {
            cp.Exe(Convert.ToInt32(pClassID));
            return gcp.GetPath;
        }

        #region ICallbackEventHandler 成员
        public string GetCallbackResult()
        {
            return msgAjax.ReturnMessage;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            JavaScriptObject jso = (JavaScriptObject)JavaScriptConvert.DeserializeObject(eventArgument);
            string sCmd = jso["cmd"].ToString();
            switch (sCmd)
            {
                case "ok":
                    cb_ok();
                    break;
            }
        }

        #endregion
    }
}
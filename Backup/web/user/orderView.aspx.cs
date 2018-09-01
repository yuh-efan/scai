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
using WZ.Model;
using WZ.Data;
using WZ.Common.CacheData;
using WZ.Client.Data;
using WZ.Common.Config;
using WZ.Data.DataItem;

namespace WZ.Web.user
{
    public partial class orderView : WZ.Client.Data.General.PageUser
    {
        private int id;

        //protected Ord_InfoM pageMod;
        protected string pagePayName;
        protected string pageStatusName;
        protected string pageAreaPath;
        protected ItemHandler kpProAttr = new ItemHandler("ProItem");
        protected SqlDataSelect d;

        protected string pageTicket_1_Number;
        protected double pageTicket_1_Price;
        protected double pageTotalPrice;//用户总价
        protected double pageTotalPrice1;//未打折后价格

        private MessageGeneral msgG = new MessageGeneral();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();

            if (id < 1)
                msgG.Error("非法操作3");

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            GetOrdInfo();
            BGOrdPro();
        }

        //订单详细信息
        private void GetOrdInfo()
        {
            //pageMod = new Ord_InfoM();

            string sSQL = "select Ticket_1_Number,Ticket_1_Price,UserName,RealName,FixTel,Tel,Area,Address,OrdNumber,TotalPrice,AddDate,Caption,Remark,Status,StatusPay,ToMinTime,ToMaxTime,(select PayName from Pay_Info where PaySN=a.FK_Pay) as pn from Ord_Info a where OrdSN=" + id + " and FK_User=" + LoginInfo.UserID;
            d = new SqlDataSelect(sSQL);
            if (d.Count > 0)
            {
                //if (d.Eval("Remark").ToString().Length == 0)
                //    pageMod.Remark = "无";

                ItemHandler kpOrd = new ItemHandler("OrderStatus");

                pageStatusName = kpOrd.GetDircBit(int.Parse(d.Eval("Status").ToString()));
                pagePayName = d.Eval("pn").ToString();

                //区域
                GetClassPath1 acp = new GetClassPath1();
                ClassPath cp = new ClassPath(PubData.GetDataTable("pub_area"), acp);
                cp.Exe(Convert.ToInt32(d.Eval("Area")));
                pageAreaPath = acp.GetPath;

                pageTicket_1_Number = d.Eval("Ticket_1_Number").ToString();
                pageTicket_1_Price = double.Parse(d.Eval("Ticket_1_Price").ToString());
                pageTotalPrice = double.Parse(d.Eval("TotalPrice").ToString());
            }
            else
            {
                msgG.Error("此订单不存在");
            }
        }

        //订单商品列表
        private void BGOrdPro()
        {
            DataTable dtPro = Ord_Pro.List(id);
            pageTotalPrice1 = PriceHandler.GetTotalPrice(dtPro, "op_UserTotalPrice");

            Bind.BGRepeater(dtPro, this.rpListProUp);
        }
    }
}
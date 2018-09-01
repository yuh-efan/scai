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

namespace WZ.Web.user
{
    public partial class orderComplete : WZ.Client.Data.General.PageUser
    {
        private int id;

        protected string sOrdNumber;
        protected string sTotalPrice;
        protected string sPayName;
        protected string sOrdSN;
        private MessageGeneral msgG = new MessageGeneral();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                id = Req.GetID();
                if (id < 1)
                    msgG.Error("非法操作3");

                LL();
            }
        }

        private void LL()
        {
            string sMsg = string.Empty;
            string sSQL = "select OrdSN,OrdNumber,TotalPrice,(select PayName from Pay_Info where PaySN=a.FK_Pay) as pn from Ord_Info a where FK_User=" + LoginInfo.UserID + " and OrdSN=" + id;

            using (IDataReader dr = DbHelp.Read(sSQL))
            {
                if (dr.Read())
                {
                    sOrdNumber = dr["OrdNumber"].ToString();
                    sTotalPrice = dr["TotalPrice"].ToString();
                    sPayName = dr["pn"].ToString();
                    sOrdSN = dr["OrdSN"].ToString();
                }
                else
                {
                    sMsg += "不存在此订单;";
                }
            }

            msgG.Error(sMsg);

        }
    }
}

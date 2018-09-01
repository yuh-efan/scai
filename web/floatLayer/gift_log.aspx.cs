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
using WZ.Data;
using WZ.Client.Data;

namespace WZ.Web.floatLayer
{
    public partial class gift_log : WZ.Client.Data.General.FloatPage
    {
        protected int id;
        protected SqlDataSelect d;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();
            if (!Page.IsPostBack)
            {
                LL();
            }
        }
        protected void LL()
        {
            string sql = "select ge.ExIntegral,ge.Num,ge.ExTotalIntegral,gi.Detail,gi.PicB,ge.GiftName from Gift_ExchangeLog as ge left join Gift_Info as gi on ge.FK_Gift=gi.GiftSN where ge.ExSN=" + id;
            d = new SqlDataSelect(sql);
        }
    }
}

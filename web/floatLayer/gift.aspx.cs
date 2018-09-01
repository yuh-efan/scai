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

namespace WZ.Web.floatLayer
{
    public partial class gift : WZ.Client.Data.General.FloatPage
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
            string sql = "select GiftSN,GiftName,Integral,PicB,Detail,StockN from Gift_Info where GiftSN=" + id;
            d = new SqlDataSelect(sql);



        }
    }
}

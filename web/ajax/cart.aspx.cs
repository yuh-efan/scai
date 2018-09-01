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
using WZ.Common.ICommon;
using WZ.Common;
using WZ.Client.Data;
using System.Collections.Generic;

namespace WZ.Web.ajax
{
    public partial class cart1 : WZ.Client.Data.General.AjaxPage
    {
        protected DataTable dtPro = null;
        protected string cou = "0";
        protected double totalPrice = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            IMessage msgAjax = new MessageAjaxC();
            int userID = Fn.IsInt(Req.GetSession(LoginInfo.C_UserID), 0);

            if (userID > 0)
            {
                cou = User_Cart.GetUserCartN(userID).ToString();

                Dictionary<int, DataTable> dict = User_Cart.List(userID, LoginInfo.UserLevel, LoginInfo.UserIdentity);
                dtPro = dict[10];
                totalPrice = double.Parse(dict[0].Rows[0]["TotalPrice"].ToString());
            }

            msgAjax.AddMessage("cou", cou);
            msgAjax.AddMessage("html", Fn.GetControlHtml(this.cCart));
            Response.Write(msgAjax.ReturnMessage);
            Response.End();
        }
    }
}

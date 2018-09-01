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
using WZ.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using WZ.Common.ICommon;

namespace WZ.Web.floatLayer
{
    /*
     * 
     * 用户确认收货
     * 
     * */
    public partial class user_confirmAccept : WZ.Client.Data.General.FloatPage
    {
        private int id;
        protected int hid;

        protected IMessage msgAjax = new MessageAjax();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginInfo.IsLogin())
            {
                string furl = "login.aspx?furl=" + Request.Url.ToString();
                Response.Redirect(furl);
                return;
            }

            id = Req.GetID();
            hid = Fn.IsInt(Req.GetForm("hid"), 0);
            if (hid > 0)
            {
                switch (hid)
                {
                    case 1://确认收货
                        Ord_Comfirm();
                        break;
                }

                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }
        }

        private void Ord_Comfirm()
        {
            string sql = "update Ord_Info set Status=40 where OrdSN=" + id + " and FK_User=" + LoginInfo.UserID + " and Status=30";
            if (DbHelp.Update(sql) > 0)
            {
                msgAjax.Success("1");
                return;
            }
            else
            {
                msgAjax.Error("提交失败");
                return;
            }
        }
    }
}
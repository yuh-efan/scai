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

namespace WZ.Web.floatLayer
{
    /*
     * 
     * 用户查看站内信
     * 
     * */
    public partial class user_letterInfo : WZ.Client.Data.General.FloatPage
    {
        private int id;
        protected SqlDataSelect d;
        protected void Page_Load(object sender, EventArgs e)
        {
            string furl = "login.aspx?furl=" + Request.Url.ToString();
            if (LoginInfo.IsLogin())
            {
                Response.Redirect(furl);
                return;
            }

            id = Req.GetID();
            string sql = "update User_Letter set IsRead=1 where LetSN=" + id + " and FK_User_To=" + LoginInfo.UserID
                +";select FK_User_From,Title,Detail,AddDate,(select UserName from User_Info where UserSN=User_Letter.FK_User_From) as fromUserName from User_Letter where LetSN=" + id + " and FK_User_To=" + LoginInfo.UserID;
            d = new SqlDataSelect(sql);
        }
    }
}
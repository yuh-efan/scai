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

namespace WZ.Web.user
{
    public partial class detailIntegral : WZ.Client.Data.General.PageUser
    {
        protected string pageUserIntegral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sSQL = "select UserIntegral from User_Info where UserSN=" + LoginInfo.UserID;
            using (IDataReader dr = DbHelp.Read(sSQL))
            {
                if (dr.Read())
                {
                    pageUserIntegral = dr["UserIntegral"].ToString();
                }
            }


            Paging pg = Log_SetUserIntegralL.List(LoginInfo.UserID, 10);
            Bind.BGRepeater(pg.GetRead(), this.rpList);
            this.ucPS1.f = pg;
        }
    }
}

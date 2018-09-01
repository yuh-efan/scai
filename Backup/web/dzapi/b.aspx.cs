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

namespace WZ.Web.dzapi
{
    public partial class b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Fn.GetAppSettings("bbsurl"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            WZ.BBS.DZHandler.DZFn.Logout("");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WZ.BBS.DZHandler.DZFn.Login(this.un.Text, this.pwd.Text);

            //DiscuzSession ds;

            //if (Request.Cookies["dnt"] == null)
            //{
            //    ds = DiscuzSessionHelper.GetSession();
            //}
            //else
            //{
                
            //    ds = DiscuzSessionHelper.GetSession();
            //    //try
            //    //{
            //        //ds.session_info = ds.GetSessionFromToken(Session["AuthToken"].ToString());
            //    //}
            //    //catch
            //    //{
            //        //Response.Redirect("SessionCreater.aspx?next=default");
            //    //}
            //    //userName = ds.GetUserInfo(ds.GetLoggedInUser().UId).UserName;
            //}

            //string username = "admin";
            //string pwd = "admin";

            //int userid = ds.GetUserID(username); 

            //ds.Login(userid, pwd, false, 100, "");


            //Response.Redirect("SessionCreater.aspx?next=default");

        }

        //public class DiscuzSessionHelper
        //{
        //    private static string apikey, secret, url;
        //    private static DiscuzSession ds;
        //    static DiscuzSessionHelper()
        //    {
        //        apikey = "64c4b33f389ceb88fd826561a745f667";
        //        secret = "1c1924468fffa63c91a47e027d8cee2a";
        //        url = Fn.GetAppSettings("bbsurl");
        //        ds = new DiscuzSession(apikey, secret, url);
        //    }

        //    public static DiscuzSession GetSession()
        //    {
        //        return ds;
        //    }
        //}
    }
}
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

namespace WZ.Web.cs
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DbHelp.GetDataTable("select * from A_Admin_User where au_id=222");
            DataRow[] arrDrw = dt.Select("au_id=1111");
            foreach (DataRow drw in arrDrw)
            {
                Response.Write(drw["au_realname"]+"<br>");
            }
        }
    }
}

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
using WZ.Data;

namespace WZ.Web.cs
{
    public partial class attr_cs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = PubData.GetDataTable("help_class");

            foreach (DataRow drw in dt.Rows)
            {
                Response.Write(drw["ClassName"] + "<br>");
            }


        }
    }
}

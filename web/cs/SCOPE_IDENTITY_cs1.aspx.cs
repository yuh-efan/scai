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
using System.Threading;

namespace WZ.Web.cs
{
    public partial class SCOPE_IDENTITY_cs1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                string sSQL = "insert into cs(CsName) values('suger1_" + i + "');select SCOPE_IDENTITY();";

                Response.Write(DbHelp.Scalar(sSQL) + "='suger1_" + i + "'<br>");
                Thread.Sleep(500);


            }
        }
    }
}
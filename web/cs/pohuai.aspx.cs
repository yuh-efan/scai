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

/*
 * 
 * 破坏测试
 * 
 * 
 * */
namespace WZ.Web.cs
{
    public partial class pohuai : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DbHelp.Def = null;

            IDbProvider a = DbHelp.Def;
            
        }
    }
}

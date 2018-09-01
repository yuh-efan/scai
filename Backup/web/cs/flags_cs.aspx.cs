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
using WZ.Common.Config;
using System.Data.OleDb;


namespace WZ.Web.cs
{
    public partial class flags_cs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //加[Flags] 位运算后 .ToString() 变成 推荐, 特价
            //没有[Flags] 位运算后  .ToString() 变成数字
            //Response.Write((PubEnum.ProItem)12);

            

        }
    }
}

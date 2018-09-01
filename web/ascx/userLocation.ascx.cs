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

/*
 * 用户中心 显示当前位置
 * 
 * */
namespace WZ.Web.ascx
{
    public partial class userLocation : System.Web.UI.UserControl
    {
        protected string text;
        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
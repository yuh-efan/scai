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
using System.Text;

namespace WZ.Web.cs
{
    public partial class IsInterned_cs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = string.IsInterned("abc1");
            //string c = string.IsInterned("asdferersdfsdfewrtretdf");

            string b = new StringBuilder().Append("asdferer").Append("sdfsdfewrtretdf").ToString();

            //Test(a);
            //Test(b);

            if (string.IsNullOrEmpty(a))
            {
                Response.Write(a + "不存在'拘留池’中");
                Response.Write("<br>");
            }

            else
            {

                Response.Write(a + "存在'拘留池’中");
                Response.Write("<br>");

            }

            if (string.IsNullOrEmpty(b))
            {

                Response.Write(b + "不存在'拘留池’中");
                Response.Write("<br>");

            }

            else
            {

                Response.Write(b + "存在'拘留池’中");
                Response.Write("<br>");

            }  

           
        }

        private void Test(string str)
        {
            string strInterned = string.IsInterned(str);
            Response.Write(string.IsNullOrEmpty(strInterned));
        }
    }
}

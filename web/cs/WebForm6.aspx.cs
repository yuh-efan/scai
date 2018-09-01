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
using System.Data.SqlClient;

namespace WZ.Web.cs
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        object s1 = "123";
        string s2 = "123";
        protected void Page_Load(object sender, EventArgs e)
        {
            

            //ClassData

            //L3();
            
        }

        private void L1()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int.Parse(s1.ToString());
            }
        }

        private void L2()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int.Parse(s2);
            }
        }

        private void L3()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Convert.ToInt32(s1.ToString());
            }
        }

    }
}

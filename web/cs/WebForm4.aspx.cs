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
using WZ.Common;
using System.Collections.Generic;
using System.Text;

namespace WZ.Web.cs
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private static Random S_Rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Response.Write(DateTime.Now.Ticks + "<br>");
            }

            LL1();
        }

        //1000000 测试 5.5s
        private void LL1()
        {
            Dictionary<double, string> list = new Dictionary<double, string>();
            StringBuilder sb = new StringBuilder();
            int n = 0;
            for (int i = 0; i < 100; i++)//1000000
            {
                n++;
                for (int j = 0; j < 15; j++)
                {
                    sb.Append(S_Rand.Next(0, 10));
                }

                try
                {
                    list.Add(double.Parse(sb.ToString()), "");
                }
                catch
                {
                    Response.Write("i=" + i + " " + sb.ToString() + "========<br>");
                    i--;
                }

                Response.Write("i=" + i + " " + sb.ToString() + "<br>");
                sb.Remove(0, sb.Length);
            }

            Response.Write(list.Count+"<br>");
            Response.Write(n);
        }

        //1000000 测试 17s
        private void LL2()
        {
            Dictionary<double, string> list = new Dictionary<double, string>();
            StringBuilder sb = new StringBuilder();
            string s = "";
            string s1= "";
            for (int i = 0; i < 1000000; i++)//1000000
            {
                for (int j = 0; j < 16; j++)
                {
                    s += S_Rand.Next(0, 10).ToString();
                }

                try
                {
                    list.Add(double.Parse(s), s1);
                }
                catch
                {
                    Response.Write("i=" + i + " " + s + "<br>");
                }

                s = s1;
            }

            Response.Write(list.Count);
        }
    }
}

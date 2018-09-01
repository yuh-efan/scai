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
using WZ.Data.ClientAction;
using System.Collections.Generic;

namespace WZ.Web.cs_han
{
    public partial class ban : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Timer总次数：" + BanCache.TimerCount + "<br>");
            Response.Write("最后运行时间：" + BanCache.TimerLast + "<br>");


            LL1();
            LL2();

        }

        private void LL1()
        {
            Response.Write("----ListInfo-----------------<br>");

            IList<BanCache.Info> list1 = BanCache.ListInfo;
            int i = 0;
            foreach (BanCache.Info l in list1)
            {
                i++;
                Response.Write(" " + i + "<br>");
                Response.Write("IP=" + l.IP + "<br>");
                Response.Write("T=" + l.Identifier + "<br>");
                Response.Write("Dtime=" + l.Dtime + "<br>");
                Response.Write("AreaTime=" + l.AreaTime + "<br>");
                Response.Write("---------------------<br>");
            }
        }

        private void LL2()
        {
            Response.Write("----ListBan-----------------<br>");
            IList<BanCache.Info> list1 = BanCache.ListBan;
            int i = 0;
            foreach (BanCache.Info l in list1)
            {
                i++;
                Response.Write(" " + i + "<br>");
                Response.Write("IP=" + l.IP + "<br>");
                Response.Write("T=" + l.Identifier + "<br>");
                Response.Write("Dtime=" + l.Dtime + "<br>");
                Response.Write("AreaTime=" + l.AreaTime + "<br>");
                Response.Write("---------------------<br>");
            }
        }
    }
}

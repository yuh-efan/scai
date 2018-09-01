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
using WZ.Data;
using WZ.Common.CacheData;
using WZ.Common.Config;
using WZ.Data.ClientAction;
using System.Threading;
using System.Collections.Generic;

namespace WZ.Web.cs
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int i = 0;
            //while (i < 10)
            //{
            //    BanLogin.listInfo.Add(new BanLogin.Info() { Dtime = DateTime.Now, IP = "sdf" + i.ToString() });
            //    i++;
            //}


            //Response.Write(BanLogin.listInfo.GetEnumerator().GetType());

            //List<string>.Enumerator cacheKeys = BanLogin.listInfo.GetEnumerator();
            //while (BanLogin.listInfo.GetEnumerator().MoveNext())
            //{
            //    Response.Write(BanLogin.listInfo.GetEnumerator().Current + "<br>");
            //    Thread.Sleep(10);
            //}

            //BanLogin.Add("suger");



            foreach (BanCache.Info ii in BanCache.ListInfo)
            {
                Response.Write(ii.IP + " " + ii.Dtime.ToString() + "<br>");
            }

            Response.Write("<br>--------------------<br>");

            foreach (BanCache.Info ii in BanCache.ListBan)
            {
                Response.Write(ii.IP + " " + ii.Dtime.ToString() + "<br>");
            }
            Response.Write("<br>--------------------<br>");

            //BanLogin.thrBanUser();

            //Response.Write(BanLogin.IsBanUser("suger"));
            /*
            int i = 0;
            while (i < 10)
            {
                BanLogin.dict.Add(i.ToString(),"sdsd");
                i++;
            }

            foreach (string s  in BanLogin.dict.Keys)
            {
                Response.Write(s + "<br>");
                Thread.Sleep(100);
            }
            *
            /*
            List<string> l = new List<string>();
            IDictionaryEnumerator cacheKeys = HttpRuntime.Cache.GetEnumerator();
            while (cacheKeys.MoveNext())
            {
                Response.Write(cacheKeys.Key.ToString() + "<br>");
                Thread.Sleep(30);
            }
            */

        }
    }


}

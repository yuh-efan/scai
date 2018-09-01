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
using WZ.Client.Data;
using WZ.Common.CacheData;
using WZ.Common.Config;
using WZ.Common;
using WZ.Data;
using WZ.Data.Layout;
using System.Text;

namespace WZ.Web
{
    public partial class _default : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/default.aspx/");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sql;
            DataTable dt;

            //菜谱 首页栏目
            sql = "select top 6 ProSN,ProName,PicS from vgCaiPu_Info where Item&256=256 order by EditDate desc";
            dt = cac.GetDataTable("caipulist_Item&256=256", sql);
            this.rpCaiPuHome.dt = dt;
            this.rpCaiPuHome.listEvent = CaiPuLay.d_1;

            //产品 首页栏目
            sql = "select top 6 ProSN,ProName,PicS,Price,PriceMarket from vgPro_Info where Item&256=256 order by EditDate desc";
            dt = cac.GetDataTable("prolist_Item&256=256", sql);
            this.rpProHome.dt = dt;
            this.rpProHome.listEvent = ProLay.d_list1;

            //推荐 
            sql = "select top 4 ProSN,ProName,PicS,Price from vgPro_Info where Item&2=2 order by EditDate desc";
            dt = cac.GetDataTable("prolist_Item&2=2", sql);
            this.rpZuiXinTJ.dt = dt;
            this.rpZuiXinTJ.listEvent = ProLay.d_1;

            //促销
            sql = "select top 4 ProSN,ProName,PicS,Price1 from vgPro_Info where Item&4=4 order by EditDate desc";
            dt = cac.GetDataTable("prolist_Item&4=4", sql);
            this.rpProCX.dt = dt;
            this.rpProCX.listEvent = ProLay.d_price1_1;

            //首页栏目分类 菜谱
            sql = "select ClassSN,ClassName from vgCaiPu_Class where Item&2=2 order by Taxis asc";
            dt = cac.GetDataTable("caipu_class_Item&2=2", sql);
            this.rpCaiPuClass.dt = dt;
            this.rpCaiPuClass.listEvent = CaiPuClassHome;

            //首页栏目分类 产品
            sql = "select ClassSN,ClassName from vgPro_Class where Item&2=2 order by Taxis asc";
            dt = cac.GetDataTable("pro_class_Item&2=2", sql);
            this.rpProClass.dt = dt;
            this.rpProClass.listEvent = ProClassHome;

            //热卖商品排行
            sql = "select top 5 ProSN,ProName,PicS,PriceMarket,Price,SellN1 from vgPro_Info order by SellN1 desc";
            dt = cac.GetDataTable("prolist_hotsell1", sql);
            this.rpHotSell.dt = dt;
            this.rpHotSell.listEvent = ProLay.e_1;

            //秒杀 一个产品
            sql = "select top 1 ProSN,ProName,PicS,Price,Price1,MS_EndTime from vgPro_Info where Item&16=16 and MS_StartTime<=getdate() and MS_EndTime>=getdate() order by EditDate desc";
            dt = cac.GetDataTable("prolist_Item&16=16 and MS_StartTime<=getdate() and MS_EndTime>=getdate()", sql);
            this.rpProMS.dt = dt;
            this.rpProMS.listEvent = MSFirst;

            //公告
            sql = "select top 5 NewsSN,Title,Title1,Item,URL,UrlType from News_Info where Item&8=8 order by EditDate desc";
            dt = cac.GetDataTable("newslist_Item&8=8", sql);
            this.rpNotice.dt = dt;
            this.rpNotice.listEvent = LinkLay.listNotice1;

            //新闻首页图文
            sql = "select top 1 NewsSN,Title,Title1,Item,URL,UrlType,PicS,Detail from News_Info where Item&64=64 order by EditDate desc";
            dt = cac.GetDataTable("newslist_Item&64=64", sql);
            this.rpNewsPic.dt = dt;
            this.rpNewsPic.listEvent = NewsHomePic;

            //首页推荐
            sql = "select top 4 NewsSN,Title,Title1,Item,URL,UrlType from News_Info where Item&32=32 order by EditDate desc";
            dt = cac.GetDataTable("newslist_Item&32=32", sql);
            this.rpNewsTJ.dt = dt;
            this.rpNewsTJ.listEvent = LinkLay.list3;

            //用户实时购买
            sql = "select top 8 OrdSN,UserName,AddDate,(select count(0) from Ord_Pro op where op.FK_Order= oi.OrdSN) as cou from Ord_Info oi order by AddDate desc";
            dt = cac.GetDataTable("prolist_realtimebuy", sql);
            this.cyRealTimeBuy.dt = dt;
            this.cyRealTimeBuy.listEvent = RealTimeBuy;

            //Vote();
        }

        private StringBuilder MSFirst(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                string surplus = string.Empty;
                string endTime = drw["MS_EndTime"].ToString();
                DateTime endTime1;

                if (DateTime.TryParse(endTime, out endTime1))
                {
                    endTime = endTime1.ToString("yyyy-MM-dd hh:mm:ss");

                    //TimeSpan ts = endTime1 - DateTime.Now;
                    //if (ts.TotalDays > 1)
                    //{
                    //    surplus = ts.Days + "天 ";
                    //}

                    //if (ts.TotalHours > 1)
                    //{
                    //    surplus += ts.Hours + "时 ";
                    //}

                    //if (ts.TotalMinutes > 1)
                    //{
                    //    surplus += ts.Minutes + "分 ";
                    //}

                    //if (ts.TotalSeconds > 1)
                    //{
                    //    surplus += ts.Seconds + "秒 ";
                    //}

                }

                sb.Append("<li>");

                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"161\" height=\"110\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\"><a class=\"white\" href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\">" + drw["ProName"] + "</a></div>");
                sb.Append("<div>原价：<del>￥" + drw["Price"] + "</del></div>");
                sb.Append("<div>秒杀价：<span class=\"d-price\">￥" + drw["Price1"] + "</span></div>");

                sb.Append("<div>剩余：" );
                //sb.Append("<span id=\"d\"></span>天 ");
                sb.Append("<span id=\"h\"></span>时 ");
                sb.Append("<span id=\"m\"></span>分 ");
                sb.Append("<span id=\"s\"></span>秒");
                sb.Append("</div>");

                sb.Append("<div id='str' style=\"display:none\">"+DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")+"</div>");
                sb.Append("<div id='str2' style=\"display:none\">" + endTime + "</div>");

                sb.Append("<li class=\"today-spike-buy\" ><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\"><img src=\"images/today-spike-buy.gif\" /></a></li>");
                sb.Append("</li>");
            }
            return sb;
        }

        //首页栏目分类 产品
        private StringBuilder ProClassHome(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<a href=\"" + GetURL.Pro.Class(drw["ClassSN"]) + "\">" + drw["ClassName"] + "</a>");
            }
            return sb;
        }

        //首页栏目分类 产品
        private StringBuilder CaiPuClassHome(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<a href=\"" + GetURL.CaiPu.Class(drw["ClassSN"]) + "\">" + drw["ClassName"] + "</a>");
            }
            return sb;
        }

        //新闻首页图文
        private StringBuilder NewsHomePic(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<div class=\"left\">");
                sb.Append("<a href=\"" + GetURL.News.Info(drw) + "\" target=\"_blank\">");
                sb.Append("<img src=\"" + GetURL.News.Pic(drw["PicS"]) + "\" width=\"81\" height=\"79\" alt=\"" + drw["Title"] + "\" /></a>");
                sb.Append("</div>");

                sb.Append("<div class=\"right\">");
                sb.Append("<dl class=\"plate-top\">");
                
                sb.Append("<dt><a href=\"" + GetURL.News.Info(drw) + "\" target=\"_blank\">" + FnData.GetNewsTitle(drw) + "</a></dt>");
                sb.Append("<dd>"+Fn.Left(Fn.ReplaceHTML(drw["Detail"].ToString()), 20, "...")+"</dd>");

                sb.Append("</dl>");
                sb.Append("</div>");
            }
            return sb;
        }

        //实时购买
        private StringBuilder RealTimeBuy(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                string userName = drw["UserName"].ToString();
                if (userName.Length > 4)
                    userName = userName.Substring(0, 4);
                userName += "***";

                string time = drw["AddDate"].ToString();
                DateTime time1;
                if (DateTime.TryParse(time, out time1))
                {
                    time = time1.ToString("MM-dd hh:mm");
                }

                sb.Append("<li>");
                sb.Append("用户 <span class=\"red\">" + userName + "</span> 在 " + time + " 购买了 <span class=\"red\">" + drw["cou"] + "</span> 件菜品。");
                sb.Append("</li>");
            }
            return sb;
        }

        //客户调查
        //private void Vote()
        //{
        //    string sql = "select top 1 QuSN,ShowType,QuName from Questionnaire where IsOpen=1 order by Taxis asc,QuSN desc";
        //    DataTable dt = cac.GetDataTable("questionnaire_home", sql);
        //    if (dt.Rows.Count == 0)
        //        return;

        //    QuSN = dt.Rows[0]["QuSN"].ToString();
        //    QuName = dt.Rows[0]["QuName"].ToString();
        //    ShowType = dt.Rows[0]["ShowType"].ToString();

        //    if (ShowType == "0")
        //        ShowType = "checkbox";
        //    else
        //        ShowType = "radio";

        //    sql = "select * from Questionnaire_Vote where FK_Questionnaire=" + QuSN + " order by Taxis asc";
        //    dt = cac.GetDataTable("vote_home", sql);
        //    this.rpVote.dt = dt;
        //    this.rpVote.listEvent = new CycleEventText(VoteHome);
        //}

        //private StringBuilder VoteHome(DataTable dt)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (DataRow drw in dt.Rows)
        //    {
        //        sb.Append("<li><input name=\"cVote\" id=\"cVote" + drw["VoteSN"] + "\" type=\"" + ShowType + "\" value=\"" + drw["VoteSN"] + "\" />");
        //        sb.Append("<label for=\"cVote" + drw["VoteSN"] + "\">" + drw["VoteName"] + "</label>");
        //        sb.Append("</li>");
        //    }
        //    return sb;
        //}

        //protected string QuSN;
        //protected string QuName;
        //protected string ShowType;
    }
}
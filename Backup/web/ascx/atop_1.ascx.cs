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
using System.Collections.Generic;
using WZ.Common.CacheData;
using WZ.Common;
using WZ.Data.Layout;
using WZ.Data;

/*
 * 网站头部
 * 
 * */
namespace WZ.Web.ascx
{
    public partial class atop_1 : System.Web.UI.UserControl
    {
        private static DbCache cac = new DbCache("/ascx/atop_1.aspx/");
        private int userID;

        protected string pageUserName;
        //protected int pageUserCartN;
        protected int navIndex = 0;
        protected string keyPro;
        protected string keyCaiPu;
        protected string keyNews;

        protected string noReadLetter;

        public int NavIndex
        {
            set { this.navIndex = value; }
        }

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

            sql = "select top 1 KeyWordName from KeyWord where Item&2=2 order by Taxis asc,Num desc";
            keyPro = cac.First("keywordlist_Item&2=2", sql);

            sql = "select top 1 KeyWordName from KeyWord where Item&4=4 order by Taxis asc,Num desc";
            keyCaiPu = cac.First("keywordlist_Item&4=4", sql);

            sql = "select top 1 KeyWordName from KeyWord where Item&8=8 order by Taxis asc,Num desc";
            keyNews = cac.First("keywordlist_Item&8=8", sql);

            if (LoginInfo.IsLogin())
            {
                this.divLogin.Visible = false;
            }
            else
            {
                userID = LoginInfo.UserID;

                this.pageUserName = LoginInfo.UserName;
                this.divNoLogin.Visible = false;

                //购物车商品件数
                //this.pageUserCartN = User_Cart.GetUserCartN(userID);

                GetNoReadLetter();
            }
        }

        private void GetNoReadLetter()
        {
            string sql = "select count(0) from User_Letter where FK_User_To=" + userID + " and IsRead=0";
            int cou = int.Parse(DbHelp.Scalar(sql).ToString());
            if (cou > 0)
            {
                noReadLetter = "[<a href=\"/user/letterList.aspx\">" + DbHelp.Scalar(sql).ToString() + " 封未读</a>]";
            }
            else
            {
                noReadLetter = string.Empty;
            }
        }
    }
}
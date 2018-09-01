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
using WZ.Client.Data;
using WZ.Data;

namespace WZ.Web.user
{
    public partial class fav : WZ.Client.Data.General.PageUser
    {
        protected int t;
        protected string tit;

        protected void Page_Load(object sender, EventArgs e)
        {
            t = Fn.IsInt(Req.GetQueryString("t"), 0);
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            switch (t)
            { 
                case 0:
                    GetPro();
                    tit = "商品";
                    break;

                case 1:
                    GetCaiPu();
                    tit = "食谱";
                    break;

                default:
                    return;
                    break;
            }

            this.ucUL.Text += tit;
        }

        private void GetPro()
        {
            string sOrder = " order by a.AddDate desc";
            string sWhere = " where a.FK_User=" + LoginInfo.UserID + " and InfoType=" + t;

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0) from User_Fav a" + sWhere;
            pv.SQLRead = "select FavSN from User_Fav a" + sWhere + sOrder;
            pv.SQL = "select FavSN,FK_All,FK_User,ProName,Price,PicS,Item,a.AddDate from User_Fav a left join Pro_Info b on a.FK_All=b.ProSN where FavSN in({0})" + sOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(10));
            pg.load();

            Bind.BGRepeater(pg.GetRead(), this.rpPro);
            this.ucPS1.f = pg;
        }

        private void GetCaiPu()
        {
            string sOrder = " order by a.AddDate desc";
            string sWhere = " where a.FK_User=" + LoginInfo.UserID + " and InfoType=" + t;

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0) from User_Fav a" + sWhere;
            pv.SQLRead = "select FavSN from User_Fav a" + sWhere + sOrder;
            pv.SQL = "select FavSN,FK_All,FK_User,ProName,PicS,Item,a.AddDate from User_Fav a left join CaiPu_Info b on a.FK_All=b.ProSN where FavSN in({0})" + sOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(10));
            pg.load();

            Bind.BGRepeater(pg.GetRead(), this.rpCaiPu);
            this.ucPS1.f = pg;
        }
    
        protected void bDelete_Click(object sender, EventArgs e)
        {
            int selID = Convert.ToInt32(Fn.GetCommandName(sender));
            User_Fav.Delelte(selID,LoginInfo.UserID);
            Response.Redirect(Request.Url.ToString());
        }
    }
}

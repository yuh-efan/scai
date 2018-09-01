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
using System.Collections.Generic;

namespace WZ.Web.floatLayer
{
    /*
     * 0:产品id
     * 1:产品类型(0:产品 1:菜谱 2:套餐)
     * 2:订购数量
     * 3:订购产品类型 (0:普通产品,1:企业订购产品)
     * */
    public partial class proAddCart : WZ.Client.Data.General.FloatPage
    {
        private UrlQuery uq = new UrlQuery();
        private int userIdentifier;
        private int buyType;

        protected string ids;
        protected int type;
        protected double num;
        protected string furl;

        protected void Page_Load(object sender, EventArgs e)
        {
            furl = "login.aspx?furl=" + Request.Url.ToString();
            if (LoginInfo.IsLogin())
            {
                Response.Redirect(furl);
                return;
            }

            ids = Fn.IsIntArr(uq.GetQueryString(0));
            type = Fn.IsInt(uq.GetQueryString(1), 0);
            num = Fn.IsDouble(uq.GetQueryString(2), 0d);
            buyType = Fn.IsInt(uq.GetQueryString(3), 0);
            userIdentifier = LoginInfo.UserIdentity;

            if (User_InfoL.IsPersonal(userIdentifier))//个人用户身份登录
            {
                if (buyType == 1)//订购企业产品
                {
                    Response.Redirect("proAddCart1.aspx?msg=个人用户不能订购企业区产品！");
                    return;
                }
            }
            else if (User_InfoL.IsTeam(userIdentifier))//企业用户身份登录
            {
                if (buyType == 0)//订购个人用户产品
                {
                    Response.Redirect("proAddCart1.aspx?msg=企业用户不能在此订购产品！<a href=\"/pro/team/\" target=\"_top\">点击进入企业专区</a>");
                    return;
                }
            }

            if (ids.Length == 0)
            {
                Response.Write("非法操作");
                return;
            }

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            switch (type)
            {
                case 0://产品
                    ProList(ids);
                    break;

                case 1://菜谱
                    ProList1("select FK_Pro from CaiPu_Pro where FK_CaiPu in(" + ids + ")");
                    break;

                case 2://套餐
                    string lsSql = "declare @lst table (FK_Pro int)"
                    + "insert into @lst(FK_Pro)("
                    + "select FK_Pro "
                    + "from CaiPu_Pro "
                    + "where FK_CaiPu in(select tc.FK_CaiPu from TaoCan_CaiPu tc where tc.FK_TaoCan in(" + ids + ")) "
                    + ")"

                    + "insert into @lst(FK_Pro)("
                    + "select FK_CaiPu from TaoCan_Pro where FK_TaoCan in (" + ids + ")"
                    + ")"
                    + "select FK_Pro from @lst";

                    ProList1(lsSql);

                    break;

                default:
                    Response.End();
                    break;
            }
        }

        private void ProList(string pIds)
        {
            int userLevel = LoginInfo.UserLevel;

            string sql = "select ProSN," + num + " as Num,ProName,Number,Price,Price1,Price2,MS_StartTime,MS_EndTime,PicS,LevelPrice,Item,ProIsHas,StockN,pi.Unit,pi.UnitNum from "
                + "vgPro_Info pi left join (select LevelPrice,Fk_Pro from Pro_LevelPrice where FK_User_Level=" + userLevel + ") lp on lp.Fk_Pro=pi.ProSN "
                + "where ProSN in(" + pIds + ")";

            DataTable dt = DbHelp.GetDataTable(sql);
            PriceHandler ph = new PriceHandler(dt, userLevel, userIdentifier);

            Dictionary<int, DataTable> dirc = ph.Change();

            Bind.BGRepeater(dirc[10], this.rpList);
        }

        //菜谱 套餐 
        private void ProList1(string pSql)
        {
            string proIDs = string.Empty;
            using (IDataReader dr = DbHelp.Read(pSql))
            {
                while (dr.Read())
                    proIDs += dr[0].ToString() + ",";
            }

            if (proIDs.Length > 0)
            {
                proIDs = proIDs.TrimEnd(',');
                ProList(proIDs);
            }
        }
    }
}
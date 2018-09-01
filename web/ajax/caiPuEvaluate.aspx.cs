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
using WZ.Common.ICommon;
using WZ.Data.ClientAction;

/*
 * 菜谱评价
 * 
 * */
namespace WZ.Web.ajax
{
    public partial class caiPuEvaluate : WZ.Client.Data.General.AjaxPage
    {
        private int t;
        private int id;

        private IMessage msgAjax = new MessageAjaxC();
        private BanCache banH;

        protected void Page_Load(object sender, EventArgs e)
        {
            t = Fn.IsInt(Req.GetQueryString("t"), 0);
            id = Fn.IsInt(Req.GetQueryString("id"), 0);
            banH = new BanCache("caipu_comment_" + id, new TimeSpan(0, 0, 10), 1);

            switch (t)
            {
                case 1://提交
                    Add();
                    break;

                default:
                    msgAjax.Error("非法操作");
                    break;
            }
            Response.Write(msgAjax.ReturnMessage);
        }

        private void Add()
        {
            if (banH.IsBan())
            {
                msgAjax.Error("ban");
                return;
            }

            int fraction = Fn.IsInt(Req.GetQueryString("star"), 3);
            if (fraction < 0 || fraction > 5)
                fraction = 3;

            int userID = 0;
            if (!LoginInfo.IsLogin())
            {
                userID = LoginInfo.UserID;
            }

            string sDetail = Server.HtmlEncode(Req.GetForm("content"));
            if (sDetail.Length > 600)
            {
                msgAjax.Error("above");
                return;
            }

            string sSql = "insert into CaiPu_Evaluate(FK_User,FK_Pro,Fraction,Detail,Purview,IP) values(@FK_User,@FK_Pro,@Fraction,@Detail,@Purview,@IP)";
            IDataParameter[] dp = { 
                                    DbHelp.Def.AddParam("@FK_User",userID),
                                    DbHelp.Def.AddParam("@FK_Pro",id),
                                    DbHelp.Def.AddParam("@Fraction",fraction),
                                    DbHelp.Def.AddParam("@Detail",sDetail),
                                    DbHelp.Def.AddParam("@Purview",0),
                                    DbHelp.Def.AddParam("@IP",Request.UserHostAddress),
                                  };

            if (DbHelp.Update(sSql, dp) > 0)
            {
                banH.Add();
                msgAjax.Success("1");
            }
            else
            {
                msgAjax.Error("nosubmit");
            }
        }
    }
}

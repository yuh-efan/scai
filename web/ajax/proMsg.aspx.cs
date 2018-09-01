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
using Newtonsoft.Json;
using WZ.Client.Data;
using WZ.Common.ICommon;
using WZ.Data.ClientAction;
using WZ.Model;
using WZ.Data;

/*
 * 产品 评论
 * 
 * */
namespace WZ.Web.ajax
{
    public partial class proMsg : WZ.Client.Data.General.AjaxPage
    {
        private int t;
        private int id;
        private IMessage msgAjax = new MessageAjaxC();
        private BanCache banH;

        protected void Page_Load(object sender, EventArgs e)
        {
            t = Fn.IsInt(Req.GetQueryString("t"), 0);
            id = Fn.IsInt(Req.GetQueryString("id"), 0);
            banH = new BanCache("pro_msg_" + id, new TimeSpan(0, 0, 10), 1);
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

            if (LoginInfo.NoLogin1(msgAjax))
                return;

            string sDetail = Server.HtmlEncode(Req.GetForm("content"));

            if (sDetail.Length == 0)
            {
                msgAjax.Error("input");
                return;
            }

            if (sDetail.Length > 600)
            {
                msgAjax.Error("above");
                return;
            }

            Pro_MsgM mod = new Pro_MsgM();
            mod.FK_User = LoginInfo.UserID;
            mod.FK_Pro = id;
            mod.Detail = sDetail;
            mod.Purview = 0;
            mod.IP = Request.UserHostAddress;

            ProMsg_TransM tmod = new ProMsg_TransM();
            tmod.mod = mod;

            DbHelp.ExecuteTrans(new DbHelpParam(), this.ProEval_Trans, tmod);

            if (tmod.returnValue == "1")
            {
                msgAjax.Success("1");
            }
            else
            {
                msgAjax.Error(tmod.returnValue);
            }
        }

        public class ProMsg_TransM : WZ.Common.DbHelp.ITransM
        {
            public Pro_MsgM mod;
        }

        private int ProEval_Trans(IDbHelp thelp, object obj)
        {
            ProMsg_TransM tmod = (ProMsg_TransM)obj;
            Pro_MsgM mod = tmod.mod;

            string sSql = "insert into Pro_Msg(FK_User,FK_Pro,Detail,Purview,IP) values(@FK_User,@FK_Pro,@Detail,@Purview,@IP)";
            IDataParameter[] dp = { 
                            DbHelp.Def.AddParam("@FK_User",mod.FK_User),
                            DbHelp.Def.AddParam("@FK_Pro",mod.FK_Pro),
                            DbHelp.Def.AddParam("@Detail",mod.Detail),
                            DbHelp.Def.AddParam("@Purview",mod.Purview),
                            DbHelp.Def.AddParam("@IP",mod.IP),
                                  };

            if (thelp.Update(sSql, dp) > 0)
            {
                banH.Add();

                //增加积分或经验
                string sname = DbHelp.First("select ProName from Pro_Info where ProSN=" + mod.FK_Pro);
                User_FractHandler.FractHandlerParam ufParam = new User_FractHandler.FractHandlerParam(mod.FK_User, "system", 1, "pro_comment", "pro_comment", "产品评论 \"" + sname + "\"");
                ufParam.FK_All = mod.FK_Pro;

                string slog = new User_FractHandler(thelp).SetFract(ufParam);
                //string slog = new User_FractHandler(thelp).SetFract(mod.FK_User, "system", 1, "pro_comment", "pro_comment", "产品评论 \"" + sname + "\"");
                if (slog != "1")
                {
                    tmod.returnValue = slog;
                    return 0;
                }

                tmod.returnValue = "1";
                return 1;
            }
            else
            {
                tmod.returnValue = "nosubmit";
                return 0;
            }
        }


    }
}

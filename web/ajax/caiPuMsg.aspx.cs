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
using WZ.Data;
using WZ.Model;

namespace WZ.Web.ajax
{
    public partial class caiPuMsg : WZ.Client.Data.General.AjaxPage
    {
        private int t;
        private int id;
        private IMessage msgAjax = new MessageAjaxC();
        private BanCache banH;

        protected void Page_Load(object sender, EventArgs e)
        {
            t = Fn.IsInt(Req.GetQueryString("t"), 0);
            id = Fn.IsInt(Req.GetQueryString("id"), 0);
            banH = new BanCache("caipu_msg_" + id, new TimeSpan(0, 0, 10), 1);

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

            int userID = 0;
            if (!LoginInfo.IsLogin())
            {
                userID = LoginInfo.UserID;
            }

            CaiPu_MsgM mod = new CaiPu_MsgM();
            mod.FK_User = userID;
            mod.FK_Pro = id;
            mod.Detail = sDetail;
            mod.Purview = 1;
            mod.IP = Request.UserHostAddress;

            CaiPuMsg_TransM tmod = new CaiPuMsg_TransM();
            tmod.mod = mod;

            DbHelp.ExecuteTrans(new DbHelpParam(), this.CaiPuEval_Trans, tmod);

            if (tmod.returnValue == "1")
            {
                msgAjax.Success("1");
            }
            else
            {
                msgAjax.Error(tmod.returnValue);
            }
            
        }

        public class CaiPuMsg_TransM : WZ.Common.DbHelp.ITransM
        {
            public CaiPu_MsgM mod;
        }

        private int CaiPuEval_Trans(IDbHelp thelp, object obj)
        {
            CaiPuMsg_TransM tmod = (CaiPuMsg_TransM)obj;
            CaiPu_MsgM mod = tmod.mod;


            string sSql = "insert into CaiPu_Msg(FK_User,FK_Pro,Detail,Purview,IP) values(@FK_User,@FK_Pro,@Detail,@Purview,@IP)";
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

                //若用户登录
                if (mod.FK_User > 0)
                {
                    //增加积分或经验
                    string sname = DbHelp.First("select ProName from CaiPu_Info where ProSN=" + mod.FK_Pro);
                    User_FractHandler.FractHandlerParam ufParam = new User_FractHandler.FractHandlerParam(mod.FK_User, "system", 1, "caipu_comment", "caipu_comment", "菜谱评论 \"" + sname + "\"");
                    ufParam.FK_All = mod.FK_Pro;
                    string slog = new User_FractHandler(thelp).SetFract(ufParam);
                    //string slog = new User_FractHandler(thelp).SetFract(mod.FK_User, "system", 1, "caipu_comment", "caipu_comment", "菜谱评论 \"" + sname + "\"");
                    if (slog != "1")
                    {
                        tmod.returnValue = slog;
                        return 0;
                    }
                }
            }
            else
            {
                tmod.returnValue = "nosubmit";
                return 0;
            }

            tmod.returnValue = "1";
            return 1;
        }

    }
}

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
using System.Collections.Generic;

/*
 * 新闻评论
 * 
 * */
namespace WZ.Web.ajax
{
    public partial class newsMsg : WZ.Client.Data.General.AjaxPage
    {
        private int id;
        private IMessage msgAjax = new MessageAjaxC();
        private BanCache banH;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(Req.GetQueryString("id"), 0);
            banH = new BanCache("news_msg_" + id, new TimeSpan(0, 0, 10), 1);

            Add();
            Response.Write(msgAjax.ReturnMessage);
        }

        private void Add()
        {
            if (banH.IsBan())
            {
                msgAjax.Error("ban");
                return;
            }

            int userID = 0;
            if (LoginInfo.IsLogin())
            { }
            else
            {
                userID = LoginInfo.UserID;
            }

            string sDetail = Server.HtmlEncode(Req.GetForm("content"));

            if (sDetail.Length == 0)
            {
                msgAjax.Error("input");
                return;
            }

            if (sDetail.Length == 0 || sDetail.Length > 600)
            {
                msgAjax.Error("nobuy");
                return;
            }

            News_MsgM mod = new News_MsgM();
            mod.FK_User = userID;
            mod.FK_News = id;
            mod.Detail = sDetail;
            mod.Purview = 1;
            mod.IP = Request.UserHostAddress;

            NewsMsg_TransM tmod = new NewsMsg_TransM();
            tmod.mod = mod;

            DbHelp.ExecuteTrans(new DbHelpParam(), this.NewsEval_Trans, tmod);

            if (tmod.returnValue == "1")
            {
                msgAjax.Success("1");
            }
            else
            {
                msgAjax.Error(tmod.returnValue);
            }
        }

        public class NewsMsg_TransM : WZ.Common.DbHelp.ITransM
        {
            public News_MsgM mod;
        }

        private int NewsEval_Trans(IDbHelp thelp, object obj)
        {
            NewsMsg_TransM tmod = (NewsMsg_TransM)obj;
            News_MsgM mod = tmod.mod;

            string sql = "insert into News_Msg(FK_User,FK_News,Detail,Purview,IP) values(@FK_User,@FK_News,@Detail,@Purview,@IP)";
            IDataParameter[] dp = { 
                            DbHelp.Def.AddParam("@FK_User",mod.FK_User ),
                            DbHelp.Def.AddParam("@FK_News",mod.FK_News ),
                            DbHelp.Def.AddParam("@Detail",mod.Detail),
                            DbHelp.Def.AddParam("@Purview",mod.Purview),
                            DbHelp.Def.AddParam("@IP",mod.IP),
                                  };

            if (thelp.Update(sql, dp) > 0)
            {
                banH.Add();

                //若用户登录
                if (mod.FK_User > 0)
                {
                    //增加积分或经验
                    string sname = DbHelp.First("select Title from News_Info where NewsSN=" + mod.FK_News);
                    User_FractHandler.FractHandlerParam ufParam = new User_FractHandler.FractHandlerParam(mod.FK_User, "system", 1, "news_comment", "news_comment", "新闻评论 \"" + sname + "\"");
                    ufParam.FK_All = mod.FK_News;
                    string slog = new User_FractHandler(thelp).SetFract(ufParam);
                    //string slog = new User_FractHandler(thelp).SetFract(mod.FK_User, "system", 1, "news_comment", "news_comment", "新闻评论 \"" + sname + "\"");
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

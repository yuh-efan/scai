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
using WZ.Common.ICommon;
using WZ.Client.Data;
using WZ.Data.ClientAction;

/*
 * 问卷调查
 * 
 * */
namespace WZ.Web.ajax
{
    public partial class vote : WZ.Client.Data.General.AjaxPage
    {
        private int userID = 0;
        private int id;
        private IMessage msgAjax = new MessageAjaxC();
        private BanCache banH;
        private BanData banD;
        private int t;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(Req.GetQueryString("id"), 0);
            banH = new BanCache("qu_msg_" + id, new TimeSpan(0, 0, 10), 1);
            
            t = Req.GetID("t");

            if (!LoginInfo.IsLogin())
            {
                userID = LoginInfo.UserID;
            }

            banD = new BanData(userID, "qu_msg_" + id, new TimeSpan(1, 0, 0, 0), 1);
            switch (t)
            {
                case 0://投票
                    TouPiao();
                    break;

                case 1://评论
                    Comment();
                    break;

                default:
                    msgAjax.Error("非法操作");
                    break;
            }

            Response.Write(msgAjax.ReturnMessage);
            Response.End();
        }

        #region 评论

        private void Comment()
        {
            if (banH.IsBan())
            {
                msgAjax.Error("ban");
                return;
            }

            string content = Server.HtmlEncode(Req.GetForm("content"));

            if (content.Length == 0)
            {
                msgAjax.Error("input");
                return;
            }

            if (content.Length > 600)
            {
                msgAjax.Error("评论内容不能超出600字");
                return;
            }

            string sql = "select top 1 1 from Questionnaire where IsOpen=1 and QuSN=" + id;
            if (DbHelp.First(sql, "0") != "1")
            {
                msgAjax.Error("不存在此记录");
                return;
            }

            TransM mod = new TransM();
            mod.content = content;

            DbHelp.ExecuteTrans(new DbHelpParam(), AddComment_Trans, mod);
        }

        private int AddComment_Trans(IDbHelp thelp, object obj)
        {
            if (AddComment(thelp, obj))
            {
                banH.Add();
                msgAjax.Success("1");
                return 1;
            }
            else
            {
                msgAjax.Error("提交失败");
                return 0;
            }
        }
        #endregion

        #region 投票
        private void TouPiao()
        {
            //用户选中项
            string sVoteID = Req.GetForm("cVote");
            if (sVoteID.Length < 1)
            {
                msgAjax.Error("至少选择一项");
                return;
            }

            //是否非法id
            if (!Fn.IsIntArrBool(sVoteID))
            {
                msgAjax.Error("非法操作" + sVoteID);
                return;
            }

            string content = Server.HtmlEncode(Req.GetForm("content"));
            if (content.Length > 600)
            {
                msgAjax.Error("评论内容不能超出600字");
                return;
            }

            string sql = "select top 1 1 from Questionnaire where IsOpen=1 and QuSN=" + id;
            if (DbHelp.First(sql, "0") != "1")
            {
                msgAjax.Error("不存在此记录");
                return;
            }

            //sql = "select top 1 1 from Ban_Log where ban_type=0 and ban_adddate>@ban_adddate and FK_All=" + id + " and ban_ip=@ban_ip";

            //string ban_adddate = DateTime.Now.ToString("yyyy-MM-dd");

            //IDataParameter[] dp = { 
            //                DbHelp.Def.AddParam("@ban_adddate",ban_adddate),
            //                DbHelp.Def.AddParam("@ban_ip",Request.UserHostAddress)
            //                      };

            //if (DbHelp.First(sql, dp, "0") == "1")
            //{
            //    msgAjax.Error("您今天已投票");
            //    return;
            //}

            if (banD.IsBan())
            {
                msgAjax.Error("您今天已投票");
                return;
            }

            TransM mod = new TransM();
            mod.content = content;
            mod.sVoteID = sVoteID;

            DbHelp.ExecuteTrans(new DbHelpParam(), TouPiao_Trans, mod);
        }

        private int TouPiao_Trans(IDbHelp thelp, object obj)
        {
            try
            {
                return TouPiao_Trans1(thelp, obj);
            }
            catch (Exception ex)
            {
                msgAjax.Error(ex.Message);
                return 0;
            }
        }

        private int TouPiao_Trans1(IDbHelp thelp, object obj)
        {
            TransM mod = (TransM)obj;

            string sql = "update Questionnaire_Vote set Total=Total+1 where FK_Questionnaire=" + id + " and VoteSN in(" + mod.sVoteID + ")";
            //投票
            if (thelp.Update(sql) > 0)
            {
                //添加评论
                if (mod.content.Length > 0)
                {
                    if (!AddComment(thelp, obj))
                    {
                        msgAjax.Error("提交失败 2");
                        return 0;
                    }
                }

                banD.Add();
            }
            else
            {
                msgAjax.Error("提交失败 3");
                return 0;
            }

            //成功
            msgAjax.Success("1");
            return 1;
        }
        #endregion

        private class TransM : DbHelp.ITransM
        {
            public string sVoteID;
            public string content;
        }

        private bool AddComment(IDbHelp thelp, object obj)
        {
            TransM mod = (TransM)obj;

            //添加评论
            string sql = "insert into Questionnaire_Msg(FK_User,FK_Questionnaire,Detail,Purview,IP) values(@FK_User,@FK_Questionnaire,@Detail,@Purview,@IP)";

            string sIP = Request.UserHostAddress;
            IDataParameter[] dp = { 
                            DbHelp.Def.AddParam("@FK_User",userID),
                            DbHelp.Def.AddParam("@FK_Questionnaire",id),
                            DbHelp.Def.AddParam("@Detail",mod.content),
                            DbHelp.Def.AddParam("@Purview",1),
                            DbHelp.Def.AddParam("@IP",sIP),
                                  };

            return thelp.Update(sql, dp) > 0;
        }
    }
}
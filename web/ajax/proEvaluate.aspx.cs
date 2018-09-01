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
using System.Collections.Generic;
using WZ.Data;
using WZ.Model;

/*
 * 产品评价
 * 
 * */
namespace WZ.Web.ajax
{
    public partial class proEvaluate : WZ.Client.Data.General.AjaxPage
    {
        private int t;
        private int id;

        private IMessage msgAjax = new MessageAjaxC();
        private BanCache banH;

        protected void Page_Load(object sender, EventArgs e)
        {
            t = Fn.IsInt(Req.GetQueryString("t"), 0);
            id = Fn.IsInt(Req.GetQueryString("id"), 0);
            banH = new BanCache("pro_eval_" + id, new TimeSpan(0, 0, 10), 1);

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

            int fraction = Fn.IsInt(Req.GetQueryString("star"), 3);
            if (fraction < 0 || fraction > 5)
                fraction = 3;

            string sDetail = Server.HtmlEncode(Req.GetForm("content"));
            if (sDetail.Length > 600)
            {
                msgAjax.Error("above");
                return;
            }

            if (sDetail.Length == 0)
            {
                msgAjax.Error("input");
                return;
            }

            int userID = LoginInfo.UserID;

            string sql = "select (select count(0) from (Ord_Pro op inner join Pro_Info pi on op.FK_Pro=pi.ProSN) left join Ord_Info oi on op.FK_Order=oi.OrdSN where op.FK_Pro={1} and op.FK_User={0} and oi.Status=50) as ordProCount,"
            + "(select count(0) from Pro_Evaluate where FK_User={0} and FK_Pro={1}) as proEvalCount";

            using (IDataReader dr = DbHelp.Read(string.Format(sql, userID, id)))
            {
                if (dr.Read())
                {
                    int ordProCount = int.Parse(dr["ordProCount"].ToString());

                    if (ordProCount == 0)
                    {
                        msgAjax.Error("nobuy");//未订购此产品
                        return;
                    }

                    int proEvalCount = int.Parse(dr["proEvalCount"].ToString());



                    if (proEvalCount >= ordProCount)
                    {
                        msgAjax.Error("has");//已评论此产品
                        return;
                    }
                }
                else
                {
                    msgAjax.Error("error");
                    return;
                }
            }

            Pro_EvaluateM mod = new Pro_EvaluateM();
            mod.FK_User = userID;
            mod.FK_Pro = id;
            mod.Fraction = fraction;
            mod.Detail = sDetail;
            mod.Purview = 0;
            mod.IP = Request.UserHostAddress;

            ProEval_TransM tmod = new ProEval_TransM();
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

        public class ProEval_TransM : WZ.Common.DbHelp.ITransM
        {
            public Pro_EvaluateM mod;
        }

        private int ProEval_Trans(IDbHelp thelp, object obj)
        {
            ProEval_TransM tmod = (ProEval_TransM)obj;
            Pro_EvaluateM mod = tmod.mod;

            string sql = "insert into Pro_Evaluate(FK_User,FK_Pro,Fraction,Detail,Purview,IP) values(@FK_User,@FK_Pro,@Fraction,@Detail,@Purview,@IP)";
            IDataParameter[] dp = { 
                                    DbHelp.Def.AddParam("@FK_User",mod.FK_User),
                                    DbHelp.Def.AddParam("@FK_Pro",mod.FK_Pro),
                                    DbHelp.Def.AddParam("@Fraction",mod.Fraction),
                                    DbHelp.Def.AddParam("@Detail",mod.Detail),
                                    DbHelp.Def.AddParam("@Purview",mod.Purview),
                                    DbHelp.Def.AddParam("@IP",mod.IP),
                                  };

            if (thelp.Update(sql, dp) > 0)
            {
                banH.Add();

                //增加积分或经验
                string sname = DbHelp.First("select ProName from Pro_Info where ProSN=" + mod.FK_Pro);
                User_FractHandler.FractHandlerParam ufParam = new User_FractHandler.FractHandlerParam(mod.FK_User, "system", 1, "pro_eval", "pro_eval", "产品评价 \"" + sname + "\"");
                ufParam.FK_All = mod.FK_Pro;

                string slog = new User_FractHandler(thelp).SetFract(ufParam);
                //string slog = new User_FractHandler(thelp).SetFract(mod.FK_User, "system", 1, "pro_eval", "pro_eval", "产品评价 \"" + sname + "\"");
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

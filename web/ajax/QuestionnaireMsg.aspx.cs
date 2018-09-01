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

namespace WZ.Web.ajax
{
    public partial class QuestionnaireMsg : WZ.Client.Data.General.AjaxPage
    {
        private int id;
        private IMessage msgAjax = new MessageAjaxC();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(Req.GetQueryString("id"), 0);

            Add();

            Response.Write(msgAjax.ReturnMessage);
            Response.End();
        }

        private void Add()
        {
            string sDetail = Server.HtmlEncode(Req.GetForm("content"));

            if (sDetail.Length == 0)
            {
                msgAjax.Error("input");
                return;
            }

            if (sDetail.Length > 600)
            {
                msgAjax.Error("不能超出600字");
                return;
            }

            int userID=0;
            if (!LoginInfo.IsLogin())
            {
                userID = LoginInfo.UserID;
            }
            
            string sSql = "insert into Questionnaire_Msg(FK_User,FK_Questionnaire,Detail,Purview,IP) values(@FK_User,@FK_Questionnaire,@Detail,@Purview,@IP)";
            IDataParameter[] dp = { 
                            DbHelp.Def.AddParam("@FK_User",userID),
                            DbHelp.Def.AddParam("@FK_Questionnaire",id),
                            DbHelp.Def.AddParam("@Detail",sDetail),
                            DbHelp.Def.AddParam("@Purview",0),
                            DbHelp.Def.AddParam("@IP",Request.UserHostAddress),
                                  };

            if (DbHelp.Update(sSql, dp) > 0)
            {
                msgAjax.Success("1");
            }
            else
            {
                msgAjax.Error("nosubmit");
            }
        }
    }
}

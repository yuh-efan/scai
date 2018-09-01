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

namespace WZ.Web.ajax
{
    public partial class taoCanMsg : WZ.Client.Data.General.AjaxPage
    {
        private int t;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            t = Fn.IsInt(Req.GetQueryString("t"), 0);
            id = Fn.IsInt(Req.GetQueryString("id"), 0);

            switch (t)
            {
                case 0://显示
                    GetHtml();
                    break;

                case 1://提交
                    Add();
                    WriteEndJso();
                    break;

                default:
                    jso.Add("info", "null");
                    WriteEndJso();
                    break;
            }
        }

        private void Add()
        {
            if (LoginInfo.IsLogin())
            {
                jso.Add("info", "nologin");
                return;
            }

            string sDetail = Server.HtmlEncode(Req.GetForm("content"));
            if (sDetail.Length > 600)
            {
                jso.Add("info","above");
                return;
            }

            string sSql = "insert into TaoCan_Msg(FK_User,FK_Pro,Detail,Purview,IP) values(@FK_User,@FK_Pro,@Detail,@Purview,@IP)";
            IDataParameter[] dp = { 
                            DbHelp.Def.AddParam("@FK_User",LoginInfo.UserID),
                            DbHelp.Def.AddParam("@FK_Pro",id),
                            DbHelp.Def.AddParam("@Detail",sDetail),
                            DbHelp.Def.AddParam("@Purview",0),
                            DbHelp.Def.AddParam("@IP",Request.UserHostAddress),
                                  };

            if (DbHelp.Update(sSql, dp) > 0)
            {
                jso.Add("info", "success");
            }
            else
            {
                jso.Add("info", "nosubmit:");//没有提交
            }
        }

        private void GetHtml()
        {
            string sSql = "select top 5 ev.Detail,ev.ReDetail,ev.AddDate,ui.UserName from TaoCan_Msg ev left join User_Info ui on ev.FK_User=ui.UserSN where Purview=1 and FK_Pro=" + id + " order by ev.AddDate desc";
            DataTable dt = DbHelp.GetDataTable(sSql);
            Bind.BGRepeater(dt, this.rpMsg);
        }
    }
}

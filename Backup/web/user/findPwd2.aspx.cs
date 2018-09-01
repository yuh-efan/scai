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
using System.Text;
using WZ.Common;

namespace WZ.Web.user
{
    public partial class findPwd2 : WZ.Client.Data.General.BasePage
    {
        private UrlQuery uq = new UrlQuery();
        private string Email;
        private string Key;

        protected void Page_Load(object sender, EventArgs e)
        {
            Email = uq.GetQueryString(0);
            Key = uq.GetQueryString(1);
            if (uq.ToString().Length == 0)
            {
                Js.Alert("非法操作！");
            }

            string sql = "select 1 from User_FindPwdEmail where FPEmail=@FPEmail and FPKey=@FPKey and AddDate>(dateadd(dd,-3,getdate())) order by AddDate desc";
            IDataParameter[] param ={
                                DbHelp.Def.AddParam("@FPEmail",Email),
                                DbHelp.Def.AddParam("@FPKey",Key),
                              };

            string str = DbHelp.First(sql, param);
            if (str.Length == 0)
            {
                stmsg.Text = "<h1 style=\"text-align:center;width:100%;line-height:300px\">此链接已失效</h1>";
                this.form1.Visible = false;
            }
        }

        protected void bOK_Click(object sender, EventArgs e)
        {
            string sPwd = Req.GetForm("cPwd").Trim();
            string sPwdSure = Req.GetForm("cPwdSure").Trim();

            if (sPwd.Length == 0)
                Js.Alert("请输入密码");

            if (sPwd.Length < 5 || sPwd.Length > 30)
                Js.Alert("密码不能小于5到30位数");

            if (sPwdSure.Length == 0)
                Js.Alert("请输入确认密码");

            if (sPwd != sPwdSure)
                Js.Alert("两次密码输入不一致");

            EditPwd_TransM tmod = new EditPwd_TransM();
            tmod.sPwd = sPwd;
            tmod.sPwdSure = sPwdSure;
            tmod.sKey = Key;
            tmod.sEmail = Email;

            DbHelp.ExecuteTrans(new DbHelpParam(), EditPwd_Trans, tmod);

            if (tmod.returnValue == "1")
            {
                Response.Redirect("/user/findPwd3.aspx");
            }
            else
            {
                Js.Alert(tmod.returnValue);
            }
        }

        private class EditPwd_TransM : DbHelp.ITransM
        {
            public string sPwd;
            public string sPwdSure;
            public string sKey;
            public string sEmail;
        }

        private int EditPwd_Trans(IDbHelp thelp, DbHelp.ITransM pMod)
        {
            EditPwd_TransM tmod = (EditPwd_TransM)pMod;

            //查询是否生效
            string sql = "select FK_User from User_FindPwdEmail where FPEmail=@FPEmail and FPKey=@FPKey and AddDate>(dateadd(dd,-3,getdate())) order by AddDate desc";
            IDataParameter[] param ={
                                DbHelp.Def.AddParam("@FPEmail",Email),
                                DbHelp.Def.AddParam("@FPKey",Key),
                              };
            string str = thelp.First(sql, param, "0");
            if (str == "0")
            {
                tmod.returnValue = "此链接已失效";
                return 0;
            }

            //更新密码
            sql = "update User_Info set UserPwd=@UserPwd where UserSN=@UserSN";
            IDataParameter[] param2 ={
                                DbHelp.Def.AddParam("@UserPwd", Fn.MD5(tmod.sPwd)),
                                DbHelp.Def.AddParam("@UserSN",str),
                              };

            //删除用户的找回密码记录
            if (thelp.Update(sql, param2) <= 0)
            {
                tmod.returnValue = "找不到此用户";
                return 0;
            }

            sql = "delete User_FindPwdEmail where FK_User=@FK_User";
            IDataParameter[] param3 ={
                                DbHelp.Def.AddParam("@FK_User",str),
                              };
            if (thelp.Update(sql, param3) <= 0)
            {
                tmod.returnValue = "设置失败";
                return 0;
            }

            tmod.returnValue = "1";
            return 1;
        }
    }
}

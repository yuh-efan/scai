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
using System.Net.Mail;
using WZ.Common.EMail;
using System.Text;
using WZ.Data;

namespace WZ.Web.user
{
    public partial class findPwd1 : WZ.Client.Data.General.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        protected void bOK_Click(object sender, EventArgs e)
        {
            string sName = Fn.EncodeHtml(Req.GetForm("cName").Trim());
            string sMail = Fn.EncodeHtml(Req.GetForm("cMail").Trim());

            if (sName.Length == 0 || sMail.Length == 0 || sName.Length > 30 || sMail.Length > 30)
            {
                Js.Alert("请输入用户名和邮箱,且用户名,邮箱不能超过30个字");
            }

            if (!Fn.IsRegex(sName, Fn.EnumRegex.用户名))
                Js.Alert("用户名有非法字符");

            if (!Fn.IsRegex(sMail, Fn.EnumRegex.电子邮件))
                Js.Alert("邮箱格式不正确");

            string sql = "select UserSN from User_Info where UserName=@UserName and Email=@Email";
            IDataParameter[] param ={
                                    DbHelp.Def.AddParam("@UserName",sName),
                                    DbHelp.Def.AddParam("@Email",sMail),
                                   };

            string str = DbHelp.First(sql, param,"0");
            if (str == "0")
            {
                Js.Alert("不存在此账号");
            }
            else
            {
                string Key = Guid.NewGuid().ToString();
                Key = Key.Substring(0, 8) + Key.Substring(24, 12);
                sql = "insert into User_FindPwdEmail(FK_User,FPEmail,FPKey)values(@FK_User,@FPEmail,@FPKey)";
                IDataParameter[] param2 ={
                                    DbHelp.Def.AddParam("@FK_User",str),
                                    DbHelp.Def.AddParam("@FPEmail",sMail),
                                    DbHelp.Def.AddParam("@FPKey", Key),
                                   };

                if (DbHelp.Update(sql, param2) > 0)
                {
                    string p = string.Format("{0}-{1}", sMail, Key);

                    //发送邮件
                    string url = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") + "/email/findPwd.aspx?s=" + p;
                    string sText = Fn.GetPageHtml(url);

                    User_InfoL.SendEmail(sMail, "找回密码", sText);

                    //sendEmail(sMail, " 找回密码", p);
                    Js.Write("alert('电子邮件已发送，请登入邮箱按照邮件提示操作。');top.open('http://mail." + sMail.Split('@')[1] + "');top.history.go(-1)");
                }
            }
        }

        //private void sendEmail(string pUserName, string sTitle, string pParam)
        //{
        //    string url = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") + "/email/findPwd.aspx?s=" + pParam;
        //    string s = Fn.GetPageHtml(url);

        //    MailAddress mailFrom = new MailAddress(EmailInfo.eInfo.SelfAddress, EmailInfo.eInfo.SelfName);
        //    MailAddress mailTo = new MailAddress(pUserName);
        //    MailParam param = new MailParam(EmailInfo.eInfo.SelfServer, mailFrom, EmailInfo.eInfo.SelfPwd, mailTo, sTitle, s, null);
        //    param.SmtpPort = EmailInfo.eInfo.Port;
        //    param.EnableSsl = EmailInfo.eInfo.EnableSsl;

        //    MailHandler mh = new MailHandler();
        //    mh.SendSmtpEMail(param);

        //    //MailAddress mailFrom = new MailAddress("yuhua19871132@gmail.com", "搜菜网");
        //    //MailAddress mailTo = new MailAddress(pUserName);
        //    //MailHandler mh = new MailHandler();
        //    //MailParam param = new MailParam("smtp.gmail.com", mailFrom, "13575685774", mailTo, sTitle, s, null);
        //    //param.SmtpPort = 587;
        //    //param.EnableSsl = true;
        //    //mh.SendSmtpEMail(param);
        //}

        private void LL()
        {

        }
    }
}

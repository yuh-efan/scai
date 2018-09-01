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
using System.Text;
using WZ.Model;
using WZ.Client.Data;
using WZ.Data;
using System.Net.Mail;
using WZ.Common.EMail;
using WZ.Common.ICommon;

namespace WZ.Web.user
{
    public partial class reg : WZ.Client.Data.General.BasePage
    {
        protected string url;
        private IMessage msgAjax = new MessageAjax();

        protected void Page_Load(object sender, EventArgs e)
        {
            string hid = Req.GetForm("hid");
            if (hid == "1")
            {
                string cmd = Req.GetForm("cmd");
                if (cmd == "reg")
                {
                    Reg();
                }
                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }

            if (!this.IsPostBack)
            {
                url = Req.GetQueryString("url");
                if (url.Length == 0)
                    url = Req.GetUrlReferrer("/");
                url = Server.UrlEncode(url);//新加
            }
        }

        private void Reg()
        {
            if (Req.GetForm("cCode").Length == 0)
            {
                msgAjax.Error("code.input;");
            }
            else
            {
                if (!Fn.IsVerifyCode1("cCode", "uverify"))
                    msgAjax.Error("code.wrong;");
            }

            string sName = Fn.EncodeHtml(Req.GetForm("cName").Trim());
            string sEmail = Fn.EncodeHtml(Req.GetForm("cEmail").Trim());
            string sPwd = Req.GetForm("cPwd").Trim();
            string sPwdSure = Req.GetForm("cPwdSure").Trim();
            string sCard = Fn.EncodeHtml(Req.GetForm("cCard").Trim());
            string sPromoter = Req.GetForm("cPromoter").Trim();
            
            //用户名
            if (sName.Length == 0)
            {
                msgAjax.Error("name.input;");//请输入用户名
            }
            else
            {
                if (sName.Length < 5 || sName.Length > 30)
                {
                    msgAjax.Error("name.above;");//用户名须在5-30个字符之间
                }
                else
                {
                    if (!Fn.IsRegex(sName, Fn.EnumRegex.用户名))
                    {
                        msgAjax.Error("name.format;");//用户名格式不正确
                    }
                    else
                    {
                        if (User_InfoL.IsUserName(sName))
                        {
                            msgAjax.Error("name.has;");//此用户名已被注册，请重新输入用户名
                        }
                    }
                }
            }

            //邮箱
            if (sEmail.Length == 0)
            {
                msgAjax.Error("email.input;");//请输入邮箱
            }
            else
            {
                if (sEmail.Length < 5 || sEmail.Length > 30)
                {
                    msgAjax.Error("email.above;");//邮箱须在5-30个字符之间
                }
                else
                {
                    if (!Fn.IsRegex(sEmail, Fn.EnumRegex.电子邮件))
                    {
                        msgAjax.Error("email.format;");//邮箱格式不正确
                    }
                    else
                    {
                        if (User_InfoL.IsEmail(sEmail))
                        {
                            msgAjax.Error("email.has;");//此邮箱名已被注册，请重新输入用户名
                        }
                    }
                }
            }

            //密码
            if (sPwd.Length == 0)
            {
                msgAjax.Error("pwd.input;");//请输入密码
            }
            else
            {
                if (sPwd.Length < 5 || sPwd.Length > 30)
                {
                    msgAjax.Error("pwd.above;");//密码不能小于5位数
                }
            }

            //确认密码
            if (sPwdSure.Length == 0)
            {
                msgAjax.Error("pwd1.input;");//请输入确认密码
            }
            else
            {
                if (sPwd != sPwdSure)
                {
                    msgAjax.Error("pwd1.notEqual;");//两次密码输入不一致
                }
            }

            //会员卡号
            int exp = 0;
            if (sCard.Length > 0)
            {
                if (!Activity_InfoL.IsOpen("user_card"))
                {
                    msgAjax.Error("card.clo;");
                    return;
                }

                if (!User_CardL.IsUse(sCard, out exp))
                {
                    msgAjax.Error("card.wrong;");
                    return;
                }

                if (exp <= 0)
                {
                    msgAjax.Error("card.wrong;");
                    return;
                }
            }

            //推广员号码
            int UserBTJ = 0;
            if (sPromoter.Length > 0)
            {
                int iPromoter;

                if (!int.TryParse(sPromoter, out iPromoter))
                {
                    msgAjax.Error("promoter.wrong;");
                    return;
                }

                if (!Activity_InfoL.IsOpen("user_promoter"))
                {
                    msgAjax.Error("promoter.clo;");
                    return;
                }

                if (!User_InfoL.IsUserPromoter(iPromoter))
                {
                    msgAjax.Error("promoter.wrong;");
                    return;
                }

                UserBTJ = iPromoter;
            }
            
            if (msgAjax.IsError)
                return;

            User_InfoM infoMod = new User_InfoM();
            infoMod.UserName = sName;
            infoMod.UserPwd = Fn.MD5(sPwd);
            infoMod.LastLoginIP = Request.UserHostAddress;
            infoMod.OpenIdentity = 1;//个人用户
            infoMod.FK_User_Level = User_LevelL.GetDefaultLevel();
            infoMod.Email = sEmail;
            infoMod.UserCard = sCard;
            infoMod.UserBTJ = UserBTJ;

            User_PersonalM perMod = new User_PersonalM();

            User_InfoL.Reg_TransM lsTrans = new User_InfoL.Reg_TransM();
            lsTrans.infoMod = infoMod;
            lsTrans.perMod = perMod;
            if (exp > 0)
            {
                lsTrans.IsUseCard = true;
                lsTrans.Exp = exp;
            }

            DbHelp.ExecuteTrans(new DbHelpParam(), User_InfoL.Reg_Trans, lsTrans);

            if (lsTrans.returnValue == "1")
            {
                User_Info.Login(sName, sPwd);
                Session.Remove("uverify");
                int isSend = 0;
                try
                {
                    string url = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") + "/email/regSuccess.aspx?un=" + sName;
                    string sText = Fn.GetPageHtml(url);

                    User_InfoL.SendEmail(sEmail, sName + " 您好,您在搜菜网已成功注册会员", sText);
                    isSend = 1;
                }
                catch
                { }

                msgAjax.Success(isSend.ToString());
            }
            else
            {
                msgAjax.Error(lsTrans.returnValue);
            }
        }


    }
}

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
using WZ.Data.DataItem;
using WZ.Data;
using WZ.Model;
using WZ.Client.Data;
using System.Net.Mail;
using WZ.Common.EMail;

namespace WZ.Web.content.propaganda
{
    public partial class reg : System.Web.UI.Page
    {
        private IMessage msgAjax = new MessageAjax();

        private ItemHandler ih_Sex = new ItemHandler("Sex");
        protected string pageSex;

        protected void Page_Load(object sender, EventArgs e)
        {
            int hid = Fn.IsInt(Req.GetForm("hid"), 0);
            if (hid > 0)
            {
                string cmd = Req.GetForm("cmd");
                switch (cmd)
                {
                    case "reg":
                        Reg();
                        break;
                }

                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }

            LL();
        }

        private void LL()
        {
            pageSex = Bind.GetHtmlRadio(ih_Sex.GetItemList(), "cSex", "1");
        }

        private void Reg()
        {
            if (Req.GetForm("cIsAgree") != "1")
            {
                msgAjax.Error("必需同意[搜菜网用户注册协议]才能注册;");
                return;
            }

            if (!Fn.IsVerifyCode1("cCode", "uverify"))
            {
                msgAjax.Error("code.wrong;");
                return;
            }

            string cname = Fn.EncodeHtml(Req.GetForm("cname").Trim());
            string email = Fn.EncodeHtml(Req.GetForm("email").Trim());
            string pwd = Req.GetForm("pwd").Trim();
            string pwd1 = Req.GetForm("pwd1").Trim();
            string realname = Fn.EncodeHtml(Req.GetForm("realname").Trim());
            string sSex = Req.GetForm("cSex").Trim();
            string sArea = Req.GetForm("cArea").Trim();
            string address = Fn.EncodeHtml(Req.GetForm("address").Trim());
            string tel = Fn.EncodeHtml(Req.GetForm("tel").Trim());
            string telfix = Fn.EncodeHtml(Req.GetForm("telfix").Trim());
            string sCard = Fn.EncodeHtml(Req.GetForm("card").Trim());
            string sPromoter = Req.GetForm("cPromoter").Trim();

            //用户名
            if (cname.Length == 0)
            {
                msgAjax.Error("请输入用户名;");
            }
            else
            {
                if (cname.Length < 5 || cname.Length > 30)
                {
                    msgAjax.Error("用户名需在5-30个字符之间;");
                }
                else
                {
                    if (!Fn.IsRegex(cname, Fn.EnumRegex.用户名))
                    {
                        msgAjax.Error("用户名中有非法字条;");
                    }
                    else
                    {
                        if (User_InfoL.IsUserName(cname))
                        {
                            msgAjax.Error("此用户名已被注册，请重新输入;");
                        }
                    }
                }
            }

            if (email.Length == 0)
            {
                msgAjax.Error("请输入邮箱;");
            }
            else
            {
                if (email.Length < 5 || email.Length > 30)
                {
                    msgAjax.Error("邮箱需在5-30个字符之间;");
                }
                else
                {
                    if (!Fn.IsRegex(email, Fn.EnumRegex.电子邮件))
                    {
                        msgAjax.Error("邮箱格式不正确;");
                    }
                    else
                    {
                        if (User_InfoL.IsEmail(email))
                        {
                            msgAjax.Error("此邮箱名已被注册，请重新输入;");
                        }
                    }
                }
            }

            if (pwd.Length == 0)
            {
                msgAjax.Error("请输入密码;");
            }
            else
            {
                if (pwd.Length < 5 || pwd.Length > 30)
                {
                    msgAjax.Error("密码需在5-30位数之间;");
                }
                else
                {
                    if (pwd1.Length == 0)
                    {
                        msgAjax.Error("请输入确认密码;");
                    }
                    else
                    {
                        if (pwd != pwd1)
                            msgAjax.Error("两次密码输入不一致;");
                    }
                }
            }

            //会员卡号
            int exp = 0;
            if (sCard.Length > 0)
            {
                if (!Activity_InfoL.IsOpen("user_card"))
                {
                    msgAjax.Error("会员卡活动已关闭;");
                    return;
                }

                if (!User_CardL.IsUse(sCard, out exp))
                {
                    msgAjax.Error("会员卡错误或不存在此卡号;");
                    return;
                }

                if (exp <= 0)
                {
                    msgAjax.Error("会员卡错误或不存在此卡号;");
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
                    msgAjax.Error("推广员号码错误或不存在此推广员;");
                    return;
                }

                if (!Activity_InfoL.IsOpen("user_promoter"))
                {
                    msgAjax.Error("注册推广员活动已关闭;");
                    return;
                }

                if (!User_InfoL.IsUserPromoter(iPromoter))
                {
                    msgAjax.Error("推广员号码错误或不存在此推广员;");
                    return;
                }

                UserBTJ = iPromoter;
            }

            if (realname.Length > 30)
                msgAjax.Error("联系人不超过30个字;");

            if (tel.Length > 25)
                msgAjax.Error("手机不超过25字;");

            if (telfix.Length > 25)
                msgAjax.Error("固定电话不超过25字;");

            if (address.Length > 300)
                msgAjax.Error("地址不超过300字;");

            int iArea = Fn.IsInt(sArea, 0);
            if (iArea < 0)
                msgAjax.Error("非法操作;");
            else if (iArea > 0)
            {
                if (ClassData.HasNext("Pub_Area", iArea))
                    msgAjax.Error("请选择最后一级分类;");
            }

            //if (tel.Length == 0 && telfix.Length == 0)
            //{
            //    msgAjax.Error("手机和固定电话必填一个;");
            //}

            if (msgAjax.IsError)
                return;

            //账号信息
            User_InfoM infoMod = new User_InfoM();
            infoMod.FK_User_Level = User_LevelL.GetDefaultLevel();
            infoMod.UserName = cname;
            infoMod.UserPwd = Fn.MD5(pwd);
            infoMod.LastLoginIP = Request.UserHostAddress;
            infoMod.OpenIdentity = 1;//个人用户
            infoMod.Email = email;
            infoMod.UserCard = sCard;
            infoMod.UserBTJ = UserBTJ;

            //个人用户信息
            User_PersonalM perMod = new User_PersonalM();
            perMod.RealName = realname;
            perMod.Sex = byte.Parse(sSex);
            perMod.Area = iArea;
            perMod.Address = address;
            perMod.FixTel = telfix;
            perMod.Tel = tel;

            //收货信息
            User_ContactM conMod = new User_ContactM();
            conMod.FK_Area = iArea;
            conMod.Name = realname;
            conMod.Address = address;
            conMod.FixTel = telfix;
            conMod.Tel = tel;

            //事务类
            User_InfoL.Reg1_TransM lsTrans = new User_InfoL.Reg1_TransM();
            lsTrans.infoMod = infoMod;
            lsTrans.perMod = perMod;
            lsTrans.conMod = conMod;
           
            if (exp > 0)
            {
                lsTrans.IsUseCard = true;
                lsTrans.Exp = exp;
            }
            DbHelp.ExecuteTrans(new DbHelpParam(), User_InfoL.Reg1_Trans, lsTrans);

            if (lsTrans.returnValue == "1")
            {
                Session.Remove("uverify");
                User_Info.Login(cname, pwd);

                int isSend = 0;
                try
                {
                    string url = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") + "/email/regSuccess.aspx?un=" + cname;
                    string sText = Fn.GetPageHtml(url);

                    User_InfoL.SendEmail(email, cname + " 您好,您在搜菜网已成功注册会员", sText);
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

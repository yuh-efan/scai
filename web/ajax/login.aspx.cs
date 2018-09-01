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
using WZ.Data.ClientAction;
using WZ.Common.Config;

/*
 * 会员登录
 * 
 * */
namespace WZ.Web.ajax
{
    public partial class login : WZ.Client.Data.General.AjaxPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginInfo.banHandler.IsBan())
            {
                if (!Fn.IsVerifyCode("cCode", "uverify"))
                {
                    jso.Add("err", "验证码输入错误");
                    jso.Add("v", "1");//前台是否刷新 显示 验证码
                    WriteEndJso();
                }
            }

            string UserName = Req.GetForm("cName").Trim();
            string UserPwd = Req.GetForm("cPwd").Trim();
            if (UserName.Length > Constant.MaxCount_UserName)
            {
                UserName = UserName.Substring(0, Constant.MaxCount_UserName);
            }

            if (UserName.Length == 0)
            {
                jso.Add("err", "请输入用户名");
                WriteEndJso();
            }

            if (UserPwd.Length == 0)
            {
                jso.Add("err", "请输入密码");
                WriteEndJso();
            }

            if (User_Info.Login(UserName, UserPwd))
            {
                jso.Add("success", "登录成功");
                WriteEndJso();
            }
            else
            {
                if (LoginInfo.banHandler.IsBan())
                    jso.Add("v", "1");
                jso.Add("err", "用户名或密码错误");
                WriteEndJso();
            }

        }
    }
}

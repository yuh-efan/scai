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
using WZ.Data;

/*
 * 验证用户名,邮箱,验证码等
 * 
 * */
namespace WZ.Web.ajax
{
    public partial class checkInfo : Page
    {
        private int t;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";

            t = Fn.IsInt(Req.GetQueryString("t"), 0);

            switch (t)
            { 
                case 0://用户名
                    CheckUserName();
                    break;

                case 1://邮箱
                    CheckEmail();
                    break;

                case 2://验证码
                    CheckCode();
                    break;

                default:
                    CheckUserName();
                    break;
            }
        }

        private void CheckCode()
        {
            bool b = true;
            string strCode = Req.GetQueryString("s");
            string strCode1 = Req.GetSession("uverify");

            if (strCode.Length == 0 || (string.Compare(strCode, strCode1, true) != 0))
            {
                b = false;
            }

            if (b)
                Response.Write('1');//正确
            else
                Response.Write('0');//错误
        }

        private void CheckUserName()
        {
            string s = Req.GetQueryString("s");
            if (!Fn.IsRegex(s, Fn.EnumRegex.用户名))
            {
                Response.Write('2');//格式不正确
                Response.End();
            }

            if (User_InfoL.IsUserName(s))
                Response.Write('1');
            else
                Response.Write('0');
        }

        private void CheckEmail()
        {
            string s = Req.GetQueryString("s");
            if (!Fn.IsRegex(s, Fn.EnumRegex.电子邮件))
            {
                Response.Write('2');//格式不正确
                Response.End();
            }

            if (User_Info.IsEmail(s))
                Response.Write('1');//已存在
            else
                Response.Write('0');//不存
        }
    }
}
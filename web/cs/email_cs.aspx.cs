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
using WZ.Common.EMail;
using System.Net.Mail;
using System.Collections.Generic;
using WZ.Common;
using System.Net;
using System.IO;
using System.Text;

namespace WZ.Web.cs
{
    public partial class email_cs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //WZ.Web.email.reg_success d = new WZ.Web.email.reg_success();
            //d.LL();
            //Response.Write(d.f);
            Response.Write(Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath,"") + "/default.aspx");
            //Response.Write(Request.Url.AbsoluteUri + "/default.aspx");

            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") + "/email/regSuccess.aspx?un=suger";
            string s = Fn.GetPageHtml(url);

            MailAddress mailFrom = new MailAddress("sugercgqtest@gmail.com", "搜菜网");
            MailAddress mailTo = new MailAddress(toMail.Text);
            MailHandler mh = new MailHandler();
            MailParam param = new MailParam("smtp.gmail.com", mailFrom, "pmsJ1293", mailTo, title.Text, s, null);
            param.SmtpPort = 587;
            param.EnableSsl = true;
            mh.SendSmtpEMail(param);
            Response.Write("成功1");
        }
    }
}

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
using WZ.Data;
using WZ.Common.ICommon;
using WZ.Common;

namespace WZ.Web.ajax
{
    public partial class checkCard : WZ.Client.Data.General.AjaxPage
    {
        private IMessage msgAjax = new MessageAjaxC();
        private string number;

        protected void Page_Load(object sender, EventArgs e)
        {
            number = Fn.EncodeHtml(Req.GetQueryString("number"));

            check();
            Response.Write(msgAjax.ReturnMessage);
            Response.End();
        }

        private void check()
        {
            if (!Activity_InfoL.IsOpen("user_card"))
            {
                msgAjax.Error("card.clo");
                return;
            }

            int exp;
            if (!User_CardL.IsUse(number, out exp))
            {
                msgAjax.Error("card.wrong");
                return;
            }

            if (exp <= 0)
            {
                msgAjax.Error("card.wrong");
                return;
            }

            msgAjax.Success("1");
        }
    }
}

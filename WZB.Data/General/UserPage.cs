using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WZ.Common;
using WZ.Common.ICommon;

namespace WZ.Client.Data.General
{
    public abstract class PageUser : BasePage
    {
        protected IMessage msgAjax = new MessageAjaxC();
        protected override void OnPreInit(EventArgs e)
        {
            if (LoginInfo.NoLogin(msgAjax))
            {
                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }
            //base.OnPreInit(e);
        }
    }

    //public abstract class PageUserOutVar : PageUser
    //{
    //    protected override void OnPreInit(EventArgs e)
    //    {
    //        base.OnPreInit(e);
    //        OutVar();
    //    }


    //    public abstract void OutVar();
    //}
}

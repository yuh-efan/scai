using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace WZ.Common
{
    public class MessageAjaxJs
    {
        private bool IsAjaxValidator = false;
        private Page page;

        public MessageAjaxJs(bool pIsAjaxValidator, Page pPage)
        {
            this.IsAjaxValidator = pIsAjaxValidator;
            this.page = pPage;
        }

        public string WriteJS1(string pClientCallBack)
        {
            return WriteJS1("cmd", pClientCallBack,  false, true);
        }

        public string WriteJS1(string pClientCallBack, bool pIsLoading)
        {
            return WriteJS1("cmd", pClientCallBack,  false, pIsLoading);
        }

        public string WriteJS1(string pEventArgument, string pClientCallBack)
        {
            return WriteJS1(pEventArgument, pClientCallBack,  false, true);
        }

        public string WriteJS1(string pEventArgument, string pClientCallBack, bool pIsAjax)
        {
            return WriteJS1(pEventArgument, pClientCallBack,  pIsAjax, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEventArgument">参数</param>
        /// <param name="pClientCallBack"></param>
        /// <param name="pIsAjax">是否无视 if(!IsAjaxValidator) return true; 存在</param>
        /// <param name="pIsLoading"></param>
        /// <returns></returns>
        public string WriteJS1(string pEventArgument, string pClientCallBack,bool pIsAjax, bool pIsLoading)
        {
            return ((IsAjaxValidator && pIsLoading) ? "message.Loading();" : string.Empty)
                + (pIsAjax ? string.Empty : "if(!__isajaxpost) return true;")
                + "__ajax_exe(" + pEventArgument + "," + pClientCallBack + ");"
                 + "return false;";
        }

        public void PageScript()
        {
            string t = IsAjaxValidator ? "true" : "false";
            this.page.ClientScript.RegisterClientScriptBlock(this.page.GetType(), "test", "<script type=\"text/javascript\">var __isajaxpost=" + t + ";</script><div id=\"__ajax_error_html\"></div>");
           
        }
    }
}

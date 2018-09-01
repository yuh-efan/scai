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
using System.Reflection;

namespace WZ.Web.cs
{
    public partial class callback : System.Web.UI.Page, ICallbackEventHandler
    {
        private string aaa;

        private MessageAjax Message = new MessageAjax();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ClientScript.GetCallbackEventReference(this, "pStr", "callBack", null);
            if (!IsPostBack)
            {
                //this.ClientScript.GetCallbackEventReference(this, "'aa1|'+pStr", "callBack", "aa");
                this.ClientScript.GetCallbackEventReference(this, "'aa1|'+pStr", "callBack", "aa", true);
                //Config.cs.i++;
            }
            else
            {
                //Config.cs.s = Req.GetForm("cTxt");
                //Config.cs.i+=2;
            }
        }

        protected void bOK_Click1(object sender, EventArgs e)
        {



            //HttpFileCollection hfc = // HttpContext.Current.Request.Files;
            //Response.Write(hpf.FileName);

            string sMsg = ValidatorData("提交1");
            //new MessageGeneral().Error(sMsg);
        }

        protected void bOK_Click2(object sender, EventArgs e)
        {
            string sMsg = ValidatorData("提交2");
            //new MessageGeneral().Error(sMsg);
        }

        private string ValidatorData(string pS)
        {
            string sMsg = "ssss--" + pS;
            //Config.cs.i += 1;
            return sMsg;
            

            //Add();
        }

        public string aa1(string pStr)
        {
            WZ.Common.Config.cs.i += 1;
            return pStr + DateTime.Now.ToString();
        }

        private string _callbackEventArgument;
        public string GetCallbackResult1()
        {
            string[] parts = _callbackEventArgument.Split('|');
            object[] args = null;
            string result = "";

            if (parts.Length > 1)
            {
                args = new object[parts.Length - 1];
                Array.Copy(parts, 1, args, 0, args.Length);
                
            }
            WZ.Common.Config.cs.i += 5;
            WZ.Common.Config.cs.s = parts[1];

            MethodInfo method = this.GetType().GetMethod(parts[0]);

            if (method != null)
            {
                result = (string)method.Invoke(this, args);
            }

            return result;
        } 

        #region ICallbackEventHandler 成员

        public string GetCallbackResult()
        {
            return Req.GetRequest("cTxt");
            //return aaa;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            _callbackEventArgument = eventArgument;
            
            //string sTxt = Req.GetRequest("cTxt");
            //new MessageGeneral().Error(ValidatorData("2"));
            //aaa = Message.ReturnMessage + sTxt;
        }

        #endregion
    }
}

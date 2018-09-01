using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Common
{
    public class MessageGeneral : ICommon.IMessage
    {
        public enum MessageEnum
        {
            出现以下错误信息 = 0,
            成功信息 = 1,
            提示信息 = 2,
        }

        public static readonly string[] MessageTitle = { 
                                                     "出现以下错误信息:",
                                                     "成功信息:",
                                                     "提示信息:",
                                                 };

        public static readonly string[] MessageType = { 
                                                     "error",
                                                     "success",
                                                     "message",
                                                 };


        private string returnMessage = string.Empty;

        public string ReturnMessage
        {
            get { return this.returnMessage; }
        }

        /// <summary>
        /// 出错信息
        /// </summary>
        /// <param name="pErrMsg"></param>
        public void Error(string pErrMsg)
        {

            if (pErrMsg.Length > 0)
                WriteMessage(ref pErrMsg, string.Empty, MessageGeneral.MessageEnum.出现以下错误信息);
        }

        /// <summary>
        /// 出错信息 有路径
        /// </summary>
        /// <param name="pErrMsg"></param>
        /// <param name="pPath"></param>
        public void Error(string pErrMsg, string pPath)
        {
            if (pErrMsg.Length > 0)
                WriteMessage(ref pErrMsg, pPath, MessageGeneral.MessageEnum.出现以下错误信息);
        }

        /// <summary>
        /// 成功信息
        /// </summary>
        /// <param name="pErrMsg"></param>
        public void Success(string pErrMsg)
        {
            if (pErrMsg.Length > 0)
                WriteMessage(ref pErrMsg, string.Empty, MessageGeneral.MessageEnum.成功信息);
        }

        /// <summary>
        /// 成功信息
        /// </summary>
        /// <param name="pErrMsg"></param>
        /// <param name="pPath"></param>
        public void Success(string pErrMsg, string pPath)
        {
            if (pErrMsg.Length > 0)
                WriteMessage(ref pErrMsg, pPath, MessageGeneral.MessageEnum.成功信息);
        }

        public void AddMessage(string pKey, string pMsg)
        {

        }

        public void WriteMessage(ref string pMsg, string pPath, MessageGeneral.MessageEnum pEM)
        {
            string sTitle = MessageGeneral.MessageTitle[(int)pEM];
            string sType = MessageGeneral.MessageType[(int)pEM];
            WriteMessage(sTitle, ref pMsg, pPath, sType);
        }

        public void WriteMessage(string pTitie, ref string pMsg, string pPath, string pType)
        {
            const string str0 = "<br><br> <a name=\"back1\" id=\"back1\" href=\"{0}\">按回车 返回</a>";
            const string str1 = "<div style=\"font-size:12px;padding-left:200px;\"><span style=\"color:#ff0000; font-size:14px;\">";
            const string str2 = "<ul style=\"list-style-type:decimal\">";
            const string str3 = "<script type=\"text/javascript\">document.getElementById('back1').focus();</script>";

            HttpContext.Current.Response.Write(Config.HTML.C_H1);
            HttpContext.Current.Response.Write(str1);
            HttpContext.Current.Response.Write(pTitie + "</span>");

            HttpContext.Current.Response.Write(str2);
            string[] p = pMsg.TrimEnd(';').Split(';');
            if (pPath.Length == 0)
            {
                foreach (string s in p)
                {
                    HttpContext.Current.Response.Write("<li>");
                    HttpContext.Current.Response.Write(s);
                    HttpContext.Current.Response.Write("</li>");
                }

                string ss = Req.GetUrlReferrer("");
                if (ss.Length > 0)
                    ss = "javascript:location.href='" + ss + "'";
                else
                    ss = "javascript:history.back();";
                HttpContext.Current.Response.Write(string.Format(str0, ss));
            }
            else
            {
                foreach (string s in p)
                {
                    HttpContext.Current.Response.Write("<li>");
                    HttpContext.Current.Response.Write(s);
                    HttpContext.Current.Response.Write("</li>");
                }

                HttpContext.Current.Response.Write(string.Format(str0, pPath));
            }

            HttpContext.Current.Response.Write(str3);
            HttpContext.Current.Response.Write("</ul>");
            HttpContext.Current.Response.Write("</div>");
            HttpContext.Current.Response.Write(Config.HTML.C_H2);
            HttpContext.Current.Response.End();
        }

        public void Write(string pErrMsg)
        {
            if (pErrMsg.Length > 0)
                WriteMessage(ref pErrMsg, string.Empty, MessageGeneral.MessageEnum.提示信息);
        }

        #region IMessage 成员


        public bool IsError
        {
            get
            {
                //必须false 否则MessageAjax自动切换MessageGeneral模式时将永远验证不通过
                return false;
            }
        }

        #endregion

        #region IMessage 成员


        public bool IsSuccess
        {
            get { throw new NotImplementedException(); }
        }

        public string GetInfo
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}

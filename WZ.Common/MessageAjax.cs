using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace WZ.Common
{
    public class MessageAjax : ICommon.IMessage
    {
        private string returnMessageTemp = string.Empty;

        private JavaScriptObject jso = new JavaScriptObject();

        public string ReturnMessage
        {
            get
            {
                object o;
                if (jso.TryGetValue("info", out o))
                {
                    jso["info"] = o.ToString().TrimEnd(';');
                }
                
                return JavaScriptConvert.SerializeObject(jso);
            }
        }

        public string GetInfo
        {
            get
            {
                object o;
                if (jso.TryGetValue("info", out o))
                {
                    return o.ToString().TrimEnd(';');
                }

                return string.Empty;
            }
        }

        //public bool HasMsg
        //{
        //    get { return jso.ContainsKey("info"); }
        //}

        public bool IsError
        {
            get
            {
                object o;
                if (jso.TryGetValue("type", out o))
                {
                    if (o.ToString() == "error")
                        return true;
                }
                return false;
            }
        }

        public bool IsSuccess
        {
            get
            {
                object o;
                if (jso.TryGetValue("type", out o))
                {
                    if (o.ToString() == "success")
                        return true;
                }
                return false;
            }
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

        public void Write(string pErrMsg)
        {
            if (pErrMsg.Length > 0)
                WriteMessage(ref pErrMsg, string.Empty, MessageGeneral.MessageEnum.提示信息);
        }

        /// <summary>
        /// json 添加
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pMsg"></param>
        public void AddMessage(string pKey, string pMsg)
        {
            if (jso.ContainsKey(pKey))
            {
                jso[pKey] = pMsg;
            }
            else
            {
                jso.Add(pKey, pMsg);
            }
        }

        public void WriteMessage(ref string pMsg, string pPath, MessageGeneral.MessageEnum pEM)
        {
            string sTitle = MessageGeneral.MessageTitle[(int)pEM];
            string sType = MessageGeneral.MessageType[(int)pEM];

            WriteMessage(sTitle, ref pMsg, pPath, sType);
        }

        public void WriteMessage(string pTitie, ref string pMsg, string pPath, string pType)
        {
            if (pType.Length == 0)
                throw new Exception("信息类型 MessageType 不能为空");

            //标题
            if (!jso.ContainsKey("title"))
            {
                if (pTitie.Length == 0)
                    pTitie = "信息提示";

                jso.Add("title", pTitie);
            }

            //显示内容
            this.returnMessageTemp += pMsg;
            if (jso.ContainsKey("info"))
            {
                jso["info"] = this.returnMessageTemp;
            }
            else
            {
                jso.Add("info", this.returnMessageTemp);
            }

            //跳转路径
            if (pPath.Length > 0)
            {
                if (!jso.ContainsKey("path"))
                {
                    jso.Add("path", pPath);
                }
            }

            //信息类型
            if (!jso.ContainsKey("type"))
            {
                jso.Add("type", pType);
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Reflection;
using System.Web;

namespace WZ.Common
{
    /// <summary>
    /// 快速获取表单值,已过时
    /// </summary>
    public class ReqHandle
    {
        private NameValueCollection nvc;
        private string prefix;
        private Dictionary<string, string> dirc;

        /// <summary>
        /// 是否运行过IsRun_ReqToDirc方法
        /// </summary>
        private bool IsRun_ReqToDirc = false;

        /// <summary>
        /// NameValueCollection所有数据
        /// </summary>
        public Dictionary<string, string> Dirc
        { get { return this.dirc; } }

        public string Text(string pName)
        {
            string s = this.prefix + pName;

            if (!dirc.ContainsKey(s))
                dirc.Add(s, string.Empty);

            return Dirc[s];
        }

        public void SetText(string pName, string pValue)
        {
            string s = this.prefix + pName;

            if (dirc.ContainsKey(s))
                dirc[s] = pValue;
            else
                dirc.Add(s, pValue);
        }

        public ReqHandle()
        {
            this.nvc = HttpContext.Current.Request.Form;
            this.prefix = "c";
        }

        public ReqHandle(NameValueCollection pNvc, string pPrefix)
        {
            this.nvc = pNvc;
            this.prefix = pPrefix;
        }

        /// <summary>
        /// 将指定的NameValueCollection所有数据添加到Dictionary string, string 
        /// </summary>
        /// <returns></returns>
        public int ReqToDirc()
        {
            return ReqToDirc(new Dictionary<string, string>());
        }

        /// <summary>
        /// 将指定的NameValueCollection所有数据添加到Dictionary string, string 
        /// </summary>
        /// <param name="pDirc">需要替换的NameValueCollection key值</param>
        /// <returns></returns>
        public int ReqToDirc(Dictionary<string, string> pDirc)
        {
            dirc = new Dictionary<string, string>();
            foreach (string s in nvc.Keys)
            {
                if (pDirc.ContainsKey(s))
                    dirc.Add(pDirc[s], nvc[s]);
                else
                    dirc.Add(s, nvc[s]);
            }

            IsRun_ReqToDirc = true;

            return nvc.Count;
        }

        #region 存到Object
        /// <summary>
        /// 保存到Object
        /// </summary>
        /// <param name="t"></param>
        public int ToObject(object t)
        {
            if (!IsRun_ReqToDirc)
                throw new Exception("请先运行此对象的 ReqToDirc() 方法");

            Type type = t.GetType();

            int tempN = 0;
            string tempName;//名称
            string tempReqValue;//值
            PropertyInfo[] arrPi = type.GetProperties();
            foreach (PropertyInfo pi in arrPi)
            {
                tempName = prefix + pi.Name;

                if (!dirc.ContainsKey(tempName))
                    continue;

                tempReqValue = dirc[tempName];

                try
                {
                    pi.SetValue(t, Convert.ChangeType(tempReqValue, pi.PropertyType), null);//赋值
                    tempN++;
                }
                catch (Exception e)
                {
                    throw new Exception("系统异常提示:" + tempName + "=" + tempReqValue + " " + e.Message);
                }
            }
            return tempN;
        }
        #endregion
    }
}

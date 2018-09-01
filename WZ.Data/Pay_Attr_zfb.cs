using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;

namespace WZ.Data
{
    /// <summary>
    /// 支付宝
    /// </summary>
    public class Pay_Attr_zfb : WZ.Data.IData.IPay
    {
        private Dictionary<string, string> dirc = new Dictionary<string, string>();

        public Pay_Attr_zfb()
        {
            dirc.Add("Account", "支付宝帐号");
        }

        public Dictionary<string, string> attrName
        {
            get { return dirc; }
            set { this.dirc = value; }
        }

        public Dictionary<string, string> ValidatorData()
        {
            string sAccount = Req.GetForm("cAccount");
            string sPartner = Req.GetForm("cPartner");
            string sKey = Req.GetForm("cKey");

            string sMsg = string.Empty;

            if (sAccount.Length == 0)
                sMsg = "请输入支付宝账号;";

            if (sPartner.Length == 0)
                sMsg += "请输入合作伙伴id;";

            if (sKey.Length == 0)
                sMsg += "请输入交易安全校验码;";

            new MessageGeneral().Error(sMsg);

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Account", sAccount);
            d.Add("Partner", sPartner);
            d.Add("Key", sKey);

            return d;
        }

      
    }
}

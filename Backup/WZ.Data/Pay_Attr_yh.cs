using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;

namespace WZ.Data
{
    public class Pay_Attr_yh : WZ.Data.IData.IPay
    {
        private Dictionary<string, string> dirc = new Dictionary<string, string>();

        public Pay_Attr_yh()
        {
            dirc.Add("YhRealName", "姓名");
            dirc.Add("YhNumber", "卡号");
            dirc.Add("YhArea", "开户地");
        }

        public Dictionary<string, string> attrName
        {
            get { return dirc; }
            set { this.dirc = value; }
        }

        public Dictionary<string, string> ValidatorData()
        {
            string sYhRealName = Req.GetForm("cYhRealName");//银行卡姓名
            string sYhNumber = Req.GetForm("cYhNumber");//银行卡号
            string sYhArea = Req.GetForm("cYhArea");//银行开户地

            string sMsg = string.Empty;

            if (sYhRealName.Length == 0)
                sMsg += "请输入银行卡姓名;";

            if (sYhNumber.Length == 0)
                sMsg += "请输入银行卡号;";

            new MessageGeneral().Error(sMsg);

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("YhRealName", sYhRealName);
            d.Add("YhNumber", sYhNumber);
            d.Add("YhArea", sYhArea);

            return d;
        }
    }
}

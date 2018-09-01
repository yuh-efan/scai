using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Common
{
    public class URLPaging
    {
        public string s;
        public string[] ArrPara;
        public string p;//页码

        private char strSplit = '-';
        private string strName = "s";
        private MessageGeneral msgG = new MessageGeneral();

        public URLPaging()
        {
            this.s = HttpContext.Current.Request.QueryString[strName];
            if (this.s == null)
            {
                this.s = string.Empty;
                this.ArrPara = new string[] { "" };
            }
            else
            {
                if (this.s.Length > 250)
                {
                    msgG.Error("非法操作.");
                }
                str_split();
            }
        }

        private void str_split()
        {
            ArrPara = s.Split(strSplit);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Common
{
    public class HtmlEdit
    {
        
        public static string GetTextArea(string pStr)
        {
            pStr = pStr.Replace("\r\n", "<br />");
            return pStr;
        }

        public static string ToTextArea(string pStr)
        {
            pStr = pStr.Replace("<br />", "\r\n");
            return pStr;
        }
    }
}

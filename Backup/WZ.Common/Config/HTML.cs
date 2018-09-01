using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Common.Config
{
    /// <summary>
    /// Html代码
    /// </summary>
    public class HTML
    {
        public const string C_H1 = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" ><head><meta HTTP-EQUIV=\"Pragma\" content=\"no-cache\" /></head><body>";
        public const string C_H2 = "</body></html>";

        public const string C_J1 = "<script type=\"text/javascript\">";
        public const string C_J2 = "</script>";
        
        /// <summary>
        /// 信息错误提示的html结构
        /// </summary>
        public const string CheckMsg = "<div class=\"msgCheck\" style=\"display:none\">"
+ "<div class=\"checkText\"><ul class=\"msgCheck1\"></ul><span class=\"checkClose\">关闭</span></div>"
+ "</div>"
+ "<script type=\"text/javascript\">"
+ "_.getClass(\"checkClose\").onclick=function(){_.getClass(\"msgCheck\").style.display=\"none\";};"
+ "</script>";
    }
}

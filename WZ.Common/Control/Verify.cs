using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Common.Control
{
    /// <summary>
    /// 验证码控件
    /// </summary>
    public class Verify : System.Web.UI.Control
    {
        public string _file;
        public string _attr;

        protected override void Render(System.Web.UI.HtmlTextWriter output)
        {
            output.Write("<input id=\"cCode\" name=\"cCode\" size=\"4\" maxlength=\"4\" type=\"text\" " + _attr + " /><span id=\"cCodeHtml\"></span>");
            
            output.Write("<script type=\"text/javascript\">");
            output.Write("function fnVerify()");
            output.Write("{");
            output.Write("var oCodeHtml=document.getElementById(\"cCodeHtml\");");
            output.Write("oCodeHtml.innerHTML=\"<img id='cCodePic' alt='图片验证码,单击刷新' onclick='fnVerify()' style='cursor:pointer' />\";");
            output.Write("var oCode=document.getElementById(\"cCode\");");
            output.Write("oCode.value='';");
            output.Write("oCode.focus();");
            output.Write("document.getElementById('cCodePic').src='" + _file + "?a='+Math.random();");
            output.Write("}");
            output.Write("</script>");
        }

        public string file
        {
            set { this._file = value; }
        }

        public string attr
        {
            set { this._attr = value; }
        }
    }
}
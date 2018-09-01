using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Common.Control
{
    /// <summary>
    /// 显示文本
    /// </summary>
    public class ShowText : System.Web.UI.Control
    {
        private string _text;

        protected override void Render(System.Web.UI.HtmlTextWriter output)
        {
            output.Write(this._text);
        }

        public string Text
        {
            get { return this._text; }
            set { this._text = value; }
        }
    }
}
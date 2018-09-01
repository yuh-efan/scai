using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Common.Control
{
    /// <summary>
    /// 文本框输入
    /// </summary>
    public class InputText : System.Web.UI.Control
    {
        private string _text;
        private string _id;
        private string _attr;
        private string _type = "text";

        protected override void Render(System.Web.UI.HtmlTextWriter output)
        {
            const string inputFormat = "<input id=\"{0}\" name=\"{0}\" value=\"{1}\"{2} type=\"{3}\" />";
            output.Write(string.Format(inputFormat, this._id, this._text, " " + this._attr, this._type));
        }

        public string Text
        {
            get { return this._text; }
            set { this._text = value; }
        }

        public override string ID
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Attr
        {
            get { return this._attr; }
            set { this._attr = value; }
        }

        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
    }
}

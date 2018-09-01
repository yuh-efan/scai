using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 幻灯片
    /// </summary>
    public class PPTM
    {
        private int _PPTSN;
        private string _Str;
        private string _PPTName;
        private string _PicS;
        private string _PicB;
        private string _WebURL;
        private int _Taxis;

        public int PPTSN
        {
            get { return this._PPTSN; }
            set { this._PPTSN = value; }
        }

        public string Str
        {
            get { return this._Str; }
            set { this._Str = value; }
        }

        public string PPTName
        {
            get { return this._PPTName; }
            set { this._PPTName = value; }
        }

        public string PicS
        {
            get { return this._PicS; }
            set { this._PicS = value; }
        }

        public string PicB
        {
            get { return this._PicB; }
            set { this._PicB = value; }
        }

        public string WebURL
        {
            get { return this._WebURL; }
            set { this._WebURL = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }
    }
}

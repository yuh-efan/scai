using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class LinksM
    {
        private int _LinksSN;
        private string _LinksName;
        private string _PicS;
        private string _WebURL;
        private int _LinksType;
        private int _ShowLocal;
        private int _ShowType;
        private int _Taxis;

        public int LinksSN
        {
            get { return this._LinksSN; }
            set { this._LinksSN = value; }
        }

        public string LinksName
        {
            get { return this._LinksName; }
            set { this._LinksName = value; }
        }

        public string PicS
        {
            get { return this._PicS; }
            set { this._PicS = value; }
        }

        public string WebURL
        {
            get { return this._WebURL; }
            set { this._WebURL = value; }
        }

        /// <summary>
        /// 0:友情链接  1:合作伙伴
        /// </summary>
        public int LinksType
        {
            get { return this._LinksType; }
            set { this._LinksType = value; }
        }

        /// <summary>
        /// 显示位置 1:显示在首页
        /// </summary>
        public int ShowLocal
        {
            get { return this._ShowLocal; }
            set { this._ShowLocal = value; }
        }

        /// <summary>
        /// 显示方式 0:文字链接,1:图片链接
        /// </summary>
        public int ShowType
        {
            get { return this._ShowType; }
            set { this._ShowType = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }
    }
}

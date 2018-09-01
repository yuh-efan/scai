using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class CaiPu_PicM
    {
        private int _PicSN;
        private int _FK_Pro;
        private string _PicS;
        private string _PicB;

        public int PicSN
        {
            get { return this._PicSN; }
            set { this._PicSN = value; }
        }

        /// <summary>
        /// 产品表id
        /// </summary>
        public int FK_Pro
        {
            get { return this._FK_Pro; }
            set { this._FK_Pro = value; }
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
    }
}

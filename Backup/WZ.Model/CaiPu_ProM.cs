using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 菜普对应产品列表
    /// </summary>
    public class CaiPu_ProM
    {
        private int _SN;
        private int _FK_CaiPu;
        private int _FK_Pro;

        public int SN
        {
            get { return this._SN; }
            set { this._SN = value; }
        }

        /// <summary>
        /// 菜谱id
        /// </summary>
        public int FK_CaiPu
        {
            get { return this._FK_CaiPu; }
            set { this._FK_CaiPu = value; }
        }

        /// <summary>
        /// 产品id
        /// </summary>
        public int FK_Pro
        {
            get { return this._FK_Pro; }
            set { this._FK_Pro = value; }
        }
    }
}

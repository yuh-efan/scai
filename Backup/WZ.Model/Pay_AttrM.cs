using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 支付方式属性
    /// </summary>
    public class Pay_AttrM
    {
        private int _AttrSN;
        private int _FK_Pay;
        private string _AttrStr;
        private string _AttrValue;

        public int AttrSN
        {
            get { return this._AttrSN; }
            set { this._AttrSN = value; }
        }

        public int FK_Pay
        {
            get { return this._FK_Pay; }
            set { this._FK_Pay = value; }
        }

        public string AttrStr
        {
            get { return this._AttrStr; }
            set { this._AttrStr = value; }
        }

        /// <summary>
        /// 支付宝账号
        /// </summary>
        public string AttrValue
        {
            get { return this._AttrValue; }
            set { this._AttrValue = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public class Ord_StatusM
    {
        private int _StaSN;
        private string _StaName;

        public int StaSN
        {
            get { return this._StaSN; }
            set { this._StaSN = value; }
        }

        public string StaName
        {
            get { return this._StaName; }
            set { this._StaName = value; }
        }
    }
}

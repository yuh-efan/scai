using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public class Pay_InfoM
    {
        private int _PaySN;
        private string _PayType;
        private string _PayName;
        private double _PayRate;
        private int _Taxis;
        private string _Detail;

        public int PaySN
        {
            get { return this._PaySN; }
            set { this._PaySN = value; }
        }

        public string PayType
        {
            get { return this._PayType; }
            set { this._PayType = value; }
        }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string PayName
        {
            get { return this._PayName; }
            set { this._PayName = value; }
        }

        /// <summary>
        /// 支付费率
        /// </summary>
        public double PayRate
        {
            get { return this._PayRate; }
            set { this._PayRate = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }
    }
}

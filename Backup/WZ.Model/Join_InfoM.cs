using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Join_InfoM
    {
        private int _JoinSN;
        private string _JoinName;
        private byte _JoinType;
        private string _SupplyProduct;
        private string _Address;
        private string _Detail;
        private string _Tel;
        private string _FixTel;
        private string _Fax;
        private DateTime _AddDate;

        public int JoinSN
        {
            get { return this._JoinSN; }
            set { this._JoinSN = value; }
        }

        /// <summary>
        /// 商家名称
        /// </summary>
        public string JoinName
        {
            get { return this._JoinName; }
            set { this._JoinName = value; }
        }

        /// <summary>
        /// 商家 1:批发商 0:菜蓝子
        /// </summary>
        public byte JoinType
        {
            get { return this._JoinType; }
            set { this._JoinType = value; }
        }

        /// <summary>
        /// 供应产品
        /// </summary>
        public string SupplyProduct
        {
            get { return this._SupplyProduct; }
            set { this._SupplyProduct = value; }
        }

        public string Address
        {
            get { return this._Address; }
            set { this._Address = value; }
        }

        /// <summary>
        /// 商家介绍/说明
        /// </summary>
        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        public string Tel
        {
            get { return this._Tel; }
            set { this._Tel = value; }
        }

        /// <summary>
        /// 固定电话
        /// </summary>
        public string FixTel
        {
            get { return this._FixTel; }
            set { this._FixTel = value; }
        }

        public string Fax
        {
            get { return this._Fax; }
            set { this._Fax = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }
}

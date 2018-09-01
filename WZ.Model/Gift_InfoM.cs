using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 礼品
    /// </summary>
    public class Gift_InfoM
    {
        private int _GiftSN;
        private int _FK_Gift_Class;
        private string _GiftName;
        private int _Integral;
        private string _PicS;
        private string _PicB;
        private string _Detail;
        private int _ExchangeN;
        private int _Item;
        private DateTime _EditDate;
        private DateTime _AddDate;
        private double _StockN;

        public int GiftSN
        {
            get { return this._GiftSN; }
            set { this._GiftSN = value; }
        }

        public int FK_Gift_Class
        {
            get { return this._FK_Gift_Class; }
            set { this._FK_Gift_Class = value; }
        }

        public string GiftName
        {
            get { return this._GiftName; }
            set { this._GiftName = value; }
        }

        /// <summary>
        /// 所需积分
        /// </summary>
        public int Integral
        {
            get { return this._Integral; }
            set { this._Integral = value; }
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

        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        /// <summary>
        /// 兑换次数
        /// </summary>
        public int ExchangeN
        {
            get { return this._ExchangeN; }
            set { this._ExchangeN = value; }
        }

        /// <summary>
        /// 1:推荐
        /// </summary>
        public int Item
        {
            get { return this._Item; }
            set { this._Item = value; }
        }

        public DateTime EditDate
        {
            get { return this._EditDate; }
            set { this._EditDate = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }

        /// <summary>
        /// 库存
        /// </summary>
        public double StockN
        {
            get { return this._StockN; }
            set { this._StockN = value; }
        }
    }
}

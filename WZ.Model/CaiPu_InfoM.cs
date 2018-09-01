using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 菜普
    /// </summary>
    public class CaiPu_InfoM
    {
        private int _ProSN;
        private int _FK_Pro_Class;
        private int _FK_Join;
        private string _ProName;
        private string _Number;
        private string _PicS;
        private string _PicB;
        private double _Price;
        private double _PriceMarket;
        private double _PriceCost;
        private string _Unit;
        private double _UnitNum;
        private double _StockN;
        private int _SellN;
        private int _SellN1;
        private int _Hit;
        private string _Detail1;
        private string _Detail2;
        private string _Detail3;
        private byte _ProIsHas;
        private int _Item;
        private DateTime _EditDate;
        private DateTime _AddDate;

        public int ProSN
        {
            get { return this._ProSN; }
            set { this._ProSN = value; }
        }

        public int FK_Pro_Class
        {
            get { return this._FK_Pro_Class; }
            set { this._FK_Pro_Class = value; }
        }

        /// <summary>
        /// 公司/商家表ID
        /// </summary>
        public int FK_Join
        {
            get { return this._FK_Join; }
            set { this._FK_Join = value; }
        }

        public string ProName
        {
            get { return this._ProName; }
            set { this._ProName = value; }
        }

        public string Number
        {
            get { return this._Number; }
            set { this._Number = value; }
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

        /// <summary>
        /// 销售价格
        /// </summary>
        public double Price
        {
            get { return this._Price; }
            set { this._Price = value; }
        }

        /// <summary>
        /// 市场价
        /// </summary>
        public double PriceMarket
        {
            get { return this._PriceMarket; }
            set { this._PriceMarket = value; }
        }

        /// <summary>
        /// 成本价
        /// </summary>
        public double PriceCost
        {
            get { return this._PriceCost; }
            set { this._PriceCost = value; }
        }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit
        {
            get { return this._Unit; }
            set { this._Unit = value; }
        }

        public double UnitNum
        {
            get { return this._UnitNum; }
            set { this._UnitNum = value; }
        }

        public double StockN
        {
            get { return this._StockN; }
            set { this._StockN = value; }
        }

        /// <summary>
        /// 此产品销售次数
        /// </summary>
        public int SellN
        {
            get { return this._SellN; }
            set { this._SellN = value; }
        }

        /// <summary>
        /// 此产品销售总量
        /// </summary>
        public int SellN1
        {
            get { return this._SellN1; }
            set { this._SellN1 = value; }
        }

        public int Hit
        {
            get { return this._Hit; }
            set { this._Hit = value; }
        }

        /// <summary>
        /// 描述,教程,适用人群
        /// </summary>
        public string Detail1
        {
            get { return this._Detail1; }
            set { this._Detail1 = value; }
        }

        public string Detail2
        {
            get { return this._Detail2; }
            set { this._Detail2 = value; }
        }

        public string Detail3
        {
            get { return this._Detail3; }
            set { this._Detail3 = value; }
        }

        /// <summary>
        /// 0:上架 1:下架
        /// </summary>
        public byte ProIsHas
        {
            get { return this._ProIsHas; }
            set { this._ProIsHas = value; }
        }

        /// <summary>
        /// 产品属性
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
    }
}

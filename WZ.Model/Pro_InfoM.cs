using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 产品信息
    /// </summary>
    public class Pro_InfoM
    {
        private int _ProSN;
        private int _FK_Pro_Class;
        private int _FK_Join;
        private byte _JoinType;
        private string _ProName;
        private string _Number;
        private string _PicS;
        private string _PicB;
        private double _Price;
        private double _Price1;
        private double _Price2;
        private double _Price3;
        private double _Price4;
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
        private byte _ProIsHas;
        private int _Item;
        private DateTime _MS_StartTime;
        private DateTime _MS_EndTime;
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

        /// <summary>
        /// 0:菜篮子 1:商家
        /// </summary>
        public byte JoinType
        {
            get { return this._JoinType; }
            set { this._JoinType = value; }
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
        /// 秒杀,促销价
        /// </summary>
        public double Price1
        {
            get { return this._Price1; }
            set { this._Price1 = value; }
        }

        /// <summary>
        /// 企业价
        /// </summary>
        public double Price2
        {
            get { return this._Price2; }
            set { this._Price2 = value; }
        }

        /// <summary>
        /// 暂无
        /// </summary>
        public double Price3
        {
            get { return this._Price3; }
            set { this._Price3 = value; }
        }

        /// <summary>
        /// 暂无
        /// </summary>
        public double Price4
        {
            get { return this._Price4; }
            set { this._Price4 = value; }
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

        /// <summary>
        /// 秒杀开始时间
        /// </summary>
        public DateTime MS_StartTime
        {
            get { return this._MS_StartTime; }
            set { this._MS_StartTime = value; }
        }

        /// <summary>
        /// 秒杀结束时间
        /// </summary>
        public DateTime MS_EndTime
        {
            get { return this._MS_EndTime; }
            set { this._MS_EndTime = value; }
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

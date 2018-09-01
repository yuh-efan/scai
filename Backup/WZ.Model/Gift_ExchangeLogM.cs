using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 礼品兑换记录
    /// </summary>
    public class Gift_ExchangeLogM
    {
        private int _ExSN;
        private int _FK_User;
        private int _FK_Gift;
        private string _GiftName;
        private int _ExIntegral;
        private int _ExTotalIntegral;
        private double _Num;
        private string _gift_UserName;
        private string _gift_RealName;
        private int _gift_Area;
        private string _gift_Address;
        private string _gift_Tel;
        private string _gift_FixTel;
        private string _gift_Caption;
        private DateTime _AddDate;

        public int ExSN
        {
            get { return this._ExSN; }
            set { this._ExSN = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        public int FK_Gift
        {
            get { return this._FK_Gift; }
            set { this._FK_Gift = value; }
        }

        /// <summary>
        /// 兑换总积分
        /// </summary>
        public string GiftName
        {
            get { return this._GiftName; }
            set { this._GiftName = value; }
        }

        /// <summary>
        /// 此礼品的积分
        /// </summary>
        public int ExIntegral
        {
            get { return this._ExIntegral; }
            set { this._ExIntegral = value; }
        }

        /// <summary>
        /// 总积分 
        /// </summary>
        public int ExTotalIntegral
        {
            get { return this._ExTotalIntegral; }
            set { this._ExTotalIntegral = value; }
        }

        /// <summary>
        /// 兑换数量
        /// </summary>
        public double Num
        {
            get { return this._Num; }
            set { this._Num = value; }
        }

        public string gift_UserName
        {
            get { return this._gift_UserName; }
            set { this._gift_UserName = value; }
        }

        public string gift_RealName
        {
            get { return this._gift_RealName; }
            set { this._gift_RealName = value; }
        }

        public int gift_Area
        {
            get { return this._gift_Area; }
            set { this._gift_Area = value; }
        }

        public string gift_Address
        {
            get { return this._gift_Address; }
            set { this._gift_Address = value; }
        }

        /// <summary>
        /// 手机
        /// </summary>
        public string gift_Tel
        {
            get { return this._gift_Tel; }
            set { this._gift_Tel = value; }
        }

        /// <summary>
        /// 固定电话
        /// </summary>
        public string gift_FixTel
        {
            get { return this._gift_FixTel; }
            set { this._gift_FixTel = value; }
        }

        public string gift_Caption
        {
            get { return this._gift_Caption; }
            set { this._gift_Caption = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }

}

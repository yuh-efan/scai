using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public class Ord_InfoM
    {
        private int _OrdSN;
        private int _FK_Pay;
        private byte _UserType;
        private int _UserIdentity;
        private int _UserLevel;
        private string _PayType;
        private string _OrdNumber;
        private int _FK_User;
        private string _TeamName;
        private string _UserCard;
        private string _UserName;
        private string _RealName;
        private string _FixTel;
        private string _Tel;
        private int _Area;
        private string _Address;
        private string _Ticket_1_Number;
        private double _Ticket_1_Price;
        private double _TotalPrice;
        private string _StatusCancelRemark;
        private int _Status;
        private byte _StatusPay;
        private string _Caption;
        private string _Remark;
        private DateTime _JiaoHuoTime;
        private DateTime _AddDate;
        private int _AreaTime;
        private DateTime _ToMinTime;
        private DateTime _ToMaxTime;
        private int _FK_AdminUser_PeiSong;
        private int _FK_AdminUser_ChuKu;

        public int OrdSN
        {
            get { return this._OrdSN; }
            set { this._OrdSN = value; }
        }

        public int FK_Pay
        {
            get { return this._FK_Pay; }
            set { this._FK_Pay = value; }
        }

        /// <summary>
        /// 会员类型(对应订购产品A,B,C,D,E,F类)0=A 1=B 2=C 3=D 4=E 5=F 类 
        /// </summary>
        public byte UserType
        {
            get { return this._UserType; }
            set { this._UserType = value; }
        }

        /// <summary>
        /// 此用户以何种身份订购
        /// </summary>
        public int UserIdentity
        {
            get { return this._UserIdentity; }
            set { this._UserIdentity = value; }
        }

        /// <summary>
        /// 用户订购时的等级
        /// </summary>
        public int UserLevel
        {
            get { return this._UserLevel; }
            set { this._UserLevel = value; }
        }

        public string PayType
        {
            get { return this._PayType; }
            set { this._PayType = value; }
        }

        public string OrdNumber
        {
            get { return this._OrdNumber; }
            set { this._OrdNumber = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        /// <summary>
        /// 团队名称(如 公司名称)
        /// </summary>
        public string TeamName
        {
            get { return this._TeamName; }
            set { this._TeamName = value; }
        }

        public string UserCard
        {
            get { return this._UserCard; }
            set { this._UserCard = value; }
        }

        /// <summary>
        /// 联系人姓名/公司名称
        /// </summary>
        public string UserName
        {
            get { return this._UserName; }
            set { this._UserName = value; }
        }

        /// <summary>
        /// 联系人姓名/公司名称
        /// </summary>
        public string RealName
        {
            get { return this._RealName; }
            set { this._RealName = value; }
        }

        /// <summary>
        /// 固定电话
        /// </summary>
        public string FixTel
        {
            get { return this._FixTel; }
            set { this._FixTel = value; }
        }

        /// <summary>
        /// 手机
        /// </summary>
        public string Tel
        {
            get { return this._Tel; }
            set { this._Tel = value; }
        }

        /// <summary>
        /// 地区
        /// </summary>
        public int Area
        {
            get { return this._Area; }
            set { this._Area = value; }
        }

        public string Address
        {
            get { return this._Address; }
            set { this._Address = value; }
        }

        /// <summary>
        /// 抵金券号码
        /// </summary>
        public string Ticket_1_Number
        {
            get { return this._Ticket_1_Number; }
            set { this._Ticket_1_Number = value; }
        }

        /// <summary>
        /// 抵金券面值(金额)
        /// </summary>
        public double Ticket_1_Price
        {
            get { return this._Ticket_1_Price; }
            set { this._Ticket_1_Price = value; }
        }

        /// <summary>
        /// 订单实际总价格(即打折后,使用抵金券后等)
        /// </summary>
        public double TotalPrice
        {
            get { return this._TotalPrice; }
            set { this._TotalPrice = value; }
        }

        /// <summary>
        /// 用户申请取消的备注
        /// </summary>
        public string StatusCancelRemark
        {
            get { return this._StatusCancelRemark; }
            set { this._StatusCancelRemark = value; }
        }

        /// <summary>
        /// 订单状态 10:已结算 20:已取消 30:已发货 40:确认收货  50:已完成
        /// </summary>
        public int Status
        {
            get { return this._Status; }
            set { this._Status = value; }
        }

        /// <summary>
        /// 支付状态 0:未付款 1:已付款 2:已预付
        /// </summary>
        public byte StatusPay
        {
            get { return this._StatusPay; }
            set { this._StatusPay = value; }
        }

        /// <summary>
        /// 用户符加信息(备注)
        /// </summary>
        public string Caption
        {
            get { return this._Caption; }
            set { this._Caption = value; }
        }

        /// <summary>
        /// 网站方备注
        /// </summary>
        public string Remark
        {
            get { return this._Remark; }
            set { this._Remark = value; }
        }

        public DateTime JiaoHuoTime
        {
            get { return this._JiaoHuoTime; }
            set { this._JiaoHuoTime = value; }
        }

        /// <summary>
        /// 订购时间
        /// </summary>
        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }

        /// <summary>
        /// 配送时间(存储id,不是时间)
        /// </summary>
        public int AreaTime
        {
            get { return this._AreaTime; }
            set { this._AreaTime = value; }
        }

        /// <summary>
        /// 到货最小时间
        /// </summary>
        public DateTime ToMinTime
        {
            get { return this._ToMinTime; }
            set { this._ToMinTime = value; }
        }

        /// <summary>
        /// 到货最大时间
        /// </summary>
        public DateTime ToMaxTime
        {
            get { return this._ToMaxTime; }
            set { this._ToMaxTime = value; }
        }

        /// <summary>
        /// 配送人
        /// </summary>
        public int FK_AdminUser_PeiSong
        {
            get { return this._FK_AdminUser_PeiSong; }
            set { this._FK_AdminUser_PeiSong = value; }
        }

        /// <summary>
        /// 出库
        /// </summary>
        public int FK_AdminUser_ChuKu
        {
            get { return this._FK_AdminUser_ChuKu; }
            set { this._FK_AdminUser_ChuKu = value; }
        }
    }

}

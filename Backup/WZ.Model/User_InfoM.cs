using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 用户主表
    /// </summary>
    public class User_InfoM
    {
        private int _UserSN;
        private int _FK_User_Level;
        private int _UserBTJ;
        private int _OpenIdentity;
        private byte _UserType;
        private string _UserName;
        private string _UserCard;
        private string _Email;
        private string _UserPwd;
        private string _LastLoginIP;
        private int _LoginN;
        private DateTime _LastLoginTime;
        private string _UserTGNumber;
        private int _UserIntegral;
        private int _UserConsumeIntegral;
        private double _UserMoney;
        private double _UserFreezeMoney;
        private int _UserExp;
        private DateTime _UserAddDate;

        public int UserSN
        {
            get { return this._UserSN; }
            set { this._UserSN = value; }
        }

        public int FK_User_Level
        {
            get { return this._FK_User_Level; }
            set { this._FK_User_Level = value; }
        }

        /// <summary>
        /// 被推广ID
        /// </summary>
        public int UserBTJ
        {
            get { return this._UserBTJ; }
            set { this._UserBTJ = value; }
        }

        /// <summary>
        /// 开通身份(位) 0:无任何身份 1:个人 2:店铺 4:推广员 8:企业
        /// </summary>
        public int OpenIdentity
        {
            get { return this._OpenIdentity; }
            set { this._OpenIdentity = value; }
        }

        /// <summary>
        /// 会员类型(对应订购产品A,B,C,D,E,F类)0=A 1=B 2=C 3=D 4=E 5=F 类 
        /// </summary>
        public byte UserType
        {
            get { return this._UserType; }
            set { this._UserType = value; }
        }

        public string UserName
        {
            get { return this._UserName; }
            set { this._UserName = value; }
        }

        /// <summary>
        /// 会员卡
        /// </summary>
        public string UserCard
        {
            get { return this._UserCard; }
            set { this._UserCard = value; }
        }

        public string Email
        {
            get { return this._Email; }
            set { this._Email = value; }
        }

        public string UserPwd
        {
            get { return this._UserPwd; }
            set { this._UserPwd = value; }
        }

        public string LastLoginIP
        {
            get { return this._LastLoginIP; }
            set { this._LastLoginIP = value; }
        }

        public int LoginN
        {
            get { return this._LoginN; }
            set { this._LoginN = value; }
        }

        public DateTime LastLoginTime
        {
            get { return this._LastLoginTime; }
            set { this._LastLoginTime = value; }
        }

        /// <summary>
        /// 推广号码
        /// </summary>
        public string UserTGNumber
        {
            get { return this._UserTGNumber; }
            set { this._UserTGNumber = value; }
        }

        public int UserIntegral
        {
            get { return this._UserIntegral; }
            set { this._UserIntegral = value; }
        }

        /// <summary>
        /// 消耗积分
        /// </summary>
        public int UserConsumeIntegral
        {
            get { return this._UserConsumeIntegral; }
            set { this._UserConsumeIntegral = value; }
        }

        /// <summary>
        /// 会员预存款
        /// </summary>
        public double UserMoney
        {
            get { return this._UserMoney; }
            set { this._UserMoney = value; }
        }

        /// <summary>
        /// 会员冻结金额
        /// </summary>
        public double UserFreezeMoney
        {
            get { return this._UserFreezeMoney; }
            set { this._UserFreezeMoney = value; }
        }

        /// <summary>
        /// 经验值
        /// </summary>
        public int UserExp
        {
            get { return this._UserExp; }
            set { this._UserExp = value; }
        }

        public DateTime UserAddDate
        {
            get { return this._UserAddDate; }
            set { this._UserAddDate = value; }
        }
    }
}
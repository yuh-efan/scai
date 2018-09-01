using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{

    /// <summary>
    /// 用户申请推广员
    /// </summary>
    public class User_ApplyFor_1M
    {
        private int _af_ID;
        private int _FK_User;
        private int _FK_AdminID;
        private string _RealName;
        private byte _Sex;
        private string _Address;
        private string _Tel;
        private string _FixTel;
        private string _Bank_Name;
        private string _Bank_KHD;
        private string _Bank_Account;
        private string _Remark;
        private byte _Status;
        private DateTime _AddDate;

        public int af_ID
        {
            get { return this._af_ID; }
            set { this._af_ID = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        /// <summary>
        /// 管理员 处理者
        /// </summary>
        public int FK_AdminID
        {
            get { return this._FK_AdminID; }
            set { this._FK_AdminID = value; }
        }

        public string RealName
        {
            get { return this._RealName; }
            set { this._RealName = value; }
        }

        public byte Sex
        {
            get { return this._Sex; }
            set { this._Sex = value; }
        }

        public string Address
        {
            get { return this._Address; }
            set { this._Address = value; }
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

        /// <summary>
        /// 银行名称
        /// </summary>
        public string Bank_Name
        {
            get { return this._Bank_Name; }
            set { this._Bank_Name = value; }
        }

        /// <summary>
        /// 银行开户地
        /// </summary>
        public string Bank_KHD
        {
            get { return this._Bank_KHD; }
            set { this._Bank_KHD = value; }
        }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string Bank_Account
        {
            get { return this._Bank_Account; }
            set { this._Bank_Account = value; }
        }

        public string Remark
        {
            get { return this._Remark; }
            set { this._Remark = value; }
        }

        /// <summary>
        /// 0:未处理 1:已处理 2:不做处理
        /// </summary>
        public byte Status
        {
            get { return this._Status; }
            set { this._Status = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }


}

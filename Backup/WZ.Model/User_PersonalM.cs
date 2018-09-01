using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 用户个人表
    /// </summary>
    public class User_PersonalM
    {
        private int _FK_User;
        private string _RealName;
        private byte _Sex;
        private int _Area;
        private string _Address;
        private DateTime _Birthday;
        private string _Tel;
        private string _FixTel;
        private DateTime _AddDate;

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
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

        public DateTime Birthday
        {
            get { return this._Birthday; }
            set { this._Birthday = value; }
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

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }
}

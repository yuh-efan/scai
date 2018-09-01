using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 会员团体身份(如 企业 等)
    /// </summary>
    public class User_TeamM
    {
        private int _FK_User;
        private string _TeamName;
        private string _RealName;
        private int _Area;
        private string _Address;
        private string _Tel;
        private string _FixTel;
        private string _Detail;
        private DateTime _AddDate;

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        /// <summary>
        /// 团队名称(公司名称)
        /// </summary>
        public string TeamName
        {
            get { return this._TeamName; }
            set { this._TeamName = value; }
        }

        public string RealName
        {
            get { return this._RealName; }
            set { this._RealName = value; }
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

        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }

}

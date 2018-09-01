using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class User_FindPwdEmailM
    {
        private int _FPESN;
        private string _FPUserName;
        private string _FPKey;
        private DateTime _AddDate;

        public int FPESN
        {
            get { return this._FPESN; }
            set { this._FPESN = value; }
        }

        public string FPUserName
        {
            get { return this._FPUserName; }
            set { this._FPUserName = value; }
        }

        /// <summary>
        /// 认证此链接的key
        /// </summary>
        public string FPKey
        {
            get { return this._FPKey; }
            set { this._FPKey = value; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 设置会员等级日志
    /// </summary>
    public class Log_SetUserLevelM
    {
        private int _SULSN;
        private int _FK_User;
        private string _Operator;
        private int _SetLevel;
        private string _Remark;
        private string _IP;
        private DateTime _AddDate;

        public int SULSN
        {
            get { return this._SULSN; }
            set { this._SULSN = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        public string Operator
        {
            get { return this._Operator; }
            set { this._Operator = value; }
        }

        public int SetLevel
        {
            get { return this._SetLevel; }
            set { this._SetLevel = value; }
        }

        public string Remark
        {
            get { return this._Remark; }
            set { this._Remark = value; }
        }

        public string IP
        {
            get { return this._IP; }
            set { this._IP = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }
}

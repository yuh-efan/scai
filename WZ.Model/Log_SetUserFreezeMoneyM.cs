using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 冻结金额日志
    /// </summary>
    public class Log_SetUserFreezeMoneyM
    {
        private int _SUFMID;
        private int _FK_User;
        private string _Number;
        private string _Operator;
        private double _SetFreezeMoney;
        private string _Remark;
        private string _IP;
        private DateTime _AddDate;

        public int SUFMID
        {
            get { return this._SUFMID; }
            set { this._SUFMID = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        public string Number
        {
            get { return this._Number; }
            set { this._Number = value; }
        }

        public string Operator
        {
            get { return this._Operator; }
            set { this._Operator = value; }
        }

        public double SetFreezeMoney
        {
            get { return this._SetFreezeMoney; }
            set { this._SetFreezeMoney = value; }
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

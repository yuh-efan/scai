using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 订单日志
    /// </summary>
    public class Log_OrdM
    {
        private int _LOSN;
        private int _FK_Ord;
        private int _FK_User;
        private string _Operator;
        private string _Remark;
        private string _IP;
        private DateTime _AddDate;

        public int LOSN
        {
            get { return this._LOSN; }
            set { this._LOSN = value; }
        }

        public int FK_Ord
        {
            get { return this._FK_Ord; }
            set { this._FK_Ord = value; }
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

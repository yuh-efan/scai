using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 举报信息
    /// </summary>
    public class ReportM
    {
        private int _RepSN;
        private int _FK_User;
        private string _Detail;
        private DateTime _AddDate;

        public int RepSN
        {
            get { return this._RepSN; }
            set { this._RepSN = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
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

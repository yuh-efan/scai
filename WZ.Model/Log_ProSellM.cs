using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 商品销售日志
    /// </summary>
    public class Log_ProSellM
    {
        private int _HSSN;
        private int _FK_User;
        private int _FK_Pro;
        private int _SellN;
        private DateTime _AddDate;

        public int HSSN
        {
            get { return this._HSSN; }
            set { this._HSSN = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        public int FK_Pro
        {
            get { return this._FK_Pro; }
            set { this._FK_Pro = value; }
        }

        public int SellN
        {
            get { return this._SellN; }
            set { this._SellN = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }
}

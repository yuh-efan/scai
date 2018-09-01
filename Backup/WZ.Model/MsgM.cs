using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 网站留言
    /// </summary>
    public class MsgM
    {
        private int _MsgSN;
        private int _FK_User;
        private string _Detail;
        private DateTime _AddDate;

        public int MsgSN
        {
            get { return this._MsgSN; }
            set { this._MsgSN = value; }
        }

        /// <summary>
        /// 0:匿名留言 >0用户
        /// </summary>
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

using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 用户站内信
    /// </summary>
    public class User_LetterM
    {
        private int _LetSN;
        private int _FK_User_From;
        private int _FK_User_To;
        private string _Title;
        private string _Detail;
        private byte _IsRead;
        private DateTime _AddDate;

        public int LetSN
        {
            get { return this._LetSN; }
            set { this._LetSN = value; }
        }

        /// <summary>
        /// 发送方userid 若为0 则管理员
        /// </summary>
        public int FK_User_From
        {
            get { return this._FK_User_From; }
            set { this._FK_User_From = value; }
        }

        /// <summary>
        /// 招收方userid 
        /// </summary>
        public int FK_User_To
        {
            get { return this._FK_User_To; }
            set { this._FK_User_To = value; }
        }

        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }

        /// <summary>
        /// 发送内容
        /// </summary>
        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        /// <summary>
        /// 是否已读 0未读 1:已读
        /// </summary>
        public byte IsRead
        {
            get { return this._IsRead; }
            set { this._IsRead = value; }
        }

        /// <summary>
        /// 发送日期
        /// </summary>
        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }
}

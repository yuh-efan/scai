using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 网站内容,如广告
    /// </summary>
    public class WebInfoM
    {
        private int _InfoSN;
        private string _Str;
        private string _InfoName;
        private string _Detail;
        private DateTime _StartTime;
        private DateTime _EndTime;

        public int InfoSN
        {
            get { return this._InfoSN; }
            set { this._InfoSN = value; }
        }

        public string Str
        {
            get { return this._Str; }
            set { this._Str = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string InfoName
        {
            get { return this._InfoName; }
            set { this._InfoName = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        /// <summary>
        /// 放置开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return this._StartTime; }
            set { this._StartTime = value; }
        }

        /// <summary>
        /// 放置结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return this._EndTime; }
            set { this._EndTime = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 产品评价
    /// </summary>
    public class Pro_EvaluateM
    {
        private int _EvalSN;
        private int _FK_User;
        private int _FK_Pro;
        private int _Fraction;
        private string _Detail;
        private string _ReDetail;
        private byte _Purview;
        private string _IP;
        private DateTime _AddDate;

        public int EvalSN
        {
            get { return this._EvalSN; }
            set { this._EvalSN = value; }
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

        /// <summary>
        /// 分数
        /// </summary>
        public int Fraction
        {
            get { return this._Fraction; }
            set { this._Fraction = value; }
        }

        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        public string ReDetail
        {
            get { return this._ReDetail; }
            set { this._ReDetail = value; }
        }

        /// <summary>
        /// 0:未审核 1:通过审核 2:未通过审核
        /// </summary>
        public byte Purview
        {
            get { return this._Purview; }
            set { this._Purview = value; }
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

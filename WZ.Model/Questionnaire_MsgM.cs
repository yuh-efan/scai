using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class Questionnaire_MsgM
    {
        private int _MsgSN;
        private int _FK_User;
        private int _FK_Questionnaire;
        private string _EMail;
        private string _Detail;
        private string _ReDetail;
        private byte _Purview;
        private string _IP;
        private DateTime _AddDate;

        public int MsgSN
        {
            get { return this._MsgSN; }
            set { this._MsgSN = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        public int FK_Questionnaire
        {
            get { return this._FK_Questionnaire; }
            set { this._FK_Questionnaire = value; }
        }

        public string EMail
        {
            get { return this._EMail; }
            set { this._EMail = value; }
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

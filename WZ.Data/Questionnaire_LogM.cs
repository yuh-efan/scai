using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Data
{
    /// <summary>
    /// 调查日志表
    /// </summary>
    public class Questionnaire_LogM
    {
        private int _ql_id;
        private int _FK_User;
        private int _FK_Questionnaire;
        private string _ql_ip;
        private DateTime _ql_AddDate;

        public int ql_id
        {
            get { return this._ql_id; }
            set { this._ql_id = value; }
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

        public string ql_ip
        {
            get { return this._ql_ip; }
            set { this._ql_ip = value; }
        }

        public DateTime ql_AddDate
        {
            get { return this._ql_AddDate; }
            set { this._ql_AddDate = value; }
        }
    }

}

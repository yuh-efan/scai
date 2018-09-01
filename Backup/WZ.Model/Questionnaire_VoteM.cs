using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 问卷调查 投票表
    /// </summary>
    public class Questionnaire_VoteM
    {
        private int _VoteSN;
        private int _FK_Questionnaire;
        private string _VoteName;
        private string _Detail;
        private int _Total;
        private int _Taxis;

        public int VoteSN
        {
            get { return this._VoteSN; }
            set { this._VoteSN = value; }
        }

        public int FK_Questionnaire
        {
            get { return this._FK_Questionnaire; }
            set { this._FK_Questionnaire = value; }
        }

        public string VoteName
        {
            get { return this._VoteName; }
            set { this._VoteName = value; }
        }

        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        public int Total
        {
            get { return this._Total; }
            set { this._Total = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }
    }
}

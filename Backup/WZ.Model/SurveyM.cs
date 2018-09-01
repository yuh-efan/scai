using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 调查表
    /// </summary>
    public class SurveyM
    {
        private int _SurveySN;
        private int _FK_User;
        private string _BirDate;
        private string _FamilyN;
        private int _Trades;
        private int _Income;
        private int _Cuisine;
        private int _Vegetables;
        private int _Taste;
        private int _Factor;
        private string _Proposal;

        public int SurveySN
        {
            get { return this._SurveySN; }
            set { this._SurveySN = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        public string BirDate
        {
            get { return this._BirDate; }
            set { this._BirDate = value; }
        }

        public string FamilyN
        {
            get { return this._FamilyN; }
            set { this._FamilyN = value; }
        }

        /// <summary>
        /// 从事行业
        /// </summary>
        public int Trades
        {
            get { return this._Trades; }
            set { this._Trades = value; }
        }

        /// <summary>
        /// 月平均收入
        /// </summary>
        public int Income
        {
            get { return this._Income; }
            set { this._Income = value; }
        }

        /// <summary>
        /// 厨艺水平
        /// </summary>
        public int Cuisine
        {
            get { return this._Cuisine; }
            set { this._Cuisine = value; }
        }

        /// <summary>
        /// 菜系
        /// </summary>
        public int Vegetables
        {
            get { return this._Vegetables; }
            set { this._Vegetables = value; }
        }

        /// <summary>
        /// 口味
        /// </summary>
        public int Taste
        {
            get { return this._Taste; }
            set { this._Taste = value; }
        }

        /// <summary>
        /// 网购食品您更注重那些因素
        /// </summary>
        public int Factor
        {
            get { return this._Factor; }
            set { this._Factor = value; }
        }

        /// <summary>
        /// 对搜菜网的建议
        /// </summary>
        public string Proposal
        {
            get { return this._Proposal; }
            set { this._Proposal = value; }
        }
    }

}

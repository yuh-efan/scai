using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 帮助信息
    /// </summary>
    public class Help_InfoM
    {
        private int _HelpSN;
        private double _FK_Help_Class;
        private string _Title;
        private string _Detail;
        private int _Taxis;
        private DateTime _EditDate;
        private DateTime _AddDate;
        private int _Item;

        public int HelpSN
        {
            get { return this._HelpSN; }
            set { this._HelpSN = value; }
        }

        public double FK_Help_Class
        {
            get { return this._FK_Help_Class; }
            set { this._FK_Help_Class = value; }
        }

        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }

        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }

        public DateTime EditDate
        {
            get { return this._EditDate; }
            set { this._EditDate = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }

        /// <summary>
        /// 1:显示底部
        /// </summary>
        public int Item
        {
            get { return this._Item; }
            set { this._Item = value; }
        }
    }
}

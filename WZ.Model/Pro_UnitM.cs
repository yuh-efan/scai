using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class Pro_UnitM
    {
        private int _UnitSN;
        private string _UnitName;
        private int _Taxis;

        public int UnitSN
        {
            get { return this._UnitSN; }
            set { this._UnitSN = value; }
        }

        public string UnitName
        {
            get { return this._UnitName; }
            set { this._UnitName = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }
    }
}

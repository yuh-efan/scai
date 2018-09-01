using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class Pub_Area1M
    {
        private double _ClassSN;
        private string _ClassName;
        private int _Taxis;

        public double ClassSN
        {
            get { return this._ClassSN; }
            set { this._ClassSN = value; }
        }

        public string ClassName
        {
            get { return this._ClassName; }
            set { this._ClassName = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }
    }
}

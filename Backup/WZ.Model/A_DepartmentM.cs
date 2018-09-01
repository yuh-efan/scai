using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class A_DepartmentM
    {
        private int _ClassSN;
        private int _PClassSN;
        private string _ClassName;
        private int _Taxis;
        private int _ClassLevel;
        private string _Detail;

        public int ClassSN
        {
            get { return this._ClassSN; }
            set { this._ClassSN = value; }
        }

        public int PClassSN
        {
            get { return this._PClassSN; }
            set { this._PClassSN = value; }
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

        public int ClassLevel
        {
            get { return this._ClassLevel; }
            set { this._ClassLevel = value; }
        }

        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }
    }

}

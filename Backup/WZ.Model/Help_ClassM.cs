using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 帮助分类
    /// </summary>
    public class Help_ClassM
    {
        private double _ClassSN;
        private int _PClassSN;
        private string _ClassName;
        private int _Taxis;
        private byte _ClassLevel;
        private string _Str;
        private byte _IsDel;

        public double ClassSN
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

        public byte ClassLevel
        {
            get { return this._ClassLevel; }
            set { this._ClassLevel = value; }
        }

        /// <summary>
        /// 别名
        /// </summary>
        public string Str
        {
            get { return this._Str; }
            set { this._Str = value; }
        }

        public byte IsDel
        {
            get { return this._IsDel; }
            set { this._IsDel = value; }
        }
    }
}

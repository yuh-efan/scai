using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class Vote_ClassM
    {
        private int _ClassSN;
        private int _PClassSN;
        private string _ClassName;
        private int _Taxis;
        private byte _ClassLevel;
        private string _Str;
        private string _PicS;

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

        public byte ClassLevel
        {
            get { return this._ClassLevel; }
            set { this._ClassLevel = value; }
        }

        /// <summary>
        /// 唯一值
        /// </summary>
        public string Str
        {
            get { return this._Str; }
            set { this._Str = value; }
        }

        public string PicS
        {
            get { return this._PicS; }
            set { this._PicS = value; }
        }
    }
}

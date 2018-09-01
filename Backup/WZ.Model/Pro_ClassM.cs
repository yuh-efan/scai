using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 产品分类
    /// </summary>
    public class Pro_ClassM
    {
        private int _ClassSN;
        private int _PClassSN;
        private string _ClassName;
        private int _Taxis;
        private byte _ClassLevel;
        private byte _Item;
        private byte _IsShow;

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
        /// 1:显示首页 2:首页栏目
        /// </summary>
        public byte Item
        {
            get { return this._Item; }
            set { this._Item = value; }
        }

        /// <summary>
        /// 是否前台显示
        /// </summary>
        public byte IsShow
        {
            get { return this._IsShow; }
            set { this._IsShow = value; }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 菜谱属性分类
    /// </summary>
    public class CaiPu_ClassAttrM
    {
        private int _ClassSN;
        private int _PClassSN;
        private string _ClassName;
        private int _Taxis;
        private byte _ClassLevel;
        private byte _IsDel;

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
        /// 可否删除 0:可以删除 1:不能删除
        /// </summary>
        public byte IsDel
        {
            get { return this._IsDel; }
            set { this._IsDel = value; }
        }
    }
}

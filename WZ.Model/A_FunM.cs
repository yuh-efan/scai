using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 功能表
    /// </summary>
    public class A_FunM
    {
        private int _ClassSN;
        private int _PClassSN;
        private string _ClassName;
        private int _Taxis;
        private int _ClassLevel;
        private string _f_SoleIdentifier;
        private string _f_FileName;
        private byte _f_IsShowMenu;
        private byte _f_IsShowSetFun;
        private string _f_Detail;

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

        /// <summary>
        /// 功能名称
        /// </summary>
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

        /// <summary>
        /// 权限标识
        /// </summary>
        public string f_SoleIdentifier
        {
            get { return this._f_SoleIdentifier; }
            set { this._f_SoleIdentifier = value; }
        }

        /// <summary>
        /// 功能文件路径 若没有可能为空
        /// </summary>
        public string f_FileName
        {
            get { return this._f_FileName; }
            set { this._f_FileName = value; }
        }

        /// <summary>
        /// 1:是否做为菜单显示
        /// </summary>
        public byte f_IsShowMenu
        {
            get { return this._f_IsShowMenu; }
            set { this._f_IsShowMenu = value; }
        }

        public byte f_IsShowSetFun
        {
            get { return this._f_IsShowSetFun; }
            set { this._f_IsShowSetFun = value; }
        }

        /// <summary>
        /// 功能说明
        /// </summary>
        public string f_Detail
        {
            get { return this._f_Detail; }
            set { this._f_Detail = value; }
        }
    }


}

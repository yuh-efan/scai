using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 菜谱属性分类 值
    /// </summary>
    public class CaiPu_ClassAttrInfoM
    {
        private int _AttrSN;
        private int _FK_Info;
        private int _FK_Info_ClassAttr1;
        private int _FK_Info_ClassAttr2;

        public int AttrSN
        {
            get { return this._AttrSN; }
            set { this._AttrSN = value; }
        }

        public int FK_Info
        {
            get { return this._FK_Info; }
            set { this._FK_Info = value; }
        }

        /// <summary>
        /// 一级分类id
        /// </summary>
        public int FK_Info_ClassAttr1
        {
            get { return this._FK_Info_ClassAttr1; }
            set { this._FK_Info_ClassAttr1 = value; }
        }

        /// <summary>
        /// 二级分类id
        /// </summary>
        public int FK_Info_ClassAttr2
        {
            get { return this._FK_Info_ClassAttr2; }
            set { this._FK_Info_ClassAttr2 = value; }
        }
    }
}

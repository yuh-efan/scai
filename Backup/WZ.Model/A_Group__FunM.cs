using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 组与功能关联表
    /// </summary>
    public class A_Group__FunM
    {
        private int _g_f_ID;
        private string _FK_A_Fun__SoleIdentifier;
        private string _FK_A_Group__SoleIdentifier;

        public int g_f_ID
        {
            get { return this._g_f_ID; }
            set { this._g_f_ID = value; }
        }

        /// <summary>
        /// A_Fun 唯一标识符
        /// </summary>
        public string FK_A_Fun__SoleIdentifier
        {
            get { return this._FK_A_Fun__SoleIdentifier; }
            set { this._FK_A_Fun__SoleIdentifier = value; }
        }

        public string FK_A_Group__SoleIdentifier
        {
            get { return this._FK_A_Group__SoleIdentifier; }
            set { this._FK_A_Group__SoleIdentifier = value; }
        }
    }

}

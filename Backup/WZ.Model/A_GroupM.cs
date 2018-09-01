using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 管理组
    /// </summary>
    public class A_GroupM
    {
        private int _g_ID;
        private string _g_Name;
        private string _g_SoleIdentifier;

        public int g_ID
        {
            get { return this._g_ID; }
            set { this._g_ID = value; }
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string g_Name
        {
            get { return this._g_Name; }
            set { this._g_Name = value; }
        }

        /// <summary>
        /// 唯一标识符
        /// </summary>
        public string g_SoleIdentifier
        {
            get { return this._g_SoleIdentifier; }
            set { this._g_SoleIdentifier = value; }
        }
    }

}

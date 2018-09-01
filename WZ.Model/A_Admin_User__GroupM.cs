using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 管理员与组关联
    /// </summary>
    public class A_Admin_User__GroupM
    {
        private int _au_g_id;
        private int _FK_A_Admin_User;
        private string _FK_A_Group__SoleIdentifier;

        public int au_g_id
        {
            get { return this._au_g_id; }
            set { this._au_g_id = value; }
        }

        public int FK_A_Admin_User
        {
            get { return this._FK_A_Admin_User; }
            set { this._FK_A_Admin_User = value; }
        }

        public string FK_A_Group__SoleIdentifier
        {
            get { return this._FK_A_Group__SoleIdentifier; }
            set { this._FK_A_Group__SoleIdentifier = value; }
        }
    }

}

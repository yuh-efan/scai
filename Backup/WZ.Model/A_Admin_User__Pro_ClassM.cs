using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 管理员与产品分类(产品分类负责人)
    /// </summary>
    public class A_Admin_User__Pro_ClassM
    {
        private int _au_pc_id;
        private int _FK_A_Admin_User;
        private int _FK_Pro_Class;

        public int au_pc_id
        {
            get { return this._au_pc_id; }
            set { this._au_pc_id = value; }
        }

        public int FK_A_Admin_User
        {
            get { return this._FK_A_Admin_User; }
            set { this._FK_A_Admin_User = value; }
        }

        public int FK_Pro_Class
        {
            get { return this._FK_Pro_Class; }
            set { this._FK_Pro_Class = value; }
        }
    }


}

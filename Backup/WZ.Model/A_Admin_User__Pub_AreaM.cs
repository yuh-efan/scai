using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 管理员与区域关联(负责的区域)
    /// </summary>
    public class A_Admin_User__Pub_AreaM
    {
        private int _au_pa_id;
        private int _FK_A_Admin_User;
        private int _FK_Pub_Area;

        public int au_pa_id
        {
            get { return this._au_pa_id; }
            set { this._au_pa_id = value; }
        }

        public int FK_A_Admin_User
        {
            get { return this._FK_A_Admin_User; }
            set { this._FK_A_Admin_User = value; }
        }

        public int FK_Pub_Area
        {
            get { return this._FK_Pub_Area; }
            set { this._FK_Pub_Area = value; }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class User_CartM
    {
        private int _CartSN;
        private int _FK_All;
        private int _FK_User;
        private double _Num;

        public int CartSN
        {
            get { return this._CartSN; }
            set { this._CartSN = value; }
        }

        /// <summary>
        /// 产品id,营养套餐id 等都可以
        /// </summary>
        public int FK_All
        {
            get { return this._FK_All; }
            set { this._FK_All = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        public double Num
        {
            get { return this._Num; }
            set { this._Num = value; }
        }
    }
}

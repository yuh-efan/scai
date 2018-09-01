using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 会员等级对应产品价格表
    /// </summary>
    public class Pro_LevelPriceM
    {
        private int _LPSN;
        private int _FK_User_Level;
        private int _FK_Pro;
        private double _LevelPrice;

        public int LPSN
        {
            get { return this._LPSN; }
            set { this._LPSN = value; }
        }

        public int FK_User_Level
        {
            get { return this._FK_User_Level; }
            set { this._FK_User_Level = value; }
        }

        public int FK_Pro
        {
            get { return this._FK_Pro; }
            set { this._FK_Pro = value; }
        }

        public double LevelPrice
        {
            get { return this._LevelPrice; }
            set { this._LevelPrice = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 用户收藏
    /// </summary>
    public class User_FavM
    {
        private int _FavSN;
        private int _FK_All;
        private int _FK_User;
        private byte _InfoType;
        private DateTime _AddDate;

        public int FavSN
        {
            get { return this._FavSN; }
            set { this._FavSN = value; }
        }

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

        /// <summary>
        /// 0:产品 1:菜谱 2:套餐
        /// </summary>
        public byte InfoType
        {
            get { return this._InfoType; }
            set { this._InfoType = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }
}

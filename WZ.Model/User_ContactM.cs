using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 收货方联系信息
    /// </summary>
    public class User_ContactM
    {
        private int _ConSN;
        private int _FK_User;
        private int _FK_Area;
        private string _Name;
        private string _Address;
        private string _FixTel;
        private string _Tel;

        /// <summary>
        /// 收货信息
        /// </summary>
        public int ConSN
        {
            get { return this._ConSN; }
            set { this._ConSN = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        public int FK_Area
        {
            get { return this._FK_Area; }
            set { this._FK_Area = value; }
        }

        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }

        public string Address
        {
            get { return this._Address; }
            set { this._Address = value; }
        }

        public string FixTel
        {
            get { return this._FixTel; }
            set { this._FixTel = value; }
        }

        public string Tel
        {
            get { return this._Tel; }
            set { this._Tel = value; }
        }
    }


}

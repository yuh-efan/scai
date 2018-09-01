using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 预订产品库
    /// </summary>
    public class E_BookProM
    {
        private int _bp_ID;
        private int _FK_A_Admin_User;
        private int _FK_Pro;
        private string _bp_ProNumber;
        private string _bp_ProName;
        private string _bp_ProUnit;
        private double _bp_ProUnitNum;
        private double _bp_Num;
        private DateTime _bp_AddDate;

        public int bp_ID
        {
            get { return this._bp_ID; }
            set { this._bp_ID = value; }
        }

        public int FK_A_Admin_User
        {
            get { return this._FK_A_Admin_User; }
            set { this._FK_A_Admin_User = value; }
        }

        public int FK_Pro
        {
            get { return this._FK_Pro; }
            set { this._FK_Pro = value; }
        }

        public string bp_ProNumber
        {
            get { return this._bp_ProNumber; }
            set { this._bp_ProNumber = value; }
        }

        public string bp_ProName
        {
            get { return this._bp_ProName; }
            set { this._bp_ProName = value; }
        }

        public string bp_ProUnit
        {
            get { return this._bp_ProUnit; }
            set { this._bp_ProUnit = value; }
        }

        public double bp_ProUnitNum
        {
            get { return this._bp_ProUnitNum; }
            set { this._bp_ProUnitNum = value; }
        }

        public double bp_Num
        {
            get { return this._bp_Num; }
            set { this._bp_Num = value; }
        }

        public DateTime bp_AddDate
        {
            get { return this._bp_AddDate; }
            set { this._bp_AddDate = value; }
        }
    }
}

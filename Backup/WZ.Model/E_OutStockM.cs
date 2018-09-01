using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 出库记录
    /// </summary>
    public class E_OutStockM
    {
        private int _os_ID;
        private int _FK_A_Admin_User;
        private int _FK_A_Admin_User_Job;
        private int _FK_Pro;
        private string _os_AdminName;
        private string _os_AdminRealName;
        private string _os_ProNumber;
        private string _os_ProName;
        private string _os_ProUnit;
        private double _os_ProUnitNum;
        private double _os_Num;
        private int _os_Type;
        private string _os_Remark;
        private DateTime _os_AddDate;

        public int os_ID
        {
            get { return this._os_ID; }
            set { this._os_ID = value; }
        }

        public int FK_A_Admin_User
        {
            get { return this._FK_A_Admin_User; }
            set { this._FK_A_Admin_User = value; }
        }

        /// <summary>
        /// 负责人
        /// </summary>
        public int FK_A_Admin_User_Job
        {
            get { return this._FK_A_Admin_User_Job; }
            set { this._FK_A_Admin_User_Job = value; }
        }

        public int FK_Pro
        {
            get { return this._FK_Pro; }
            set { this._FK_Pro = value; }
        }

        public string os_AdminName
        {
            get { return this._os_AdminName; }
            set { this._os_AdminName = value; }
        }

        public string os_AdminRealName
        {
            get { return this._os_AdminRealName; }
            set { this._os_AdminRealName = value; }
        }

        public string os_ProNumber
        {
            get { return this._os_ProNumber; }
            set { this._os_ProNumber = value; }
        }

        public string os_ProName
        {
            get { return this._os_ProName; }
            set { this._os_ProName = value; }
        }

        public string os_ProUnit
        {
            get { return this._os_ProUnit; }
            set { this._os_ProUnit = value; }
        }

        public double os_ProUnitNum
        {
            get { return this._os_ProUnitNum; }
            set { this._os_ProUnitNum = value; }
        }

        public double os_Num
        {
            get { return this._os_Num; }
            set { this._os_Num = value; }
        }

        /// <summary>
        /// 出库类型 0:正常出库 1:损耗出库
        /// </summary>
        public int os_Type
        {
            get { return this._os_Type; }
            set { this._os_Type = value; }
        }

        public string os_Remark
        {
            get { return this._os_Remark; }
            set { this._os_Remark = value; }
        }

        public DateTime os_AddDate
        {
            get { return this._os_AddDate; }
            set { this._os_AddDate = value; }
        }
    }

}

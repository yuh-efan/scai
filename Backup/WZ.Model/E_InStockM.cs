using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 入库记录
    /// </summary>
    public class E_InStockM
    {
        private int _is_ID;
        private int _FK_A_Admin_User;
        private int _FK_A_Admin_User_Job;
        private int _FK_Pro;
        private string _is_AdminName;
        private string _is_AdminRealName;
        private string _is_ProNumber;
        private string _is_ProName;
        private string _is_ProUnit;
        private double _is_ProUnitNum;
        private double _is_Num;
        private int _is_Type;
        private string _is_Remark;
        private DateTime _is_AddDate;

        public int is_ID
        {
            get { return this._is_ID; }
            set { this._is_ID = value; }
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

        public string is_AdminName
        {
            get { return this._is_AdminName; }
            set { this._is_AdminName = value; }
        }

        public string is_AdminRealName
        {
            get { return this._is_AdminRealName; }
            set { this._is_AdminRealName = value; }
        }

        public string is_ProNumber
        {
            get { return this._is_ProNumber; }
            set { this._is_ProNumber = value; }
        }

        public string is_ProName
        {
            get { return this._is_ProName; }
            set { this._is_ProName = value; }
        }

        public string is_ProUnit
        {
            get { return this._is_ProUnit; }
            set { this._is_ProUnit = value; }
        }

        public double is_ProUnitNum
        {
            get { return this._is_ProUnitNum; }
            set { this._is_ProUnitNum = value; }
        }

        public double is_Num
        {
            get { return this._is_Num; }
            set { this._is_Num = value; }
        }

        /// <summary>
        /// 入库类型 0:正常入库 1:损耗入库
        /// </summary>
        public int is_Type
        {
            get { return this._is_Type; }
            set { this._is_Type = value; }
        }

        public string is_Remark
        {
            get { return this._is_Remark; }
            set { this._is_Remark = value; }
        }

        public DateTime is_AddDate
        {
            get { return this._is_AddDate; }
            set { this._is_AddDate = value; }
        }
    }


}

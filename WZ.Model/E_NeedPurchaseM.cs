using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 需要采购的产品
    /// </summary>
    public class E_NeedPurchaseM
    {
        private int _np_ID;
        private int _FK_A_Admin_User;
        private int _FK_A_Admin_User_Job;
        private string _np_AdminName;
        private string _np_AdminRealName;
        private int _FK_Pro;
        private byte _np_ProLevel;
        private string _np_ProNumber;
        private string _np_ProName;
        private string _np_ProUnit;
        private double _np_ProUnitNum;
        private double _np_CurProStock;
        private double _np_Num;
        private double _np_InStockNum;
        private string _np_UserRemark;
        private int _np_Status;
        private int _np_Type;
        private string _np_Remark;
        private DateTime _np_AddDate;

        public int np_ID
        {
            get { return this._np_ID; }
            set { this._np_ID = value; }
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

        public string np_AdminName
        {
            get { return this._np_AdminName; }
            set { this._np_AdminName = value; }
        }

        public string np_AdminRealName
        {
            get { return this._np_AdminRealName; }
            set { this._np_AdminRealName = value; }
        }

        public int FK_Pro
        {
            get { return this._FK_Pro; }
            set { this._FK_Pro = value; }
        }

        public byte np_ProLevel
        {
            get { return this._np_ProLevel; }
            set { this._np_ProLevel = value; }
        }

        public string np_ProNumber
        {
            get { return this._np_ProNumber; }
            set { this._np_ProNumber = value; }
        }

        public string np_ProName
        {
            get { return this._np_ProName; }
            set { this._np_ProName = value; }
        }

        public string np_ProUnit
        {
            get { return this._np_ProUnit; }
            set { this._np_ProUnit = value; }
        }

        public double np_ProUnitNum
        {
            get { return this._np_ProUnitNum; }
            set { this._np_ProUnitNum = value; }
        }

        public double np_CurProStock
        {
            get { return this._np_CurProStock; }
            set { this._np_CurProStock = value; }
        }

        public double np_Num
        {
            get { return this._np_Num; }
            set { this._np_Num = value; }
        }

        /// <summary>
        /// 已入库数量
        /// </summary>
        public double np_InStockNum
        {
            get { return this._np_InStockNum; }
            set { this._np_InStockNum = value; }
        }

        public string np_UserRemark
        {
            get { return this._np_UserRemark; }
            set { this._np_UserRemark = value; }
        }

        /// <summary>
        /// 入库状态 0:未入库 1:已入库 2:部分入库 
        /// </summary>
        public int np_Status
        {
            get { return this._np_Status; }
            set { this._np_Status = value; }
        }

        /// <summary>
        /// 0:前台提交 1:手工提交
        /// </summary>
        public int np_Type
        {
            get { return this._np_Type; }
            set { this._np_Type = value; }
        }

        public string np_Remark
        {
            get { return this._np_Remark; }
            set { this._np_Remark = value; }
        }

        public DateTime np_AddDate
        {
            get { return this._np_AddDate; }
            set { this._np_AddDate = value; }
        }
    }
}

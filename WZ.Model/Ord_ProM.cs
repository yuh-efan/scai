using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 订单产品列表
    /// </summary>
    public class Ord_ProM
    {
        private int _op_ID;
        private int _FK_Order;
        private int _FK_Pro;
        private int _FK_User;
        private byte _op_ProLevel;
        private string _op_ProName;
        private string _op_ProNumber;
        private string _op_ProUnit;
        private double _op_ProUnitNum;
        private double _op_ProPrice;
        private double _op_UserPrice;
        private double _op_UserTotalPrice;
        private double _op_Percentage;
        private double _op_CurProStock;
        private double _op_Num;
        private double _op_ActualNum;
        private int _op_Status;
        private int _op_StatusOutStock;
        private DateTime _op_AddDate;

        public int op_ID
        {
            get { return this._op_ID; }
            set { this._op_ID = value; }
        }

        public int FK_Order
        {
            get { return this._FK_Order; }
            set { this._FK_Order = value; }
        }

        public int FK_Pro
        {
            get { return this._FK_Pro; }
            set { this._FK_Pro = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        public byte op_ProLevel
        {
            get { return this._op_ProLevel; }
            set { this._op_ProLevel = value; }
        }

        public string op_ProName
        {
            get { return this._op_ProName; }
            set { this._op_ProName = value; }
        }

        public string op_ProNumber
        {
            get { return this._op_ProNumber; }
            set { this._op_ProNumber = value; }
        }

        public string op_ProUnit
        {
            get { return this._op_ProUnit; }
            set { this._op_ProUnit = value; }
        }

        public double op_ProUnitNum
        {
            get { return this._op_ProUnitNum; }
            set { this._op_ProUnitNum = value; }
        }

        /// <summary>
        /// 产品价格
        /// </summary>
        public double op_ProPrice
        {
            get { return this._op_ProPrice; }
            set { this._op_ProPrice = value; }
        }

        /// <summary>
        /// 用户实际价格
        /// </summary>
        public double op_UserPrice
        {
            get { return this._op_UserPrice; }
            set { this._op_UserPrice = value; }
        }

        /// <summary>
        /// 用户小计价格
        /// </summary>
        public double op_UserTotalPrice
        {
            get { return this._op_UserTotalPrice; }
            set { this._op_UserTotalPrice = value; }
        }

        public double op_Percentage
        {
            get { return this._op_Percentage; }
            set { this._op_Percentage = value; }
        }

        public double op_CurProStock
        {
            get { return this._op_CurProStock; }
            set { this._op_CurProStock = value; }
        }

        /// <summary>
        /// 订购产品数量
        /// </summary>
        public double op_Num
        {
            get { return this._op_Num; }
            set { this._op_Num = value; }
        }

        /// <summary>
        /// 实际发货数量
        /// </summary>
        public double op_ActualNum
        {
            get { return this._op_ActualNum; }
            set { this._op_ActualNum = value; }
        }

        /// <summary>
        /// 分配状态  0:未分配置 1:已分配
        /// </summary>
        public int op_Status
        {
            get { return this._op_Status; }
            set { this._op_Status = value; }
        }

        /// <summary>
        /// 出库状态 0:未出库 1:已出库 2:部分出库
        /// </summary>
        public int op_StatusOutStock
        {
            get { return this._op_StatusOutStock; }
            set { this._op_StatusOutStock = value; }
        }

        public DateTime op_AddDate
        {
            get { return this._op_AddDate; }
            set { this._op_AddDate = value; }
        }
    }


}

using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 投拆信息
    /// </summary>
    public class Complaint_InfoM
    {
        private int _cp_SN;
        private int _FK_A_Admin_User;
        private string _cp_TakeOver;
        private int _cp_Type;
        private string _cp_UserName;
        private string _cp_RealName;
        private string _cp_Title;
        private string _cp_Detail;
        private string _cp_HandleResult;
        private int _cp_Status;
        private DateTime _cp_AddDate_Complaint;
        private DateTime _cp_AddDate;

        public int cp_SN
        {
            get { return this._cp_SN; }
            set { this._cp_SN = value; }
        }

        /// <summary>
        /// 添加记录人
        /// </summary>
        public int FK_A_Admin_User
        {
            get { return this._FK_A_Admin_User; }
            set { this._FK_A_Admin_User = value; }
        }

        /// <summary>
        /// 接手客服
        /// </summary>
        public string cp_TakeOver
        {
            get { return this._cp_TakeOver; }
            set { this._cp_TakeOver = value; }
        }

        public int cp_Type
        {
            get { return this._cp_Type; }
            set { this._cp_Type = value; }
        }

        public string cp_UserName
        {
            get { return this._cp_UserName; }
            set { this._cp_UserName = value; }
        }

        public string cp_RealName
        {
            get { return this._cp_RealName; }
            set { this._cp_RealName = value; }
        }

        public string cp_Title
        {
            get { return this._cp_Title; }
            set { this._cp_Title = value; }
        }

        /// <summary>
        /// 投拆信息
        /// </summary>
        public string cp_Detail
        {
            get { return this._cp_Detail; }
            set { this._cp_Detail = value; }
        }

        /// <summary>
        /// 问题处理结果
        /// </summary>
        public string cp_HandleResult
        {
            get { return this._cp_HandleResult; }
            set { this._cp_HandleResult = value; }
        }

        /// <summary>
        /// 0:未处理 1:处理中 2:已完成处理 3:取消处理
        /// </summary>
        public int cp_Status
        {
            get { return this._cp_Status; }
            set { this._cp_Status = value; }
        }

        /// <summary>
        /// 客户投拆时间
        /// </summary>
        public DateTime cp_AddDate_Complaint
        {
            get { return this._cp_AddDate_Complaint; }
            set { this._cp_AddDate_Complaint = value; }
        }

        /// <summary>
        /// 记录添加时间
        /// </summary>
        public DateTime cp_AddDate
        {
            get { return this._cp_AddDate; }
            set { this._cp_AddDate = value; }
        }
    }


}

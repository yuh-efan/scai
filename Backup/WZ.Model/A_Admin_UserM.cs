using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 管理员表
    /// </summary>
    public class A_Admin_UserM
    {
        private int _au_ID;
        private int _FK_A_Department;
        private string _au_WorkNumber;
        private string _au_Name;
        private string _au_Password;
        private string _au_RealName;
        private byte _au_Sex;
        private string _au_Tel;
        private string _au_ComTel;
        private string _au_Address;
        private string _au_QQ;
        private DateTime _au_AddTime;
        private int _au_LoginN;
        private string _au_LastIP;
        private DateTime _au_LastTime;
        private string _au_SessionID;
        private int _au_ThingStatus;
        private int _au_Status;
        private int _au_Integral;
        private int _au_Level;

        public int au_ID
        {
            get { return this._au_ID; }
            set { this._au_ID = value; }
        }

        /// <summary>
        /// 部门id
        /// </summary>
        public int FK_A_Department
        {
            get { return this._FK_A_Department; }
            set { this._FK_A_Department = value; }
        }

        /// <summary>
        /// 工号
        /// </summary>
        public string au_WorkNumber
        {
            get { return this._au_WorkNumber; }
            set { this._au_WorkNumber = value; }
        }

        /// <summary>
        /// 管理员用户名
        /// </summary>
        public string au_Name
        {
            get { return this._au_Name; }
            set { this._au_Name = value; }
        }

        /// <summary>
        /// 管理员密码
        /// </summary>
        public string au_Password
        {
            get { return this._au_Password; }
            set { this._au_Password = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string au_RealName
        {
            get { return this._au_RealName; }
            set { this._au_RealName = value; }
        }

        public byte au_Sex
        {
            get { return this._au_Sex; }
            set { this._au_Sex = value; }
        }

        public string au_Tel
        {
            get { return this._au_Tel; }
            set { this._au_Tel = value; }
        }

        public string au_ComTel
        {
            get { return this._au_ComTel; }
            set { this._au_ComTel = value; }
        }

        public string au_Address
        {
            get { return this._au_Address; }
            set { this._au_Address = value; }
        }

        public string au_QQ
        {
            get { return this._au_QQ; }
            set { this._au_QQ = value; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime au_AddTime
        {
            get { return this._au_AddTime; }
            set { this._au_AddTime = value; }
        }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int au_LoginN
        {
            get { return this._au_LoginN; }
            set { this._au_LoginN = value; }
        }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string au_LastIP
        {
            get { return this._au_LastIP; }
            set { this._au_LastIP = value; }
        }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime au_LastTime
        {
            get { return this._au_LastTime; }
            set { this._au_LastTime = value; }
        }

        public string au_SessionID
        {
            get { return this._au_SessionID; }
            set { this._au_SessionID = value; }
        }

        /// <summary>
        /// 0:正常 1:请假 2:出差 3:其它....
        /// </summary>
        public int au_ThingStatus
        {
            get { return this._au_ThingStatus; }
            set { this._au_ThingStatus = value; }
        }

        /// <summary>
        /// 管理员状态 0:正常 1:禁用
        /// </summary>
        public int au_Status
        {
            get { return this._au_Status; }
            set { this._au_Status = value; }
        }

        /// <summary>
        /// 管理员积分
        /// </summary>
        public int au_Integral
        {
            get { return this._au_Integral; }
            set { this._au_Integral = value; }
        }

        /// <summary>
        /// 管理员等级
        /// </summary>
        public int au_Level
        {
            get { return this._au_Level; }
            set { this._au_Level = value; }
        }
    }

}

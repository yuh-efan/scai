using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 活动列表
    /// </summary>
    public class Activity_InfoM
    {
        private int _act_ID;
        private string _act_Identifier;
        private string _act_Name;
        private byte _act_Status;

        public int act_ID
        {
            get { return this._act_ID; }
            set { this._act_ID = value; }
        }

        public string act_Identifier
        {
            get { return this._act_Identifier; }
            set { this._act_Identifier = value; }
        }

        public string act_Name
        {
            get { return this._act_Name; }
            set { this._act_Name = value; }
        }

        /// <summary>
        /// 活动状态 0:关闭活动 1:开启活动
        /// </summary>
        public byte act_Status
        {
            get { return this._act_Status; }
            set { this._act_Status = value; }
        }
    }
}

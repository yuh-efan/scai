using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 问卷调查主表
    /// </summary>
    public class QuestionnaireM
    {
        private int _QuSN;
        private byte _ShowType;
        private string _QuName;
        private string _Detail;
        private DateTime _AddDate;
        private int _Taxis;
        private byte _IsOpen;
        private int _Item;

        public int QuSN
        {
            get { return this._QuSN; }
            set { this._QuSN = value; }
        }

        /// <summary>
        /// 显示方式 0:复选框 1:单选框
        /// </summary>
        public byte ShowType
        {
            get { return this._ShowType; }
            set { this._ShowType = value; }
        }

        public string QuName
        {
            get { return this._QuName; }
            set { this._QuName = value; }
        }

        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }

        /// <summary>
        /// 0:关闭 1:开户
        /// </summary>
        public byte IsOpen
        {
            get { return this._IsOpen; }
            set { this._IsOpen = value; }
        }

        /// <summary>
        /// 暂时用不到
        /// </summary>
        public int Item
        {
            get { return this._Item; }
            set { this._Item = value; }
        }
    }
}

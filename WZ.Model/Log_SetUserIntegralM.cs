using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 设置会员积分日志
    /// </summary>
    public class Log_SetUserIntegralM
    {
        private int _SUISN;
        private int _FK_User;
        private int _FK_All;
        private string _Operator;
        private string _Fract_Identifier;
        private int _SetValue;
        private string _Remark;
        private string _IP;
        private DateTime _AddDate;

        public int SUISN
        {
            get { return this._SUISN; }
            set { this._SUISN = value; }
        }

        public int FK_User
        {
            get { return this._FK_User; }
            set { this._FK_User = value; }
        }

        /// <summary>
        /// 被操作对象id(如 产品,新闻,菜谱等)
        /// </summary>
        public int FK_All
        {
            get { return this._FK_All; }
            set { this._FK_All = value; }
        }

        /// <summary>
        /// 操作者(用户名)
        /// </summary>
        public string Operator
        {
            get { return this._Operator; }
            set { this._Operator = value; }
        }

        /// <summary>
        /// 类型标识
        /// </summary>
        public string Fract_Identifier
        {
            get { return this._Fract_Identifier; }
            set { this._Fract_Identifier = value; }
        }

        public int SetValue
        {
            get { return this._SetValue; }
            set { this._SetValue = value; }
        }

        public string Remark
        {
            get { return this._Remark; }
            set { this._Remark = value; }
        }

        public string IP
        {
            get { return this._IP; }
            set { this._IP = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }

}

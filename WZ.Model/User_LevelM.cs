using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 会员等级类型
    /// </summary>
    public class User_LevelM
    {
        private int _LevelSN;
        private byte _LevelType;
        private string _LevelName;
        private double _Percentage;
        private byte _IsDefault;
        private int _LevelExp;

        /// <summary>
        /// 如 1:1级(普通) 2:2级(高级)
        /// </summary>
        public int LevelSN
        {
            get { return this._LevelSN; }
            set { this._LevelSN = value; }
        }

        /// <summary>
        /// 0:普通零售会员等级 1:批发代理会员等级
        /// </summary>
        public byte LevelType
        {
            get { return this._LevelType; }
            set { this._LevelType = value; }
        }

        public string LevelName
        {
            get { return this._LevelName; }
            set { this._LevelName = value; }
        }

        /// <summary>
        /// 折扣百分比 0-100
        /// </summary>
        public double Percentage
        {
            get { return this._Percentage; }
            set { this._Percentage = value; }
        }

        /// <summary>
        /// 是否默认会员 1:是 0:否
        /// </summary>
        public byte IsDefault
        {
            get { return this._IsDefault; }
            set { this._IsDefault = value; }
        }

        /// <summary>
        /// 所需经验
        /// </summary>
        public int LevelExp
        {
            get { return this._LevelExp; }
            set { this._LevelExp = value; }
        }
    }

}

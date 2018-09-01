using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 网站配置
    /// </summary>
    public class WebConfigM
    {
        private int _WebConfigSN;
        private string _Str;
        private string _ConfigName;
        private string _Detail;
        private byte _IsShowFCK;

        public int WebConfigSN
        {
            get { return this._WebConfigSN; }
            set { this._WebConfigSN = value; }
        }

        /// <summary>
        /// 唯一标识符
        /// </summary>
        public string Str
        {
            get { return this._Str; }
            set { this._Str = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string ConfigName
        {
            get { return this._ConfigName; }
            set { this._ConfigName = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        /// <summary>
        /// 是否用fck编辑内容 0:否 1:是
        /// </summary>
        public byte IsShowFCK
        {
            get { return this._IsShowFCK; }
            set { this._IsShowFCK = value; }
        }
    }
}

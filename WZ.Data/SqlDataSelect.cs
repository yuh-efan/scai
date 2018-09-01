using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;

namespace WZ.Data
{
    /// <summary>
    /// 获取单条记录
    /// </summary>
    public class SqlDataSelect
    {
        private DataTable dtInfo;

        public DataTable GetInfo
        {
            get { return this.dtInfo; }
        }

        public int Count
        {
            get
            {
                if (dtInfo == null)
                    return 0;

                return dtInfo.Rows.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sSQL">查语句</param>
        public SqlDataSelect(string pSql)
        {
            dtInfo = DbHelp.GetDataTable(pSql);
        }

        public SqlDataSelect(string pSql, IDataParameter[] pDp)
        {
            dtInfo = DbHelp.GetDataTable(pSql, pDp);
        }

        public SqlDataSelect(IDbHelpParam param, IDbHelp thelp)
        {
            this.dtInfo = thelp.GetDataTable(param);
        }

        public SqlDataSelect(DataTable pDt)
        {
            this.dtInfo = pDt;
        }

        /// <summary>
        /// 获取字段内容
        /// </summary>
        /// <param name="pFieldName">字段名</param>
        /// <returns></returns>
        public object Eval(string pFieldName)
        {
            if (dtInfo == null || dtInfo.Rows.Count < 1)
                return string.Empty;

            return dtInfo.Rows[0][pFieldName];
        }
    }
}

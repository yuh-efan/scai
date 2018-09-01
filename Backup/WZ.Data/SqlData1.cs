using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using System.Reflection;
using Newtonsoft.Json;
using System.Web;
using WZ.Common.ICommon;

namespace WZ.Data
{
    /// <summary>
    /// 增,删,改
    /// </summary>
    public class SqlData1
    {
        #region help
        protected IDbHelp curHelp;

        public SqlData1()
        {
            this.curHelp = new DefaultHelp();
        }

        public SqlData1(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        #region 添加单条记录
        /// <summary>
        /// 添加单条记录
        /// </summary>
        /// <param name="pMod"></param>
        /// <param name="pFields"></param>
        /// <returns></returns>
        public bool Add(object pMod, string pFields)
        {
            string tableName = SqlData.GetTableName(pMod);

            if (pFields == null || pFields.Length == 0)
                throw new Exception("字段 " + pFields + " 不能为空");

            string[] aFields = pFields.Split(',');
            int arrN = aFields.Length;

            IDataParameter[] aDp = DbHelp.Def.GetArrParam(arrN);

            string str = string.Empty;
            string str1 = string.Empty;
            string s;
            for (int i = 0; i < arrN; i++)
            {
                s = aFields[i];

                str += s + ",";
                str1 += "@" + s + ",";

                aDp[i] = DbHelp.Def.AddParam("@" + s, SqlData.GetModelFieldValue(s, pMod));
            }

            str = str.TrimEnd(',');
            str1 = str1.TrimEnd(',');
            string sSQL = "insert into  " + tableName + "(" + str + ") values(" + str1 + ")";

            return this.curHelp.Update(sSQL, aDp) > 0;
        }
        #endregion

        #region 添加单条记录并返回ID
        /// <summary>
        /// 添加单条记录并返回ID
        /// </summary>
        /// <param name="pMod"></param>
        /// <param name="pFields"></param>
        /// <returns></returns>
        public int AddReturnID(object pMod, string pFields)
        {
            string tableName = SqlData.GetTableName(pMod);

            if (pFields == null || pFields.Length == 0)
                throw new Exception("字段 " + pFields + " 不能为空");

            string[] aFields = pFields.Split(',');
            int arrN = aFields.Length;

            IDataParameter[] aDp = DbHelp.Def.GetArrParam(arrN);

            string str = string.Empty;
            string str1 = string.Empty;
            string s;
            for (int i = 0; i < arrN; i++)
            {
                s = aFields[i];

                str += s + ",";
                str1 += "@" + s + ",";

                aDp[i] = DbHelp.Def.AddParam("@" + s, SqlData.GetModelFieldValue(s, pMod));
            }

            str = str.TrimEnd(',');
            str1 = str1.TrimEnd(',');
            string sSQL = "insert into  " + tableName + "(" + str + ") values(" + str1 + ");select SCOPE_IDENTITY()";

            return Convert.ToInt32(this.curHelp.Scalar(sSQL, aDp));
        }
        #endregion

        #region 修改单条记录
        /// <summary>
        /// 修改单条记录
        /// </summary>
        /// <param name="pMod"></param>
        /// <param name="pFields"></param>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public bool Edit(object pMod, string pFields, string pWhere)
        {
            string tableName = SqlData.GetTableName(pMod);
            if (pMod == null)
                throw new Exception("IModel对象 不能为null");

            if (pFields == null || pFields.Length == 0)
                throw new Exception("字段不能为空");

            if (pWhere == null || pWhere.Length == 0)
                throw new Exception("where 条件不能为空");

            string[] aFields = pFields.Split(',');
            int arrN = aFields.Length;

            IDataParameter[] aDp = DbHelp.Def.GetArrParam(arrN);

            string str = string.Empty;
            string s;
            for (int i = 0; i < arrN; i++)
            {
                s = aFields[i];

                str += s + "=" + "@" + s + ",";

                aDp[i] = DbHelp.Def.AddParam("@" + s, SqlData.GetModelFieldValue(s, pMod));
            }

            str = str.TrimEnd(',');
            string sSQL = "update  " + tableName + " set " + str + " where " + pWhere;

            return this.curHelp.Update(sSQL, aDp) > 0;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace WZ.Common
{
    /// <summary>
    /// 事务操作基本功能
    /// </summary>
    public class TransHelp : IDbHelp
    {
        private IDbCommand cmd;//查看参数是否不断添加
        private IDbProvider dbProvider;

        public IDbProvider DbProvider
        {
            get { return this.dbProvider; }
        }

        public TransHelp(IDbCommand pCmd)
        {
            this.cmd = pCmd;
            this.dbProvider = DbHelp.Def;
        }

        #region Update
        public int Update(string pSQL)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL);
            return Update(dhp);
        }

        public int Update(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pArrParam);
            return Update(dhp);
        }

        public int Update(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pCmdType, pArrParam);
            return Update(dhp);
        }

        public int Update(IDbHelpParam pDbHelpParam)
        {
            try
            {
                SetCmd(pDbHelpParam);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "trans_Update sql:" + pDbHelpParam.SQL);
            }
        }
        #endregion

        #region DataTable
        public DataTable GetDataTable(string pSQL)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL);
            return GetDataTable(dhp);
        }

        public DataTable GetDataTable(string pSQL, CommandType pCmdType)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pCmdType);
            return GetDataTable(dhp);
        }

        public DataTable GetDataTable(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pArrParam);
            return GetDataTable(dhp);
        }

        public DataTable GetDataTable(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pCmdType, pArrParam);
            return GetDataTable(dhp);
        }

        public DataTable GetDataTable(IDbHelpParam pDbHelpParam)
        {
            try
            {
                DataTable dt = new DataTable();
                DbDataAdapter sda;
                SetCmd(pDbHelpParam);
                sda = dbProvider.NewDataAdapter();
                sda.SelectCommand = (DbCommand)cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "trans_GetDataTable sql:" + pDbHelpParam.SQL);
            }
        }
        #endregion

        #region DataSet
        public DataSet GetDataSet(string pSQL)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL);
            return GetDataSet(dhp);
        }

        public DataSet GetDataSet(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pArrParam);
            return GetDataSet(dhp);
        }

        public DataSet GetDataSet(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pCmdType, pArrParam);
            return GetDataSet(dhp);
        }

        public DataSet GetDataSet(IDbHelpParam pDbHelpParam)
        {
            try
            {
                DataSet ds = new DataSet();
                DbDataAdapter sda;
                SetCmd(pDbHelpParam);
                sda = dbProvider.NewDataAdapter();
                sda.SelectCommand = (DbCommand)cmd;
                sda.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "trans_GetDataSet sql:" + pDbHelpParam.SQL);
            }
        }
        #endregion

        #region Read
        public IDataReader Read(string pSQL)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL);
            return Read(dhp);
        }

        public IDataReader Read(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pArrParam);
            return Read(dhp);
        }

        public IDataReader Read(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pCmdType, pArrParam);
            return Read(dhp);
        }

        public IDataReader Read(IDbHelpParam pDbHelpParam)
        {
            try
            {
                SetCmd(pDbHelpParam);
                IDataReader rdr = cmd.ExecuteReader();
                return rdr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Read sql:" + pDbHelpParam.SQL);
            }
        }
        #endregion

        #region Scalar
        public object Scalar(string pSQL)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL);
            return Scalar(dhp);
        }

        /// <summary>
        /// 第一行第一列 可能为null
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public object Scalar(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pArrParam);
            return Scalar(dhp);
        }

        /// <summary>
        /// 第一行第一列 可能为null
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pCmdType">设置CommandType</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public object Scalar(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pCmdType, pArrParam);
            return Scalar(dhp);
        }

        public object Scalar(IDbHelpParam pDbHelpParam)
        {
            try
            {
                SetCmd(pDbHelpParam);
                object val = cmd.ExecuteScalar();
                return val;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Scalar sql:" + pDbHelpParam.SQL);
            }
        }
        #endregion

        #region First
        public string First(string pSQL)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL);
            return First(dhp, string.Empty);
        }

        public  string First(string pSQL, string pReturn)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL);
            return First(dhp, pReturn);
        }

        public  string First(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pArrParam);
            return First(dhp, string.Empty);
        }

        public  string First(string pSQL, IDataParameter[] pArrParam, string pReturn)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pArrParam);
            return First(dhp, pReturn);
        }

        public  string First(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam, string pReturn)
        {
            IDbHelpParam dhp = new TransHelpParam(pSQL, pCmdType, pArrParam);
            return First(dhp, pReturn);
        }

        public string First(IDbHelpParam pDbHelpParam, string pReturn)
        {
            string str;
            using (IDataReader dr = Read(pDbHelpParam))
            {
                if (dr.Read())
                    str = dr[0].ToString();
                else
                    str = pReturn;

                if (str.Length == 0)
                    str = pReturn;
                return str;
            }
        }
        #endregion

        private void SetCmd(IDbHelpParam pDbHelpParam)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = pDbHelpParam.SQL;
            cmd.CommandType = pDbHelpParam.CmdType;

            if (pDbHelpParam.ArrParm != null)
            {
                foreach (IDataParameter dp in pDbHelpParam.ArrParm)
                    cmd.Parameters.Add(dp);
            }
        }
        #region IDbHelp 成员

        public void ExecuteTrans(IDbHelpParam pDbHelpParam, DbHelp.ExecuteTransHandler pTrands, WZ.Common.DbHelp.ITransM pObj)
        {
            throw new NotImplementedException("事务不能嵌套使用");
        }

        public DataTable GetDataTable_Paging(IDbHelpParam pDbHelpParam, int pPageIndex, int pPageSize)
        {
            throw new NotImplementedException("事务中无分页功能");
        }

        public DataTable GetDataTable_Paging(string pSQL, int pPageIndex, int pPageSize)
        {
            throw new NotImplementedException("事务中无分页功能");
        }

        #endregion
    }
}

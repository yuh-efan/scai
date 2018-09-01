using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace WZ.Common
{
    /// <summary>
    /// SqlServer 驱动
    /// 各成员方法注释在 IDbProvider接口
    /// </summary>
    public class SqlServerProvider : IDbProvider
    {
        private string _StrConn;

        public SqlServerProvider(string pStrConn)
        {
            _StrConn = pStrConn;
        }

        public string StrConn
        {
            get { return _StrConn; }
        }

        public IDataParameter AddParam(string pParamName, object pParamText)
        {
            return new SqlParameter(pParamName, pParamText);
        }

        public IDataParameter AddParam(string pParamName, DbType pDbType, object pParamText)
        {
            SqlParameter Param = new SqlParameter(pParamName, pDbType);
            Param.Value = pParamText;
            return Param;
        }

        public IDataParameter AddParam(string pParamName, DbType pDbType, object pParamText, int pParamSize)
        {
            SqlParameter Param = new SqlParameter(pParamName, pDbType);
            Param.Value = pParamText;
            Param.Size = pParamSize;
            return Param;
        }

        public IDataParameter[] GetArrParam(int pN)
        {
            return new SqlParameter[pN];
        }

        public IDbConnection NewConnection()
        {
            return new SqlConnection(_StrConn); 
        }

        public DbDataAdapter NewDataAdapter()
        {
            return new SqlDataAdapter();
        }

        #region IDisposable 成员
        public void Dispose(IDbConnection pConn)
        {
            pConn.Dispose();
        }
        #endregion
    }
}

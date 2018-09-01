using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;

namespace WZ.Common
{
    /// <summary>
    /// OleDb 驱动 
    /// 各成员方法注释在 IDbProvider接口
    /// </summary>
    public class OleDbProvider : IDbProvider
    {
        private string _StrConn;

        public OleDbProvider(string pStrConn)
        {
            _StrConn = pStrConn;
        }

        public string StrConn
        {
            get { return _StrConn; }
        }

        public IDataParameter AddParam(string pParamName, object pParamText)
        {
            return new OleDbParameter(pParamName, pParamText);
        }

        public IDataParameter AddParam(string pParamName, DbType pDbType, object pParamText)
        {
            OleDbParameter Param = new OleDbParameter(pParamName, pDbType);
            Param.Value = pParamText;
            return Param;
        }

        public IDataParameter AddParam(string pParamName, DbType pDbType, object pParamText, int pParamSize)
        {
            OleDbParameter Param = new OleDbParameter(pParamName, pDbType);
            Param.Value = pParamText;
            Param.Size = pParamSize;
            return Param;
        }

        public IDataParameter[] GetArrParam(int pN)
        {
            return new OleDbParameter[pN];
        }
        
        public IDbConnection NewConnection()
        {
            return new OleDbConnection(_StrConn);
        }

        public DbDataAdapter NewDataAdapter()
        {
            return new OleDbDataAdapter();
        }

        #region IDisposable 成员
        public void Dispose(IDbConnection pConn)
        {
            pConn.Dispose();
        }
        #endregion
    }
}

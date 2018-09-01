using System;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace WZ.Common
{
    /// <summary>
    /// 数据种驱动接口
    /// </summary>
    public interface IDbProvider
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        string StrConn { get; }
        //IDbConnection Conn { get; }
        
        /// <summary>
        /// 添加参数 Parameter
        /// </summary>
        /// <param name="pParamName">字段名:如 @ProName</param>
        /// <param name="pParamText">内容:如 电视机</param>
        /// <returns></returns>
        IDataParameter AddParam(string pParamName, object pParamText);

        /// <summary>
        /// 添加参数 Parameter
        /// </summary>
        /// <param name="pParamName">字段名:如 @ProName</param>
        /// <param name="pDbType">类型:如 DbType.Int32</param>
        /// <param name="pParamText">内容:如 电视机</param>
        /// <returns></returns>
        IDataParameter AddParam(string pParamName, DbType pDbType, object pParamText);

        /// <summary>
        /// 添加参数 Parameter
        /// </summary>
        /// <param name="pParamName">字段名:如 @ProName</param>
        /// <param name="pDbType">类型:如 DbType.Int32</param>
        /// <param name="pParamText">内容:如 电视机</param>
        /// <param name="pParamSize">字段大小</param>
        /// <returns></returns>
        IDataParameter AddParam(string pParamName, DbType pDbType, object pParamText, int pParamSize);

        /// <summary>
        /// 获取一个 Parameter 数组
        /// </summary>
        IDataParameter[] GetArrParam(int pN);

        /// <summary>
        /// new SqlConnection
        /// </summary>
        /// <param name="pStrConn"></param>
        /// <returns></returns>
        IDbConnection NewConnection();

        /// <summary>
        /// new DbDataAdapter
        /// </summary>
        /// <returns></returns>
        DbDataAdapter NewDataAdapter();

        void Dispose(IDbConnection pConn);

        //SqlTransaction;
        //OleDbTransaction;
    }
}
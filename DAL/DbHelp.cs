using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Web;
using System.Text;
using System.Configuration;

namespace WZ.Common
{
    /// <summary>
    /// 数据库操作
    /// </summary>
    public static class DbHelp
    {
        #region 插入,更新或删除
        /// <summary>
        /// 插入,更新或删除
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <returns></returns>
        public static int Update(string pSQL)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL);
            return Update(dhp);
        }

        /// <summary>
        /// 插入,更新或删除
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static int Update(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pArrParam);
            return Update(dhp);
        }

        /// <summary>
        /// 插入,更新或删除
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pCmdType">设置CommandType</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static int Update(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pCmdType, pArrParam);
            return Update(dhp);
        }

        /// <summary>
        /// 插入,更新或删除
        /// </summary>
        /// <param name="pDbHelpParam">DbHelp 接收参数专用类</param>
        /// <returns></returns>
        public static int Update(IDbHelpParam pDbHelpParam)
        {
            IDbConnection conn = pDbHelpParam.DbProvider.NewConnection();
            try
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    SetCmd(pDbHelpParam, cmd, conn);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
            catch (Exception ex)
            {
                pDbHelpParam.DbProvider.Dispose(conn);
                throw new Exception(ex.Message + "Update sql:" + pDbHelpParam.SQL);
            }
            finally
            {
                pDbHelpParam.DbProvider.Dispose(conn);
            }
        }
        #endregion

        #region DataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string pSQL)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL);
            return GetDataTable(dhp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pCmdType">设置CommandType</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string pSQL, CommandType pCmdType)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pCmdType);
            return GetDataTable(dhp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pArrParam);
            return GetDataTable(dhp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pCmdType">设置CommandType</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pCmdType, pArrParam);
            return GetDataTable(dhp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDbHelpParam">DbHelp 接收参数专用类</param>
        /// <returns></returns>
        public static DataTable GetDataTable(IDbHelpParam pDbHelpParam)
        {
            IDbConnection conn = pDbHelpParam.DbProvider.NewConnection();
            try
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    DataTable dt = new DataTable();
                    DbDataAdapter sda;
                    SetCmd(pDbHelpParam, cmd, conn);
                    sda = pDbHelpParam.DbProvider.NewDataAdapter();
                    sda.SelectCommand = (DbCommand)cmd;
                    sda.Fill(dt);
                    //HttpContext.Current.Response.Write(((System.Data.SqlClient.SqlCommand)cmd).Parameters["@PageCount"].Value.ToString());
                    cmd.Parameters.Clear();

                    return dt;
                }
            }
            catch (Exception ex)
            {
                pDbHelpParam.DbProvider.Dispose(conn);
                throw new Exception(ex.Message + "GetDataTable sql:" + pDbHelpParam.SQL);
            }
            finally
            {
                pDbHelpParam.DbProvider.Dispose(conn);
            }
        }
        #endregion

        #region DataSet
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string pSQL)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL);
            return GetDataSet(dhp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pArrParam);
            return GetDataSet(dhp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pCmdType">设置CommandType</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pCmdType, pArrParam);
            return GetDataSet(dhp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDbHelpParam">DbHelp 接收参数专用类</param>
        /// <returns></returns>
        public static DataSet GetDataSet(IDbHelpParam pDbHelpParam)
        {
            IDbConnection conn = pDbHelpParam.DbProvider.NewConnection();
            try
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    DataSet ds = new DataSet();
                    DbDataAdapter sda;
                    SetCmd(pDbHelpParam, cmd, conn);
                    sda = pDbHelpParam.DbProvider.NewDataAdapter();
                    sda.SelectCommand = (DbCommand)cmd;
                    sda.Fill(ds);

                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    return ds;
                }

            }
            catch (Exception ex)
            {
                pDbHelpParam.DbProvider.Dispose(conn);
                throw new Exception(ex.Message + "GetDataSet sql:" + pDbHelpParam.SQL);
            }
            finally
            {
                pDbHelpParam.DbProvider.Dispose(conn);
            }
        }
        #endregion

        #region DataTable分页
        /// <summary>
        /// 用于分页 返回当前页的DataTable
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pPageIndex">当前页码</param>
        /// <param name="pPageSize">每页记录数</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Paging(string pSQL, int pPageIndex, int pPageSize)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL);
            return GetDataTable_Paging(dhp, pPageIndex, pPageSize);
        }

        /// <summary>
        /// 用于分页 返回当前页的DataTable
        /// </summary>
        /// <param name="pDbHelpParam">DbHelp 接收参数专用类</param>
        /// <param name="pPageIndex">当前页码</param>
        /// <param name="pPageSize">每页记录数</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Paging(IDbHelpParam pDbHelpParam, int pPageIndex, int pPageSize)
        {
            IDbConnection conn = pDbHelpParam.DbProvider.NewConnection();
            try
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    DbDataAdapter sda;

                    SetCmd(pDbHelpParam, cmd, conn);

                    sda = pDbHelpParam.DbProvider.NewDataAdapter();
                    sda.SelectCommand = (DbCommand)cmd;
                    if (pPageIndex < 1) pPageIndex = 1;
                    int startRecord = (pPageIndex - 1) * pPageSize;
                    sda.Fill(ds, startRecord, pPageSize, "0");
                    dt = ds.Tables[0];
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                pDbHelpParam.DbProvider.Dispose(conn);
                throw new Exception(ex.Message + "GetDataTable_Paging sql:" + pDbHelpParam.SQL);
            }
            finally
            {
                pDbHelpParam.DbProvider.Dispose(conn);
            }
        }
        #endregion

        #region DataReader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <returns></returns>
        public static IDataReader Read(string pSQL)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL);
            return Read(dhp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static IDataReader Read(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pArrParam);
            return Read(dhp);
        }

        public static IDataReader Read(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pCmdType, pArrParam);
            return Read(dhp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDbHelpParam">DbHelp 接收参数专用类</param>
        /// <returns></returns>
        public static IDataReader Read(IDbHelpParam pDbHelpParam)
        {
            IDbConnection conn = pDbHelpParam.DbProvider.NewConnection();
            try
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    SetCmd(pDbHelpParam, cmd, conn);

                    IDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    return rdr;
                }
            }
            catch (Exception ex)
            {
                pDbHelpParam.DbProvider.Dispose(conn);
                throw new Exception(ex.Message + "Read sql:" + pDbHelpParam.SQL);
            }
            finally
            {

            }
        }
        #endregion

        #region 返回第一行第一列 可能会null
        /// <summary>
        /// 第一行第一列 可能为null
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <returns></returns>
        public static object Scalar(string pSQL)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL);
            return Scalar(dhp);
        }

        /// <summary>
        /// 第一行第一列 可能为null
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static object Scalar(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pArrParam);
            return Scalar(dhp);
        }

        /// <summary>
        /// 第一行第一列 可能为null
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pCmdType">设置CommandType</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static object Scalar(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pCmdType, pArrParam);
            return Scalar(dhp);
        }

        /// <summary>
        /// 第一行第一列 可能为null
        /// </summary>
        /// <param name="pDbHelpParam">DbHelp 接收参数专用类</param>
        /// <returns></returns>
        public static object Scalar(IDbHelpParam pDbHelpParam)
        {
            IDbConnection conn = pDbHelpParam.DbProvider.NewConnection();
            try
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    SetCmd(pDbHelpParam, cmd, conn);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    return val;
                }
            }
            catch (Exception ex)
            {
                pDbHelpParam.DbProvider.Dispose(conn);
                throw new Exception(ex.Message + "Scalar sql:" + pDbHelpParam.SQL);
            }
            finally
            {
                pDbHelpParam.DbProvider.Dispose(conn);
            }
        }
        #endregion

        #region 返回第一行第一列
        /// <summary>
        /// 第一行第一列 找不到时默认返回 string.Empty
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <returns></returns>
        public static string First(string pSQL)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL);
            return First(dhp, string.Empty);
        }

        /// <summary>
        /// 第一行第一列 找不到时默认返回 str_return
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="str_return"></param>
        /// <returns></returns>
        public static string First(string pSQL, string pReturn)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL);
            return First(dhp, pReturn);
        }

        /// <summary>
        /// 第一行第一列 找不到时默认返回 string.Empty
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <returns></returns>
        public static string First(string pSQL, IDataParameter[] pArrParam)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pArrParam);
            return First(dhp, string.Empty);
        }

        /// <summary>
        /// 第一行第一列 找不到时默认返回 pReturn
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <param name="pReturn"></param>
        /// <returns></returns>
        public static string First(string pSQL, IDataParameter[] pArrParam, string pReturn)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pArrParam);
            return First(dhp, pReturn);
        }

        /// <summary>
        /// 第一行第一列 找不到时默认返回 pReturn
        /// </summary>
        /// <param name="pSQL">sql 语句</param>
        /// <param name="pCmdType">设置CommandType</param>
        /// <param name="pArrParam">IDataParameter 参数数组</param>
        /// <param name="pReturn"></param>
        /// <returns></returns>
        public static string First(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam, string pReturn)
        {
            IDbHelpParam dhp = new DbHelpParam(pSQL, pCmdType, pArrParam);
            return First(dhp, pReturn);
        }

        /// <summary>
        /// 第一行第一列 找不到时默认返回 pReturn
        /// </summary>
        /// <param name="pDbHelpParam">DbHelp 接收参数专用类</param>
        /// <param name="pReturn"></param>
        /// <returns></returns>
        public static string First(IDbHelpParam pDbHelpParam, string pReturn)
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

        #region 事务处理
        /// <summary>
        /// 事务处理
        /// </summary>
        /// <param name="pDbHelpParam">DbHelp 接收参数专用类</param>
        /// <param name="pTrands">要处理事务的方法</param>
        /// <param name="pObj">传参数</param>
        public static void ExecuteTrans(IDbHelpParam pDbHelpParam, ExecuteTransHandler pTrands, ITransM pObj)
        {
            IDbConnection conn = pDbHelpParam.DbProvider.NewConnection();
            try
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    IDbTransaction trans;
                    SetCmd(pDbHelpParam, cmd, conn);
                    trans = conn.BeginTransaction();
                    cmd.Transaction = trans;

                    try
                    {
                        int returnTrands = pTrands(new TransHelp(cmd), pObj);//执行业务逻辑

                        if (returnTrands == 1)
                        {
                            trans.Commit();//提交事务
                        }
                        else
                        {
                            trans.Rollback();//回滚事务
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            trans.Rollback();//回滚事务
                            pObj.returnValue = "1:"+ex.Message;
                        }
                        catch (Exception exTrans)
                        {
                            pObj.returnValue = "2"+ex.Message + " " + exTrans.Message;
                            throw new Exception(ex.Message + " " + exTrans.Message + ":回滚事务出错");
                        }
                    }

                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                pDbHelpParam.DbProvider.Dispose(conn);
                throw new Exception(ex.Message + "Update sql:" + pDbHelpParam.SQL);
            }
            finally
            {
                pDbHelpParam.DbProvider.Dispose(conn);
            }
        }
        #endregion

        #region 设置参数
        /// <summary>
        /// 设置 DbCommand
        /// </summary>
        /// <param name="pDbHelpParam">DbHelp 接收参数专用类</param>
        /// <param name="pCommand">IDbCommand</param>
        /// <param name="pConn">IDbConnection</param>
        private static void SetCmd(IDbHelpParam pDbHelpParam, IDbCommand pCommand, IDbConnection pConn)
        {
            if (pConn.State != ConnectionState.Open)
                pConn.Open();

            pCommand.Connection = pConn;
            pCommand.CommandText = pDbHelpParam.SQL;
            pCommand.CommandType = pDbHelpParam.CmdType;

            if (pDbHelpParam.ArrParm != null)
            {
                foreach (IDataParameter dp in pDbHelpParam.ArrParm)
                    pCommand.Parameters.Add(dp);
            }
        }
        #endregion

        #region 数据库类型
        private class ProviderLS
        {
            internal static readonly IDbProvider CurProvider = new SqlServerProvider(ConnString.SqlServer);
            //internal static readonly IDbProvider CurProvider = new OleDbProvider(ConnString.DefaultStr);
            //internal static readonly IDbProvider CurProvider = new AccessProvider(ConnString.Access);
        }
        #endregion

        #region 其它实例help需要使用
        /// <summary>
        /// 返回默认数据库
        /// </summary>
        public static IDbProvider Def
        {
            get { return ProviderLS.CurProvider; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transHelp">TransHelp 可以在事务中具有增,删,改查功能</param>
        /// <param name="obj">object参数</param>
        /// <returns>0:回滚事务 1:提交事务</returns>
        public delegate int ExecuteTransHandler(IDbHelp transHelp, ITransM obj);

        public abstract class ITransM
        {
            public string returnValue = "0";
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Threading;
using System.Data.Common;
using System.Web;

namespace WZ.Common
{
    /// <summary>
    /// Address OleDbConnection
    /// </summary>
    public class AccessProvider : IDbProvider
    {
        private static readonly List<IDbConnection> UseList = new List<IDbConnection>();
        private static readonly List<IDbConnection> FreeList = new List<IDbConnection>();
        private static readonly Dictionary<string, AccessProvider> PoolsList = new Dictionary<string, AccessProvider>();
        private static readonly object lockObj = new object();

        public static int TimerN = 0;

        private static Timer timer;

        private static readonly int MaxPoosN = 1000;

        private string _StrConn;

        public AccessProvider(string pStrConn)
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
            return AccessProvider.GetConn(this._StrConn);
        }

        public DbDataAdapter NewDataAdapter()
        {
            return new OleDbDataAdapter();
        }

        #region IDisposable 成员
        public void Dispose(IDbConnection pConn)
        {
            AccessProvider.ReturnConn(this._StrConn, pConn);
        }
        #endregion

        #region Pools
        public IDbConnection GetConnection()
        {
            lock (lockObj)
            {
                IDbConnection conn;

                //若有空闲池 FreeList > UseList
                if (FreeList.Count > 0)
                {
                    conn = FreeList[0];

                    //将空闲池加入到使用池
                    UseList.Add(conn);

                    //去除当前使用池
                    FreeList.RemoveAt(0);

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                }
                else
                {
                    for (int i = 0; i < UseList.Count; i++)
                    {
                        IDbConnection conn_ls = UseList[i];

                        if (conn_ls.State == ConnectionState.Closed)
                            UseList.RemoveAt(i);
                    }

                    if (UseList.Count >= MaxPoosN)
                    {
                        throw new Exception("连接池的连接数超过最大限制 " + MaxPoosN + "个,使用中:" + UseList.Count + "个,空闲:" + FreeList.Count + "个,请等几秒后再刷新.");
                    }

                    conn = new OleDbConnection(this.StrConn);
                    UseList.Add(conn);
                }

                return conn;
            }
        }

        public void TimerPools()
        {
            if (FreeList.Count > 0)
            {
                lock (lockObj)
                {
                    if (FreeList.Count > 0)
                    {
                        IDbConnection conn = FreeList[0];//测试析构函数是否可以清处
                        FreeList.RemoveAt(0);
                        try
                        {
                            conn.Close();
                            conn.Dispose();
                        }
                        catch { }
                    }
                }
            }
        }

        /// <summary>
        /// UseList > FreeList
        /// </summary>
        /// <param name="pConn"></param>
        public void ReturnConnection(IDbConnection pConn)
        {
            lock (lockObj)
            {
                if (!UseList.Contains(pConn))
                    return;

                UseList.Remove(pConn);
                FreeList.Add(pConn);
            }
        }

        public static IDbConnection GetConn(string pConnStr)
        {
            //是否在链接池中
            if (!PoolsList.ContainsKey(pConnStr))
            {
                lock (PoolsList)
                {
                    if (!PoolsList.ContainsKey(pConnStr))
                        PoolsList.Add(pConnStr, new AccessProvider(pConnStr));
                }
            }

            if (timer == null)
                timer = new Timer(new TimerCallback(Callback), null, 5000, 5000);

            return PoolsList[pConnStr].GetConnection();
        }

        private static void Callback(object pO)
        {
            TimerN++;
            foreach (AccessProvider cp in PoolsList.Values)
            {
                cp.TimerPools();
            }
        }

        public static void ReturnConn(string pConnStr, IDbConnection pConn)
        {
            if (!PoolsList.ContainsKey(pConnStr))
                return;

            PoolsList[pConnStr].ReturnConnection(pConn);
        }
        #endregion
    }
}

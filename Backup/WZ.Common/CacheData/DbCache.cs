using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WZ.Common.CacheData
{
    /// <summary>
    /// 数据缓存
    /// </summary>
    public class DbCache
    {
        private readonly static DefaultCacheStrategy instance = new DefaultCacheStrategy();
        private static IList<string> list = new List<string>();
        private string prefix;
        private int _timeOut;

        /// <summary>
        /// 单位秒 默认600
        /// </summary>
        public int TimeOut
        {
            get
            {
                if (this._timeOut <= 0)
                {
                    return 600;
                }
                return this._timeOut;
            }
            set
            {
                this._timeOut = (value > 0) ? value : 600;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPrefix">缓存前缀</param>
        public DbCache(string pPrefix)
        {
            this.prefix = pPrefix;
            this.TimeOut = 3600;

            if (list.Contains(pPrefix))
            {
                throw new Exception("已包含缓存前缀名为" + pPrefix + ",请重新指定缓存前缀");
            }
            else
            {
                list.Add(pPrefix);
            }
        }

        public DbCache(string pPrefix, int second)
        {
            this.prefix = pPrefix;
            this.TimeOut = second;

            if (list.Contains(pPrefix))
            {
                throw new Exception("已包含缓存前缀名为" + pPrefix + ",请重新指定缓存前缀");
            }
            else
            {
                list.Add(pPrefix);
            }
        }

        public DataTable GetDataTable(string pName, string pSql)
        {
            string sKey = this.prefix + pName;
            object o = instance.GetCacheData(sKey);

            if (o == null)
            {
                DataTable dt = DbHelp.GetDataTable(pSql);
                Fn.SetDataTablePrimary(dt);
                instance.Add(sKey, dt, TimeOut);
                return dt;
            }
            else
            {
                return (DataTable)o;
            }
        }

        public DataTable GetDataTable(string pName, DbHelpParam pParam)
        {
            string sKey = this.prefix + pName;
            object o = instance.GetCacheData(sKey);

            if (o == null)
            {
                DataTable dt = DbHelp.GetDataTable(pParam);
                Fn.SetDataTablePrimary(dt);
                instance.Add(sKey, dt, TimeOut);
                return dt;
            }
            else
            {
                return (DataTable)o;
            }
        }

        public DataTable GetDataTable_CacheDepend(string pName, string pSql, string[] pDependKey)
        {
            string sKey = this.prefix + pName;
            object o = instance.GetCacheData(sKey);

            if (o == null)
            {
                DataTable dt = DbHelp.GetDataTable(pSql);
                Fn.SetDataTablePrimary(dt);
                instance.AddCacheDepend(sKey, dt, TimeOut, pDependKey);
                return dt;
            }
            else
            {
                return (DataTable)o;
            }
        }

        public string First(string pName, string pSql)
        {
            string sKey = this.prefix + pName;
            object o = instance.GetCacheData(sKey);

            if (o == null)
            {
                string s = DbHelp.First(pSql,string.Empty);
                instance.Add(sKey, s, TimeOut);
                return s;
            }
            else
            {
                return o.ToString();
            }
        }

        public void Delete(string pKeyName)
        {
            instance.RemoveCache(this.prefix + pKeyName);
        }

        /// <summary>
        /// 获取缓存策略
        /// </summary>
        public static DefaultCacheStrategy GetInstance
        {
            get { return instance; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.Caching;
using System.Collections;
using System.Text.RegularExpressions;

namespace WZ.Common.CacheData
{
    public class DefaultCacheStrategy// : ICacheStrategy
    {
        protected static volatile Cache webCache = HttpRuntime.Cache;
        //private static CacheItemRemovedCallback onRemoveCallback = new CacheItemRemovedCallback(this.onRemove);

        ///// <summary>
        ///// 添加Cache 
        ///// 最后一次访问所插入对象时与该对象过期时之间的时间间隔。如果该值等效于 20 分钟，则对象在最后一次被访问 20 分钟之后将过期并被从缓存中移除。如果使用可调过期，则 absoluteExpiration 参数必须为 System.Web.Caching.Cache.NoAbsoluteExpiration。
        ///// </summary>
        ///// <param name="objId"></param>
        ///// <param name="o"></param>
        //public virtual void AddDefault(string objId, object o)
        //{
        //    if (((objId != null) && (objId.Length != 0)) && (o != null))
        //    {
        //        CacheItemRemovedCallback onRemoveCallback = new CacheItemRemovedCallback(this.onRemove);
        //        if (this.TimeOut == 0x1c20)//7200
        //        {
        //            webCache.Insert(objId, o, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High, onRemoveCallback);
        //        }
        //        else
        //        {
        //            webCache.Insert(objId, o, null, DateTime.Now.AddSeconds((double)this.TimeOut), Cache.NoSlidingExpiration, CacheItemPriority.Default, onRemoveCallback);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 添加Cache
        ///// </summary>
        ///// <param name="objId"></param>
        ///// <param name="o"></param>
        //public static void Add(string objId, object o)
        //{
        //    if (((objId != null) && (objId.Length != 0)) && (o != null))
        //    {
        //        //CacheItemRemovedCallback onRemoveCallback = new CacheItemRemovedCallback(this.onRemove);
        //        //webCache.Insert(objId, o, null, DateTime.Now.AddSeconds((double)this.TimeOut), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemoveCallback);
        //        webCache.Insert(objId, o, null, DateTime.Now.AddSeconds((double)this.TimeOut), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        //    }
        //}

        public void Add(string objId, object o, int second)
        {
            webCache.Insert(objId, o, null, DateTime.Now.AddSeconds((double)second), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public void AddCacheDepend(string objId, object o, int second, string[] dependKey)
        {
            CacheDependency dependencies = new CacheDependency(null, dependKey, DateTime.Now);
            webCache.Insert(objId, o, dependencies, DateTime.Now.AddSeconds((double)second), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public void AddFileDepend(string objId, object o, int second, string[] files)
        {
            CacheDependency dependencies = new CacheDependency(files, DateTime.Now);
            webCache.Insert(objId, o, dependencies, DateTime.Now.AddSeconds((double)second), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        /// <summary>
        /// 移除缓存时 回调的方法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="reason"></param>
        public void onRemove(string key, object val, CacheItemRemovedReason reason)
        { }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="objId"></param>
        public void RemoveCache(string objId)
        {
            webCache.Remove(objId);
        }

        /// <summary>
        /// 删除所有缓存
        /// </summary>
        public void RemoveCacheAll()
        {
            IList<string> l = GetCacheKeys();
            foreach (string s in l)
            {
                webCache.Remove(s);
            }
        }

        /// <summary>
        /// 删除 匹配到的缓存
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public void RemoveCacheRegex(string pattern)
        {
            IList<string> l = SearchCacheRegex(pattern);
            foreach (string s in l)
            {
                webCache.Remove(s);
            }
        }

        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        public IList<string> GetCacheKeys()
        {
            List<string> l = new List<string>();
            IDictionaryEnumerator cacheKeys = webCache.GetEnumerator();
            while (cacheKeys.MoveNext())
            {
                l.Add(cacheKeys.Key.ToString());
            }
            return l.AsReadOnly();
        }

        /// <summary>
        /// 搜索 匹配到的缓存
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public IList<string> SearchCacheRegex(string pattern)
        {
            List<string> l = new List<string>();
            IDictionaryEnumerator cacheKeys = webCache.GetEnumerator();

            string s;
            while (cacheKeys.MoveNext())
            {
                s = cacheKeys.Key.ToString();
                if (Regex.IsMatch(s, pattern))
                {
                    l.Add(s);
                }
            }
            return l.AsReadOnly();
        }

        /// <summary>
        /// 获得缓存数据
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public object GetCacheData(string objId)
        {
            if ((objId != null) && (objId.Length != 0))
            {
                return webCache.Get(objId);
            }
            return null;
        }

        // 获取Cache
        public static Cache GetHttpCache
        {
            get { return webCache; }
        }

        ///// <summary>
        ///// 设置 缓存超时时间 默认3600秒
        ///// </summary>
        //public virtual int TimeOut
        //{
        //    get
        //    {
        //        if (this._timeOut <= 0)
        //        {
        //            return 0xe10;//3600
        //        }
        //        return this._timeOut;
        //    }
        //    set
        //    {
        //        this._timeOut = (value > 0) ? value : 0xe10;//3600
        //    }
        //}
    }
}
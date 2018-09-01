using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Common.CacheData
{
    /// <summary>
    /// 缓存策略接口
    /// </summary>
    public interface ICacheStrategy
    {
        /// <summary>
        /// 添加Cache
        /// 最后一次访问所插入对象时与该对象过期时之间的时间间隔。如果该值等效于 20 分钟，则对象在最后一次被访问 20 分钟之后将过期并被从缓存中移除。如果使用可调过期，则 absoluteExpiration 参数必须为 System.Web.Caching.Cache.NoAbsoluteExpiration。
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        void AddDefault(string objId, object o);

        /// <summary>
        /// 添加Cache
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        void Add(string objId, object o);

        /// <summary>
        /// 添加Cache 有缓存依赖
        /// 若有dependKey缓存有任何一项更改时,会自动清除此项
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        /// <param name="dependKey"></param>
        void AddCacheDepend(string objId, object o, string[] dependKey);

        /// <summary>
        /// 添加Cache 有缓存依赖
        /// 若有files 文件有任何一项更改时,会自动清除此项
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        /// <param name="files"></param>
        void AddFileDepend(string objId, object o, string[] files);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="objId"></param>
        void RemoveCache(string objId);

        /// <summary>
        /// 删除所有缓存
        /// </summary>
        void RemoveCacheAll();

        /// <summary>
        /// 删除 匹配到的缓存
        /// </summary>
        /// <param name="pattern"></param>
        void RemoveCacheRegex(string pattern);

        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        IList<string> GetCacheKeys();

        /// <summary>
        /// 搜索 匹配到的缓存
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        IList<string> SearchCacheRegex(string pattern);

        /// <summary>
        /// 获得缓存数据
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        object GetCacheData(string objId);

        /// <summary>
        /// 设置 缓存超时时间
        /// </summary>
        int TimeOut { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common.CacheData;
using WZ.Common;
using System.Web;
using WZ.Data.IData;

namespace WZ.Data
{
    /// <summary>
    /// 递归循环方法
    /// </summary>
    /// <param name="pDrw"></param>
    public class ClassPath : WZ.Data.IData.AbsClassRecursive
    {
        private IClassPath iclassPath;
        
        //public ClassPath(SCWCache.CacheKey pKey, WZ.Data.IData.IClassPath pCP)
        //    : base("ClassSN", "ClassName", pKey)
        //{
        //    this.iclassPath = pCP;
        //}

        public ClassPath(DataTable pDt, WZ.Data.IData.IClassPath pCP)
            : base("ClassSN", "ClassName", pDt)
        {
            this.iclassPath = pCP;
        }

        /// <summary>
        /// 分类ID
        /// </summary>
        /// <param name="pClassID"></param>
        public void Exe(int pClassID)
        {
            iclassPath.ClearData();
            base.Run(pClassID);
        }

        public void Exe(object pClassID)
        {
            iclassPath.ClearData();
            base.Run(Convert.ToInt32(pClassID));
        }

        /// <summary>
        /// 循环ID所在的每一个等级只一次
        /// </summary>
        /// <param name="pDrw"></param>
        protected override void HandlerRecursive(DataRow pDrw)
        {
            iclassPath.ClassEach(pDrw);
        }
    }
}
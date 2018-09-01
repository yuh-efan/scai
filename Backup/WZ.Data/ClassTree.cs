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
    public class ClassTree : WZ.Data.IData.AbsClassTreeRecursive
    {
        private IClassTree iclassTree;

        public ClassTree(DataTable pDt, WZ.Data.IData.IClassTree pCP)
            : base(pDt)
        {
            this.iclassTree = pCP;
        }

        public ClassTree(DataTable pDt, WZ.Data.IData.IClassTree pCP, string pOrderBy)
            : base(pDt)
        {
            this.orderBy = pOrderBy;
            this.iclassTree = pCP;
        }

        /// <summary>
        /// 分类ID
        /// </summary>
        /// <param name="pClassID"></param>
        public void Exe(int pClassID)
        {
            iclassTree.ClearData();
            base.Run(pClassID);
        }

        public void Exe(object pClassID)
        {
            iclassTree.ClearData();
            base.Run(Fn.IsInt(pClassID.ToString(), 0));
        }

        /// <summary>
        /// 循环每一行
        /// </summary>
        /// <param name="pDrw"></param>
        protected override void HandlerRecursive(DataRow pDrw)
        {
            iclassTree.ClassEach(pDrw);
        }
    }
}
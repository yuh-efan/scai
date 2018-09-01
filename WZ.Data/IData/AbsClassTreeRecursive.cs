using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common.CacheData;

namespace WZ.Data.IData
{
    /// <summary>
    /// 代表具有获取分类列表的 递归功能
    /// </summary>
    public abstract class AbsClassTreeRecursive
    {
        protected string orderBy = "Taxis desc";
        protected DataTable dtClass;
        protected List<int> errList = new List<int>();//阻止死循环

        public DataTable DtClass
        { get { return this.dtClass; } }

        public AbsClassTreeRecursive(DataTable pDt)
        {
            this.dtClass = pDt;
        }

        protected void Run(int pClassID)
        {
            RunRecursive(pClassID);
            this.errList.Clear();
        }

        private void RunRecursive(int pClassID)
        {
            if (errList.Contains(pClassID))
                return;

            errList.Add(pClassID);

            DataRow[] aDrw = dtClass.Select("PClassSN=" + pClassID, orderBy);

            foreach (DataRow drw in aDrw)
            {
                int lsLevel = Convert.ToInt32(drw["ClassLevel"]);
                int lsClassID = Convert.ToInt32(drw["ClassSN"]);
                HandlerRecursive(drw);
                RunRecursive(lsClassID);
            }
        }
        protected abstract void HandlerRecursive(DataRow pDrw);
    }
}

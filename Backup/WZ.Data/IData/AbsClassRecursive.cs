using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common.CacheData;

namespace WZ.Data.IData
{
    
    /// <summary>
    /// 代表具有递归功能
    /// </summary>
    public abstract class AbsClassRecursive
    {
        protected string fieldClassID;
        protected string fieldPClassID;
        protected string fieldClassName;
        protected DataTable dtClass;
        protected List<int> errList = new List<int>();//阻止死循环

        public DataTable DtClass
        { get { return this.dtClass; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFieldClassID"></param>
        /// <param name="pFieldClassName"></param>
        /// <param name="pKey"></param>
        //public AbsClassRecursive(string pFieldClassID, string pFieldClassName, SCWCache.CacheKey pKey)
        //{
        //    this.fieldClassID = pFieldClassID;
        //    this.fieldPClassID = "P" + pFieldClassID;
        //    this.fieldClassName = pFieldClassName;
        //    this.dtClass = SCWCache.GetDataTable(pKey);
        //}

        public AbsClassRecursive(string pFieldClassID, string pFieldClassName, DataTable pDt)
        {
            this.fieldClassID = pFieldClassID;
            this.fieldPClassID = "P" + pFieldClassID;
            this.fieldClassName = pFieldClassName;
            this.dtClass = pDt;
        }

        protected void Run(int pClassID)
        {
            RunRecursive(pClassID);
            this.errList.Clear();
        }

        /// <summary>
        /// 递归设置分类路径
        /// </summary>
        /// <param name="pPClassID">PClassID</param>
        /// <returns></returns>
        private void RunRecursive(int pClassID)
        {
            if (errList.Contains(pClassID))
                return;

            errList.Add(pClassID);
            int lsID;
            int iPClassID = 0;//上一级分类id
            foreach (DataRow drw in this.dtClass.Rows)
            {
                lsID = Convert.ToInt32(drw[fieldClassID]);
                if (lsID == pClassID)
                {
                    HandlerRecursive(drw);
                    iPClassID = Convert.ToInt32(drw[fieldPClassID]);
                    break;
                }
            }

            if (iPClassID > 0)
                RunRecursive(iPClassID);
        }

        protected abstract void HandlerRecursive(DataRow pDrw);
    }
}

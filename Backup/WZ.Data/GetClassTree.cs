using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;
using System.Data;

namespace WZ.Data
{
    /// <summary>
    /// 生成分类树
    /// </summary>
    public class GetClassTree : WZ.Data.IData.IClassTree
    {
        private IList<DataRow> dataRowList = new List<DataRow>();

        /// <summary>
        /// 获取分类id路径,从最底层开始
        /// </summary>
        public IList<DataRow> DataRowList
        {
            get { return this.dataRowList; }
        }

        #region IClassPath 成员

        public void ClearData()
        {
            this.dataRowList.Clear();
        }

        public void ClassEach(System.Data.DataRow pDrw)
        {
            dataRowList.Add(pDrw);
        }
        #endregion
    }
}

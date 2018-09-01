using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;

namespace WZ.Data
{
    /// <summary>
    /// 获取分类路径 有链接
    /// </summary>
    public class GetClassPath : WZ.Data.IData.IClassPath
    {
        private IList<int> idList = new List<int>();
        private string sPath = string.Empty;
        private string willPath = string.Empty;

        public GetClassPath(string pWillPath)
        {
            this.willPath = pWillPath;
        }

        /// <summary>
        /// 获取分类id路径,从最底层开始
        /// </summary>
        public IList<int> PathListID
        {
            get { return this.idList; }
        }

        /// <summary>
        /// 获取分类路径
        /// </summary>
        public string GetPath
        {
            get { return this.sPath; }
        }

        #region IClassPath 成员

        public void ClearData()
        {
            this.idList.Clear();
            this.sPath = string.Empty;
        }

        public void ClassEach(System.Data.DataRow pDrw)
        {
            this.sPath = " &gt; <a href=\"" + string.Format(willPath, pDrw["ClassSN"]) + "\">" + pDrw["ClassName"].ToString() + "</a>" + this.sPath;
            this.idList.Add(Convert.ToInt32(pDrw["ClassSN"]));
        }
        #endregion
    }
}

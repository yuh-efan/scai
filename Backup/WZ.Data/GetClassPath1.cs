using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;

namespace WZ.Data
{
    /// <summary>
    /// 获取分类路径 无链接
    /// </summary>
    public class GetClassPath1 : WZ.Data.IData.IClassPath
    {
        private string sPath = string.Empty;
        private byte level = 0;//当前id是第几层

        public byte GetLevel
        {
            get { return this.level; }
        }

        /// <summary>
        /// 获取分类路径
        /// </summary>
        public string GetPath
        {
            get
            {
                if (this.sPath.Length > 0)
                    this.sPath = this.sPath.Trim().TrimEnd('>');

                return this.sPath;
            }
        }

        #region IClassPath 成员

        public void ClearData()
        {
            this.sPath = string.Empty;
        }

        public void ClassEach(System.Data.DataRow pDrw)
        {
            this.sPath = pDrw["ClassName"].ToString() + " > " + this.sPath;
            level++;
        }
        #endregion
    }
}

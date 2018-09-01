using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace WZ.Client.Data.General
{
    public class BaseListUserControl : UserControl
    {
        protected bool isDispose = false;
        protected int width = 10;
        protected int height = 10;

        #region 属性
        /// <summary>
        /// 图片宽度
        /// </summary>
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// 图片高度
        /// </summary>
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        #endregion

        protected string SetCss(string pName)
        {
            if (pName != null && pName.Length > 0)
            {
                return " class=\"" + pName + "\"";
            }

            return string.Empty;
        }
    }
}

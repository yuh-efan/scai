using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Common
{
    /// <summary>
    /// 最近浏览过
    /// </summary>
    public class HistoryData
    {
        private string cookieName;
        private int max;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCookieName">cookie名</param>
        /// <param name="pMax">最多存储量</param>
        public HistoryData(string pCookieName, int pMax)
        {
            this.cookieName = pCookieName;
            this.max = pMax - 1;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public string Add(int pID)
        {
            string sID = pID.ToString();

            if (pID <= 0)
                max++;

            string showpro = Req.GetCookies(cookieName);
            showpro = Fn.IsIntArr(showpro);

            if (showpro.Length == 0)
                showpro = sID;
            else
            {
                string[] aStr = showpro.Split(',');
                int aStrN = aStr.Length;
                string lsStr;
                showpro = string.Empty;
                int lsJ = 0;
                for (int i = 0; i < aStrN; i++)
                {
                    lsStr = aStr[i];

                    if (lsStr != sID)
                    {
                        showpro = (lsStr + "," + showpro);
                        lsJ++;
                    }
                    if (lsJ >= max)
                        break;
                }

                if (pID > 0)
                    showpro = sID + "," + showpro;

                showpro = showpro.TrimEnd(',');
            }

            Fn.SetCookie(cookieName, showpro, DateTime.Now.AddDays(10));

            return showpro;
        }
    }
}

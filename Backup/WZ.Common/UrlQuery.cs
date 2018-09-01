using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Common
{
    public class UrlQuery
    {
        private string sQuery;
        private string[] arrQuery;
        private char fg = '-';

        public Dictionary<int, string> d = new Dictionary<int, string>();

        public UrlQuery()
        {
            QueryStringToURLPara();
        }

        public string GetQueryString(int pIndex)
        {
            if (d.ContainsKey(pIndex))
                return d[pIndex];

            return string.Empty;
        }

        public void QueryStringToURLPara()
        {
            sQuery = HttpContext.Current.Request.QueryString["s"];
            if (sQuery == null)
                arrQuery = new string[] { "" };
            else
            {
                arrQuery = sQuery.Split(fg);
                for (int i = 0; i < arrQuery.Length; i++)
                {
                    d.Add(i, arrQuery[i]);
                }
            }
        }

        public override string ToString()
        {
            return GetURL();
        }

        public string ToString(int pIndex, string pValue)
        {
            int max = 0;
            foreach (int i in d.Keys)
            {
                if (i > max)
                    max = i;
            }

            if (pIndex > max)
                max = pIndex;

            for (int i = 0; i <= max; i++)
            {
                if (d.ContainsKey(i))
                {
                    if (i == pIndex)
                        d[i] = pValue;
                    else
                        d[i] = d[i];
                }
                else
                {
                    if (i == pIndex)
                        d.Add(i, pValue);
                    else
                        d.Add(i, string.Empty);
                }
            }
            
            return GetURL();
        }

        //public string ToString(Dictionary<int, string> pD)
        //{
        //    foreach (int s in pD.Keys)
        //    {
        //        if (d.ContainsKey(s))
        //            d[s] = pD[s];
        //        else
        //            d.Add(s, pD[s]);
        //    }
        //    return GetURL();
        //}

        private string GetURL()
        {
            StringBuilder sb = new StringBuilder();
            string s;
            foreach (int n in d.Keys)
            {
                s = d[n];
                //if (s != "0" && (s.Length > 0))
                //{
                    sb.Append(s);
                    sb.Append(fg);
                //}
            }

            return sb.ToString().TrimEnd(fg);
        }
    }
}

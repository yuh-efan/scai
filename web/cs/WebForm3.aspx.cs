using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using WZ.Common;

/*
 * 
 * IEnumerable 与 IEnumerator
 * 
 * 
 * */
namespace WZ.Web.cs
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string aa = "select";
            //Response.Write(aa.CompareTo(Req.GetQueryString("s")));

            string r = "select abc,def from vgPro_Info";

            if (string.Compare(r.Substring(0, 6), "select", true) == 0)
            {
                r = "select top 1" + r.Substring(6);
            }

            Response.Write(r);



            //    Dictionary<int,int>

            //    cs1[] peopleArray = new cs1[3]
            //{
            //    new cs1("John", "Smith"),
            //    new cs1("Jim", "Johnson"),
            //    new cs1("Sue", "Rabon"),
            //};

            //    cs2 peopleList = new cs2(peopleArray);

            //    cs3 a = (cs3)peopleList.GetEnumerator();
            //    a.MoveNext();
            //    Response.Write(((cs1)a.Current).name1 + " " + ((cs1)a.Current).name2 + "<br>");
            //    a.MoveNext();
            //    Response.Write(((cs1)a.Current).name1 + " " + ((cs1)a.Current).name2 + "<br>");
            //    a.MoveNext();
            //    Response.Write(((cs1)a.Current).name1 + " " + ((cs1)a.Current).name2 + "<br>");
            //    if (a.MoveNext())
            //        Response.Write(((cs1)a.Current).name1 + " " + ((cs1)a.Current).name2 + "<br>");

            //foreach (cs1 p in peopleList)
            //{


            //    Response.Write(p.name1 + " " + p.name2 + "<br>");
            //}


        }
    }

    public class cs1
    {
        public string name1;
        public string name2;

        public cs1(string pA, string pB)
        {
            this.name1 = pA;
            this.name2 = pB;
        }
    }

    public class cs2 : IEnumerable
    {
        private cs1[] _cs1;

        public cs2(cs1[] pArr)
        {
            _cs1 = new cs1[pArr.Length];
            for (int i = 0; i < pArr.Length; i++)
            {
                _cs1[i] = pArr[i];
            }
        }

        #region IEnumerable 成员

        public IEnumerator GetEnumerator()
        {
            HttpContext.Current.Response.Write("1<br>");
            return new cs3(_cs1);
        }

        #endregion
    }

    public class cs3 : IEnumerator
    {
        public cs1[] _cs1;
        private int ii = -1;

        public cs3(cs1[] pList)
        {
            _cs1 = pList;
        }

        #region IEnumerator 成员

        public object Current
        {
            get
            {
                try
                {
                    return _cs1[ii];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            ii++;
            HttpContext.Current.Response.Write("a " + ii + "<br>");
            return (ii < _cs1.Length);//结束条件
        }

        public void Reset()
        {
            ii = -1;
        }

        #endregion
    }


}

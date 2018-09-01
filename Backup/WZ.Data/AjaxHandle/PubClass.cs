using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using WZ.Common.CacheData;
using WZ.Common;
using Newtonsoft.Json;

namespace WZ.Data.AjaxHandle
{
    /// <summary>
    /// 分类
    /// </summary>
    public class PubClass
    {
        private int _id;
        private int _sid;
        private HttpContext context;
        private DataTable dt;
        private string OrderBy = "Taxis asc";

        private JavaScriptArray aJso = new JavaScriptArray();

        public PubClass(DataTable pDt)
        {
            this.dt = pDt;
        }

        public void Run()
        {
            context = HttpContext.Current;
            //SCWCache.CacheKey ck;

            //#region
            //switch (Req.GetQueryString("t"))
            //{
            //    case "news":
            //        ck = SCWCache.CacheKey.News_Class;
            //        break;

            //    case "pro":
            //        ck = SCWCache.CacheKey.Pro_Class;
            //        break;

            //    case "help":
            //        ck = SCWCache.CacheKey.Help_Class;
            //        break;

            //    case "pack":
            //        ck = SCWCache.CacheKey.Pack_Class;
            //        break;

            //    case "area":
            //        ck = SCWCache.CacheKey.Pub_Area;
            //        break;

            //    default:
            //        ck = SCWCache.CacheKey.Pub_Area;
            //        break;
            //}
            //#endregion

            //dt = SCWCache.GetDataTable(ck);

            if (dt == null)
            {
                context.Response.Write(JavaScriptConvert.SerializeObject(aJso));
                return;
            }

            this._sid = Req.GetID("sid");
            //若有修改ID,则运行EditData
            if (this._sid > 0)
            {
                EditData1();
            }
            else
            {
                this._id = Req.GetID();
                SelectData();
            }
            context.Response.Write(JavaScriptConvert.SerializeObject(aJso));
        }

        private void EditData1()
        {
            List<int> errList = new List<int>();//防止因数据库问题而死循环; 保存classID,下面有用
            Dictionary<int, DataRow[]> listDrw = new Dictionary<int, DataRow[]>();
            int lsid = this._sid;

            while (true)
            {
                if (errList.Contains(lsid))
                    break;
                errList.Add(lsid);
                int lsid1 = lsid;
                lsid = ClassData.GetPClassID(dt, lsid);

                DataRow[] aDrw = dt.Select("PClassSN=" + lsid, OrderBy);

                listDrw.Add(lsid1, aDrw);

                if (lsid == 0)
                    break;
            }

            int[] ak = new int[listDrw.Count];
            int i = 0;
            foreach (int k in listDrw.Keys)
            {
                ak[i] = k;
                i++;
            }

            //反向插入
            int listN = listDrw.Count - 1;
            for (int j = listN; j >= 0; j--)
            {
                int k = ak[j];

                aJso.Add(AddJso(listDrw[k], k));
            }

            //选中的后一级
            DataRow[] aDrwEnd = dt.Select("PClassSN=" + this._sid, OrderBy);

            JavaScriptArray jsa = (JavaScriptArray)AddJso(aDrwEnd, -1);
            if (jsa.Count > 0)
                aJso.Add(jsa);
        }

        private void SelectData()
        {
            DataRow[] aDrw = dt.Select("PClassSN=" + this._id, OrderBy);

            foreach (DataRow drw in aDrw)
            {
                JavaScriptObject lsJso = new JavaScriptObject();

                lsJso.Add("i", drw["ClassSN"]);
                lsJso.Add("n", drw["ClassName"]);

                if (dt.Select("PClassSN=" + drw["ClassSN"], OrderBy).Length > 0)
                {
                    lsJso.Add("b", "1");
                }
                aJso.Add(lsJso);
            }
        }

        private object AddJso(DataRow[] pDrw, int pSelID)
        {
            JavaScriptArray aLsJso = new JavaScriptArray();
            foreach (DataRow drw in pDrw)
            {
                JavaScriptObject lsJso = new JavaScriptObject();

                int dAreaID = Convert.ToInt32(drw["ClassSN"]);
                lsJso.Add("i", dAreaID);
                lsJso.Add("n", drw["ClassName"]);

                if (dt.Select("PClassSN=" + dAreaID).Length > 0)
                {
                    lsJso.Add("b", "1");
                }

                if (pSelID == dAreaID)
                {
                    lsJso.Add("s", "1");
                }
                if (lsJso.Count > 0)
                    aLsJso.Add(lsJso);
            }
            return aLsJso;
        }
    }
}

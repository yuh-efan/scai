using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web;
using WZ.Common.CacheData;

namespace WZ.Common.Control.PageControl
{
    public class ProList : Repeater
    {
        private static DefaultCacheStrategy instance = new DefaultCacheStrategy();

        private DataTable dt;

        public decimal ClassID;
        public Byte Top;
        public bool IsDispose;
        public Config.PubEnum.ProItem proItem;

        private const string C_SQL = "select top {1} ProSN,ProName,PicS,Price from vgPro_Info where Item&{0}={0} order by EditDate desc,ProSN desc"; 

        public ProList()
        {
            this.IsDispose = false;
            this.ClassID = 0;
            this.EnableViewState = false;
        }

        protected override void Render(HtmlTextWriter writer)
        {

            writer.Write(proItem);
            //base.Render(writer);
        }

        protected override void OnLoad(EventArgs e)
        {
            
            
            
            //base.OnLoad(e);
        }

        //private DataTable GetDataTable()
        //{
        //    string sKey = "ProList_" + ClassID + proItem + Top;
        //    object o = instance.GetCacheData(sKey);

        //    if (o == null)
        //    {
        //        string sWhere = Config.PubEnum.ProItem;
                
        //        if (ClassID == 0)
        //        {
        //            sWhere += "";
        //        }

        //        DataTable dt = DbHelp.GetDataTable(dic[pCK]);
        //        instance.Add(sKey, dt);
        //        return dt;
        //    }
        //    else
        //    {
        //        return (DataTable)o;
        //    }
        //}
    }
}
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
using WZ.Common;
using System.Text;
using System.Collections.Generic;

/*
 * 搜索输入框自动弹出相关关键词
 * 
 * */
namespace WZ.Web.ajax
{
    public partial class searchKW : Page
    {
        private int t;
        private string kw;
        private StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";

            t = Fn.IsInt(Req.GetQueryString("t"), -1);
            kw = Req.GetQueryString("kw");

            WZ.Common.Config.cs.s = kw;

            if (kw.Length > 30)
            {
                kw = kw.Substring(0, 30);
            }

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            switch (t)
            {
                case 0:
                    GetPro();
                    break;
                case 1:
                    GetCaiPu();
                    break;

                //case 2:
                //    GetTapCan();
                //    break;

                case 2:
                    GetNews();
                    break;
            }
        }

        private void GetPro()
        {
            string sql = "select top 5 ProName from vgPro_Info where ProName like '%'+@ProName+'%' order by SellN1 desc";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@ProName",kw)
                                  };
            DataTable dt = DbHelp.GetDataTable(sql, dp);
            w(dt);
        }

        private void GetCaiPu()
        {
            string sql = "select top 5 ProName from vgCaiPu_Info where ProName like '%'+@ProName+'%' order by SellN1 desc";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@ProName",kw)
                                  };
            DataTable dt = DbHelp.GetDataTable(sql, dp);
            w(dt);
        }

        //private void GetTapCan()
        //{
        //    string sql = "select top 5 ProName from vgTaoCan_Info where ProName like '%'+@ProName+'%' order by SellN1 desc";
        //    IDataParameter[] dp = { 
        //                          DbHelp.Def.AddParam("@ProName",kw)
        //                          };
        //    DataTable dt = DbHelp.GetDataTable(sql, dp);
        //    w(dt);
        //}

        private void GetNews()
        {
            string sql = "select top 5 Title from News_Info where Title like '%'+@Title+'%' order by Hit desc";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@Title",kw)
                                  };
            DataTable dt = DbHelp.GetDataTable(sql, dp);
            w(dt);
        }

        private void w(DataTable pDt)
        {
            sb.Append("[");
            foreach (DataRow drw in pDt.Rows)
            {
                sb.Append("'"+drw[0].ToString()+"'");
                sb.Append(",");
            }
            sb.Append("]");
            
            Response.Write(sb.ToString());
        }
    }
}

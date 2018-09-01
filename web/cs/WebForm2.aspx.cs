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
using WZ.Common.CacheData;
using WZ.Data;
using WZ.Data.ClientAction;
using System.Data.SqlClient;

/*
 * 
 * 各种分页方法
 * 
 * */
namespace WZ.Web.cs
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private DataTable dt = null;
        private int p;
        private int t;

        protected void Page_Load(object sender, EventArgs e)
        {
            t = Fn.IsInt(Req.GetQueryString("t"), 1);
            if (t == 1)
            {
                L1();
            }
            else if (t == 2)
            {
                L2();
            }
            else if (t == 3)
            {
                L3();
            }
            else if (t == 4)
            {
                L4();
            }

            else if (t == 5)
            {
                L5();
            }

            if (dt == null)
                return;
            foreach (DataRow drw in dt.Rows)
            {
                Response.Write(drw["prosn"] + " : " + drw["proname"] + "<br>");
            }
        }

        private void L1()
        {
            string sqlSelect, sqlFrom, sqlWhere, sqlOrder, pkName;
            sqlSelect = "select prosn,proname ";
            sqlFrom = " from cs..pro_info";
            sqlWhere = "";
            sqlOrder = " order by prosn desc";
            pkName = "prosn";

            PagingVar pv = new PagingVar();
            //pv.PageCount = 100;
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(32));
            pg.load();
            dt = pg.GetDataTable();
        }

        private void L2()
        {
            IDataParameter Param = new SqlParameter();
            Param.ParameterName = "@PageCount";
            Param.Value = 1;
            Param.DbType = DbType.Int32;
            Param.Direction = ParameterDirection.Output;

            //sp_PageView 'pro_info','prosn',2,10,'*','prosn desc','prosn>200',8
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@tbname","cs..pro_info"),
                                  DbHelp.Def.AddParam("@FieldKey","prosn"),
                                  DbHelp.Def.AddParam("@PageCurrent",Fn.IsInt(Req.GetQueryString("p"),1)),
                                  DbHelp.Def.AddParam("@PageSize","32"),
                                  DbHelp.Def.AddParam("@FieldShow","prosn,proname"),
                                  DbHelp.Def.AddParam("@FieldOrder","prosn desc"),
                                  DbHelp.Def.AddParam("@Where",""),
                                  Param
                                  };

            dt = DbHelp.GetDataTable("sp_PageView", CommandType.StoredProcedure, dp);
        }

        private void L3()
        {
            string sql = "select prosn from cs..pro_info";
            IDataReader dr = DbHelp.Read(sql);
            int jj = 0;
            while (dr.Read())
            {
                if (jj > 100)
                    break;
                jj++;
            }
            
            dr.Close();
            Response.Write(dr.RecordsAffected);
        }

        private void L4()
        {
            string sql = "DECLARE @pagenum AS INT, @pagesize AS INT"
+ "\nSET @pagenum = " + Fn.IsInt(Req.GetQueryString("p"), 1)
+ "\nSET @pagesize = 32"
+ "\nSELECT *"
+ " FROM (SELECT ROW_NUMBER() OVER(ORDER BY prosn DESC) AS rownum,"
        + "prosn, proname"
      + " FROM cs..pro_info) AS D"
+ " WHERE rownum BETWEEN (@pagenum-1)*@pagesize+1 AND @pagenum*@pagesize"
+ " ORDER BY prosn DESC";
            dt = DbHelp.GetDataTable(sql);


        }

        private void L5()
        { 
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@TableName","cs..pro_info"),
                                  DbHelp.Def.AddParam("@PageSize","32"),
                                  DbHelp.Def.AddParam("@PageIndex",Fn.IsInt(Req.GetQueryString("p"),1)),
                                  DbHelp.Def.AddParam("@FieldKey","prosn"),
                                  DbHelp.Def.AddParam("@Fields","prosn,proname"),
                                  DbHelp.Def.AddParam("@Where","prosn>1"),
                                  DbHelp.Def.AddParam("@Order","prosn desc"),
                                  DbHelp.Def.AddParam("@PageCount","-1"),
                                  };

            dt = DbHelp.GetDataTable("sp_paging", CommandType.StoredProcedure, dp);

            //sp_paging 'pro_info',10,83866,'prosn','prosn,proname','prosn>100','prosn desc',-1
        }
    }
}
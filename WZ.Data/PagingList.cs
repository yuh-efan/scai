using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Data;
using System.Web;
using WZ.Common;

namespace WZ.Data
{
    public class PagingList
    {
        /// <summary>
        /// 用于存储表结构,识别排序字段
        /// </summary>
        private DataTable structDt;
        private string tableName;

        private PagingUrlVar puv;
        private string pKName;

        /// <summary>
        /// 是否对 sqlFrom 赋过值,用于识别排序字段
        /// 如果对sqlFrom赋过值,则一般情况是是有多张情况下才会重新赋值的
        /// </summary>
        private bool isSqlFromFu = false;

        private string sqlSelect = "select";
        private string sqlFrom = "from ";
        private string sqlWhere = "where 1=1";
        private string sqlOrder = "";

        private List<IDataParameter> paramList = new List<IDataParameter>();

        /// <summary>
        /// 单项查询 sql where 条件数组
        /// </summary>
        public string[] ArrWhereSQL;

        #region 属性
        public string TableName
        {
            get { return this.tableName; }
        }

        public string PKName
        {
            get { return this.pKName; }
        }

        public string SqlSelect
        {
            get { return this.sqlSelect; }
            set { this.sqlSelect = value; }
        }

        public string SqlFrom
        {
            get { return this.sqlFrom; }
            set
            {
                isSqlFromFu = true;
                this.sqlFrom = value;
            }
        }

        public string SqlWhere
        {
            get { return this.sqlWhere; }
            set { this.sqlWhere = value; }
        }

        public string SqlOrder
        {
            get { return this.sqlOrder; }
            set { this.sqlOrder = value; }
        }

        public bool IsSqlFromFu
        {
            get { return this.isSqlFromFu; }
        }

        public List<IDataParameter> ParamList
        {
            get { return this.paramList; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pPKName">主键名</param>
        /// <param name="pPageSize">每页显示记录数</param>
        public PagingList(string pTableName, string pPKName, int pPageSize)
        {
            this.tableName = pTableName;
            this.pKName = pPKName;
            this.puv = new PagingUrlVar(pPageSize);

            PagingList_Load();
        }

        public PagingList(string pTableName, string pPKName, PagingUrlVar pUrlVar)
        {
            this.tableName = pTableName;
            this.pKName = pPKName;
            this.puv = pUrlVar;

            PagingList_Load();
        }

        private void PagingList_Load()
        {
            this.sqlSelect = "select *";
            this.sqlFrom = "from " + tableName;
            this.sqlWhere = "where 1=1";
            this.sqlOrder = "order by " + pKName + " desc";
        }

        private void SetGetList()
        {
            if (this.sqlWhere.Length == 0)
                this.sqlWhere = "where 1=1";

            this.sqlWhere = " " + this.sqlWhere;
            this.sqlFrom = " " + this.sqlFrom;
            this.sqlOrder = " " + this.sqlOrder;

            if (isSqlFromFu)
            {
                structDt = DbHelp.GetDataTable(this.sqlSelect.Replace("select", "select top 1") + this.sqlFrom);
            }
            else
            {
                structDt = DbHelp.GetDataTable("select top 1 * from " + this.tableName);
            }
        }

        public Paging List()
        {
            return List(false);
        }

        public Paging List(bool isWhere)
        {
            SetGetList();

            PagingVar pv = new PagingVar();

            #region where
            if (ArrWhereSQL != null)
            {
                int searchWhereType = Req.GetID("SearchType", -1);

                if (searchWhereType != -1)
                {
                    string sKeyWrod = Req.GetQueryString("KeyWord").Trim();
                    this.SqlWhere += " and " + ArrWhereSQL[searchWhereType];
                    
                    paramList.Add(DbHelp.Def.AddParam("@KeyWrod", sKeyWrod));

                    
                }
            }
            #endregion

            if (paramList.Count > 0)
            {
                pv.DataParm = paramList.ToArray();
            }

            #region order by
            int searchOrder = Req.GetID("SearchOrderBy", -1);
            if (searchOrder != -1)
            {
                int searchOrderValue = Req.GetID("SearchOrderValue", 0);//0降序 1升序
                this.sqlOrder = " order by " + this.structDt.Columns[searchOrder].ColumnName + " " + (searchOrderValue == 1 ? "asc" : "desc");
            }
            #endregion

            pv.SQLCount = "select count(0)" + this.sqlFrom + this.sqlWhere;
            pv.SQLRead = "select " + pKName + this.sqlFrom + this.sqlWhere + this.sqlOrder;

            //abc a,def b where a.id=b.id 这种情况时,需要where
            if (isWhere)
                pv.SQL = this.sqlSelect + this.sqlFrom + this.sqlWhere + " and " + pKName + " in({0})" + this.sqlOrder;
            else
                pv.SQL = this.sqlSelect + this.sqlFrom + " where " + pKName + " in({0})" + this.sqlOrder;

            Paging pg = new Paging(pv, this.puv);
            pg.load();
            return pg;
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public DataTable ListAll()
        {
            SetGetList();

            #region order by
            int searchOrder = Req.GetID("SearchOrderBy", -1);
            if (searchOrder != -1)
            {
                int searchOrderValue = Req.GetID("SearchOrderValue", 0);//0降序 1升序
                this.sqlOrder = " order by " + this.structDt.Columns[searchOrder].ColumnName + " " + (searchOrderValue == 1 ? "asc" : "desc");
            }
            #endregion

            return DbHelp.GetDataTable(this.sqlSelect + this.sqlFrom + this.sqlWhere + this.sqlOrder);
        }

        public string AOnClick(string pFieldName)
        {
            string a = "location.href='{0}'";

            int fieldIndex = FnData.GetTableFieldIndex(structDt, pFieldName);

            URLPara urlp = new URLPara();
            urlp.QueryStringToURLPara();

            int searchOrderValue = Req.GetID("SearchOrderValue", 0);//0降序 1升序
            //HttpContext.Current.Response.Write(searchOrderValue + ",");

            foreach (DataColumn s in structDt.Columns)
            {
                if (string.Compare(s.ColumnName, pFieldName, true) == 0)
                {
                    searchOrderValue = searchOrderValue == 1 ? 0 : 1;
                    break;
                }
            }

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("SearchOrderBy", fieldIndex.ToString());
            d.Add("SearchOrderValue", searchOrderValue.ToString());

            if (!urlp.d.ContainsKey("SearchOrderBy"))
            {
                urlp.d.Add("SearchOrderBy", "");
            }

            if (!urlp.d.ContainsKey("SearchOrderValue"))
            {
                urlp.d.Add("SearchOrderValue", "");
            }

            a = string.Format(a, urlp.ToString(d));

            return a;
        }
    }
}
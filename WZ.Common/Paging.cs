using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Text.RegularExpressions;
using System.Data;

namespace WZ.Common
{
    /// <summary>
    /// 不能实例化该类
    /// </summary>
    public abstract class AbsUrlVar
    {
        private int _records_count;

        public int page_index;
        public int page_size;
        public int page_count;
        //public string page_url;

        /// <summary>
        /// 设置变量
        /// </summary>
        public void SetVar(int page_size, int page_index)
        {
            if (page_size <= 0)
                this.page_size = 10;
            else
                this.page_size = page_size;

            this.page_index = page_index;
        }

        #region 记录数
        /// <summary>
        /// 总记录数
        /// 当设置此属性时,同时求出 页总数(page_count) , 获取页码(page_index)
        /// </summary>
        public int records_count
        {
            get { return _records_count; }
            set
            {
                _records_count = value;
                if (_records_count < 0)
                    _records_count = 0;

                #region 求出总页数 page_count
                if (_records_count == 0)
                    page_count = 1;
                else
                {
                    if (_records_count % page_size == 0)
                        page_count = _records_count / page_size;
                    else
                        page_count = (_records_count / page_size) + 1;
                }
                #endregion

                //验证page_index并更进
                if (_records_count == 0 || page_index < 0 || page_index > page_count)
                    page_index = 1;
            }
        }
        #endregion
    }

    /// <summary>
    /// 分页属性辅助类
    /// </summary>
    public class PagingUrlVar : AbsUrlVar
    {
        public PagingUrlVar(int page_size)
        {
            int page_index;
            page_index = Fn.IsInt(Req.GetQueryString("p"), 1);
            SetVar(page_size, page_index);
        }

        public PagingUrlVar(int page_size, int page_index)
        {
            SetVar(page_size, page_index);
        }
    }

    /// <summary>
    /// sql语句 与 数据库驱动 相关
    /// </summary>
    public class PagingVar
    {
        public IDbProvider ConnProvider = DbHelp.Def;
        public CommandType CommType = CommandType.Text;
        public IDataParameter[] DataParm;

        /// <summary>
        /// 获取总记录数
        /// 如:select count(0) from table where abc=1
        /// </summary>
        public string SQLCount;

        /// <summary>
        /// 循环主键 如:select ProID from table where abc=1 order by ProID desc
        /// </summary>
        public string SQLRead;

        /// <summary>
        /// 获取记录 如:select ProID,Name,Price table where abc=1 and ProID in({0}) order by ProID desc
        /// </summary>
        public string SQL;

        ///// <summary>
        ///// 最大记录数
        ///// </summary>
        //public int row_max = 0;

        /// <summary>
        /// 最大分类数
        /// </summary>
        public int PageCount = -1;

        public PagingVar()
        { }

        public PagingVar(IDbProvider pDbProvider)
        {
            this.ConnProvider = pDbProvider;
        }
    }

    public class PagingVarSP
    {

    }

    public interface IPaging
    {
        PagingUrlVar um { get; set; }
    }

    public class Paging_SP : IPaging
    {
        private string _sql;
        private PagingUrlVar _um;

        public PagingVarSP fd;

        public Paging_SP(PagingVarSP fd, PagingUrlVar um)
        {
            this.fd = fd;
            this.um = um;
        }

        public void load()
        {

        }

        #region IPaging 成员

        public PagingUrlVar um
        {
            get { return _um; }
            set { _um = value; }

        }

        #endregion
    }

    #region 时间 换 空间
    /// <summary>
    /// 时间 换 空间
    /// </summary>
    public class Paging : IPaging
    {
        private string _sql;

        private PagingUrlVar _um;
        public PagingVar fd;

        public Paging(PagingVar fd, PagingUrlVar um)
        {
            this.fd = fd;
            this.um = um;
        }

        public void load()
        {
            IDataReader records;

            DbHelpParam dhp;
            #region 获取总记录
            if (fd.PageCount > 0)
            {
                um.records_count = fd.PageCount * um.page_size;
            }
            else
            {
                dhp = new DbHelpParam(fd.SQLCount, fd.CommType, fd.DataParm, fd.ConnProvider);
                um.records_count = Convert.ToInt32(DbHelp.Scalar(dhp));
            }

            if (string.Compare(fd.SQLRead.Substring(0, 6), "select", true) == 0)
            {
                fd.SQLRead = "select top " + (um.page_index * um.page_size) + fd.SQLRead.Substring(6);//因records.RecordsAffected性能问题 需要加top
            }

            #endregion

            #region 获取当前页主键 sql_key 集合
            int PageLowerBound, PageUpperBound;
            PageLowerBound = (um.page_index - 1) * um.page_size;//每页开始时
            PageUpperBound = PageLowerBound + um.page_size - 1;//每页最后时

            StringBuilder sbSQL = new StringBuilder();
            int i = 0;

            dhp = new DbHelpParam(fd.SQLRead, fd.CommType, fd.DataParm, fd.ConnProvider);
            using (records = DbHelp.Read(dhp))
            {
                //跳过前面查询
                while (0 < PageLowerBound)
                {
                    if (!records.Read())
                        break;
                    PageLowerBound--;
                }

                const string dehao = ",";
                while ((i < um.page_size) && records.Read())
                {
                    sbSQL.Append(records[0]);
                    sbSQL.Append(dehao);
                    i++;
                }
                records.Close();
            }

            if (sbSQL.Length > 0)
            {
                sbSQL.Remove(sbSQL.Length - 1, 1);
                this._sql = string.Format(fd.SQL, sbSQL.ToString());
            }
            else
            {
                this._sql = string.Format(fd.SQL, '0');
            }

            #endregion
        }

        #region Ify 成员
        public PagingUrlVar um
        {
            get { return _um; }
            set { _um = value; }

        }
        #endregion

        public IDataReader GetRead()
        {
            DbHelpParam dhp = new DbHelpParam(this._sql, fd.CommType, fd.DataParm, fd.ConnProvider);
            return DbHelp.Read(dhp);
        }

        public DataTable GetDataTable()
        {
            DbHelpParam dhp = new DbHelpParam(this._sql, fd.CommType, fd.DataParm, fd.ConnProvider);
            return DbHelp.GetDataTable(dhp);
        }

        public string SQL
        {
            get { return this._sql; }
        }
    }
    #endregion

    #region 空间 换 时间
    /// <summary>
    /// 空间 换 时间
    /// </summary>
    public class Paging_DataTable : IPaging
    {
        private PagingUrlVar _um;
        private DataTable dt;
        public DataTable datatable;

        public Paging_DataTable(DataTable dt, PagingUrlVar um)
        {
            this.dt = dt;
            this.um = um;
        }

        public void load()
        {
            um.records_count = dt.Rows.Count;

            int PageLowerBound, PageUpperBound;
            PageLowerBound = (um.page_index - 1) * um.page_size;//每页开始时
            PageUpperBound = PageLowerBound + um.page_size - 1;//每页最后时

            datatable = dt.Clone();
            for (int i = PageLowerBound; i <= PageUpperBound; i++)
            {
                DataRow newdr = datatable.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                datatable.Rows.Add(newdr);
            }
        }
        #region Ify 成员

        public PagingUrlVar um
        {
            get { return _um; }
            set { _um = value; }

        }

        #endregion
    }
    #endregion

    #region 时间 换 空间 Adapter
    /// <summary>
    /// 时间 换 空间
    /// </summary>
    public class Paging_Adapter : IPaging
    {
        private PagingUrlVar _um;
        private string sql;
        private string sql_count;
        public DataTable datatable;

        public PagingVar fd;

        public Paging_Adapter(string sql, string sql_count, PagingUrlVar um)
        {
            fy_adapter1(sql, sql_count, um, null);
        }

        public Paging_Adapter(string sql, string sql_count, PagingUrlVar um, PagingVar fd)
        {
            fy_adapter1(sql, sql_count, um, fd);
        }

        public void fy_adapter1(string sql, string sql_count, PagingUrlVar um, PagingVar fd)
        {
            this.sql = sql;
            this.sql_count = sql_count;
            this.um = um;
            this.fd = fd;
        }

        public void load()
        {
            DbHelpParam dhp = new DbHelpParam(sql_count, fd.CommType, fd.DataParm, fd.ConnProvider);
            um.records_count = Convert.ToInt32(DbHelp.Scalar(dhp).ToString());

            dhp.SQL = sql;
            datatable = DbHelp.GetDataTable_Paging(dhp, um.page_index, um.page_size);//参数需要优化
        }
        #region Ify 成员

        public PagingUrlVar um
        {
            get { return _um; }
            set { _um = value; }
        }

        #endregion
    }
    #endregion
}



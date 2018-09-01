using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using WZ.Common.CacheData;
using WZ.Common.ICommon;

namespace WZ.Data
{
    /// <summary>
    /// 分类操作类
    /// </summary>
    public class ClassData
    {
        private string tableName;
        private DataTable dtClass;
        private IMessage message;
        private string orderBy = " order by Taxis asc";

        public string TableName
        { get { return this.tableName; } }


        public string OrderBy
        { set { this.orderBy = " " + value; } }

        public DataTable DtClass
        {
            get { return this.dtClass; }
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="pTableName">表名</param>
        public ClassData(string pTableName)
        {
            this.tableName = pTableName;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pMessage"></param>
        public ClassData(string pTableName, IMessage pMessage)
        {
            this.tableName = pTableName;
            this.message = pMessage;
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public DataTable List()
        {
            if (dtClass != null)
                return dtClass;

            string sSQL = "select * from " + tableName + orderBy;
            dtClass = DbHelp.GetDataTable(sSQL);
            Fn.SetDataTablePrimary(dtClass);//设置第一个字段为主键
            return dtClass;
        }

        /// <summary>
        /// 获取下一级分类列表
        /// </summary>
        /// <param name="pID">分类ID</param>
        /// <returns></returns>
        public DataTable List(int pClassID)
        {
            string sSQL = "select * from " + tableName + " where PClassSN=" + pClassID + orderBy;
            return DbHelp.GetDataTable(sSQL);
        }

        /// <summary>
        /// 获取下一级分类列表
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pClassID"></param>
        /// <param name="pOrderBy"></param>
        /// <returns></returns>
        public static DataRow[] List(DataTable pDt, int pClassID, string pOrderBy)
        {
            if (pDt == null)
                return null;

            return pDt.Select("PClassSN=" + pClassID, pOrderBy);
        }

        /// <summary>
        /// 获取上一级分类ID
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pClassID"></param>
        /// <returns></returns>
        public static int GetPClassID(DataTable pDt, int pClassID)
        {
            string o = Fn.GetDataTableFind(pDt, pClassID, "PClassSN").ToString();

            if (o.Length == 0)
                return 0;

            return Convert.ToInt32(o);
        }

        /// <summary>
        /// 获取分类路径
        /// </summary>
        /// <param name="pClassID">分类ID</param>
        /// <returns></returns>
        public string GetPath(int pClassID)
        {
            GetClassPath1 acp = new GetClassPath1();
            ClassPath cp = new ClassPath(List(), acp);
            cp.Exe(pClassID);
            string sPath = acp.GetPath;
            sPath = sPath.Length == 0 ? "顶级分类" : sPath;
            return sPath;
        }

        /// <summary>
        /// 获取分类等级
        /// </summary>
        /// <param name="pClassID">分类ID</param>
        /// <returns></returns>
        public byte GetLevel(int pClassID)
        {
            GetClassPath1 acp = new GetClassPath1();
            ClassPath cp = new ClassPath(List(), acp);
            cp.Exe(pClassID);
            return acp.GetLevel;
        }

        /// <summary>
        /// 获取上一级分类ID
        /// </summary>
        /// <param name="pClassID">分类ID</param>
        /// <returns></returns>
        public int GetPClassID(int pClassID)
        {
            string o = Fn.GetDataTableFind(List(), pClassID, "PClassSN").ToString();
            if (o.Length == 0)
                return 0;
            return Convert.ToInt32(o);
        }

        /// <summary>
        /// 获取排序最大值 +1
        /// </summary>
        /// <param name="pClassID">分类ID</param>
        /// <returns></returns>
        public int GetAddRowTaxis(int pClassID)
        {
            return FnData.GetAddRowID(tableName, "Taxis", "where pClassSN=" + pClassID);
        }

        /// <summary>
        /// ClassID +1
        /// </summary>
        /// <param name="pClassID">分类ID</param>
        /// <returns></returns>
        public int GetAddRowClassID()
        {
            return FnData.GetAddRowID(tableName, "ClassSN");
        }

        /// <summary>
        /// 返回树型结构DataTable
        /// </summary>
        /// <param name="pMaxLevel">允许分类添加最大级数  0:无级限</param>
        /// <returns></returns>
        public DataTable GetTree(int pMaxLevel)
        {
            DataTable dtClassAll = List();
            return GetTree(dtClassAll, 0, pMaxLevel, orderBy.Replace("order by ", ""));
            //return GetTree(0, pMaxLevel);
        }

        /// <summary>
        /// 返回树型结构DataTable
        /// </summary>
        /// <param name="pClassID">从该id开始生成树</param>
        /// <param name="pMaxLevel">允许分类添加最大级数  0:无级限</param>
        /// <returns></returns>
        public DataTable GetTree(int pClassID, int pMaxLevel)
        {
            DataTable dtClassAll = List();
            return GetTree(dtClassAll, pClassID, pMaxLevel, orderBy.Replace("order by ", ""));
        }

        public static DataTable GetTree(DataTable pDt, int pClassID, int pMaxLevel, string pOrderBy)
        {
            //DataTable dtClassAll = List();
            GetClassTree gct = new GetClassTree();
            ClassTree ct = new ClassTree(pDt, gct, pOrderBy);
            ct.Exe(pClassID);

            DataTable dt = pDt.Clone();
            if (pMaxLevel > 0)
            {
                IList<DataRow> rowList = new List<DataRow>();
                foreach (DataRow drw in gct.DataRowList)
                {
                    if (Convert.ToInt32(drw["ClassLevel"]) < pMaxLevel)
                        rowList.Add(drw);
                }

                Fn.DrwToDt(rowList, dt);
            }
            else
            {
                Fn.DrwToDt(gct.DataRowList, dt);
            }

            return dt;
        }

        /// <summary>
        /// 判断是否有下一级分类
        /// </summary>
        /// <param name="pClassID"></param>
        /// <returns></returns>
        public bool HasNext(int pClassID)
        {
            string sql = "select top 1 1 from " + tableName + " where PClassSN=" + pClassID;
            return DbHelp.First(sql, "0") == "1";
        }

        /// <summary>
        /// 判断是否有下一级分类
        /// </summary>
        /// <param name="pTableName"></param>
        /// <param name="pClassID"></param>
        /// <returns></returns>
        public static bool HasNext(string pTableName, int pClassID)
        {
            string sql = "select top 1 1 from " + pTableName + " where PClassSN=" + pClassID;
            return DbHelp.First(sql, "0") == "1";
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="pTableName"></param>
        /// <param name="pClassID"></param>
        /// <returns></returns>
        public void Delelte(int pClassID)
        {
            if (message == null)
                return;

            string sSQL = "select ClassSN from " + tableName + " where PClassSN=" + pClassID;
            if (Convert.ToInt32(DbHelp.First(sSQL, "0")) > 0)
            {
                message.Error("请先删除此分类下的所有子类;");
                return;
            }

            sSQL = "delete from " + tableName + " where ClassSN=" + pClassID;
            if (DbHelp.Update(sSQL) > 0)
                message.Success("删除成功");
            else
                message.Error("删除失败");
        }
    }
}

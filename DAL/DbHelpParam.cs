using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace WZ.Common
{
    /// <summary>
    /// DbHelp 接收参数专用类
    /// </summary>
    public class DbHelpParam : IDbHelpParam
    {
        private CommandType cmdType = CommandType.Text;
        private IDataParameter[] arrParm = null;
        private IDbProvider dbProvider = DbHelp.Def;
        private string sql;

        #region 属性
        /// <summary>
        /// 指定如何解释命令字符串
        /// 默认CommandType.Text
        /// </summary>
        public CommandType CmdType
        {
            get { return this.cmdType; }
        }

        /// <summary>
        /// 表示 Command 对象的参数
        /// 默认null
        /// </summary>
        public IDataParameter[] ArrParm
        {
            get { return this.arrParm; }
        }

        /// <summary>
        /// 继承与 IDbProvider 的对象 可以是 AccressProvider,OleDbProvider 或 SqlServerProvider等
        /// 默认DbHelp.Def
        /// </summary>
        public IDbProvider DbProvider
        {
            get { return this.dbProvider; }
        }

        public string SQL
        {
            get { return this.sql; }
            set { this.sql = value; }
        }
        #endregion

        public DbHelpParam()
        {

        }

        public DbHelpParam(string sSQL)
        {
            this.sql = sSQL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCmdType">IDataParameter 参数数组</param>
        public DbHelpParam(string sSQL, IDataParameter[] pArrParm)
        {
            this.sql = sSQL;
            this.arrParm = pArrParm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCmdType">设置CommandType</param>
        public DbHelpParam(string sSQL, CommandType pCmdType)
        {
            this.sql = sSQL;
            this.cmdType = pCmdType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCmdType">设置CommandType</param>
        /// <param name="pArrParm">IDataParameter 参数数组</param>
        public DbHelpParam(string sSQL, CommandType pCmdType, IDataParameter[] pArrParm)
        {
            this.sql = sSQL;
            this.cmdType = pCmdType;
            this.arrParm = pArrParm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCmdType">设置CommandType</param>
        /// <param name="pAParm">IDataParameter 参数数组</param>
        /// <param name="pDbProvider">继承与 IDbProvider 的对象 可以是 AccressProvider,OleDbProvider 或 SqlServerProvider等</param>
        public DbHelpParam(string sSQL, CommandType pCmdType, IDataParameter[] pArrParm, IDbProvider pDbProvider)
        {
            this.sql = sSQL;
            this.cmdType = pCmdType;
            this.arrParm = pArrParm;
            this.dbProvider = pDbProvider;
        }
    }
}

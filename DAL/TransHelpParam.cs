using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace WZ.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class TransHelpParam : IDbHelpParam
    {
        private CommandType cmdType = CommandType.Text;
        private IDataParameter[] arrParm = null;
        private IDbProvider dbProvider = null;
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

        public TransHelpParam()
        {

        }

        public TransHelpParam(string sSQL)
        {
            this.sql = sSQL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCmdType">IDataParameter 参数数组</param>
        public TransHelpParam(string sSQL, IDataParameter[] pArrParm)
        {
            this.sql = sSQL;
            this.arrParm = pArrParm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCmdType">设置CommandType</param>
        public TransHelpParam(string sSQL, CommandType pCmdType)
        {
            this.sql = sSQL;
            this.cmdType = pCmdType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCmdType">设置CommandType</param>
        /// <param name="pArrParm">IDataParameter 参数数组</param>
        public TransHelpParam(string sSQL, CommandType pCmdType, IDataParameter[] pArrParm)
        {
            this.sql = sSQL;
            this.cmdType = pCmdType;
            this.arrParm = pArrParm;
        }
    }
}

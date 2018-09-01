using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WZ.Common
{
    public interface IDbHelp
    {
        void ExecuteTrans(IDbHelpParam pDbHelpParam, DbHelp.ExecuteTransHandler pTrands, WZ.Common.DbHelp.ITransM pObj);
        string First(string pSQL);
        string First(IDbHelpParam pDbHelpParam, string pReturn);
        string First(string pSQL, IDataParameter[] pArrParam);
        string First(string pSQL, string pReturn);
        string First(string pSQL, IDataParameter[] pArrParam, string pReturn);
        string First(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam, string pReturn);
        DataSet GetDataSet(IDbHelpParam pDbHelpParam);
        DataSet GetDataSet(string pSQL);
        DataSet GetDataSet(string pSQL, IDataParameter[] pArrParam);
        DataSet GetDataSet(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam);
        DataTable GetDataTable(IDbHelpParam pDbHelpParam);
        DataTable GetDataTable(string pSQL);
        DataTable GetDataTable(string pSQL, CommandType pCmdType);
        DataTable GetDataTable(string pSQL, IDataParameter[] pArrParam);
        DataTable GetDataTable(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam);
        DataTable GetDataTable_Paging(IDbHelpParam pDbHelpParam, int pPageIndex, int pPageSize);
        DataTable GetDataTable_Paging(string pSQL, int pPageIndex, int pPageSize);
        IDataReader Read(IDbHelpParam pDbHelpParam);
        IDataReader Read(string pSQL);
        IDataReader Read(string pSQL, IDataParameter[] pArrParam);
        IDataReader Read(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam);
        object Scalar(IDbHelpParam pDbHelpParam);
        object Scalar(string pSQL);
        object Scalar(string pSQL, IDataParameter[] pArrParam);
        object Scalar(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam);
        int Update(IDbHelpParam pDbHelpParam);
        int Update(string pSQL);
        int Update(string pSQL, IDataParameter[] pArrParam);
        int Update(string pSQL, CommandType pCmdType, IDataParameter[] pArrParam);
    }
}

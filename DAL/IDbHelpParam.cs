using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WZ.Common
{
    public interface IDbHelpParam
    {
        CommandType CmdType { get; }
        IDataParameter[] ArrParm { get; }
        IDbProvider DbProvider { get; }
        string SQL { get; set; }
    }
}

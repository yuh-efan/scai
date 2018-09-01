using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WZ.Data.Merge
{
    /// <summary>
    /// 合并订单
    /// </summary>
    public class Merge_Ord_Handler
    {

    }

    public class Merge_Ord_Info
    {
        public DataRow ordInfo;
        public List<Merge_Ord_Pro> proList = new List<Merge_Ord_Pro>();
        public int IsDel = 0;//合并时用到,0:未删除,1:已删除 用于在算法时标识
    }

    public class Merge_Ord_Pro
    {
        public DataRow proInfo;
        public int IsDel = 0;//合并时用到,0:未删除,1:已删除 用于在算法时标识
    }
}

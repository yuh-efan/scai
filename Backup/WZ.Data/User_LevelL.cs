using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common.CacheData;
using WZ.Common;

namespace WZ.Data
{
    public class User_LevelL
    {
        private DataTable dtUser_Level;

        public User_LevelL()
        {
            this.dtUser_Level = PubData.GetDataTable("user_level");
        }
        
        /// <summary>
        /// 获取会员等级名称
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public object GetLevelName(object pObj)
        {
            const string sLevelName = "LevelName";
            return Fn.GetDataTableFind(this.dtUser_Level, pObj, sLevelName);
        }

        /// <summary>
        /// 获取会员等级对应的折扣
        /// </summary>
        /// <param name="pUserLevel">会员等级</param>
        /// <returns></returns>
        public static double GetLevelDiscount(int pUserLevel)
        {
            DataTable dt = PubData.GetDataTable("user_level");
            //DataTable dt = SCWCache.GetDataTable(SCWCache.CacheKey.User_Level);

            object obj = Fn.GetDataTableFind(dt, pUserLevel, "ls_Discount");

            if (obj.ToString() == string.Empty)
            {
                //obj一般情况不可能为空,需要添加日志 需要优化
                return 1;
            }

            return Convert.ToDouble(obj);
        }

        /// <summary>
        /// 获取默认等级
        /// </summary>
        /// <returns></returns>
        public static int GetDefaultLevel()
        {
            return int.Parse(DbHelp.First("select LevelSN from User_Level where IsDefault=1", "1"));
        }
    }
}
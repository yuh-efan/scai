using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common.CacheData;
using System.Data;

/*
 * 公共数据
 * 
 * */
namespace WZ.Data
{
    public class PubData
    {
        public readonly static DbCache PubCache = new DbCache("wz.");

        private static Dictionary<string, string> dirc = new Dictionary<string, string>();
        static PubData()
        {
            dirc.Add("pro_class", "select * from vgPro_Class order by Taxis asc");//产品分类
            dirc.Add("caipu_class", "select * from vgCaiPu_Class order by Taxis asc");//菜谱分类
            dirc.Add("help_class", "select * from Help_Class order by Taxis asc");//帮助分类
            dirc.Add("user_level", "select LevelSN,LevelType,LevelName,Percentage,(Percentage/100) as ls_Discount,IsDefault,LevelExp from User_Level");//会员等级
            dirc.Add("pub_area", "select ClassSN,ClassName,PClassSN,Taxis from Pub_Area order by Taxis asc");//区域
            dirc.Add("join_info", "select JoinSN,JoinName from Join_Info");//Join_Info
            dirc.Add("webinfo", "select * from WebInfo");//网站内容,如广告
            dirc.Add("caipu_classattr", "select * from CaiPu_ClassAttr order by Taxis asc");//菜谱属性分类
            dirc.Add("pay_info", "select * from Pay_Info order by Taxis desc");//支付方式
        }

        /// <summary>
        /// 表名
        /// </summary>
        /// <param name="pKeyName"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string pKeyName)
        {
            try
            {
                return PubCache.GetDataTable(pKeyName, dirc[pKeyName]);
            }
            catch (Exception e)
            {
                throw new Exception(pKeyName + e.Message);
            }
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="pKeyName"></param>
        public static void DeleteCache(string pKeyName)
        {
            if (!dirc.ContainsKey(pKeyName))
                throw new Exception(pKeyName + ":关键字不在字典中");
            PubCache.Delete(pKeyName);
        }
    }
}

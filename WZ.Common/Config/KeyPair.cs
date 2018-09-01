using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Common.Config
{/*
    public class KeyPair
    {
        #region IKeyPair
        /// <summary>
        /// 普通 Dictionary
        /// </summary>
        public abstract class IKeyPair
        {
            public Dictionary<string, string> Dirc;

            /// <summary>
            /// 获取Dictionary 对应key值
            /// </summary>
            /// <param name="pKey"></param>
            /// <returns></returns>
            public string GetDirc(string pKey)
            {
                string s = string.Empty;
                if (pKey.Length > 0)
                {
                    Dirc.TryGetValue(pKey, out s);
                    //if (Dirc.ContainsKey(pKey))
                    //    s = Dirc[pKey];
                }
                return s;
            }
        }

        public abstract class IKeyPairBit : IKeyPair
        {
            /// <summary>
            /// 获取Dictionary 对应key值 位计算
            /// </summary>
            /// <param name="pKey"></param>
            /// <returns></returns>
            public string GetDircBit(int pKey)
            {
                string str = string.Empty;
                foreach (string s in Dirc.Keys)
                {
                    int iKey = Convert.ToInt32(s);
                    if ((iKey & pKey) == iKey)
                        str += Dirc[s] + ",";
                }

                if (str.Length > 0)
                    str = str.TrimEnd(',');
                return str;
            }
        }


        #endregion

        #region 审核 0:未审核 1:通过审核 2:未通过审核
        /// <summary>
        /// 审核 0:未审核 1:通过审核 2:未通过审核
        /// </summary>
        public class Audit : IKeyPair
        {
            public Audit()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("0", "未审核");
                Dirc.Add("1", "通过");
                Dirc.Add("2", "未通过");
            }
        }
        #endregion

        #region 文章版权 1:原创 2:转载
        /// <summary>
        /// 文章版权 1:原创 2:转载
        /// </summary>
        public class NewsType : IKeyPair
        {
            public NewsType()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "原创");
                Dirc.Add("2", "转载");
            }
        }
        #endregion

        #region 产品属性
        /// <summary>
        /// 产品属性
        /// </summary>
        public class ProItem : IKeyPairBit
        {
            public ProItem()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "新品");
                Dirc.Add("2", "推荐");
                Dirc.Add("4", "促销");
                Dirc.Add("8", "热销");
                Dirc.Add("16", "秒杀");
                //Dirc.Add("64", "菜蓝子");
                Dirc.Add("128", "无公害");
                Dirc.Add("256", "首页栏目");
                Dirc.Add("1024", "独家");

                Dirc.Add("32", "推荐到菜篮子专栏首页");
                Dirc.Add("512", "推荐到菜篮子专栏栏目");

            }
        }
        #endregion

        #region 菜谱属性
        /// <summary>
        /// 菜谱属性
        /// </summary>
        public class CaiPuItem : IKeyPairBit
        {
            public CaiPuItem()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "精品食谱");
                Dirc.Add("2", "推荐1");
                Dirc.Add("4", "推荐2");
                //Dirc.Add("64", "菜蓝子");
                Dirc.Add("128", "无公害");
                Dirc.Add("256", "首页栏目");
            }
        }
        #endregion

        #region 套餐属性
        /// <summary>
        /// 套餐属性
        /// </summary>
        public class TaoCanItem : IKeyPairBit
        {
            public TaoCanItem()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "精品食谱");
                Dirc.Add("2", "推荐1");
                Dirc.Add("4", "推荐2");
                //Dirc.Add("64", "菜蓝子");
                Dirc.Add("128", "无公害");
                Dirc.Add("256", "首页栏目");
            }
        }
        #endregion

        #region 帮助属性
        /// <summary>
        /// 帮助属性
        /// </summary>
        public class HelpItem : IKeyPairBit
        {
            public HelpItem()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "显示底部");
            }
        }
        #endregion

        #region 产品类型
        /// <summary>
        /// 产品类型 0:产品 1:菜谱 3:营养套餐
        /// </summary>
        public class ProType : IKeyPair
        {
            public ProType()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("0", "产品");
                Dirc.Add("1", "菜谱");
                Dirc.Add("2", "营养套餐");
            }
        }
        #endregion

        #region 新闻页链接类型 0:资讯页 1:独立页
        /// <summary>
        /// 新闻页链接类型 0:资讯页 1:独立页
        /// </summary>
        public class NewsUrlType : IKeyPair
        {
            public NewsUrlType()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "资讯页");
                Dirc.Add("2", "独立页");
            }
        }
        #endregion

        #region 新闻属性
        /// <summary>
        /// 新闻属性
        /// </summary>
        public class NewsItem : IKeyPairBit
        {
            public NewsItem()
            {
                Dirc = new Dictionary<string, string>();

                Dirc.Add("32", "首页推荐");
                Dirc.Add("64", "首页图文");

                Dirc.Add("4", "内页推荐");
                Dirc.Add("1", "内页图文");

                Dirc.Add("2", "幻灯片");
                Dirc.Add("8", "公告");
                Dirc.Add("16", "活动");

            }
        }
        #endregion

        #region 幻灯片位置
        /// <summary>
        /// 幻灯片位置
        /// </summary>
        public class PPTStr : IKeyPair
        {
            public PPTStr()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("home", "首页");
                Dirc.Add("caipu", "菜谱");
                Dirc.Add("taocan", "营养套餐");
                Dirc.Add("cailangzi", "菜篮子专栏");
                Dirc.Add("gift", "礼品兑换区");
            }
        }
        #endregion

        #region 是否
        /// <summary>
        /// 是否
        /// </summary>
        public class YesOrNo : IKeyPair
        {
            public YesOrNo()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "是");
                Dirc.Add("0", "否");
            }
        }
        #endregion

        #region 从事行业
        /// <summary>
        /// 从事行业
        /// </summary>
        public class Trades : IKeyPair
        {
            public Trades()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "企业雇主/企业经营者");
                Dirc.Add("2", "高级行政人员(行政总裁、总经理、董事等)");
                Dirc.Add("3", "中层管理人员(总监、经理、主任等)");
                Dirc.Add("4", "专业人士(会计师、律师、工程师、医生、教师等)");
                Dirc.Add("5", "办公职员(一般文职、业务、办事人员等)工人、蓝领");
                Dirc.Add("6", "工人/蓝领");
                Dirc.Add("7", "公务员、公共事业单位员工");
                Dirc.Add("8", "自由职业者");
                Dirc.Add("9", "军人");
                Dirc.Add("10", "学生");
                Dirc.Add("11", "退休人员");
                Dirc.Add("12", "家庭主妇");
                Dirc.Add("13", "其他");
            }
        }
        #endregion

        #region 月均收入
        /// <summary>
        /// 月均收入
        /// </summary>
        public class Income : IKeyPair
        {
            public Income()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "无收入");
                Dirc.Add("2", "2000 元以下");
                Dirc.Add("3", "2000～3999 元");
                Dirc.Add("4", "4000～5999 元");
                Dirc.Add("5", "6000～7999 元");
                Dirc.Add("6", "8000～9999 元");
                Dirc.Add("7", "10000～15000 元");
                Dirc.Add("8", "15000 元以上");
            }
        }
        #endregion

        #region 厨艺水平
        /// <summary>
        /// 厨艺水平
        /// </summary>
        public class Cuisine : IKeyPair
        {
            public Cuisine()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "初级");
                Dirc.Add("2", "中级");
                Dirc.Add("3", "高级");
            }
        }
        #endregion

        #region 喜欢菜系
        /// <summary>
        /// 喜欢菜系
        /// </summary>
        public class Vegetables : IKeyPairBit
        {
            public Vegetables()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "川菜");
                Dirc.Add("2", "鲁菜");
                Dirc.Add("4", "苏菜");
                Dirc.Add("8", "粤菜");
                Dirc.Add("16", "浙菜");
                Dirc.Add("32", "闽菜");
                Dirc.Add("64", "湘菜");
                Dirc.Add("128", "徽菜");
                Dirc.Add("256", "京菜");
                Dirc.Add("512", "晋菜");
                Dirc.Add("1024", "上海菜");
                Dirc.Add("2048", "西北菜");
                Dirc.Add("4096", "东北菜");
                Dirc.Add("8192", "泰国菜");
                Dirc.Add("16384", "日韩料理");
                Dirc.Add("32768", "其他");
            }
        }
        #endregion

        #region 喜欢口味
        /// <summary>
        /// 喜欢口味
        /// </summary>
        public class Taste : IKeyPairBit
        {
            public Taste()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "酸味");
                Dirc.Add("2", "甜味");
                Dirc.Add("4", "苦味");
                Dirc.Add("8", "辣味");
                Dirc.Add("16", "咸味");
                Dirc.Add("32", "香味");
                Dirc.Add("64", "麻辣");
                Dirc.Add("128", "清淡");
                Dirc.Add("256", "酸辣");
                Dirc.Add("512", "微苦");
                Dirc.Add("1024", "微辣");
                Dirc.Add("2048", "香酥");
                Dirc.Add("4096", "香脆");
                Dirc.Add("8192", "怪味");
            }
        }
        #endregion

        #region 网购食品您更注重那些因素
        /// <summary>
        /// 网购食品您更注重那些因素
        /// </summary>
        public class Factor : IKeyPairBit
        {
            public Factor()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "健康新鲜");
                Dirc.Add("2", "价格低廉");
                Dirc.Add("4", "营养搭配");
                Dirc.Add("8", "配送快捷");
                Dirc.Add("16", "服务态度");
            }
        }
        #endregion

        #region 订单状态
        /// <订单状态>
        /// 订单状态
        /// </summary>
        public class OrderStatus : IKeyPairBit
        {
            public const int 已结算 = 1;
            public const int 已发货 = 2;
            public const int 已付款 = 4;
            public const int 已完成 = 8;
            public const int 已取消 = 16;

            public OrderStatus()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "已结算");
                Dirc.Add("2", "已发货");
                Dirc.Add("4", "已付款");
                Dirc.Add("8", "已完成");
                Dirc.Add("16", "已取消");
            }
        }
        #endregion

        #region 关键词状态
        /// <summary>
        /// 关键词状态
        /// </summary>
        public class KeyWordItem : IKeyPairBit
        {
            public KeyWordItem()
            {
                Dirc = new Dictionary<string, string>();
                Dirc.Add("1", "前台显示");
                Dirc.Add("2", "显示在搜索框(商品)");
                Dirc.Add("4", "显示在搜索框(食谱)");
                Dirc.Add("8", "显示在搜索框(资讯)");
            }
        }
        #endregion

        public static Dictionary<string, string> YesNo;//是否
        public static Dictionary<string, string> Sex;//男女
        //public static Dictionary<string, string> OrderState;//订单状态
        public static Dictionary<string, string> IsHas;//上下架
        public static Dictionary<string, string> selListModel;//无
        public static Dictionary<string, string> selListPriceOrder;//无
        public static Dictionary<string, string> selSearchList;//无
        public static Dictionary<string, string> JoinTypeList;//商家,菜篮子
        public static Dictionary<string, string> LevelType;//会员类型
        //public static Dictionary<string, string> ThingType;//东西类型 0:产品 1:营养套餐
        public static Dictionary<string, string> BulletinType;//活动通知 0:网站公告 1:活动通知

        public static Dictionary<string, string> LinksType;//0:友情链接 1:合作伙伴
        public static Dictionary<string, string> LinksShowLocal;//显示位置 1:显示在首页
        public static Dictionary<string, string> LinksShowType;//显示方式 0:文字链接,1:图片链接



        //public static Dictionary<string, string> AttrList;//产品属性

        public static Dictionary<string, string> PayType;//支付方式类型



        static KeyPair()
        {
            Load_YesNo();
            //Load_OrderState();
            Load_Sex();
            Load_IsHas();
            Load_selListModel();
            Load_selListPriceOrder();
            Load_selSearchList();
            Load_JoinTypeList();
            Load_LevelType();
            //Load_ThingType();
            Load_BulletinType();
            Load_LinksType();
            //Load_AttrList();
            Load_PayType();
            Load_LinksShowLocal();
            Load_LinksShowType();

        }

        #region 显示方式 0:文字链接,1:图片链接
        /// <summary>
        /// 显示方式 0:文字链接,1:图片链接
        /// </summary>
        private static void Load_LinksShowType()
        {
            LinksShowType = new Dictionary<string, string>();
            LinksShowType.Add("0", "文字链接");
            LinksShowType.Add("1", "图片链接");
        }

        public static string GetLinksShowType(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (LinksShowType.ContainsKey(pKey))
                {
                    s = LinksShowType[pKey];
                }
            }
            return s;
        }
        #endregion

        #region 友情链接 显示位置
        /// <summary>
        /// 友情链接 显示位置
        /// </summary>
        private static void Load_LinksShowLocal()
        {
            LinksShowLocal = new Dictionary<string, string>();
            LinksShowLocal.Add("0", "无");
            LinksShowLocal.Add("1", "显示在首页");
        }

        public static string GetLinksShowLocal(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (LinksShowLocal.ContainsKey(pKey))
                {
                    s = LinksShowLocal[pKey];
                }
            }
            return s;
        }
        #endregion

        #region 支付方式类型
        /// <summary>
        /// 是否
        /// </summary>
        private static void Load_PayType()
        {
            PayType = new Dictionary<string, string>();
            PayType.Add("zfb", "支付宝");
            PayType.Add("gs", "工商银行");
            PayType.Add("ny", "农业银行");
            PayType.Add("zg", "中国银行");
            PayType.Add("js", "建设银行");
            PayType.Add("yck", "预存款");
            PayType.Add("qt", "其它");
        }

        public static string GetPayType(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (PayType.ContainsKey(pKey))
                {
                    s = PayType[pKey];
                }
            }
            return s;
        }
        #endregion

        #region 商品属性
        //private static void Load_AttrList()
        //{
        //    AttrList = new Dictionary<string, string>();
        //    AttrList.Add("1", "新品");
        //    AttrList.Add("2", "推荐");
        //    AttrList.Add("4", "特价");
        //    AttrList.Add("8", "热销");
        //    AttrList.Add("16", "回收");
        //    AttrList.Add("32", "不能使用优惠卷");
        //    AttrList.Add("64", "菜蓝子");
        //    AttrList.Add("128", "无公害");
        //}

        //public static string GetAttrList(object pKey)
        //{
        //    if (pKey.ToString().Length == 0)
        //        return string.Empty;
        //    return ((Config.PubEnum.ProItem)pKey).ToString();
        //}
        #endregion

        #region 友情链接
        private static void Load_LinksType()
        {
            LinksType = new Dictionary<string, string>();
            LinksType.Add("0", "友情链接");
            LinksType.Add("1", "合作伙伴");
        }

        public static string GetLinksType(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (LinksType.ContainsKey(pKey))
                {
                    s = LinksType[pKey];
                }
            }
            return s;
        }
        #endregion

        #region 活动通知
        private static void Load_BulletinType()
        {
            BulletinType = new Dictionary<string, string>();
            BulletinType.Add("0", "网站公告");
            BulletinType.Add("1", "活动通知");
        }

        public static string GetBulletinType(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (BulletinType.ContainsKey(pKey))
                {
                    s = BulletinType[pKey];
                }
            }
            return s;
        }
        #endregion

        #region 东西类型
        //private static void Load_ThingType()
        //{
        //    ThingType = new Dictionary<string, string>();
        //    ThingType.Add("0", "产品");
        //    ThingType.Add("1", "营养套餐");
        //}

        //public static string GetThingType(string pKey)
        //{
        //    string s = string.Empty;
        //    if (pKey.Length > 0)
        //    {
        //        if (ThingType.ContainsKey(pKey))
        //        {
        //            s = ThingType[pKey];
        //        }
        //    }
        //    return s;
        //}
        #endregion

        #region 会员类型
        private static void Load_LevelType()
        {
            LevelType = new Dictionary<string, string>();
            LevelType.Add("0", "普通零售会员等级");
            LevelType.Add("1", "批发代理会员等级");
        }

        public static string GetLevelType(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (LevelType.ContainsKey(pKey))
                {
                    s = LevelType[pKey];
                }
            }
            return s;
        }
        #endregion

        #region 是否
        /// <summary>
        /// 是否
        /// </summary>
        private static void Load_YesNo()
        {
            YesNo = new Dictionary<string, string>();
            YesNo.Add("1", "是");
            YesNo.Add("0", "否");
        }

        public static string GetYesNo(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (YesNo.ContainsKey(pKey))
                {
                    s = YesNo[pKey];
                }
            }
            return s;
        }
        #endregion

        #region 性别
        /// <summary>
        /// 性别
        /// </summary>
        private static void Load_Sex()
        {
            Sex = new Dictionary<string, string>();
            Sex.Add("1", "男");
            Sex.Add("0", "女");
            //Sex.Add("3", "保密");
        }

        /// <summary>
        /// 获取性别
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public static string GetSexName(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (Sex.ContainsKey(pKey))
                {
                    s = Sex[pKey];
                }
            }
            return s;
        }
        #endregion

        #region 订单状态
        /// <summary>
        /// 订单状态
        /// </summary>
        //private static void Load_OrderState()
        //{
        //    OrderState = new Dictionary<string, string>();
        //    OrderState.Add("1", "未付款");
        //    OrderState.Add("2", "已付款");
        //    OrderState.Add("4", "配货中");
        //    OrderState.Add("8", "已发货");
        //    OrderState.Add("16", "完成");
        //    OrderState.Add("32", "申请退款");
        //    OrderState.Add("64", "已退款");
        //    OrderState.Add("128", "作废");
        //}

        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        //public static string GetOrderName(object pKey)
        //{
        //    if (pKey.ToString().Length == 0)
        //        return string.Empty;
        //    return ((Config.PubEnum.Ord_Status)pKey).ToString();

        //    //string s = string.Empty;
        //    //if (pKey.Length > 0)
        //    //{
        //    //    if (OrderState.ContainsKey(pKey))
        //    //    {
        //    //        s = OrderState[pKey];
        //    //    }
        //    //}
        //    //return s;
        //}
        #endregion

        #region 上架下架
        /// <summary>
        /// 上架下架
        /// </summary>
        private static void Load_IsHas()
        {
            IsHas = new Dictionary<string, string>();
            IsHas.Add("0", "上架");
            IsHas.Add("1", "下架");
        }

        /// <summary>
        /// 获取上价下价
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public static string GetIsHas(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (IsHas.ContainsKey(pKey))
                {
                    s = IsHas[pKey];
                }
            }
            return s;
        }

        /// <summary>
        /// 获取上价下价
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string GetIsHas(string pKey, bool b)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (!b && pKey == "0") return s;
                if (IsHas.ContainsKey(pKey))
                {
                    s = IsHas[pKey];
                }
            }
            return s;
        }
        #endregion

        #region 列表显示方式
        /// <summary>
        /// 列表显示方式
        /// </summary>
        private static void Load_selListModel()
        {
            selListModel = new Dictionary<string, string>();
            selListModel.Add("_1", "显示模式");
            selListModel.Add("0", "横向图片模式");
            selListModel.Add("1", "纵向列表模式");
        }
        #endregion

        #region 列表价格排序
        /// <summary>
        /// 列表显示方式
        /// </summary>
        private static void Load_selListPriceOrder()
        {
            selListPriceOrder = new Dictionary<string, string>();
            selListPriceOrder.Add("_1", "价格排序");
            selListPriceOrder.Add("0", "低->高");
            selListPriceOrder.Add("1", "高->低");
        }
        #endregion

        #region 商品搜索
        /// <summary>
        /// 商品搜索
        /// </summary>
        private static void Load_selSearchList()
        {
            selSearchList = new Dictionary<string, string>();
            selSearchList.Add("1", "商品名称");
            selSearchList.Add("2", "商品编号");
            selSearchList.Add("3", "商品价格");
        }
        #endregion

        #region 商家类型
        /// <summary>
        /// 商家类型
        /// </summary>
        private static void Load_JoinTypeList()
        {
            JoinTypeList = new Dictionary<string, string>();
            JoinTypeList.Add("0", "菜蓝子");
            JoinTypeList.Add("1", "商家");
        }

        /// <summary>
        /// 获取商家名称
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public static string GetJoinTypeList(string pKey)
        {
            string s = string.Empty;
            if (pKey.Length > 0)
            {
                if (JoinTypeList.ContainsKey(pKey))
                {
                    s = JoinTypeList[pKey];
                }
            }
            return s;
        }
        #endregion
    }

    */
}

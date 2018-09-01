using System;
using System.Collections.Generic;
using System.Text;
using WZ.Data.DataItem;

namespace WZ.Data.DataItem
{
    public class ItemInfoData
    {
        /// <summary>
        /// 工作状态
        /// </summary>
        public static List<ItemInfo> AdminUser_ThingStatus;

        /// <summary>
        /// 会员类型
        /// </summary>
        public static List<ItemInfo> User_Type;

        /// <summary>
        /// 推广员申请
        /// </summary>
        public static List<ItemInfo> User_ApplyFor_1_Status;

        /// <summary>
        /// 投拆类型
        /// </summary>
        public static List<ItemInfo> Complaint_Type;

        /// <summary>
        /// 投拆状态
        /// </summary>
        public static List<ItemInfo> Complaint_Status;

        /// <summary>
        /// 采购任务(需要采购产品库) 状态
        /// </summary>
        public static List<ItemInfo> NeedPurchase_Status;

        /// <summary>
        /// 采购任务(需要采购产品库) 类型
        /// </summary>
        public static List<ItemInfo> NeedPurchase_Type;

        /// <summary>
        /// 入库类型
        /// </summary>
        public static List<ItemInfo> InStock_Type;

        /// <summary>
        /// 出库类型
        /// </summary>
        public static List<ItemInfo> OutStock_Type;

        /// <summary>
        /// 出库产品状态
        /// </summary>
        public static List<ItemInfo> OrdPro_StatusOutStock;

        /// <summary>
        /// 活动列表状态
        /// </summary>
        public static List<ItemInfo> Activity_List_Status;

        /// <summary>
        /// 抵金券状态
        /// </summary>
        public static List<ItemInfo> Ticket_1_Status;

        /// <summary>
        /// 会员卡状态
        /// </summary>
        public static List<ItemInfo> Card_Status;

        static ItemInfoData()
        {
            //工作状态
            AdminUser_ThingStatus = new List<ItemInfo>();
            AdminUser_ThingStatus.Add(new ItemInfo() { id = "0", name = "正常" });
            AdminUser_ThingStatus.Add(new ItemInfo() { id = "1", name = "请假" });
            AdminUser_ThingStatus.Add(new ItemInfo() { id = "2", name = "出差" });

            User();

            Erp();

            //活动相关
            Activity();
        }

        private static void User()
        {
            //用户类型
            User_Type = new List<ItemInfo>();
            User_Type.Add(new ItemInfo() { id = "0", name = "A类" });
            User_Type.Add(new ItemInfo() { id = "1", name = "B类" });
            User_Type.Add(new ItemInfo() { id = "2", name = "C类" });
            User_Type.Add(new ItemInfo() { id = "3", name = "D类" });
            User_Type.Add(new ItemInfo() { id = "4", name = "E类" });
            User_Type.Add(new ItemInfo() { id = "5", name = "F类" });

            //推广员申请
            User_ApplyFor_1_Status = new List<ItemInfo>();
            User_ApplyFor_1_Status.Add(new ItemInfo() { id = "0", name = "未处理" });
            User_ApplyFor_1_Status.Add(new ItemInfo() { id = "1", name = "通过" });
            User_ApplyFor_1_Status.Add(new ItemInfo() { id = "2", name = "未通过" });
        }

        private static void Erp()
        {
            //投拆类型
            Complaint_Type = new List<ItemInfo>();
            Complaint_Type.Add(new ItemInfo() { id = "0", name = "A类问题" });
            Complaint_Type.Add(new ItemInfo() { id = "1", name = "B类问题" });
            Complaint_Type.Add(new ItemInfo() { id = "2", name = "C类问题" });
            Complaint_Type.Add(new ItemInfo() { id = "4", name = "D类问题" });
            Complaint_Type.Add(new ItemInfo() { id = "8", name = "E类问题" });
            Complaint_Type.Add(new ItemInfo() { id = "16", name = "F类问题" });

            //投拆状态
            Complaint_Status = new List<ItemInfo>();
            Complaint_Status.Add(new ItemInfo() { id = "0", name = "未处理" });
            Complaint_Status.Add(new ItemInfo() { id = "1", name = "处理中" });
            Complaint_Status.Add(new ItemInfo() { id = "2", name = "已完成处理" });
            Complaint_Status.Add(new ItemInfo() { id = "3", name = "取消处理" });

            //采购任务(需要采购产品库) 状态
            NeedPurchase_Status = new List<ItemInfo>();
            NeedPurchase_Status.Add(new ItemInfo() { id = "0", name = "未入库" });
            NeedPurchase_Status.Add(new ItemInfo() { id = "1", name = "已入库" });
            NeedPurchase_Status.Add(new ItemInfo() { id = "2", name = "部分入库" });

            //采购任务(需要采购产品库) 类型
            NeedPurchase_Type = new List<ItemInfo>();
            NeedPurchase_Type.Add(new ItemInfo() { id = "0", name = "订单提交" });
            NeedPurchase_Type.Add(new ItemInfo() { id = "1", name = "手工提交" });

            //入库类型
            InStock_Type = new List<ItemInfo>();
            InStock_Type.Add(new ItemInfo() { id = "0", name = "正常" });
            InStock_Type.Add(new ItemInfo() { id = "1", name = "损耗" });
            InStock_Type.Add(new ItemInfo() { id = "2", name = "补货" });

            //出库类型
            OutStock_Type = new List<ItemInfo>();
            OutStock_Type.Add(new ItemInfo() { id = "0", name = "正常" });
            OutStock_Type.Add(new ItemInfo() { id = "1", name = "损耗" });
            OutStock_Type.Add(new ItemInfo() { id = "2", name = "补货" });

            //出库产品状态
            OrdPro_StatusOutStock = new List<ItemInfo>();
            OrdPro_StatusOutStock.Add(new ItemInfo() { id = "0", name = "未出库" });
            OrdPro_StatusOutStock.Add(new ItemInfo() { id = "1", name = "已出库" });
            OrdPro_StatusOutStock.Add(new ItemInfo() { id = "2", name = "部分出库" });

        }

        private static void Activity()
        {
            //活动列表状态
            Activity_List_Status = new List<ItemInfo>();
            Activity_List_Status.Add(new ItemInfo() { id = "0", name = "关闭" });
            Activity_List_Status.Add(new ItemInfo() { id = "1", name = "启用" });

            //抵金券状态
            Ticket_1_Status = new List<ItemInfo>();
            Ticket_1_Status.Add(new ItemInfo() { id = "0", name = "未使用" });
            Ticket_1_Status.Add(new ItemInfo() { id = "1", name = "已使用" });

            //会员卡状态
            Card_Status = new List<ItemInfo>();
            Card_Status.Add(new ItemInfo() { id = "0", name = "未注册" });
            Card_Status.Add(new ItemInfo() { id = "1", name = "已注册" });
        }
    }
}

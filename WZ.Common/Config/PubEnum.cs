using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;

namespace WZ.Common.Config
{
    /// <summary>
    /// 公共枚举
    /// </summary>
    public class PubEnum
    {
        /// <summary>
        /// 订单里保存每个产品购买的时的产品状态
        /// </summary>
        [Flags]
        public enum CurrentProStatus
        {
            不存在此商品 = 1,
            库存不足 = 2,
            已下架 = 4
        }
    }
}
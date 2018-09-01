using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using WZ.Model;

namespace WZ.Data
{
    public class Ord_ProL
    {
        #region help
        protected IDbHelp curHelp;

        public Ord_ProL()
        {
            this.curHelp = new DefaultHelp();
        }

        public Ord_ProL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        /// <summary>
        /// 获取订单下的  上架产品总额
        /// </summary>
        /// <param name="pOrderID"></param>
        /// <returns></returns>
        public static double GetTotlePrice(int pOrderID)
        {
            IDataParameter[] dp = { 
                                      DbHelp.Def.AddParam("@FK_Order", pOrderID) 
                                  };
            return Convert.ToDouble(DbHelp.First("ord_get_totprice", CommandType.StoredProcedure, dp, "0"));
        }



        //    public bool Add(Ord_ProM pMod)
        //    {
        //        const string sql = "insert into Ord_Pro(FK_Order,FK_Pro,FK_User,op_ProName,op_ProPrice,op_UserPrice,op_UserTotalPrice,op_Percentage,op_ProNum,op_ActualNum,op_ProUnit,op_ProUnitNum,op_Status)" +
        //        " values(@FK_Order,@FK_Pro,@FK_User,@op_ProName,@op_ProPrice,@op_UserPrice,@op_UserTotalPrice,@op_Percentage,@op_ProNum,@op_ActualNum,@op_ProUnit,@op_ProUnitNum,@op_Status)";

        //        IDataParameter[] dp = { 
        //                            DbHelp.Def.AddParam("@FK_Order",pMod.FK_Order),
        //                        DbHelp.Def.AddParam("@FK_Pro",pMod.FK_Pro),
        //                        DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
        //                        DbHelp.Def.AddParam("@op_ProName",pMod.op_ProName),
        //                        DbHelp.Def.AddParam("@op_ProPrice",pMod.op_ProPrice),
        //                        DbHelp.Def.AddParam("@op_UserPrice",pMod.op_UserPrice),
        //                        DbHelp.Def.AddParam("@op_UserTotalPrice",pMod.op_UserTotalPrice),
        //                        DbHelp.Def.AddParam("@op_Percentage",pMod.op_Percentage),
        //                        DbHelp.Def.AddParam("@op_ProNum",pMod.op_ProNum),
        //                        DbHelp.Def.AddParam("@op_ActualNum",pMod.op_ActualNum),
        //                        DbHelp.Def.AddParam("@op_ProUnit",pMod.op_ProUnit),
        //                        DbHelp.Def.AddParam("@op_ProUnitNum",pMod.op_ProUnitNum),
        //                        DbHelp.Def.AddParam("@op_Status",pMod.op_Status),
        //                            };
        //        return (curHelp.Update(sql, dp) > 0);
        //    }
        
    }
}

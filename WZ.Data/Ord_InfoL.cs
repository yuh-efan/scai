using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using WZ.Model;
using WZ.Common.ICommon;

namespace WZ.Data
{
    public class Ord_InfoL
    {
        #region help
        protected IDbHelp curHelp;

        public Ord_InfoL()
        {
            this.curHelp = new DefaultHelp();
        }

        public Ord_InfoL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        #region 获取订单下的  产品总额
        /// <summary>
        /// 获取订单下的  产品总额
        /// </summary>
        /// <param name="pUserID"></param>
        /// <returns></returns>
        public double GetTotPrice(int pOrderID)
        {
            string sql = "select sum(TotalPrice) from Ord_Pro where FK_Order=" + pOrderID;
            return double.Parse(curHelp.First(sql, "0"));
        }
        #endregion

        #region 更新订单的 产品总价格
        /// <summary>
        /// 更新订单的 产品总价格
        /// </summary>
        public int EditOrdTotPrice(int pOrderID)
        {
            string strSQL = "update Ord_Info set TotalPrice=@TotalPrice where OrdSN=" + pOrderID;
            double TotlePrice = GetTotPrice(pOrderID);

            IDataParameter[] dp = { 
                                      DbHelp.Def.AddParam("@TotalPrice", TotlePrice),
                                  };

            return curHelp.Update(strSQL, dp);
        }
        #endregion

        #region 添加订单
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="pMod"></param>
        /// <returns>返回订单编号</returns>
        //private int Add(Ord_InfoM pMod)
        //{
        //    //string sql = "FK_Pay,PayType,OrdNumber,FK_User,Caption,FixTel,Tel,Address,RealName,UserName,TotalPrice,Status,StatusPay,Area,AreaTime,ToMinTime,ToMaxTime,FK_AdminUser_PeiSong,FK_AdminUser_ChuKu";

        //    //string sql = "insert into Ord_Info(FK_Pay,PayType,OrdNumber,FK_User,UserName,RealName,FixTel,Tel,Area,Address,TotalPrice,Status,StatusPay,Caption,AreaTime,ToMinTime,ToMaxTime,FK_AdminUser_PeiSong,FK_AdminUser_ChuKu,UserType,UserLevel) values(@FK_Pay,@PayType,@OrdNumber,@FK_User,@UserName,@RealName,@FixTel,@Tel,@Area,@Address,@TotalPrice,@Status,@StatusPay,@Caption,@AreaTime,@ToMinTime,@ToMaxTime,@FK_AdminUser_PeiSong,@FK_AdminUser_ChuKu,@UserType,@UserLevel);select SCOPE_IDENTITY()";

        //    //IDataParameter[] dp = { 
        //    //                    DbHelp.Def.AddParam("@FK_Pay",pMod.FK_Pay),
        //    //                    DbHelp.Def.AddParam("@PayType",pMod.PayType),
        //    //                    DbHelp.Def.AddParam("@OrdNumber",pMod.OrdNumber),
        //    //                    DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
        //    //                    DbHelp.Def.AddParam("@UserName",pMod.UserName),
        //    //                    DbHelp.Def.AddParam("@RealName",pMod.RealName),
        //    //                    DbHelp.Def.AddParam("@FixTel",pMod.FixTel),
        //    //                    DbHelp.Def.AddParam("@Tel",pMod.Tel),
        //    //                    DbHelp.Def.AddParam("@Area",pMod.Area),
        //    //                    DbHelp.Def.AddParam("@Address",pMod.Address),
        //    //                    DbHelp.Def.AddParam("@TotalPrice",pMod.TotalPrice),
        //    //                    DbHelp.Def.AddParam("@Status",pMod.Status),
        //    //                    DbHelp.Def.AddParam("@StatusPay",pMod.StatusPay),
        //    //                    DbHelp.Def.AddParam("@Caption",pMod.Caption),
        //    //                    DbHelp.Def.AddParam("@AreaTime",pMod.AreaTime),
        //    //                    DbHelp.Def.AddParam("@ToMinTime",pMod.ToMinTime),
        //    //                    DbHelp.Def.AddParam("@ToMaxTime",pMod.ToMaxTime),
        //    //                    DbHelp.Def.AddParam("@FK_AdminUser_PeiSong",pMod.FK_AdminUser_PeiSong),
        //    //                    DbHelp.Def.AddParam("@FK_AdminUser_ChuKu",pMod.FK_AdminUser_ChuKu),
        //    //                    DbHelp.Def.AddParam("@UserType",pMod.UserType),
        //    //                    DbHelp.Def.AddParam("@UserLevel",pMod.UserLevel),
        //    //                      };

        //    //int ordId = int.Parse(curHelp.Scalar(sql, dp).ToString());// SqlData.AddReturnID(pMod, sql);// Convert.ToInt32(DbHelp.Scalar(sSQL, dp));

        //    SqlData1 sdata = new SqlData1(this.curHelp);
        //    string sql = "FK_Pay,PayType,OrdNumber,FK_User,UserName,RealName,FixTel,Tel,Area,Address,TotalPrice,Status,StatusPay,Caption,AreaTime,ToMinTime,ToMaxTime,FK_AdminUser_PeiSong,FK_AdminUser_ChuKu,UserType,UserLevel";

        //    int ordId = 0;
        //    try
        //    {
        //        ordId = sdata.AddReturnID(pMod, sql);
        //    }
        //    catch (Exception ex)
        //    {


        //    }

        //    if (ordId > 0)
        //    {
        //        string sRemark = "订单-创建:<ss>" + pMod.OrdNumber + "</ss>";

        //        Log_OrdM mod = new Log_OrdM();
        //        mod.FK_Ord = ordId;
        //        mod.FK_User = pMod.FK_User;
        //        mod.Operator = pMod.UserName;
        //        mod.Remark = sRemark;

        //        new Log_OrdL(this.curHelp).Add(mod);
        //    }

        //    return ordId;
        //}
        #endregion

        public class LS_TransM : DbHelp.ITransM
        {
            public Ord_InfoM Mod;
            public IList<Ord_ProM> IMod;
            public IMessage msgAjax;
        }

        public static int AddOrder_Trans(IDbHelp thelp, object obj)
        {
            LS_TransM tMod = (LS_TransM)obj;
            Ord_InfoM Mod = tMod.Mod;
            IList<Ord_ProM> IMod = tMod.IMod;
            IMessage msgAjax = tMod.msgAjax;

            SqlData1 sdata = new SqlData1(thelp);
            string sql = "UserIdentity,FK_Pay,PayType,OrdNumber,FK_User,UserName,RealName,FixTel,Tel,Area,Address,TotalPrice,Status,StatusPay,Caption,AreaTime,ToMinTime,ToMaxTime,FK_AdminUser_PeiSong,FK_AdminUser_ChuKu,UserType,UserLevel,UserCard";//添加订单

            if (User_InfoL.IsTeam(Mod.UserIdentity))//若是团体订购,则添加团体名称
            {
                sql = "UserIdentity,TeamName,FK_Pay,PayType,OrdNumber,FK_User,UserName,RealName,FixTel,Tel,Area,Address,TotalPrice,Status,StatusPay,Caption,AreaTime,ToMinTime,ToMaxTime,FK_AdminUser_PeiSong,FK_AdminUser_ChuKu,UserType,UserLevel,UserCard";//添加订单
            }

            //若有购物券
            if (Mod.Ticket_1_Number.Length > 0)
            {
                string sql_Act_1 = "update User_Ticket_1 set tic_Status=1,FK_User=" + Mod.FK_User + " where tic_Status=0 and tic_Number=@tic_Number";
                IDataParameter[] dp_Act1 = { 
                                       DbHelp.Def.AddParam("@tic_Number",Mod.Ticket_1_Number),
                                       };

                if (thelp.Update(sql_Act_1, dp_Act1) > 0)
                {
                    sql += ",Ticket_1_Number,Ticket_1_Price";

                    //总价减去抵金券金额
                    Mod.TotalPrice = Mod.TotalPrice - Mod.Ticket_1_Price;

                    //若总价格小于0 则设置为0
                    if (Mod.TotalPrice <= 0)
                    {
                        Mod.TotalPrice = 0;
                    }
                }
                else
                {
                    msgAjax.Error("抵金券号码错误3" + Mod.Ticket_1_Number);
                    return 0;
                }
            }

            int iOrdID = 0;
            try
            {
                iOrdID = sdata.AddReturnID(Mod, sql);
                if (iOrdID > 0)
                {
                    string sRemark = "订单-创建:<ss>" + Mod.OrdNumber + "</ss>";

                    Log_OrdM mod = new Log_OrdM();
                    mod.FK_Ord = iOrdID;
                    mod.FK_User = Mod.FK_User;
                    mod.Operator = Mod.UserName;
                    mod.Remark = sRemark;

                    if (!new Log_OrdL(thelp).Add(mod))
                    {
                        msgAjax.Error("err:2001");
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                msgAjax.Error(ex.Message);
                return 0;
            }

            if (iOrdID > 0)//若生成订单成功
            {
                foreach (Ord_ProM mod in IMod)
                {
                    //将添加好的OrdId 到订单产品列表
                    mod.FK_Order = iOrdID;
                    mod.op_ProLevel = Mod.UserType;
                }

                int addN = 0;//公添加了多少产品

                foreach (Ord_ProM mod_pro in IMod)
                {
                    string sql_Pro = "FK_Order,FK_Pro,FK_User,op_ProName,op_ProNumber,op_ProUnit,op_ProUnitNum,op_ProPrice,op_UserPrice,op_UserTotalPrice,op_Num,op_CurProStock,op_ActualNum,op_Status,op_ProLevel";//添加订单产品

                    string sql_1 = "FK_A_Admin_User,FK_Pro,np_ProNumber,np_ProUnit,np_ProUnitNum,np_ProName,np_Num,np_CurProStock,np_Status,np_Type,np_ProLevel";//添加采购任务
                    E_NeedPurchaseM mod_1 = new E_NeedPurchaseM();
                    mod_1.FK_A_Admin_User = 0;
                    mod_1.FK_Pro = mod_pro.FK_Pro;
                    mod_1.np_ProName = mod_pro.op_ProName;
                    mod_1.np_ProNumber = mod_pro.op_ProNumber;
                    mod_1.np_ProUnit = mod_pro.op_ProUnit;
                    mod_1.np_ProUnitNum = mod_pro.op_ProUnitNum;
                    mod_1.np_CurProStock = mod_pro.op_CurProStock;
                    mod_1.np_Num = mod_pro.op_Num;
                    mod_1.np_Status = 0;//未入库
                    mod_1.np_Type = 0;//前台提交
                    mod_1.np_ProLevel = mod_pro.op_ProLevel;

                    string sql_2 = "if exists(select top 1 1 from E_BookPro where FK_Pro=@FK_Pro)"
                        + " begin update E_BookPro set bp_Num=bp_Num+@bp_Num where FK_Pro=@FK_Pro end"
                        + " else"
                        + " begin insert into E_BookPro(FK_A_Admin_User,FK_Pro,bp_ProNumber,bp_ProUnit,bp_ProUnitNum,bp_ProName,bp_Num) values(@FK_A_Admin_User,@FK_Pro,@bp_ProNumber,@bp_ProUnit,@bp_ProUnitNum,@bp_ProName,@bp_Num) end";//总预订产品

                    IDataParameter[] dp_2 = { 
                                            DbHelp.Def.AddParam("@FK_A_Admin_User",0),
                                            DbHelp.Def.AddParam("@FK_Pro",mod_pro.FK_Pro),
                                            DbHelp.Def.AddParam("@bp_ProNumber",mod_pro.op_ProNumber),
                                            DbHelp.Def.AddParam("@bp_ProName",mod_pro.op_ProName),
                                            DbHelp.Def.AddParam("@bp_ProUnit",mod_pro.op_ProUnit),
                                            DbHelp.Def.AddParam("@bp_ProUnitNum",mod_pro.op_ProUnitNum),
                                            DbHelp.Def.AddParam("@bp_Num",mod_pro.op_Num),
                                            };

                    try
                    {
                        if (sdata.Add(mod_pro, sql_Pro)
                         && sdata.Add(mod_1, sql_1)
                         && (thelp.Update(sql_2, dp_2) > 0)
                            )
                        {
                            addN++;
                        }
                    }
                    catch (Exception ex)
                    {
                        msgAjax.Error(ex.Message + mod_pro.FK_Pro);
                        return 0;
                    }
                }

                //若添加的产品 等于 购物车的产品数量(即全部产品添加完毕)
                if (addN == IMod.Count)
                {
                    //清空购物车产品
                    new User_CartL(thelp).DeleteAll(Mod.FK_User);

                    //若选择预存支付 则冻结金额
                    if (Mod.PayType == "yck")
                    {
                        string setF = new User_InfoL(thelp).SetFreezeMoney(Mod.FK_User, Mod.TotalPrice, Mod.UserName, "订单-创建:<ss>" + Mod.OrdNumber + "</ss>", Fn.SCNumber());
                        if (setF != "1")
                        {
                            msgAjax.Error(setF);
                            return 0;
                        }
                    }

                    msgAjax.AddMessage("jumpurl", "orderComplete.aspx?id=" + iOrdID);
                    msgAjax.Success("提交成功");
                    return 1;
                }
                else
                {
                    msgAjax.Error("提交失败,共有" + IMod.Count + "个产品，但只提交了" + addN + "产品");
                    return 0;
                }
            }
            else
            {
                msgAjax.Error("订单未能提交,重试一下");
                return 0;
            }
        }
    }
}

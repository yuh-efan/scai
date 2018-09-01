using System;
using System.Collections.Generic;
using System.Text;
using WZ.Model;
using System.Data;
using WZ.Common;
using System.Web;
using WZ.Data;
using WZ.Common.Config;

namespace WZ.Client.Data
{
    public class Ord_Info
    {
        #region help
        protected IDbHelp curHelp;

        public Ord_Info()
        {
            this.curHelp = new DefaultHelp();
        }

        public Ord_Info(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="pMod"></param>
        /// <returns>返回订单编号</returns>
        //public int Add(Ord_InfoM pMod)
        //{
        //    //string sql = "FK_Pay,PayType,OrdNumber,FK_User,Caption,FixTel,Tel,Address,RealName,UserName,TotalPrice,Status,StatusPay,Area,AreaTime,ToMinTime,ToMaxTime,FK_AdminUser_PeiSong,FK_AdminUser_ChuKu";

        //    string sql = "insert into Ord_Info(FK_Pay,PayType,OrdNumber,FK_User,UserName,RealName,FixTel,Tel,Area,Address,TotalPrice,Status,StatusPay,Caption,AreaTime,ToMinTime,ToMaxTime,FK_AdminUser_PeiSong,FK_AdminUser_ChuKu,UserType,UserLevel) values(@FK_Pay,@PayType,@OrdNumber,@FK_User,@UserName,@RealName,@FixTel,@Tel,@Area,@Address,@TotalPrice,@Status,@StatusPay,@Caption,@AreaTime,@ToMinTime,@ToMaxTime,@FK_AdminUser_PeiSong,@FK_AdminUser_ChuKu,@UserType,@UserLevel);select SCOPE_IDENTITY()";

        //    IDataParameter[] dp = { 
        //                        DbHelp.Def.AddParam("@FK_Pay",pMod.FK_Pay),
        //                        DbHelp.Def.AddParam("@PayType",pMod.PayType),
        //                        DbHelp.Def.AddParam("@OrdNumber",pMod.OrdNumber),
        //                        DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
        //                        DbHelp.Def.AddParam("@UserName",pMod.UserName),
        //                        DbHelp.Def.AddParam("@RealName",pMod.RealName),
        //                        DbHelp.Def.AddParam("@FixTel",pMod.FixTel),
        //                        DbHelp.Def.AddParam("@Tel",pMod.Tel),
        //                        DbHelp.Def.AddParam("@Area",pMod.Area),
        //                        DbHelp.Def.AddParam("@Address",pMod.Address),
        //                        DbHelp.Def.AddParam("@TotalPrice",pMod.TotalPrice),
        //                        DbHelp.Def.AddParam("@Status",pMod.Status),
        //                        DbHelp.Def.AddParam("@StatusPay",pMod.StatusPay),
        //                        DbHelp.Def.AddParam("@Caption",pMod.Caption),
        //                        DbHelp.Def.AddParam("@AreaTime",pMod.AreaTime),
        //                        DbHelp.Def.AddParam("@ToMinTime",pMod.ToMinTime),
        //                        DbHelp.Def.AddParam("@ToMaxTime",pMod.ToMaxTime),
        //                        DbHelp.Def.AddParam("@FK_AdminUser_PeiSong",pMod.FK_AdminUser_PeiSong),
        //                        DbHelp.Def.AddParam("@FK_AdminUser_ChuKu",pMod.FK_AdminUser_ChuKu),
        //                        DbHelp.Def.AddParam("@UserType",pMod.UserType),
        //                        DbHelp.Def.AddParam("@UserLevel",pMod.UserLevel),
        //                          };

        //    int ordId = int.Parse(curHelp.Scalar(sql, dp).ToString());// SqlData.AddReturnID(pMod, sql);// Convert.ToInt32(DbHelp.Scalar(sSQL, dp));
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

        public static Paging List(int pUserId, string pType)
        {
            string sOrder = " order by AddDate desc";
            string sWhere = " where FK_User=" + pUserId;
            //PubEnum.Ord_Status 已退款 = PubEnum.Ord_Status.已退款;

            //PubEnum.Ord_Status 作废 = PubEnum.Ord_Status.作废;
            int 已完成 = 50;
            int 已取消 = 20;
            switch (pType)
            {
                case "finish":
                    sWhere += string.Format(" and (Status={0} or Status={1})", 已完成, 已取消);
                    break;

                case "ongoing":
                    sWhere += string.Format(" and (Status<>{0} and Status<>{1})", 已完成, 已取消);
                    break;

                default:
                    break;
            }

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0) from Ord_Info" + sWhere;
            pv.SQLRead = "select OrdSN from Ord_Info" + sWhere + sOrder;
            pv.SQL = "select OrdSN,OrdNumber,TotalPrice,Status,StatusPay,AddDate,ToMinTime from Ord_Info where OrdSN in({0})" + sOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(10));
            pg.load();
            return pg;
        }
    }
}

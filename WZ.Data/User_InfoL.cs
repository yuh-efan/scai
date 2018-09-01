using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;
using System.Data;
using WZ.Model;
using WZ.Common.Config;
using System.Net.Mail;
using WZ.Common.EMail;

namespace WZ.Data
{
    public class User_InfoL
    {
        #region help
        protected IDbHelp curHelp;

        public User_InfoL()
        {
            this.curHelp = new DefaultHelp();
        }

        public User_InfoL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        #region 设置 冻结/解冻金额
        /// <summary>
        /// 设置 冻结/解冻金额
        /// </summary>
        /// <param name="pUserID"></param>
        /// <param name="pMoney"></param>
        /// <param name="pRemark">备注</param>
        /// <returns></returns>
        public string SetFreezeMoney(int pUserID, double pMoney, string pOperator, string pRemark, string pNumber)
        {
            if (pMoney == 0)
            {
                return "1";
            }

            string sWhere = string.Empty;
            if (pMoney > 0)
                sWhere = " where UserSN={1} and UserMoney>=(UserFreezeMoney+{0})";//冻结时不能超过会员的预存款
            else
                sWhere = " where UserSN={1} and UserFreezeMoney+{0}>=0";//解冻时不能超过已冻结的金额

            string sSQL = string.Format("update User_Info set UserFreezeMoney=UserFreezeMoney+{0}" + sWhere, pMoney, pUserID);

            if (curHelp.Update(sSQL) > 0)
            {
                Log_SetUserFreezeMoneyM freMod = new Log_SetUserFreezeMoneyM();
                freMod.FK_User = pUserID;
                freMod.Number = pNumber;
                freMod.Operator = pOperator;
                freMod.SetFreezeMoney = pMoney;
                freMod.Remark = pRemark;

                if (new Log_SetUserFreezeMoneyL(this.curHelp).Add(freMod))
                    return "1";
                else
                    return "设置冻结金额成功,但日志添加失败";//设置冻结金额成功,但日志添加失败
            }
            else
                return "解冻金额 设置失败";//冻结/解冻金额 设置失败
        }
        #endregion

        #region 设置 预存款
        /// <summary>
        /// 设置 预存款
        /// </summary>
        /// <param name="pUserID"></param>
        /// <param name="pMoney"></param>
        /// <param name="pRemark"></param>
        public string SetUserMoney(int pUserID, double pMoney, string pOperator, string pRemark, string pNumber)
        {
            if (pMoney == 0)
            {
                return "1";
            }

            string sWhere = string.Empty;
            if (pMoney > 0)
                sWhere = "where UserSN={1}";
            else
                sWhere = "where UserSN={1} and UserMoney+{0}>=0";//扣除预存款时不能超过他本身

            string sSQL = string.Format("update User_Info set UserMoney=UserMoney+{0}" + sWhere, pMoney, pUserID);

            if (curHelp.Update(sSQL) > 0)
            {
                Log_SetUserMoneyM mod = new Log_SetUserMoneyM();
                mod.FK_User = pUserID;
                mod.Number = pNumber;
                mod.Operator = pOperator;
                mod.SetMoney = pMoney;
                mod.Remark = pRemark;

                if (new Log_SetUserMoneyL(this.curHelp).Add(mod))
                    return "1";
                else
                    return "设置预存款成功,但日志添加失败";
            }
            else
                return "预存款 设置失败";
        }
        #endregion

        #region 用户已付款
        /// <summary>
        /// 用户已付款
        /// </summary>
        /// <param name="pUserID"></param>
        /// <param name="pMoney"></param>
        /// <param name="pRemark"></param>
        public string UserPay(int pUserID, double pMoney, string pOperator, string pRemark, string pNumber)
        {
            if (pMoney == 0)
            {
                return "1";
            }

            if (pMoney > 0)
            {
                return "设置付款,金额应是负数";
            }

            string sSQL = string.Format("update User_Info set UserMoney=UserMoney+{0},UserFreezeMoney=UserFreezeMoney+{0} where UserSN={1} and UserMoney+{0}>=0 and UserFreezeMoney+{0}>=0", pMoney, pUserID);

            if (curHelp.Update(sSQL) > 0)
            {
                string sMsg = string.Empty;

                //添加 冻结金额日志
                Log_SetUserFreezeMoneyM freMod = new Log_SetUserFreezeMoneyM();
                freMod.FK_User = pUserID;
                freMod.Number = pNumber;
                freMod.Operator = pOperator;
                freMod.SetFreezeMoney = pMoney;
                freMod.Remark = pRemark;
                if (!(new Log_SetUserFreezeMoneyL(this.curHelp).Add(freMod)))
                    return "设置冻结金额成功,但日志添加失败";

                //添加 预存款日志
                Log_SetUserMoneyM mod = new Log_SetUserMoneyM();
                mod.FK_User = pUserID;
                mod.Number = pNumber;
                mod.Operator = pOperator;
                mod.SetMoney = pMoney;
                mod.Remark = pRemark;
                if (new Log_SetUserMoneyL(this.curHelp).Add(mod))
                    return "1";
                else
                    return "设置预存款成功,但日志添加失败";
            }
            else
                return "会员预存款不足 或 解冻金额超出范围";
        }
        #endregion

        #region 设置会员积分
        /// <summary>
        /// 设置会员积分
        /// </summary>
        /// <param name="pUserId"></param>
        /// <param name="pIntegral"></param>
        /// <returns></returns>
        public string SetUserIntegral(int pUserID, int pFK_All, string pIdentifier, int pIntegral, string pOperator, string pRemark)
        {
            string sWhere = string.Empty;
            if (pIntegral > 0)
                sWhere = "where UserSN={1}";
            else
                sWhere = "where UserSN={1} and UserIntegral+{0}>=0";//扣除积分时不能超过他本身

            string sSQL = string.Format("update User_Info set UserIntegral=UserIntegral+{0}" + sWhere, pIntegral, pUserID);

            if (curHelp.Update(sSQL) > 0)
            {
                Log_SetUserIntegralM mod = new Log_SetUserIntegralM();
                mod.FK_User = pUserID;
                mod.FK_All = pFK_All;
                mod.Operator = pOperator;
                mod.SetValue = pIntegral;
                mod.Remark = pRemark;
                mod.Fract_Identifier = pIdentifier;

                if (new Log_SetUserIntegralL(this.curHelp).Add(mod))
                {
                    if (pIntegral < 0)
                    {
                        string sql = "update User_Info set UserConsumeIntegral=UserConsumeIntegral+" + (-pIntegral) + " where UserSN=" + pUserID;
                        if (this.curHelp.Update(sql) > 0)
                        {
                            //成功
                        }
                        else
                        {
                            return "消耗积分设置失败";
                        }
                    }

                    //成功
                }
                else
                {
                    return "设置积分成功,但日志添加失败";
                }
            }
            else
            {
                return "会员积分 设置失败";
            }

            return "1";
        }
        #endregion

        #region 设置会员经验
        /// <summary>
        /// 设置会员经验
        /// </summary>
        /// <param name="pUserId"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public string SetUserExp(int pUserID, int pFK_All, string pIdentifier, int pValue, string pOperator, string pRemark)
        {
            string sWhere = string.Empty;
            if (pValue > 0)
                sWhere = "where UserSN={1}";
            else
                sWhere = "where UserSN={1} and UserExp+{0}>=0";//扣除经验时不能超过他本身

            string sSQL = string.Format("update User_Info set UserExp=UserExp+{0}" + sWhere, pValue, pUserID);

            if (curHelp.Update(sSQL) > 0)
            {
                Log_SetUserExpM mod = new Log_SetUserExpM();
                mod.FK_User = pUserID;
                mod.FK_All = pFK_All;
                mod.Operator = pOperator;
                mod.SetValue = pValue;
                mod.Remark = pRemark;
                mod.Fract_Identifier = pIdentifier;

                if (new Log_SetUserExpL(this.curHelp).Add(mod))
                {
                    string slog = Upgrade(pUserID);
                    if (slog != "1" && slog != "2")
                    {
                        return slog;
                    }

                    return "1";
                }
                else
                    return "设置经验成功,但日志添加失败";
            }
            else
                return "会员经验 设置失败";
        }
        #endregion

        #region 设置会员等级
        /// <summary>
        /// 设置会员等级
        /// </summary>
        /// <param name="pUserId"></param>
        /// <param name="pLevel"></param>
        public string SetUserLevel(int pUserID, int pLevel, string pOperator, string pRemark)
        {
            string sSQL = "update User_Info set FK_User_Level=" + pLevel + " where UserSN=" + pUserID;
            if (curHelp.Update(sSQL) > 0)
            {
                Log_SetUserLevelM mod = new Log_SetUserLevelM();
                mod.FK_User = pUserID;
                mod.Operator = pOperator;
                mod.SetLevel = pLevel;
                mod.Remark = pRemark;

                if (new Log_SetUserLevelL(this.curHelp).Add(mod))
                    return "1";
                else
                    return "设置等级成功,但日志添加失败";
            }
            else
                return "会员等级 设置失败";
        }
        #endregion

        //以下static

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pUserPwd"></param>
        /// <param name="pSN"></param>
        /// <returns></returns>
        public static bool EditPwd(string pUserName, string pUserPwd, int pUserID)
        {
            string sSQL = "update User_Info set UserPwd=@UserPwd where UserName=@UserName and UserSN=" + pUserID;
            IDataParameter[] dp = { 
                                    DbHelp.Def.AddParam("@UserName",pUserName),
                                    DbHelp.Def.AddParam("@UserPwd",Fn.MD5(pUserPwd))
                                   };
            return (DbHelp.Update(sSQL, dp) > 0);
        }

        public static bool EditPwd(string pUserName, string pOldPwd, string pNewPwd, int pUserID)
        {
            string sSQL = "update User_Info set UserPwd=@NewPwd where UserSN=@UserSN and UserName=@UserName and UserPwd=@OldPwd";
            IDataParameter[] dp = { 
                                    DbHelp.Def.AddParam("@NewPwd",Fn.MD5(pNewPwd)),
                                    DbHelp.Def.AddParam("@UserSN",pUserID),
                                    DbHelp.Def.AddParam("@UserName",pUserName),
                                    DbHelp.Def.AddParam("@OldPwd",Fn.MD5(pOldPwd)),
                                   };
            return (DbHelp.Update(sSQL, dp) > 0);
        }
        #endregion

        #region 获取 可用预存款
        /// <summary>
        /// 获取 可用预存款
        /// </summary>
        /// <param name="pUserId"></param>
        /// <returns></returns>
        public static DataTable GetUserCanMoney(int pUserId)
        {
            string sSQL = "select UserMoney,UserFreezeMoney," + SQL_UserCanMoney() + " from User_Info where UserSN=" + pUserId;
            return DbHelp.GetDataTable(sSQL);
        }

        public static string SQL_UserCanMoney()
        {
            return "(UserMoney - UserFreezeMoney) as UserCanMoney";
        }

        public static string SQL_UserLJPersonal()
        {
            return "from User_Info ui left join User_Personal pi on ui.UserSN=pi.FK_User";
        }

        public static string SQL_UserLJTeam()
        {
            return "from User_Info ui left join User_Team ut on ui.UserSN=ut.FK_User";
        }
        #endregion

        #region 判断用户是否存在
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="pUserName"></param>
        /// <returns></returns>
        public static bool IsUserName(string pUserName)
        {
            if (pUserName.Length > Constant.MaxCount_UserName)
                pUserName = pUserName.Substring(0, Constant.MaxCount_UserName);

            string sSQL = "select top 1 1 from User_Info where UserName=@UserName";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@UserName",pUserName)
                                  };

            bool b = false;
            using (IDataReader dr = DbHelp.Read(sSQL, dp))
            {
                if (dr.Read())
                    b = true;
            }

            return b;
        }

        public static bool IsEmail(string pEmail)
        {
            if (pEmail.Length > Constant.MaxCount_Email)
                pEmail = pEmail.Substring(0, Constant.MaxCount_Email);

            string sSQL = "select top 1 1 from User_Info where Email=@Email";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@Email",pEmail)
                                  };

            bool b = false;
            using (IDataReader dr = DbHelp.Read(sSQL, dp))
            {
                if (dr.Read())
                    b = true;
            }

            return b;
        }

        public static bool IsEmailEdit(string pEmail, int pUserID)
        {
            if (pEmail.Length > Constant.MaxCount_Email)
                pEmail = pEmail.Substring(0, Constant.MaxCount_Email);

            string sSQL = "select top 1 1 from User_Info where Email=@Email and UserSN<>" + pUserID;
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@Email",pEmail)
                                  };

            bool b = false;
            using (IDataReader dr = DbHelp.Read(sSQL, dp))
            {
                if (dr.Read())
                    b = true;
            }

            return b;
        }

        public bool IsUserCard(string pNumber)
        {
            string sSQL = "select top 1 1 from User_Info where UserCard=@UserCard";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@UserCard",pNumber)
                                  };

            bool b = false;
            using (IDataReader dr = this.curHelp.Read(sSQL, dp))
            {
                if (dr.Read())
                    b = true;
            }

            return b;
        }
        #endregion

        #region 用户注册 无配送信息
        public class Reg_TransM : DbHelp.ITransM
        {
            public User_InfoM infoMod;
            public User_PersonalM perMod;
            public bool IsUseCard = false;
            public int Exp = 0;
        }

        public static int Reg_Trans(IDbHelp tHelp, object obj)
        {
            Reg_TransM lsTrans = (Reg_TransM)obj;
            User_InfoM infoMod = lsTrans.infoMod;
            User_PersonalM perMod = lsTrans.perMod;

            if (lsTrans.IsUseCard)
            {
                if (new User_InfoL(tHelp).IsUserCard(infoMod.UserCard))
                {
                    lsTrans.returnValue = "此会员卡卡号已被人注册";
                    return 0;
                }
            }

            string sql = "insert into User_Info(FK_User_Level,UserName,UserPwd,OpenIdentity,Email,UserCard,UserBTJ) values(@FK_User_Level,@UserName,@UserPwd,@OpenIdentity,@Email,@UserCard,@UserBTJ);select SCOPE_IDENTITY()";

            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@FK_User_Level",infoMod.FK_User_Level),
                                  DbHelp.Def.AddParam("@UserName",infoMod.UserName),
                                  DbHelp.Def.AddParam("@UserPwd",infoMod.UserPwd),
                                  DbHelp.Def.AddParam("@OpenIdentity",infoMod.OpenIdentity),
                                  DbHelp.Def.AddParam("@Email",infoMod.Email),
                                  DbHelp.Def.AddParam("@UserCard",infoMod.UserCard),
                                  DbHelp.Def.AddParam("@UserBTJ",infoMod.UserBTJ),
                                  };

            //User_Info
            int uid = int.Parse(tHelp.First(sql, dp, "0").ToString());
            if (uid <= 0)
            {
                lsTrans.returnValue = "注册失败1";
                return 0;
            }

            sql = "insert into User_Personal(FK_User) values(@FK_User)";
            IDataParameter[] dp1 = { 
                                  DbHelp.Def.AddParam("@FK_User",uid),
                                       };
            //User_Personal
            if (tHelp.Update(sql, dp1) <= 0)
            {
                lsTrans.returnValue = "注册失败";
                return 0;
            }

            User_FractHandler.FractHandlerParam ufParam = new User_FractHandler.FractHandlerParam(uid, "system", 1, "reg", "reg", "注册成功 \"" + infoMod.UserName + "\"");
            string slog = new User_FractHandler(tHelp).SetFract(ufParam);
            if (slog != "1")
            {
                lsTrans.returnValue = slog;
                return 0;
            }

            //是否使用会员卡
            if (lsTrans.IsUseCard)
            {
                //设置会员卡状态
                sql = "update User_Card set FK_User=@FK_User,card_Status=1 where card_Number=@card_Number";
                IDataParameter[] dp_usercard = { 
                                  DbHelp.Def.AddParam("@FK_User",uid),
                                  DbHelp.Def.AddParam("@card_Number",infoMod.UserCard),
                                       };
                if (tHelp.Update(sql, dp_usercard) <= 0)
                {
                    lsTrans.returnValue = "注册失败2";
                    return 0;
                }

                //赠送经验
                slog = new User_InfoL(tHelp).SetUserExp(uid, uid, "reg_card", lsTrans.Exp, "system", "注册使用会员卡 \"" + infoMod.UserCard + "\" 赠送" + lsTrans.Exp + "经验");
                if (slog != "1")
                {
                    lsTrans.returnValue = slog;
                    return 0;
                }
            }

            lsTrans.returnValue = "1";
            return 1;
        }
        #endregion

        #region 用户注册 有配送信息
        public class Reg1_TransM : DbHelp.ITransM
        {
            public User_InfoM infoMod;
            public User_PersonalM perMod;
            public User_ContactM conMod;

            public bool IsUseCard = false;
            public int Exp = 0;
        }

        public static int Reg1_Trans(IDbHelp tHelp, object obj)
        {
            Reg1_TransM lsTrans = (Reg1_TransM)obj;
            User_InfoM infoMod = lsTrans.infoMod;
            User_PersonalM perMod = lsTrans.perMod;
            User_ContactM conMod = lsTrans.conMod;

            if (lsTrans.IsUseCard)
            {
                if (new User_InfoL(tHelp).IsUserCard(infoMod.UserCard))
                {
                    lsTrans.returnValue = "此会员卡卡号已被人注册";
                    return 0;
                }
            }

            string sql = "insert into User_Info(FK_User_Level,UserName,UserPwd,OpenIdentity,Email,UserCard,UserBTJ) values(@FK_User_Level,@UserName,@UserPwd,@OpenIdentity,@Email,@UserCard,@UserBTJ);select SCOPE_IDENTITY()";

            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@FK_User_Level",infoMod.FK_User_Level),
                                  DbHelp.Def.AddParam("@UserName",infoMod.UserName),
                                  DbHelp.Def.AddParam("@UserPwd",infoMod.UserPwd),
                                  DbHelp.Def.AddParam("@OpenIdentity",infoMod.OpenIdentity),
                                  DbHelp.Def.AddParam("@Email",infoMod.Email),
                                  DbHelp.Def.AddParam("@UserCard",infoMod.UserCard),
                                  DbHelp.Def.AddParam("@UserBTJ",infoMod.UserBTJ),
                                  };

            int uid = int.Parse(tHelp.First(sql, dp, "0").ToString());
            //try
            //{
            //uid = int.Parse(tHelp.First(sql, dp, "0").ToString());
            //}
            //catch (Exception ex)
            //{
            //    lsTrans.returnValue = "注册失败:" + ex.Message;
            //    return 0;
            //}

            if (uid <= 0)
            {
                lsTrans.returnValue = "注册失败2";
                return 0;
            }

            sql = "insert into User_Personal(FK_User,RealName,Sex,Area,Address,Tel,FixTel) values(@FK_User,@RealName,@Sex,@Area,@Address,@Tel,@FixTel)";
            IDataParameter[] dp1 = { 
                                    DbHelp.Def.AddParam("@FK_User",uid),
                                    DbHelp.Def.AddParam("@RealName",perMod.RealName),
                                    DbHelp.Def.AddParam("@Sex",perMod.Sex),
                                    DbHelp.Def.AddParam("@Area",perMod.Area),
                                    DbHelp.Def.AddParam("@Address",perMod.Address),
                                    DbHelp.Def.AddParam("@Tel",perMod.Tel),
                                    DbHelp.Def.AddParam("@FixTel",perMod.FixTel),
                                       };
            //User_Personal
            if (tHelp.Update(sql, dp1) <= 0)
            {
                lsTrans.returnValue = "注册失败1";
                return 0;
            }

            //是否添加收货地址
            if (conMod.Name.Length > 0 && conMod.Address.Length > 0 && (conMod.Tel.Length > 0 || conMod.FixTel.Length > 0) && conMod.FK_Area > 0)
            {
                User_ContactL uc = new User_ContactL(tHelp);
                conMod.FK_User = uid;
                string sMsg = string.Empty;

                if (uc.Add(conMod, ref sMsg))//添加收货地址
                {
                }
                else
                {
                    lsTrans.returnValue = "注册失败:" + sMsg;
                    return 0;
                }
            }

            //if (uid > 0)//账号添加成功
            //{
            //    //sql = "insert into User_Personal(FK_User,RealName,Sex,Area,Address,Tel,FixTel) values(@FK_User,@RealName,@Sex,@Area,@Address,@Tel,@FixTel)";

            //    //IDataParameter[] dp1 = { 
            //    //                    DbHelp.Def.AddParam("@FK_User",uid),
            //    //                    DbHelp.Def.AddParam("@RealName",perMod.RealName),
            //    //                    DbHelp.Def.AddParam("@Sex",perMod.Sex),
            //    //                    DbHelp.Def.AddParam("@Area",perMod.Area),
            //    //                    DbHelp.Def.AddParam("@Address",perMod.Address),
            //    //                    DbHelp.Def.AddParam("@Tel",perMod.Tel),
            //    //                    DbHelp.Def.AddParam("@FixTel",perMod.FixTel),
            //    //                       };

            //    //bool isUser_Personal;
            //    //try
            //    //{
            //    //    isUser_Personal = tHelp.Update(sql, dp1) > 0;
            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    lsTrans.returnValue = "注册失败:" + ex.Message;
            //    //    return 0;
            //    //}

            //    if (isUser_Personal)//个人用户信息添加成功
            //    {
            //        //是否添加收货地址

            //        //if (conMod.Name.Length > 0 && conMod.Address.Length > 0 && (conMod.Tel.Length > 0 || conMod.FixTel.Length > 0) && conMod.FK_Area > 0)
            //        //{
            //        //    User_ContactL uc = new User_ContactL(tHelp);
            //        //    conMod.FK_User = uid;
            //        //    string sMsg = string.Empty;

            //        //    if (uc.Add(conMod, ref sMsg))//添加收货地址
            //        //    {
            //        //    }
            //        //    else
            //        //    {
            //        //        lsTrans.returnValue = "注册失败:" + sMsg;
            //        //        return 0;
            //        //    }
            //        //}
            //        //else
            //        //{
            //        //}
            //    }
            //    else
            //    {
            //        //lsTrans.returnValue = "注册失败1";
            //        //return 0;
            //    }
            //}
            //else
            //{
            //    //lsTrans.returnValue = "注册失败2";
            //    //return 0;
            //}

            //增加积分或经验
            User_FractHandler.FractHandlerParam ufParam = new User_FractHandler.FractHandlerParam(uid, "system", 1, "reg", "reg", "注册成功 \"" + infoMod.UserName + "\"");
            string slog = new User_FractHandler(tHelp).SetFract(ufParam);
            if (slog != "1")
            {
                lsTrans.returnValue = slog;
                return 0;
            }

            //是否使用会员卡
            if (lsTrans.IsUseCard)
            {
                //设置会员卡状态
                sql = "update User_Card set FK_User=@FK_User,card_Status=1 where card_Number=@card_Number";
                IDataParameter[] dp_usercard = { 
                                  DbHelp.Def.AddParam("@FK_User",uid),
                                  DbHelp.Def.AddParam("@card_Number",infoMod.UserCard),
                                       };
                if (tHelp.Update(sql, dp_usercard) <= 0)
                {
                    lsTrans.returnValue = "注册失败2";
                    return 0;
                }

                slog = new User_InfoL(tHelp).SetUserExp(uid, uid, "reg_card", lsTrans.Exp, "system", "注册使用会员卡 \"" + infoMod.UserCard + "\" 赠送" + lsTrans.Exp + "经验");
                if (slog != "1")
                {
                    lsTrans.returnValue = slog;
                    return 0;
                }
            }

            lsTrans.returnValue = "1";
            return 1;
        }
        #endregion

        #region 获取个人用户某字段内容
        /// <summary>
        /// 获取用户主表某字段内容
        /// </summary>
        /// <param name="pUserID"></param>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public static string GetUserField_Info(int pUserID, string pFieldName)
        {
            string sql = "select " + pFieldName + " from User_Info where UserSN=" + pUserID;
            return DbHelp.First(sql);
        }

        /// <summary>
        /// 获取个人用户某字段内容
        /// </summary>
        /// <param name="pUserID"></param>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public static string GetUserField_Personal(int pUserID, string pFieldName)
        {
            string sql = "select " + pFieldName + " from User_Personal where FK_User=" + pUserID;
            return DbHelp.First(sql);
        }
        #endregion

        #region 获取团体用户某字段内容
        /// <summary>
        /// 获取团体用户某字段内容
        /// </summary>
        /// <param name="pUserID"></param>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public static string GetUserField_Team(int pUserID, string pFieldName)
        {
            string sql = "select " + pFieldName + " from User_Team where FK_User=" + pUserID;
            return DbHelp.First(sql);
        }
        #endregion

        #region 经验升级
        /// <summary>
        /// 经验升级
        /// </summary>
        /// <returns></returns>
        public string Upgrade(int pUserID)
        {
            string sql = "select top 1 LevelSN from User_Level where LevelExp<=(select UserExp from User_Info where UserSN=" + pUserID + ") order by LevelSN desc";
            int nextLevel = int.Parse(this.curHelp.First(sql, "-1"));

            if (nextLevel > 0)
            {
                return this.SetUserLevel(pUserID, nextLevel, "system", "升级 到" + nextLevel);
            }
            else
            {
                return "2";
            }
        }
        #endregion

        #region 默认邮件发送
        /// <summary>
        /// 默认邮件发送
        /// </summary>
        /// <param name="pToAddress">接收方地址</param>
        /// <param name="sTitle">标题</param>
        /// <param name="sText">内容</param>
        public static void SendEmail(string pToAddress, string sTitle, string sText)
        {
            MailAddress mailFrom = new MailAddress(EmailInfo.eInfo.SelfAddress, EmailInfo.eInfo.SelfName);
            MailAddress mailTo = new MailAddress(pToAddress);

            MailParam param = new MailParam(EmailInfo.eInfo.SelfServer, mailFrom, EmailInfo.eInfo.SelfPwd, mailTo, sTitle, sText, null);
            param.SmtpPort = EmailInfo.eInfo.Port;
            param.EnableSsl = EmailInfo.eInfo.EnableSsl;

            MailHandler mh = new MailHandler();
            mh.SendSmtpEMail(param);
        }
        #endregion

        #region 判断身份
        /// <summary>
        /// 判断身份 是否是个人
        /// </summary>
        /// <param name="pUserIdentity">用户身份标识</param>
        /// <returns></returns>
        public static bool IsPersonal(int pUserIdentity)
        {
            return (pUserIdentity & 1) == 1;
        }

        /// <summary>
        /// 判断身份 是否是店铺
        /// </summary>
        /// <param name="pUserIdentity">用户身份标识</param>
        /// <returns></returns>
        public static bool IsShop(int pUserIdentity)
        {
            return (pUserIdentity & 2) == 2;
        }

        /// <summary>
        /// 判断身份 是否是推广员
        /// </summary>
        /// <param name="pUserIdentity">用户身份标识</param>
        /// <returns></returns>
        public static bool IsPromoter(int pUserIdentity)
        {
            return (pUserIdentity & 4) == 4;
        }

        /// <summary>
        /// 判断身份 是否是团体
        /// </summary>
        /// <param name="pUserIdentity">用户身份标识</param>
        /// <returns></returns>
        public static bool IsTeam(int pUserIdentity)
        {
            return (pUserIdentity & 8) == 8;
        }
        #endregion

        #region 判断用户身份
        private static readonly string sql_IsOpenIdentity = "select top 1 1 from User_Info where UserSN=@UserSN and ((OpenIdentity & @OpenIdentity)=@OpenIdentity)";
        private static IDataParameter[] GetIsOpenIdentity_dp(int pUserID, int pIdentity)
        {
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@UserSN",pUserID),
                                  DbHelp.Def.AddParam("@OpenIdentity",pIdentity),
                                  };
            return dp;
        }

        /// <summary>
        /// 判断用户身份 是否是推广员
        /// </summary>
        /// <param name="pUserID"></param>
        /// <returns></returns>
        public static bool IsUserPromoter(int pUserID)
        {
            return DbHelp.First(sql_IsOpenIdentity, GetIsOpenIdentity_dp(pUserID, 4), "0") == "1";
        }
        #endregion

        /// <summary>
        /// 判断用户是否申请了推广员
        /// </summary>
        /// <param name="pUserID"></param>
        /// <returns></returns>
        public static bool IsApplyFor_Promoter(int pUserID)
        {
            string sql = "select top 1 1 from User_ApplyFor_1 where FK_User=" + pUserID;
            return DbHelp.First(sql, "0") == "1";
        }

    }
}

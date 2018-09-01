using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using System.Web;
using WZ.Model;
using WZ.Data;
using WZ.Common.Config;
using WZ.Data.ClientAction;

namespace WZ.Client.Data
{
    public class User_Info
    {
        #region 用户登录
        public static bool Login(string pUserName, string pUserPwd)
        {
            const string sSQL_Login = "select UserSN,UserName,FK_User_Level,OpenIdentity from User_Info where UserName=@UserName and UserPwd=@UserPwd";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@UserName",pUserName),
                                  DbHelp.Def.AddParam("@UserPwd",Fn.MD5(pUserPwd)),
                                  };
            int UserID = 0;
            string UserName = string.Empty;
            int UserLevel = 0;
            int UserIdentity = 0;

            string LastLoginTime = string.Empty;
            string LastLoginIP = string.Empty;

            bool b = false;
            using (IDataReader dr = DbHelp.Read(sSQL_Login, dp))
            {
                if (dr.Read())
                {
                    b = true;
                    UserID = Convert.ToInt32(dr["UserSN"]);
                    UserName = dr["UserName"].ToString();
                    UserLevel = Convert.ToInt32(dr["FK_User_Level"]);
                    UserIdentity = Convert.ToInt32(dr["OpenIdentity"]);
                }
                dr.Close();
            }

            if (b)
            {
                if ((UserIdentity & 1) == 1 || (UserIdentity & 2) == 2 || (UserIdentity & 4) == 4 || (UserIdentity & 8) == 8)
                {

                }
                else
                {
                    return false;
                }

                LoginInfo.Login(UserID, UserName, UserLevel, UserIdentity);
                
                IDataParameter[] dp1 = { 
                                  DbHelp.Def.AddParam("@LastLoginIP",HttpContext.Current.Request.UserHostAddress),
                                  DbHelp.Def.AddParam("@UserSN",UserID),
                                       };

                const string sqlLoginSuccess = "update User_Info set LoginN=LoginN+1,LastLoginIP=@LastLoginIP,LastLoginTime=getdate() where UserSN=@UserSN";
                DbHelp.Update(sqlLoginSuccess, dp1);
            }

            if (!b)
            {
                LoginInfo.banHandler.Add();
            }

            try
            {
                WZ.BBS.DZHandler.DZFn.Login(pUserName, pUserPwd);
            }
            catch { }

            return b;
        }
        #endregion

        #region 判断用户是否存在
        /// <summary>
        /// 判断邮箱是否存在
        /// </summary>
        /// <param name="pEmailName"></param>
        /// <returns></returns>
        public static bool IsEmail(string pEmailName)
        {
            if (pEmailName.Length > Constant.MaxCount_Email)
                pEmailName = pEmailName.Substring(0, Constant.MaxCount_Email);

            string sSQL = "select top 1 UserSN from User_Info where Email=@Email";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@Email",pEmailName)
                                  };
            bool b = false;
            using (IDataReader dr = DbHelp.Read(sSQL, dp))
            {
                if (dr.Read())
                    b = true;
            }

            return b;
        }
        #endregion
    }
}

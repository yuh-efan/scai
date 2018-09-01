using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WZ.Common.ICommon;
using WZ.Common;
using WZ.Data.ClientAction;

namespace WZ.Client.Data
{
    /// <summary>
    /// 登录处理类
    /// 获取登录信息,用户登录,用户退出等
    /// </summary>
    public class LoginInfo
    {
        public const string C_UserID = "UserID";
        public const string C_UserName = "UserName";
        public const string C_UserLevel = "UserLevel";
        public const string C_UserIdentity = "UserIdentity";
        public static BanCache banHandler = new BanCache("userlogin", new TimeSpan(0, 3, 0), 3);


        //private string userID;

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="pUserID"></param>
        /// <param name="pUserName"></param>
        /// <param name="pUserLevel"></param>
        public static void Login(int pUserID, string pUserName, int pUserLevel, int pUserIdentity)
        {
            HttpContext.Current.Session[C_UserID] = pUserID;
            HttpContext.Current.Session[C_UserName] = pUserName;
            HttpContext.Current.Session[C_UserLevel] = pUserLevel;
            HttpContext.Current.Session[C_UserIdentity] = pUserIdentity;

            HttpContext.Current.Response.Cookies.Add(new HttpCookie("lastTime", DateTime.Now.ToString("yyyy-MM-dd hh:ss:mm")));
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("lastIP", HttpContext.Current.Request.UserHostAddress));

            HttpCookie hc_lastUN = new HttpCookie("lastUN", HttpContext.Current.Server.UrlEncode(pUserName));
            hc_lastUN.Expires = DateTime.Now.AddMonths(1);
            HttpContext.Current.Response.Cookies.Add(hc_lastUN);

        }

        /// <summary>
        /// 退出
        /// </summary>
        public static void Exit()
        {
            HttpContext.Current.Session.Remove(C_UserID);
            HttpContext.Current.Session.Remove(C_UserName);
            HttpContext.Current.Session.Remove(C_UserLevel);
            HttpContext.Current.Session.Remove(C_UserIdentity);

            try
            {
                WZ.BBS.DZHandler.DZFn.Logout("");
            }
            catch
            { }
        }

        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            object o = HttpContext.Current.Session[C_UserID];
            return (o == null || o.ToString().Length < 1);
        }

        /// <summary>
        /// 用户 ID
        /// </summary>
        public static int UserID
        {
            get { return int.Parse(HttpContext.Current.Session[C_UserID].ToString()); }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserName
        {
            get { return HttpContext.Current.Session[C_UserName].ToString(); }
        }

        /// <summary>
        /// 用户等级
        /// </summary>
        public static int UserLevel
        {
            get { return int.Parse(HttpContext.Current.Session[C_UserLevel].ToString()); }
        }

        /// <summary>
        /// 用户身份
        /// </summary>
        public static int UserIdentity
        {
            get { return int.Parse(HttpContext.Current.Session[C_UserIdentity].ToString()); }
        }

        public static void NoLogin()
        {
            if (LoginInfo.IsLogin())
            {
                HttpContext.Current.Response.Redirect("/user/login.aspx?url=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.ToString()));
            }
        }

        public static void NoLoginF()
        {
            if (LoginInfo.IsLogin())
            {
                HttpContext.Current.Response.Redirect("/floatLayer/login.aspx?furl=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.ToString()));
            }
        }

        /// <summary>
        /// true:未登录
        /// ajax提交自身页时 需要 name=hid value=1 的 input(form提交方式)
        /// </summary>
        /// <param name="msg"></param>
        public static bool NoLogin(IMessage msg)
        {
            if (LoginInfo.IsLogin())
            {
                if (Req.GetForm("hid") == "1")
                {
                    string s = "您已退出登录";
                    msg.WriteMessage(string.Empty, ref s, string.Empty, "nologin");
                    return true;
                }

                HttpContext.Current.Response.Redirect("/user/login.aspx?url=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.ToString()));
            }

            return false;
        }

        /// <summary>
        /// true:未登录
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool NoLogin1(IMessage msg)
        {
            if (LoginInfo.IsLogin())
            {
                string s = "您已退出登录";
                msg.WriteMessage(string.Empty, ref s, string.Empty, "nologin");
                return true;
            }
            return false;
        }

        #region 判断用户身份
        /// <summary>
        /// 判断用户 是否是个人
        /// </summary>
        /// <returns></returns>
        public static bool IsUserPersonal()
        {
            return (UserIdentity & 1) == 1;
        }

        /// <summary>
        /// 判断用户 是否是店铺
        /// </summary>
        /// <returns></returns>
        public static bool IsUserShop()
        {
            return (UserIdentity & 2) == 2;
        }

        /// <summary>
        /// 判断用户 是否是推广员
        /// </summary>
        /// <returns></returns>
        public static bool IsUserPromoter()
        {
            return (UserIdentity & 4) == 4;
        }

        /// <summary>
        /// 判断用户 是否是团体
        /// </summary>
        /// <returns></returns>
        public static bool IsUserTeam()
        {
            return (UserIdentity & 8) == 8;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using WZ.Model;
using System.Web;

namespace WZ.Data
{
    public class User_ContactL
    {
        #region help
        protected IDbHelp curHelp;

        public User_ContactL()
        {
            this.curHelp = new DefaultHelp();
        }

        public User_ContactL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        #region 添加
        public bool Add(User_ContactM pMod)
        {
            string sMsg = string.Empty;
            return Add(pMod, ref sMsg);
        }

        public bool Add(User_ContactM pMod, ref string pMsg)
        {
            if (GetUserContactN(pMod.FK_User) >= 10)
            {
                pMsg = "最多不能超过10条;";
                return false;
            }

            string sSQL = "insert into User_Contact(FK_User,Name,Address,FixTel,Tel,FK_Area) values(@FK_User,@Name,@Address,@FixTel,@Tel,@FK_Area)";

            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
                                  DbHelp.Def.AddParam("@Name",pMod.Name),
                                DbHelp.Def.AddParam("@Address",pMod.Address),
                                DbHelp.Def.AddParam("@FixTel",pMod.FixTel),
                                DbHelp.Def.AddParam("@Tel",pMod.Tel),
                                DbHelp.Def.AddParam("@FK_Area",pMod.FK_Area),

                                  };
            return (curHelp.Update(sSQL, dp) > 0);
        }


        #endregion

        #region 用户联系方式记录数
        public int GetUserContactN(int pUserID)
        {
            string sSQL = "select count(0) from User_Contact where FK_User=" + pUserID;
            return Convert.ToInt32(curHelp.Scalar(sSQL));
        }
        #endregion

        #region 修改
        public static bool Edit(User_ContactM pMod, int pContaceID, int pUserID)
        {
            string strSql = "update User_Contact set Name=@Name,Address=@Address,FixTel=@FixTel,Tel=@Tel,FK_Area=@FK_Area where ConSN=" + pContaceID + " and FK_User=" + pUserID;

            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@Name",pMod.Name),
                                DbHelp.Def.AddParam("@Address",pMod.Address),
                                DbHelp.Def.AddParam("@FixTel",pMod.FixTel),
                                DbHelp.Def.AddParam("@Tel",pMod.Tel),
                               
                                DbHelp.Def.AddParam("@FK_Area",pMod.FK_Area),
                                  };
            return (DbHelp.Update(strSql, dp) > 0);
        }
        #endregion

        #region 删除
        //删除
        public static bool Delelte(int pID, int pUserID)
        {
            string sSQL = "delete from User_Contact where FK_User=" + pUserID + " and ConSN = " + pID;
            return (DbHelp.Update(sSQL) > 0);
        }
        #endregion

        #region 获取数据及验证
        public static User_ContactM GetData()
        {
            string sMsg = string.Empty;
            User_ContactM mod = GetData(ref sMsg);
            new MessageGeneral().Error(sMsg);
            return mod;
        }

        /// <summary>
        /// 获取数据及验证
        /// </summary>
        /// <returns></returns>
        public static User_ContactM GetData(ref string pMsg)
        {
            User_ContactM mod = new User_ContactM();

            string sName = Fn.EncodeHtml(Req.GetForm("cName").Trim());
            //string sSex = Req.GetForm("cSex").Trim();
            string sAddress = Fn.EncodeHtml(Req.GetForm("cAddress").Trim());
            string sFixTel = Fn.EncodeHtml(Req.GetForm("cFixTel").Trim());
            string sTel = Fn.EncodeHtml(Req.GetForm("cTel").Trim());
            string sArea = Req.GetForm("cArea").Trim();

            if (sName.Length < 1 || sName.Length > 30)
            {
                pMsg = "请输入收货人,不超30个字;";
                return mod;
            }

            if ((sTel.Length < 1 || sTel.Length > 25) && (sFixTel.Length < 1 || sFixTel.Length > 25))
            {
                pMsg = "手机,固定电话必填一个,不超25个位;";
                return mod;
            }

            if (sAddress.Length < 1 || sAddress.Length > 300)
            {
                pMsg = "请输入详细地址,不超300个字;";
                return mod;
            }

            if ((!Fn.IsIntBool(sArea)))
            {
                pMsg = "请选择地区;";
                return mod;
            }
            else if (Convert.ToInt32(sArea) < 1)
            {
                pMsg = "请选择地区;";
                return mod;
            }

            mod.Name = sName;
            mod.Address = sAddress;
            mod.FixTel = sFixTel;
            mod.Tel = sTel;
            mod.FK_Area = Convert.ToInt32(sArea);
            return mod;
        }
        #endregion
    }
}

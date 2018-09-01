using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using System.Web;

namespace WZ.Data.ClientAction
{
    public class BanData
    {
        #region help
        protected IDbHelp curHelp;
        #endregion

        private string banIdentifier;
        private TimeSpan areaTime;
        private int banCount;
        private int userID;

        public BanData(int pUserID, string pBanType, TimeSpan pAreaTime, int pBanCount, IDbHelp pHelp)
        {
            this.userID = pUserID;
            this.banIdentifier = pBanType;
            this.areaTime = pAreaTime;
            this.banCount = pBanCount;
            this.curHelp = pHelp;
        }

        public BanData(int pUserID, string pBanType, TimeSpan pAreaTime, int pBanCount)
        {
            this.userID = pUserID;
            this.banIdentifier = pBanType;
            this.areaTime = pAreaTime;
            this.banCount = pBanCount;
            this.curHelp = new DefaultHelp();
        }

        public bool IsBan()
        {
            string sql = "select top 1 1 from Ban_Log where ban_adddate>@ban_adddate and ban_identifier=@ban_identifier and ban_ip=@ban_ip";

            DateTime ban_adddate = DateTime.Now.Add(-areaTime);

            IDataParameter[] dp = { 
                            DbHelp.Def.AddParam("@ban_adddate",ban_adddate),
                            DbHelp.Def.AddParam("@ban_identifier",this.banIdentifier),
                            DbHelp.Def.AddParam("@ban_ip",HttpContext.Current.Request.UserHostAddress)
                                  };

            return this.curHelp.First(sql, dp, "0") == "1";
        }

        public void Add()
        {
            string sql = "insert into Ban_Log(FK_User,ban_ip,ban_identifier) values(@FK_User,@ban_ip,@ban_identifier)";

            string sIP = HttpContext.Current.Request.UserHostAddress;
            IDataParameter[] dp1 = { 
                            DbHelp.Def.AddParam("@FK_User",userID),
                            DbHelp.Def.AddParam("@ban_ip",sIP),
                            DbHelp.Def.AddParam("@ban_identifier",this.banIdentifier),
                                  };

            this.curHelp.Update(sql, dp1);
        }
    }
}

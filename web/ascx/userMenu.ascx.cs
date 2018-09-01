using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WZ.Data;
using WZ.Common;
using WZ.Client.Data;

/*
 * 用户中心 左侧菜单
 * 
 * */
namespace WZ.Web.ascx
{
    public partial class userMenu : System.Web.UI.UserControl
    {
        protected string pageUserCanMoney;
        protected string pageUserExp;
        protected string pageUserLevelName;
        protected string pageAddDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sSQL = "select UserAddDate,UserExp," + User_InfoL.SQL_UserCanMoney() + ",(select LevelName from User_Level where LevelSN=FK_User_Level) as ln from User_Info where UserSN=" + LoginInfo.UserID;
            using (IDataReader dr = DbHelp.Read(sSQL))
            {
                if (dr.Read())
                {
                    pageUserCanMoney = dr["UserCanMoney"].ToString();
                    pageUserExp = dr["UserExp"].ToString();
                    pageUserLevelName = dr["ln"].ToString();
                    pageAddDate = dr["UserAddDate"].ToString();
                }
            }

            DateTime time1;
            if (DateTime.TryParse(pageAddDate, out time1))
            {
                pageAddDate = time1.ToString("yyyy-MM-dd");
            }
        }
    }
}
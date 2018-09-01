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
using WZ.Common;
using WZ.Client.Data;
using WZ.Model;
using WZ.Data;

namespace WZ.Web.floatLayer
{
    public partial class gift1 : WZ.Client.Data.General.FloatPage
    {
        protected int id;
        protected int num;

        protected string pageRealName;
        protected string pageArea;
        protected string pageAddress;
        protected string pageTel;
        protected string pageFixTel;

        protected string pageTotalIntegral;
        protected string pageUserIntegral;

        //protected string pageAreaName;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo.NoLoginF();

            id = Req.GetID();
            num = Req.GetID("num");

            int userID = LoginInfo.UserID;
            string sql = "select top 1 FK_User,FK_Area,Name,Address,FixTel,Tel from User_Contact where FK_User=" + userID + " order by UseTime desc";
            bool b = false;

            //获取最后一次用户使用的配送信息
            using (IDataReader dr = DbHelp.Read(sql))
            {
                if (dr.Read())
                {
                    b = true;
                    pageRealName = dr["Name"].ToString();
                    pageArea = dr["FK_Area"].ToString();
                    pageAddress = dr["Address"].ToString();
                    pageTel = dr["Tel"].ToString();
                    pageFixTel = dr["FixTel"].ToString();
                }
            }

            //若没有配送信息,则从个人用户信息读取
            if (!b)
            {
                sql = "select RealName,Area,Address,Tel,FixTel from User_Personal where FK_User=" + userID;
                using (IDataReader dr = DbHelp.Read(sql))
                {
                    if (dr.Read())
                    {
                        b = true;
                        pageRealName = dr["RealName"].ToString();
                        pageArea = dr["Area"].ToString();
                        pageAddress = dr["Address"].ToString();
                        pageTel = dr["Tel"].ToString();
                        pageFixTel = dr["FixTel"].ToString();
                    }
                }
            }

            sql = "select Integral from Gift_Info where GiftSN=" + id;
            using (IDataReader dr = DbHelp.Read(sql))
            {
                if (dr.Read())
                {
                    pageTotalIntegral = ((int)num * int.Parse(dr["Integral"].ToString())).ToString();//总积分
                }
                else
                {
                    pageTotalIntegral = "不存在此礼品";
                    return;
                }
            }

            sql = "select UserIntegral from User_Info where UserSN=" + userID;
            using (IDataReader dr = DbHelp.Read(sql))
            {
                if (dr.Read())
                {
                    pageUserIntegral = dr["UserIntegral"].ToString();
                }
                else
                {
                    pageUserIntegral = "不存在用户";
                    return;
                }
            }

            //GetClassPath1 acp = new GetClassPath1();
            //ClassPath cp = new ClassPath(PubData.GetDataTable("pub_area"), acp);
            //cp.Exe(Fn.IsInt(pageArea, 0));
            //pageAreaName = acp.GetPath;
            
        }
    }
}

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
using WZ.Data;
using WZ.Common.CacheData;
using WZ.Model;
using WZ.Client.Data;
using WZ.Common.Config;
using Newtonsoft.Json;
using WZ.Data.DataItem;

namespace WZ.Web.user
{
    public partial class userInfoEdit_team : WZ.Client.Data.General.PageUser
    {
        private int userID;

        protected string pageDetail;

        protected void Page_Load(object sender, EventArgs e)
        {
            userID = LoginInfo.UserID;
            string hid = Req.GetForm("hid");
            if (hid == "1")
            {
                string cmd = Req.GetForm("cmd");
                switch (cmd)
                {
                    case "edit":
                        EditInfo();
                        break;
                }
                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sSQL = "select TeamName,RealName,Area,Address,Tel,FixTel,Email,Detail " + User_InfoL.SQL_UserLJTeam() + " where UserSN=" + userID + " and OpenIdentity&8=8";
            string sArea = string.Empty;
            using (IDataReader dr = DbHelp.Read(sSQL))
            {
                if (dr.Read())
                {
                    this.cName1.Text = dr["TeamName"].ToString();
                    this.cName.Text = dr["RealName"].ToString();
                    this.cTel.Text = dr["Tel"].ToString();
                    this.cFixTel.Text = dr["FixTel"].ToString();
                    this.cAddress.Text = dr["Address"].ToString();
                    this.cEmail.Text = dr["Email"].ToString();
                    pageDetail = dr["Detail"].ToString();
                    sArea = dr["Area"].ToString();
                    this.cArea.Text = sArea;
                }
                else
                {
                    new MessageGeneral().Error("不存此用户");
                }
            }
        }

        protected void EditInfo()
        {
            string sName1 = Fn.EncodeHtml(Req.GetForm("cName1"));
            string sName = Fn.EncodeHtml(Req.GetForm("cName"));
            string sTel = Fn.EncodeHtml(Req.GetForm("cTel"));
            string sFixTel = Fn.EncodeHtml(Req.GetForm("cFixTel"));
            string sAddress = Fn.EncodeHtml(Req.GetForm("cAddress"));
            string sArea = Req.GetForm("cArea");
            string sEmail = Fn.EncodeHtml(Req.GetForm("cEmail"));
            string sDetail = Fn.EncodeHtml(Req.GetForm("cInfo"));

            if (sName1.Length < 1 || sName1.Length > 100)
                msgAjax.Error("请输入公司名称,不超100个字;");

            if (sName.Length < 1 || sName.Length > 30)
                msgAjax.Error("请输入姓名,不超30个字;");

            if (sTel.Length == 0 && sFixTel.Length == 0)
            {
                msgAjax.Error("手机/电话必填一项;");
            }
            else
            {
                if (sTel.Length > 25)
                    msgAjax.Error("手机不超25个字符;");

                if (sFixTel.Length > 25)
                    msgAjax.Error("电话不超25个字符;");
            }

            if (sAddress.Length < 1 || sAddress.Length > 250)
                msgAjax.Error("请输入详细地址,不超250个字;");

            if ((!Fn.IsIntBool(sArea)))
            {
                msgAjax.Error("请选择地区;");
            }
            else if (Convert.ToInt32(sArea) < 1)
            {
                msgAjax.Error("请选择地区;");
            }

            if (sDetail.Length > 2000)
            {
                msgAjax.Error("公司介绍不超过2000字符;");
            }

            if (msgAjax.IsError)
                return;

            //邮箱
            if (sEmail.Length == 0)
            {
                msgAjax.Error("请输入邮箱;");//请输入邮箱
            }
            else
            {
                if (sEmail.Length < 5 || sEmail.Length > 30)
                {
                    msgAjax.Error("邮箱须在5-30个字符之间;");//邮箱须在5-30个字符之间
                }
                else
                {
                    if (!Fn.IsRegex(sEmail, Fn.EnumRegex.电子邮件))
                    {
                        msgAjax.Error("邮箱格式不正确;");//邮箱格式不正确
                    }
                    else
                    {
                        if (User_InfoL.IsEmailEdit(sEmail, userID))
                        {
                            msgAjax.Error("此邮箱名已被注册，请重新输入;");//此邮箱名已被注册，请更换一个邮箱试试
                        }
                    }
                }
            }

            if (msgAjax.IsError)
                return;

            //团体用户信息
            User_TeamM teamMod = new User_TeamM();
            teamMod.TeamName = sName1;
            teamMod.RealName = sName;
            teamMod.Area = int.Parse(sArea);
            teamMod.Address = sAddress;
            teamMod.Tel = sTel;
            teamMod.FixTel = sFixTel;
            teamMod.Detail = sDetail;

            //账户信息
            User_InfoM infoMod = new User_InfoM();
            infoMod.Email = sEmail;

            EditInfo_TransM tmod = new EditInfo_TransM();
            tmod.infoMod = infoMod;
            tmod.teamMod = teamMod;

            DbHelp.ExecuteTrans(new DbHelpParam(), EditInfo_Trans, tmod);

            if (tmod.returnValue == "1")
            {
                msgAjax.Success("1");
            }
            else
            {
                msgAjax.Error(tmod.returnValue);
            }
        }

        private class EditInfo_TransM : DbHelp.ITransM
        {
            public User_InfoM infoMod = new User_InfoM();
            public User_TeamM teamMod = new User_TeamM();
        }

        private int EditInfo_Trans(IDbHelp thelp, DbHelp.ITransM pMod)
        {
            EditInfo_TransM tmod = (EditInfo_TransM)pMod;
            User_InfoM infoMod = tmod.infoMod;
            User_TeamM teamMod = tmod.teamMod;

            #region 保存个人信息
            string sql_pre = "update User_Team set TeamName=@TeamName,RealName=@RealName,Area=@Area,Address=@Address,Tel=@Tel,FixTel=@FixTel,Detail=@Detail where FK_User=" + userID;
            IDataParameter[] dp_pre = { 
                                        DbHelp.Def.AddParam("@TeamName",teamMod.TeamName),
                                        DbHelp.Def.AddParam("@RealName",teamMod.RealName),
                                        DbHelp.Def.AddParam("@Area",teamMod.Area),
                                        DbHelp.Def.AddParam("@Address",teamMod.Address),
                                        DbHelp.Def.AddParam("@Tel",teamMod.Tel),
                                        DbHelp.Def.AddParam("@FixTel",teamMod.FixTel),
                                        DbHelp.Def.AddParam("@Detail",teamMod.Detail),
                                      };
            if (thelp.Update(sql_pre, dp_pre) <= 0)
            {
                tmod.returnValue = "您的账号信息可能已损坏，请重新注册账号或通过客服帮助";//个人用户信息保存失败
                return 0;
            }
            #endregion

            #region 保存账户信息
            string sql_info = "update User_Info set Email=@Email where UserSN=" + userID + " and OpenIdentity&8=8";
            IDataParameter[] dp_info ={
                                    DbHelp.Def.AddParam("@Email", infoMod.Email),
                                       };

            if (thelp.Update(sql_info, dp_info) <= 0)
            {
                tmod.returnValue = "c";//账户信息保存失败
                return 0;
            }
            #endregion

            tmod.returnValue = "1";
            return 1;
        }
    }
}
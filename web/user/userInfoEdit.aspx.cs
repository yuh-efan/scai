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
    public partial class userInfoEdit : WZ.Client.Data.General.PageUser
    {
        protected ItemHandler dpTrades = new ItemHandler("Trades");
        protected ItemHandler dpIncome = new ItemHandler("Income");
        protected ItemHandler dpCuisine = new ItemHandler("Cuisine");
        protected ItemHandler dpVegetables = new ItemHandler("Vegetables");
        protected ItemHandler dpTaste = new ItemHandler("Taste");
        protected ItemHandler dpFactor = new ItemHandler("Factor");

        protected string pageTrades;
        protected string pageIncome;
        protected string pageCuisine;
        protected string pageVegetables;
        protected string pageTaste;
        protected string pageFactor;

        private int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User_InfoL.IsTeam(LoginInfo.UserIdentity))
            {
                Response.Redirect("userInfoEdit_team.aspx");
            }

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
            string sSQL = "select RealName,Sex,Area,Address,Tel,FixTel,Email " + User_InfoL.SQL_UserLJPersonal() + " where UserSN=" + userID;
            string sSex = "1";
            string sArea = string.Empty;
            using (IDataReader dr = DbHelp.Read(sSQL))
            {
                if (dr.Read())
                {
                    this.cName.Text = dr["RealName"].ToString();
                    this.cTel.Text = dr["Tel"].ToString();
                    this.cFixTel.Text = dr["FixTel"].ToString();
                    this.cAddress.Text = dr["Address"].ToString();
                    this.cEmail.Text = dr["Email"].ToString();

                    sArea = dr["Area"].ToString();
                    this.cArea.Text = sArea;
                    sSex = dr["Sex"].ToString();
                }
                else
                {
                    new MessageGeneral().Error("不存此用户");
                }
            }

            this.cSex.Text = Bind.GetHtmlRadio(ItemHandler.GetItemList("Sex"), "cSex", sSex);

            //问卷调查
            string birDate = "", familyN = "", trades = "0", income = "0", cuisine = "0", proposal = "";
            int vegetables = 0, taste = 0, factor = 0;

            string sql = "select BirDate,FamilyN,Trades,Income,Cuisine,Vegetables,Taste,Factor,Proposal from Survey where FK_User=" + userID;
            using (IDataReader dr2 = DbHelp.Read(sql))
            {
                if (dr2.Read())
                {
                    birDate = dr2["BirDate"].ToString();
                    familyN = dr2["FamilyN"].ToString();
                    trades = dr2["Trades"].ToString();
                    income = dr2["Income"].ToString();
                    cuisine = dr2["Cuisine"].ToString();
                    vegetables = int.Parse(dr2["Vegetables"].ToString());
                    taste = int.Parse(dr2["Taste"].ToString());
                    factor = int.Parse(dr2["Factor"].ToString());
                    proposal = dr2["Proposal"].ToString();
                }
            }
            cBirDate.Text = birDate;
            cFamilyN.Text = familyN;
            cProposal.Text = proposal;
            //从事行业
            pageTrades = Bind.GetHtmlSelect(dpTrades.GetItemList(), "cTrades", trades, "0", "请选择");
            //月均收入
            pageIncome = Bind.GetHtmlSelect(dpIncome.GetItemList(), "cIncome", income, "0", "请选择");
            //厨艺水平
            pageCuisine = Bind.GetHtmlSelect(dpCuisine.GetItemList(), "cCuisine", cuisine, "0", "请选择");
            //喜欢菜系
            pageVegetables = Bind.GetHtmlCheckBox(dpVegetables.GetItemList(), "cVegetables", vegetables);
            //喜欢口味
            pageTaste = Bind.GetHtmlCheckBox(dpTaste.GetItemList(), "cTaste", taste);
            //网购食品您更注重那些因素
            pageFactor = Bind.GetHtmlCheckBox(dpFactor.GetItemList(), "cFactor", factor);
        }

        protected void EditInfo()
        {
            string sName = Fn.EncodeHtml(Req.GetForm("cName"));
            string sTel = Fn.EncodeHtml(Req.GetForm("cTel"));
            string sFixTel = Fn.EncodeHtml(Req.GetForm("cFixTel"));
            string sAddress = Fn.EncodeHtml(Req.GetForm("cAddress"));
            string sArea = Req.GetForm("cArea");
            string sSex = Req.GetForm("cSex");
            string sEmail = Fn.EncodeHtml(Req.GetForm("cEmail"));

            string birDate =Fn.EncodeHtml( Req.GetForm("cBirDate"));
            string familyN = Fn.EncodeHtml(Req.GetForm("cFamilyN"));
            string trades = Req.GetForm("cTrades");
            string income = Req.GetForm("cIncome");
            string cuisine = Req.GetForm("cCuisine");
            string vegetables = Req.GetForm("cVegetables");
            string taste = Req.GetForm("cTaste");
            string factor = Req.GetForm("cFactor");
            string proposal = Fn.EncodeHtml(Req.GetForm("cProposal"));

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

            if (!Fn.IsIntBool(sSex))
                msgAjax.Error("请选择性别;");

            if ((!Fn.IsIntBool(sArea)))
            {
                msgAjax.Error("请选择地区;");
            }
            else if (Convert.ToInt32(sArea) < 1)
            {
                msgAjax.Error("请选择地区;");
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

            if (!string.IsNullOrEmpty(birDate) && !Fn.IsDateBool(birDate))
                msgAjax.Error("出生日期格式错误，请重新输入！;");

            if (!string.IsNullOrEmpty(familyN) && !Fn.IsIntBool(familyN))
                msgAjax.Error("家庭成员人数格式错误，请重新输入！;");


            if (msgAjax.IsError)
                return;

            //调查
            int iVegetables = 0;
            if (vegetables.Length > 0)
            {
                if (Fn.IsIntArrBool(vegetables))
                    iVegetables = Fn.IntArrToBit(Fn.StrToIntArr(vegetables));
            }

            int iTaste = 0;
            if (taste.Length > 0)
            {
                if (Fn.IsIntArrBool(taste))
                    iTaste = Fn.IntArrToBit(Fn.StrToIntArr(taste));
            }

            int iFactor = 0;
            if (factor.Length > 0)
            {
                if (Fn.IsIntArrBool(factor))
                    iFactor = Fn.IntArrToBit(Fn.StrToIntArr(factor));
            }

            //调查信息
            SurveyM surMod = new SurveyM();
            surMod.FK_User = userID;
            surMod.BirDate = birDate;
            surMod.FamilyN = familyN;
            surMod.Trades = Fn.IsInt(trades, 0);
            surMod.Income = Fn.IsInt(income, 0);
            surMod.Cuisine = Fn.IsInt(cuisine, 0);
            surMod.Vegetables = iVegetables;
            surMod.Taste = iTaste;
            surMod.Factor = iFactor;
            surMod.Proposal = proposal;

            //个人用户信息
            User_PersonalM perMod = new User_PersonalM();
            perMod.RealName = sName;
            perMod.Sex = byte.Parse(sSex);
            perMod.Area = int.Parse(sArea);
            perMod.Address = sAddress;
            perMod.Tel = sTel;
            perMod.FixTel = sFixTel;

            //账户信息
            User_InfoM infoMod = new User_InfoM();
            infoMod.Email = sEmail;

            EditInfo_TransM tmod = new EditInfo_TransM();
            tmod.infoMod = infoMod;
            tmod.perMod = perMod;
            tmod.surMod = surMod;

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
            public User_PersonalM perMod = new User_PersonalM();
            public SurveyM surMod = new SurveyM();
        }

        private int EditInfo_Trans(IDbHelp thelp, DbHelp.ITransM pMod)
        {
            EditInfo_TransM tmod = (EditInfo_TransM)pMod;
            User_InfoM infoMod = tmod.infoMod;
            User_PersonalM perMod = tmod.perMod;
            SurveyM surMod = tmod.surMod;

            #region 保存调查信息
            string sql_sur = "if exists(select 1 from Survey where FK_User=@FK_User) "
            + "update Survey set BirDate=@BirDate,FamilyN=@FamilyN,Trades=@Trades,Income=@Income,Cuisine=@Cuisine,Vegetables=@Vegetables,Taste=@Taste,Factor=@Factor,Proposal=@Proposal where FK_User=@FK_User "
            + "else "
            + "insert into Survey(FK_User,BirDate,FamilyN,Trades,Income,Cuisine,Vegetables,Taste,Factor,Proposal) values(@FK_User,@BirDate,@FamilyN,@Trades,@Income,@Cuisine,@Vegetables,@Taste,@Factor,@Proposal)";
            IDataParameter[] dp_sur ={
                                    DbHelp.Def.AddParam("@FK_User", surMod.FK_User),
                                    DbHelp.Def.AddParam("@BirDate",surMod.BirDate),
                                    DbHelp.Def.AddParam("@FamilyN",surMod.FamilyN),
                                    DbHelp.Def.AddParam("@Trades",surMod.Trades),
                                    DbHelp.Def.AddParam("@Income",surMod.Income),
                                    DbHelp.Def.AddParam("@Cuisine",surMod.Cuisine),
                                    DbHelp.Def.AddParam("@Vegetables",surMod.Vegetables),
                                    DbHelp.Def.AddParam("@Taste",surMod.Taste),
                                    DbHelp.Def.AddParam("@Factor",surMod.Factor),
                                    DbHelp.Def.AddParam("@Proposal",surMod.Proposal),
                                    };
            if (thelp.Update(sql_sur, dp_sur) <= 0)
            {
                tmod.returnValue = "a";//调查信息保存失败
                return 0;
            }
            #endregion

            #region 保存个人信息
            string sql_pre = "update User_Personal set RealName=@RealName,Sex=@Sex,Area=@Area,Address=@Address,Tel=@Tel,FixTel=@FixTel where FK_User=" + userID;
            IDataParameter[] dp_pre = { 
                                        DbHelp.Def.AddParam("@RealName",perMod.RealName),
                                        DbHelp.Def.AddParam("@Sex",perMod.Sex),
                                        DbHelp.Def.AddParam("@Area",perMod.Area),
                                        DbHelp.Def.AddParam("@Address",perMod.Address),
                                        DbHelp.Def.AddParam("@Tel",perMod.Tel),
                                        DbHelp.Def.AddParam("@FixTel",perMod.FixTel),
                                      };
            if (thelp.Update(sql_pre, dp_pre) <= 0)
            {
                tmod.returnValue = "您的账号信息可能已损坏，请重新注册账号或通过客服帮助";//个人用户信息保存失败
                return 0;
            }
            #endregion

            #region 保存账户信息
            string sql_info = "update User_Info set Email=@Email where UserSN=" + userID;
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
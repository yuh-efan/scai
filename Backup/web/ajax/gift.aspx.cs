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
using WZ.Client.Data.General;
using WZ.Client.Data;
using WZ.Common;
using WZ.Common.ICommon;
using WZ.Data;
using WZ.Model;

namespace WZ.Web.ajax
{
    public partial class gift : AjaxPage
    {
        private IMessage msgAjax = new MessageAjaxC();

        private int id;
        private double excount;//兑换数量
        private int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginInfo.NoLogin1(msgAjax))
            {
                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }

            id = Fn.IsInt(Req.GetQueryString("id"), 0);

            userID = LoginInfo.UserID;

            Exchange();

            Response.Write(msgAjax.ReturnMessage);
            Response.End();
        }

        private void Exchange()
        {
            //验证文本框输入
            if (!double.TryParse(Req.GetQueryString("excount"), out excount))
            {
                msgAjax.Error("errnumber");
                return;
            }
            else
            {
                if (excount <= 0)
                {
                    msgAjax.Error("errnumber");
                    return;
                }
            }

            string g_GiftName;
            int g_Integral = 0;
            int g_UserIntegral = 0;
            int g_TotalIntegral = 0;
            string sql = "select GiftName,Integral from Gift_Info where GiftSN=" + id;
            using (IDataReader dr = DbHelp.Read(sql))
            {
                if (dr.Read())
                {
                    g_GiftName = dr["GiftName"].ToString();
                    g_Integral = int.Parse(dr["Integral"].ToString());
                    g_TotalIntegral = (int)excount * g_Integral;//总积分

                }
                else
                {
                    msgAjax.Error("nogift");
                    return;
                }
            }

            sql = "select UserIntegral from User_Info where UserSN=" + userID;
            using (IDataReader dr = DbHelp.Read(sql))
            {
                if (dr.Read())
                {
                    g_UserIntegral = int.Parse(dr["UserIntegral"].ToString());
                }
                else
                {
                    msgAjax.Error("不存在用户");
                    return;
                }
            }

            if (g_UserIntegral < g_TotalIntegral)
            {
                msgAjax.Error("nointegral");
                //msgAjax.Error("您的积分不足，还差" + (g_TotalIntegral - g_UserIntegral));
                return;
            }

            int t = Req.GetID("t");
            if (t == 1)//判断
            {
                msgAjax.Success("1");
                return;
            }

            if (t == 2)//兑换
            {
                string sName = Req.GetForm("cName").Trim();
                string sSex = Req.GetForm("cSex").Trim();
                string sAddress = Req.GetForm("cAddress").Trim();
                string sFixTel = Req.GetForm("cFixTel").Trim();
                string sTel = Req.GetForm("cTel").Trim();
                string sArea = Req.GetForm("cArea").Trim();
                string sInfo = Fn.EncodeHtml(Req.GetForm("cInfo").Trim());

                if (sName.Length < 1 || sName.Length > 30)
                {
                    msgAjax.Error("请输入收货人,不超30个字;");
                    return;
                }

                if ((sTel.Length < 1 || sTel.Length > 25) && (sFixTel.Length < 1 || sFixTel.Length > 25))
                {
                    msgAjax.Error("手机,固定电话必填一个,不超25个位;");
                    return;
                }

                if (sAddress.Length < 1 || sAddress.Length > 300)
                {
                    msgAjax.Error("请输入详细地址,不超300个字;");
                    return;
                }

                if ((!Fn.IsIntBool(sArea)))
                {
                    msgAjax.Error("请选择地区;");
                    return;
                }
                else if (Convert.ToInt32(sArea) < 1)
                {
                    msgAjax.Error("请选择地区;");
                    return;
                }

                if (sInfo.Length > 600)
                {
                    msgAjax.Error("符加信息不能超过600字;");
                    return;
                }

                Gift_ExchangeLogM mod = new Gift_ExchangeLogM();
                mod.FK_User = userID;
                mod.FK_Gift = id;

                mod.gift_UserName = LoginInfo.UserName;
                mod.gift_RealName = sName;
                mod.gift_Address = sAddress;
                mod.gift_FixTel = sFixTel;
                mod.gift_Tel = sTel;
                mod.gift_Area = Convert.ToInt32(sArea);
                mod.gift_Caption = sInfo;

                mod.GiftName = g_GiftName;
                mod.ExIntegral = g_Integral;
                mod.ExTotalIntegral = g_TotalIntegral;
                mod.Num = excount;

                Gift_TransM trans_mod = new Gift_TransM();
                trans_mod.mod = mod;

                DbHelp.ExecuteTrans(new DbHelpParam(), this.Gift_Trans, trans_mod);

                if (trans_mod.returnValue == "1")
                {
                    msgAjax.Success("1");
                }
                else
                {
                    msgAjax.Error(trans_mod.returnValue);
                }
            }
        }

        private class Gift_TransM : WZ.Common.DbHelp.ITransM
        {
            public Gift_ExchangeLogM mod = new Gift_ExchangeLogM();
        }

        private int Gift_Trans(IDbHelp thelp, object obj)
        {
            Gift_TransM tmod = (Gift_TransM)obj;
            Gift_ExchangeLogM mod = tmod.mod;

            //积分扣除
            string msg = new User_InfoL(thelp).SetUserIntegral(userID, mod.FK_Gift, "gift", -mod.ExTotalIntegral, mod.gift_UserName, "礼品\"" + mod.GiftName + "\"兑换成功,扣除" + mod.ExTotalIntegral + "积分");

            if (msg != "1")
            {
                tmod.returnValue = msg;
                return 0;
            }

            string sql = "insert into Gift_ExchangeLog(FK_User,FK_Gift,GiftName,ExIntegral,ExTotalIntegral,Num,gift_UserName,gift_RealName,gift_Area,gift_Address,gift_Tel,gift_FixTel,gift_Caption) values(@FK_User,@FK_Gift,@GiftName,@ExIntegral,@ExTotalIntegral,@Num,@gift_UserName,@gift_RealName,@gift_Area,@gift_Address,@gift_Tel,@gift_FixTel,@gift_Caption)";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@FK_User",mod.FK_User),
                                DbHelp.Def.AddParam("@FK_Gift",mod.FK_Gift),
                                DbHelp.Def.AddParam("@GiftName",mod.GiftName),
                                DbHelp.Def.AddParam("@ExIntegral",mod.ExIntegral),
                                DbHelp.Def.AddParam("@ExTotalIntegral",mod.ExTotalIntegral),
                                DbHelp.Def.AddParam("@Num",mod.Num),
                                DbHelp.Def.AddParam("@gift_UserName",mod.gift_UserName),
                                DbHelp.Def.AddParam("@gift_RealName",mod.gift_RealName),
                                DbHelp.Def.AddParam("@gift_Area",mod.gift_Area),
                                DbHelp.Def.AddParam("@gift_Address",mod.gift_Address),
                                DbHelp.Def.AddParam("@gift_Tel",mod.gift_Tel),
                                DbHelp.Def.AddParam("@gift_FixTel",mod.gift_FixTel),
                                DbHelp.Def.AddParam("@gift_Caption",mod.gift_Caption),
                                  };

            if (thelp.Update(sql, dp) > 0)
            {
                tmod.returnValue = "1";
                return 1;
            }
            else
            {
                tmod.returnValue = "提交失败";
                return 0;
            }
        }
    }
}

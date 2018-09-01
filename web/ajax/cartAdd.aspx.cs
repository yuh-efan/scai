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
using WZ.Common;
using WZ.Client.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using WZ.Common.Config;
using WZ.Common.ICommon;

/*
 * 产品 添加到购物车
 * 
 * */
namespace WZ.Web.inc
{
    public partial class cartAdd : AjaxPage
    {
        private string ids;//产品,菜谱或套餐id 一个或多个
        private int type;//0:产品 1:菜谱 2:套餐
        private double buyCount;//购买数量
        private IMessage msgAjax = new MessageAjax();
        protected void Page_Load(object sender, EventArgs e)
        {
            LL();
            Response.Write(msgAjax.ReturnMessage);
            Response.End();
        }

        private void LL()
        {
            if (LoginInfo.NoLogin1(msgAjax))
            {
                return;
            }

            ids = Fn.IsIntArr(Req.GetQueryString("id"));
            type = Req.GetID("t");
            buyCount = Fn.IsDouble(Req.GetQueryString("n"), 1);

            if (buyCount <= 0)
            {
                msgAjax.Error("购买数量至少大于0");
                return;
            }

            if (ids.Length == 0)
            {
                msgAjax.Error("请选择商品");
                return;
            }

            switch (type)
            {
                case 0://产品
                    AddCart(Fn.StrToIntArr(ids));
                    break;

                case 1://菜谱
                    Add1("select ProSN from vgPro_Info where ProSN in(select FK_Pro from CaiPu_Pro where FK_CaiPu in (" + ids + "))");
                    break;

                //case 2://套餐
                //    string lsSql = "declare @lst table (FK_Pro int)"
                //    + "insert into @lst(FK_Pro)("
                //    + "select FK_Pro "
                //    + "from CaiPu_Pro "
                //    + "where FK_CaiPu in(select tc.FK_CaiPu from TaoCan_CaiPu tc where tc.FK_TaoCan in(" + ids + ")) "
                //    + ")"

                //    + "insert into @lst(FK_Pro)("
                //    + "select FK_CaiPu from TaoCan_Pro where FK_TaoCan in (" + ids + ")"
                //    + ")"
                //    + "select FK_Pro from @lst";

                //    Add1(lsSql);
                //    //Add1("select FK_Pro from CaiPu_Pro caip left join TaoCan_CaiPu taoc on caip.FK_CaiPu=taoc.FK_CaiPu where taoc.FK_TaoCan in (" + ids + ")");
                //    break;
            }
        }

        //添加 菜谱 套餐 
        private void Add1(string pSql)
        {
            //---获取此 菜谱或套餐 下的所有产品id
            string proIDs = string.Empty;
            string sSql = pSql;
            using (IDataReader dr = DbHelp.Read(sSql))
            {
                while (dr.Read())
                {
                    proIDs += dr[0].ToString() + ",";
                }
            }

            if (proIDs.Length > 0)
                proIDs = proIDs.TrimEnd(',');
            else
            {
                msgAjax.Error("没有商品放入购物车");
                return;
            }
            //---end

            AddCart(Fn.StrToIntArr(proIDs));
        }

        //添加产品
        private void AddCart(int[] pArrInt)
        {
            IList<User_Cart.MsgAdd> msgList = User_Cart.Add(LoginInfo.UserID, pArrInt, buyCount);

            int a1 = 0;//成功
            int a2 = 0;//超出
            int a3 = 0;//服务器端错误

            foreach (User_Cart.MsgAdd m in msgList)
            {
                switch (m.msg)
                {
                    case "1":
                        a1++;
                        break;

                    case "2":
                        a2++;
                        break;

                    default:
                        a3++;
                        break;
                }
            }

            if (a1 != msgList.Count)
            {
                if (a1 > 0)
                {
                    msgAjax.Error("成功添加产品" + a1 + "个;");
                }

                if (a2 > 0)
                {
                    msgAjax.Error("购物车产品不能超出" + Constant.MaxCount_Cart + "个;");
                }

                if (a3 > 0)
                {
                    msgAjax.Error("未知错误" + a3);
                }

            }
            else
            {
                msgAjax.Success("1");
            }
        }
    }
}

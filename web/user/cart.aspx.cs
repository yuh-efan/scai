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
using WZ.Common.Control;
using System.Text;
using WZ.Data;
using System.Collections.Generic;
using WZ.Common.Config;
using WZ.Data.DataItem;
using WZ.Common.ICommon;

namespace WZ.Web.user
{

    public partial class cart : WZ.Client.Data.General.PageUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int hid = Fn.IsInt(Req.GetForm("hid"), 0);
            if (hid > 0)
            {
                string cmd = Req.GetForm("cmd");
                switch (cmd)
                {
                    case "clearAll"://清空
                        deleteALL();
                        break;

                    case "del":
                        delete();
                        break;

                    case "editNum":
                        editNum();
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

        private int LL()
        {
            int userID = LoginInfo.UserID;
            int userLevel = LoginInfo.UserLevel;
            int userIdentity = LoginInfo.UserIdentity;

            Dictionary<int, DataTable> dic = User_Cart.List(userID, userLevel, userIdentity);
            DataTable dtTotal = dic[0];
            DataTable dtProList = dic[10];

            this.txtTotalPriceAll.Text = dtTotal.Rows[0][0].ToString();
            this.txtProN.Text = dtProList.Rows.Count.ToString();

            Bind.BGRepeater(dtProList, this.rpList);

            return dtProList.Rows.Count;
        }

        private void delete()
        {
            int id = Fn.IsInt(Req.GetForm("id"), 0);
            if (id > 0)
            {
                if (User_Cart.Delelte(LoginInfo.UserID, id))
                {
                    refresh();
                    msgAjax.Success("1");
                }
                else
                    msgAjax.Error("删除失败");
            }
            else
                msgAjax.Error("删除失败");
        }

        private void editNum()
        {
            int id = Fn.IsInt(Req.GetForm("id"), 0);
            double num = Fn.IsDouble(Req.GetForm("num"), 0);
            if (num <= 0.01)
            {
                msgAjax.Error("不能小于0.01");
                return;
            }

            if (id > 0)
            {
                string s = User_Cart.EditNum(LoginInfo.UserID, id, num);
                switch (s)
                {
                    case "0":
                        msgAjax.Error("修改失败");
                        break;
                    case "1":
                        refresh();
                        msgAjax.Success("1");
                        break;
                }
            }
        }

        private void deleteALL()
        {
            new User_CartL().DeleteAll(LoginInfo.UserID);
            refresh();
            msgAjax.Success("1");
        }

        private void refresh()
        {
            msgAjax.AddMessage("cartCount", LL().ToString());
            msgAjax.AddMessage("html", Fn.GetControlHtml(this.htm_cart));
        }
    }
}
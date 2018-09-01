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
using Newtonsoft.Json;
using WZ.Common.ICommon;
using WZ.Data.DataItem;
using WZ.Model;
using WZ.Data;

namespace WZ.Web.user
{
    /// <summary>
    /// 申请推广员
    /// </summary>
    public partial class applyFor1 : WZ.Client.Data.General.PageUser
    {
        protected string pageSex;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region ajax
            string hid = Req.GetForm("hid");
            if (hid == "1")
            {
                string cmd = Req.GetForm("cmd");
                switch (cmd)
                {
                    case "save":
                        cb_ok();
                        break;
                }
                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }
            #endregion

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            pageSex = Bind.GetHtmlRadio(new ItemHandler("Sex").GetItemList(), "sex", "1");

            string sql = "select Status from User_ApplyFor_1 where FK_User=" + LoginInfo.UserID;

            string status = string.Empty;
            using (IDataReader dr = DbHelp.Read(sql))
            {
                if (dr.Read())
                {
                    status=dr["Status"].ToString();
                }
            }

            if (status.Length == 0)
            {
                this.htm_ApplyFor_no.Visible = true;
            }
            else
            {
                switch (status)
                { 
                    case "0"://未处理
                        this.htm_ApplyFor_1.Visible = true;
                        break;

                    case "1"://通过
                        this.htm_ApplyFor_3.Visible = true;
                        break;

                    case "2"://未通过
                        this.htm_ApplyFor_2.Visible = true;
                        break;
                }
            }
        }

        protected void bOK_Click(object sender, EventArgs e)
        {
            cb_ok();
        }

        private void cb_ok()
        {
            #region
            string name = Fn.EncodeHtml(Req.GetForm("name").Trim());
            string sex = Req.GetForm("sex").Trim();
            string address = Fn.EncodeHtml(Req.GetForm("address").Trim());
            string tel = Fn.EncodeHtml(Req.GetForm("tel").Trim());
            string fixtel = Fn.EncodeHtml(Req.GetForm("fixtel").Trim());
            string bank = Fn.EncodeHtml(Req.GetForm("bank").Trim());
            string bankaccount = Fn.EncodeHtml(Req.GetForm("bankaccount").Trim());
            string remark = Fn.EncodeHtml(Req.GetForm("remark").Trim());

            //姓名
            if (name.Length == 0)
                msgAjax.Error("请输入姓名;");
            else if (name.Length > 30)
                msgAjax.Error("姓名不超过30个字;");

            //性别
            if (!Fn.IsByteBool(sex))
                msgAjax.Error("请选择性别;");


            //地址
            if (address.Length == 0)
                msgAjax.Error("请输入地址;");
            else if (address.Length > 300)
                msgAjax.Error("地址不超过300个字;");

            //手机 电话
            if (tel.Length == 0 && fixtel.Length == 0)
                msgAjax.Error("手机和电话必填一个;");
            else
            {
                if (tel.Length > 50)
                    msgAjax.Error("手机不超过50个字;");

                if (fixtel.Length > 50)
                    msgAjax.Error("电话不超过50个字;");
            }

            //开户行
            if (bank.Length == 0)
                msgAjax.Error("请输入开户银行;");
            else if (bank.Length > 50)
                msgAjax.Error("开户银行不超过50个字;");

            //银行账号
            if (bankaccount.Length == 0)
                msgAjax.Error("请输入银行账号;");
            else if (bankaccount.Length > 50)
                msgAjax.Error("银行账号不超过50个字;");

            //备注
            if (remark.Length > 600)
                msgAjax.Error("备注不超过600个字;");

            if (msgAjax.IsError)
                return;

            User_ApplyFor_1M mod = new User_ApplyFor_1M();
            mod.FK_User = LoginInfo.UserID;
            mod.RealName = name;
            mod.Sex = byte.Parse(sex);
            mod.Address = address;
            mod.Tel = tel;
            mod.FixTel = fixtel;
            mod.Bank_Name = bank;
            mod.Bank_Account = bankaccount;
            mod.Remark = remark;
            #endregion

            string sql = "FK_User,FK_AdminID,RealName,Sex,Address,Tel,FixTel,Bank_Name,Bank_Account,Remark";
            if (SqlData.Add(mod, sql))
            {
                msgAjax.Success("1");
            }
            else
            {
                msgAjax.Error("申请失败");
            }
        }
    }
}

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

namespace WZ.Web.user
{
    public partial class pwdEdit : WZ.Client.Data.General.PageUser
    {
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
        }

        protected void bOK_Click(object sender, EventArgs e)
        {
            cb_ok();
        }

        private void cb_ok()
        {
            string sOldPwd = Req.GetForm("cOldPwd").Trim();
            string sNewPwd = Req.GetForm("cNewPwd").Trim();
            string sNewPwdSure = Req.GetForm("cNewPwdSure").Trim();

            //string sMsg = string.Empty;
            if (sOldPwd.Length == 0)
                msgAjax.Error("请输入旧密码;");

            if (sNewPwd.Length == 0)
                msgAjax.Error("请输入新密码;");

            else if (sNewPwd.Length < 5 || sNewPwd.Length > 30)
            {
                msgAjax.Error("新密码5-30位之间;");
            }

            if (sNewPwdSure.Length == 0)
                msgAjax.Error("请输入新确认密码;");

            if (sNewPwd != sNewPwdSure)
                msgAjax.Error("新密码与新确认密码不一致;");

            if (msgAjax.IsError)
                return;

            if (WZ.Data.User_InfoL.EditPwd(LoginInfo.UserName, sOldPwd, sNewPwd, LoginInfo.UserID))
                msgAjax.Success("修改密码成功");
            else
                msgAjax.Error("原密码错误");
        }
    }
}

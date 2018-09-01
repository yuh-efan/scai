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

namespace WZ.Web.user
{
    public partial class userInfoEdit : WZ.Client.Data.General.PageUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sSQL = "select RealName,Sex,Area,Address,EMail,Tel from User_Info where UserSN=" + LoginInfo.UserID;
            string sSex = "1";
            string sArea = string.Empty;
            using (IDataReader dr = DbHelp.Read(sSQL))
            {
                if (dr.Read())
                {
                    this.cName.Text = dr["RealName"].ToString();
                    this.cEMail.Text = dr["EMail"].ToString();
                    this.cTel.Text = dr["Tel"].ToString();
                    this.cAddress.Text = dr["Address"].ToString();

                    sArea = dr["Area"].ToString();
                    this.cArea.Text = sArea;
                    sSex = dr["Sex"].ToString();
                }
                else
                {
                    Message.Error("不存此用户");
                }
            }

            this.cSex.Text = Bind.GetHtmlRadio(KeyPair.Sex, "cSex", sSex);

            GetClassPath1 acp = new GetClassPath1();
            ClassPath cp = new ClassPath(PubData.GetDataTable("Pub_Area"), acp);
            cp.Exe(Fn.IsInt(sArea, 0));
            this.cSelectSpanHidden.Text= acp.GetPath;

        }

        protected void bOK_Click(object sender, EventArgs e)
        {
            string sName = Req.GetForm("cName");
            string sEMail = Req.GetForm("cEMail");
            string sTel = Req.GetForm("cTel");
            string sAddress = Req.GetForm("cAddress");
            string sArea = Req.GetForm("cArea");
            string sSex = Req.GetForm("cSex");

            string sMsg = string.Empty;
            if (sName.Length < 1 || sName.Length > 20)
                sMsg += "请输入姓名,不超20个字;";

            if (sEMail.Length < 1 || sEMail.Length > 50)
                sMsg += "请输入邮箱,不超50个字;";

            if (sTel.Length < 1 || sTel.Length > 25)
                sMsg += "请输入手机,不超25个位;";

            if (sAddress.Length < 1 || sAddress.Length > 250)
                sMsg += "请输入详细地址,不超250个字;";

            if (!Fn.IsIntBool(sSex))
                sMsg += "请选择性别;";

            if ((!Fn.IsIntBool(sArea)))
            {
                sMsg += "请选择地区;";
            }
            else if (Convert.ToInt32(sArea) < 1)
            {
                sMsg += "请选择地区;";
            }
            Message.Error(sMsg);

            User_InfoM mod = new User_InfoM();
            mod.RealName = sName;
            mod.EMail = sEMail;
            mod.Tel = sTel;
            mod.Address = sAddress;
            mod.Area = Convert.ToInt32(sArea);
            mod.Sex = Convert.ToByte(sSex);

            if (User_Info.Edit(mod,LoginInfo.UserID))
            {
                Js.Alert("修改成功", Request.Url.AbsolutePath + "?r=" + Fn.SCNumber());
            }
            else
            {
                Message.Error("修改失败");
            }

        }
    }
}

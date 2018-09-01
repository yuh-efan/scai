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

/*
 * 产品,菜谱或套餐 添加到收藏夹
 * 
 * */
namespace WZ.Web.inc
{
    public partial class favAdd : AjaxPage
    {
        private int id;
        private string moreid;
        private byte t;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginInfo.IsLogin())
            {
                jso.Add("info", "nologin");
                WriteEndJso();
            }

            id = Req.GetID();
            t = Fn.IsByte(Req.GetQueryString("t"), 0);
            moreid = Req.GetQueryString("s");

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            AddPro();
            WriteEndJso();
        }

        private void AddPro()
        {
            if (id > 0)
            {
                string sMsg = Add();//订购单个产品
                if (sMsg.Length > 0)
                {
                    jso.Add("info", sMsg);
                    WriteEndJso();
                }
            }
            else
            {
                string sMsg = AddMore();//订购多个产品
                if (sMsg.Length > 0)
                {
                    jso.Add("info", sMsg);
                    WriteEndJso();
                }
            }

            jso.Add("info", "success");
        }

        //添加单个
        private string Add()
        {
            return User_Fav.Add(LoginInfo.UserID, id, t, 100);
        }

        //添加多个
        private string AddMore()
        {
            string sMsg = string.Empty;
            if (moreid.Length > 0)
                sMsg = User_Fav.Add(LoginInfo.UserID, moreid, t, 100);
            else
                sMsg = "请先选择商品";
            return sMsg;
        }
    }
}

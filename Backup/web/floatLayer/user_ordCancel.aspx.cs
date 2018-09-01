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
using WZ.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using WZ.Common.ICommon;

namespace WZ.Web.floatLayer
{
    /*
     * 
     * 用户申请取消订单
     * 
     * */
    public partial class user_ordCancel : WZ.Client.Data.General.FloatPage
    {
        private int id;
        protected int hid;

        protected IMessage msgAjax = new MessageAjax();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginInfo.IsLogin())
            {
                string furl = "login.aspx?furl=" + Request.Url.ToString();
                Response.Redirect(furl);
                return;
            }

            id = Req.GetID();
            hid = Fn.IsInt(Req.GetForm("hid"), 0);
            if (hid > 0)
            {
                switch (hid)
                {
                    case 1://申请取消
                        Ord_QX();
                        break;
                }

                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }
        }

        private void Ord_QX()
        {
            string sStatusCancelRemark =Server.HtmlEncode( Req.GetForm("content").Trim());
            if (sStatusCancelRemark.Length == 0 || sStatusCancelRemark.Length > 600)
            {
                msgAjax.Error("请输入备注，不超过600字");
                return;
            }

            string sql = "update Ord_Info set Status=@Status,StatusCancelRemark=@StatusCancelRemark where OrdSN=" + id + " and FK_User=" + LoginInfo.UserID + " and Status=10 and getdate()<dateadd(dd,0,convert(varchar(10),ToMinTime,120))";

            //凌晨时间
            DateTime lc = DateTime.Parse(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
            IDataParameter[] dp = {
                                  DbHelp.Def.AddParam("@Status",21),
                                  DbHelp.Def.AddParam("@StatusCancelRemark",sStatusCancelRemark),
                                  DbHelp.Def.AddParam("@AllowTime",lc),
                                  };

            if (DbHelp.Update(sql, dp) > 0)
            {
                msgAjax.Success("1");
                return;
            }
            else
            {
                msgAjax.Error("提交失败");
                return;
            }
        }
    }
}
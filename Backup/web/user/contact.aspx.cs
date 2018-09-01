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
using WZ.Client.Data.General;
using WZ.Model;
using System.Collections.Generic;
using WZ.Data;
using WZ.Common.CacheData;
using WZ.Common.Config;
using WZ.Common.ICommon;
using Newtonsoft.Json;
using WZ.Data.DataItem;

namespace WZ.Web.user
{
    public partial class contact : WZ.Client.Data.General.PageUser
    {
        protected int id;
        private int UserID;
        private GetClassPath1 acp = new GetClassPath1();
        private ClassPath cp;

        //private IMessage msgAjax = new MessageAjax();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();
            UserID = LoginInfo.UserID;
            cp = new ClassPath(PubData.GetDataTable("pub_area"), acp);

            string hid = Req.GetForm("hid");
            if (hid == "1")
            {
                string cmd = Req.GetForm("cmd");
                switch (cmd)
                {
                    case "save":
                        cb_ok();
                        break;
                    case "del":
                        
                        cb_delete();
                        break;
                }
                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }

            if (!this.IsPostBack)
            {
                LL();
                BGList();
            }
        }

        private void LL()
        {
            string sql;
            if (id > 0)
            {
                sql = "select Name,Address,FixTel,Tel,FK_Area from User_Contact where ConSN=" + id + " and FK_User=" + UserID;
                SqlDataSelect d = new SqlDataSelect(sql);
                if (d.Count > 0)
                {
                    this.cName.Text = d.Eval("Name").ToString();
                    this.cAddress.Text = d.Eval("Address").ToString();
                    this.cFixTel.Text = d.Eval("FixTel").ToString();
                    this.cTel.Text = d.Eval("Tel").ToString();
                    this.cArea.Text = d.Eval("FK_Area").ToString();

                    cp.Exe(d.Eval("FK_Area"));
                    //this.cSelectSpanHidden.Text = acp.GetPath;
                }
                else
                {
                    Response.Redirect(Request.Url.AbsolutePath);
                }
            }
        }

        private void BGList()
        {
            string sql = "select ConSN,Name,Address,Tel,FixTel,FK_Area from User_Contact where FK_User=" + UserID;
            DataTable dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, this.rpList);
        }

        //删除
        private void cb_delete()
        {
            int delid = Fn.IsInt(Req.GetForm("delid"),0);
            
            if (delid > 0)
            {
                string sql = "delete from User_Contact where FK_User=" + UserID + " and ConSN = " + delid;
                if (DbHelp.Update(sql) > 0)
                {
                    BGList();
                    msgAjax.AddMessage("html", Fn.GetControlHtml(this.clist));
                    msgAjax.Success("删除成功");
                }
                else
                {
                    msgAjax.Error("删除失败");
                }
            }
            else
            {
                msgAjax.Error("非法操作");
            }
        }

        protected string GetAreaPath(object pArea)
        {
            cp.Exe(Convert.ToInt32(pArea));
            return acp.GetPath;
        }

        ////添加
        //protected void bOK_Click(object sender, EventArgs e)
        //{
        //    cb_ok();
        //}

        private void cb_ok()
        {
            string sMsg = string.Empty;
            //获取数据及验证
            User_ContactM mod = User_ContactL.GetData(ref sMsg);
            if (sMsg.Length > 0)
            {
                msgAjax.Error(sMsg);
                return;
            }
            
            if (id > 0)
            {
                if (User_ContactL.Edit(mod, id, UserID))
                {
                    BGList();
                    msgAjax.AddMessage("html", Fn.GetControlHtml(this.clist));
                    msgAjax.Success("修改成功");
                }
                else
                    msgAjax.Error("修改失败,请刷新此网页解决此问题");
            }
            else
            {
                mod.FK_User = UserID;
                if (new User_ContactL().Add(mod))
                {
                    BGList();
                    msgAjax.AddMessage("html", Fn.GetControlHtml(this.clist));
                    msgAjax.Success("添加成功");
                }
                else
                    msgAjax.Error("添加失败，最多不超过10条");
            }
        }

        //#region ICallbackEventHandler 成员
        //public string GetCallbackResult()
        //{
        //    return msgAjax.ReturnMessage;
        //}

        //public void RaiseCallbackEvent(string eventArgument)
        //{
        //    JavaScriptObject jso = (JavaScriptObject)JavaScriptConvert.DeserializeObject(eventArgument);
        //    string sCmd = jso["cmd"].ToString();
        //    switch (sCmd)
        //    {
        //        case "ok":
        //            cb_ok();
        //            break;
        //    }
        //}
        //#endregion
    }
}

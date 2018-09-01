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
using Newtonsoft.Json;
using WZ.Common.ICommon;
using WZ.Data.ClientAction;

/*
 * 新闻 投票
 * 
 * */
namespace WZ.Web.ajax
{
    public partial class newsVote : WZ.Client.Data.General.AjaxPage
    {
        private int id;
        private string s;
        private IMessage msgAjax = new MessageAjaxC();
        private BanCache banH;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(Req.GetQueryString("id"), 0);
            banH = new BanCache("news_" + id, new TimeSpan(1, 0, 0, 0), 1);

            s = Req.GetQueryString("s");
            if (s.Length > 1)
                s = s.Substring(0, 1);

            if (!this.IsPostBack)
            {
                LL();
            }
            Response.Write(msgAjax.ReturnMessage);
        }

        private void LL()
        {
            if (banH.IsBan())
            {
                msgAjax.Error("ban");
                return;
            }

            string sql = "select Vote from News_Info where NewsSN=" + id;
            SqlDataSelect d = new SqlDataSelect(sql);
            if (d.Count > 0)
            { }
            else
            {
                msgAjax.Error("不存在此新闻");
                return;
            }

            string vote = d.Eval("Vote").ToString();
            JavaScriptObject jsoVote = null;
            try
            {
                jsoVote = (JavaScriptObject)JavaScriptConvert.DeserializeObject(vote);

            }
            catch
            {
                jsoVote = new JavaScriptObject();
            }
            finally
            {
                if (jsoVote == null)
                    jsoVote = new JavaScriptObject();
            }

            sql = "select top 1 1 from Vote_Class where PClassSN in(select ClassSN from Vote_Class where Str='news') and Str=@Str";
            IDataParameter[] dp = {
                                      DbHelp.Def.AddParam("@Str",s),
                                      };

            if (DbHelp.First(sql, dp, "0") == "1")
            {
                object val;
                if (jsoVote.TryGetValue(s, out val))
                {
                    jsoVote[s] = Fn.IsInt(val.ToString(), 0) + 1;
                }
                else
                {
                    jsoVote.Add(s, "1");
                }
            }
            else
            {
                msgAjax.Error("不存在此投票项");
                return;
            }

            if (jsoVote.Count > 0)
            {
                sql = "update News_Info set Vote=@Vote where NewsSN=" + id;
                IDataParameter[] dp1 = {
                                      DbHelp.Def.AddParam("@Vote",JavaScriptConvert.SerializeObject(jsoVote)),
                                      };
                DbHelp.Update(sql, dp1);
                banH.Add();
                msgAjax.Success("1");
            }
            else
            {
                msgAjax.Error("投票失败");
            }
        }
    }
}
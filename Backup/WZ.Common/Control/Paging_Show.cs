using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using WZ.Common;
using System.Web;

namespace WZ.Common.Control
{
    /// <summary>
    /// 分页
    /// </summary>
    [ToolboxData("<w:Paging_Show id=ucPS1 runat=server></w:Paging_Show>")]
    public class Paging_Show : System.Web.UI.Control//, IPostBackEventHandler
    {
        #region 属性变量
        private string _string_format;
        private string _string_format_sel;
        private string _string_format_first;
        private string _string_format_last;
        private string _string_format_prv;
        private string _string_format_next;
        private string _string_format_span;

        private int _prv_count = 5;
        private int _next_count = 5;
        private IPaging _f = null;

        private string _cs = string.Empty;

        #endregion

        #region private 没有属性
        private int page_index;
        private int page_count;
        private int records_count;

        private bool show_prv = false;
        private bool show_next = false;
        private bool isShowJump = true;

        private int startPage;
        private int endPage;
        private string query_param;
        private StringBuilder sb = new StringBuilder();

        private Dictionary<string, string> _dict;
        #endregion

        /// <summary>
        /// 分页控件样式
        /// </summary>
        public string Style = string.Empty;

        #region 计算开始与结束页码
        // 根据当前页，当前页之前可以显示的页数，算得从第几页开始进行显示
        private void SetStartPage()
        {

            // 如果当前页小于它前面所可以显示的条目数，
            // 那么显示第一页就是实际的第一页
            if (page_index <= prv_count)
            {
                startPage = 1;
            }
            else
            // 这种情况下 page_index 前面总是能显示完，
            // 要根据后面的长短确定是不是前面应该多显示
            {
                if (page_index > prv_count + 1)
                    show_prv = true;

                int linkLength = (page_count - page_index + 1) + prv_count;//实际显示个数

                int startPage = page_index - prv_count;


                //计算出需要要显示几个 的开始位置
                while (linkLength < (prv_count + next_count + 1) && startPage > 1)
                {
                    linkLength++;
                    startPage--;
                }

                this.startPage = startPage;
            }
        }

        // 根据page_index、总页数、当前页之后长度 算得显示的最末页是 第几页
        private void SetEndPage()
        {
            // 如果当前页加上它之后可以显示的页数 大于 总页数，
            // 那么显示的最末页就是实际的最末页
            if (page_index + next_count >= page_count)
            {
                endPage = page_count;
            }
            else
            {

                // 这种情况下 page_index后面的总是可以显示完，
                // 要根据前面的长短确定是不是后面应该多显示

                int linkLength = (page_index - startPage + 1) + next_count;

                int endPage = page_index + next_count;

                while (linkLength < prv_count + next_count + 1 && endPage < page_count)
                {
                    linkLength++;
                    endPage++;
                }

                if (endPage < page_count)
                    show_next = true;

                this.endPage = endPage;
            }
        }
        #endregion

        #region 输出Html
        protected override void Render(HtmlTextWriter output)
        {
            if (Page.IsPostBack || f == null)
             return;

            //若未指定URL格式 则按系统默认提取
            if (cs.Length == 0)
            {
                URLPara urlp = new URLPara();
                urlp.QueryStringToURLPara();
                cs = urlp.ToString("p", "{0}");
            }

            page_index = f.um.page_index;
            page_count = f.um.page_count;
            query_param = "p";
            records_count = f.um.records_count;

            SetStartPage();
            SetEndPage();
           

            if (Style.Length == 0)
            {
                OnLoad_Default();
                Render_Default(output);
            }
            else
            {
                switch (Style.ToLower())
                {
                    case "style1":
                        OnLoad_Style1();
                        Render_Style1(output);
                        break;

                    case "ajax_style_1":
                        OnLoad_Ajax_Style_1();
                        Render_Ajax_Style_1(output);
                        break;

                    default:
                        OnLoad_Default();
                        Render_Default(output);
                        break;
                }
            }

        }
        #endregion

        #region 样式 Style1
        private void OnLoad_Style1()
        {
            _string_format = "<a href=\"{0}\">{1}</a>";
            _string_format_sel = "<a class=\"cp\">{0}</a>";
            _string_format_first = "<a href=\"{0}\" title=\"第一页\"><<</a>";
            _string_format_last = "<a href=\"{0}\" title=\"最后一页\">>></a>";
            _string_format_prv = "<a href=\"{0}\" title=\"上一页\"><</a>";
            _string_format_next = "<a href=\"{0}\" title=\"下一页\">></a>";
            _string_format_span = "<span class=\"s1\">共<b>{2}</b>条 第<b>{0}</b>页/共<b>{1}</b>页</span>";

            string_format = string.Format(string_format, cs, "{0}");

            if (show_prv)
                string_format_first = string.Format(string_format_first, string.Format(cs, "1"));
            else
                string_format_first = string.Empty;

            if (show_next)
                string_format_last = string.Format(string_format_last, string.Format(cs, page_count));
            else
                string_format_last = string.Empty;

            if (page_index > 1)
                string_format_prv = string.Format(string_format_prv, string.Format(cs, page_index - 1));
            else
                string_format_prv = string.Empty;

            if (page_index < page_count)
                string_format_next = string.Format(string_format_next, string.Format(cs, page_index + 1));
            else
                string_format_next = string.Empty;

            string_format_span = string.Format(string_format_span, page_index, page_count, records_count);


            for (int i = startPage; i <= endPage; i++)
            {
                if (i == page_index)
                    sb.Append(string.Format(string_format_sel, i));
                else
                    sb.Append(string.Format(string_format, i));
            }
        }

        private void Render_Style1(HtmlTextWriter output)
        {
            output.Write("<span class=\"pagination\">");
            output.Write(string_format_first);
            output.Write(string_format_prv);
            output.Write(sb.ToString());
            output.Write(string_format_next);
            output.Write(string_format_last);
            output.Write("</span>");

            output.Write(string_format_span);

            if (isShowJump)
            {
                string unid = this.UniqueID;
                string input_text_id = "__" + query_param + unid;
                string js_name = "__jump" + unid;


                output.Write("<span class=\"s2\">");
                output.Write("到第<input type=\"text\" class=\"jump_input\" name=\"" + input_text_id + "\" maxlength=\"8\" value=\"" + (page_index + 1) + "\" />页 ");
                output.Write("<input type=\"button\" class=\"list_p6\" value=\"确定\" onclick=\"" + js_name + "()\" />");
                output.Write("<script type=\"text/javascript\">");

                output.Write("function " + js_name + "(){");
                output.Write("var __param=\"");
                #region
                if (this.Dict != null)
                {
                    foreach (string sKey in this.Dict.Keys)
                    {
                        if (sKey == query_param)
                            continue;

                        output.Write("&");
                        output.Write(sKey);
                        output.Write("=");
                        output.Write(HttpContext.Current.Server.UrlEncode(this.Dict[sKey]));
                    }
                }
                else
                {
                    foreach (string s in HttpContext.Current.Request.QueryString)
                    {
                        if (s == null || s == query_param)
                            continue;

                        output.Write("&");
                        output.Write(s);
                        output.Write("=");
                        output.Write(HttpContext.Current.Server.UrlEncode(Req.GetQueryString(s)));

                    }
                }
                output.Write("\";");
                #endregion

                output.Write("var __cururl='" + HttpContext.Current.Request.Url.AbsolutePath + "';");
                output.Write("var __query_p='?" + query_param + "='+document.getElementById('" + input_text_id + "').value;");
                output.Write("location.href=__cururl+__query_p+__param;");
                output.Write("}");
                output.Write("</script>");
                output.Write("</span>");

            }
        }
        #endregion

        #region 样式 Default
        private void OnLoad_Default()
        {
            _string_format = "<a href=\"{0}\">{1}</a>";
            _string_format_sel = "<a class=\"cp\">{0}</a>";
            _string_format_first = "<a href=\"{0}\" class=\"first\">首页</a>";
            _string_format_last = "<a href=\"{0}\" class=\"next\">尾页</a>";
            _string_format_prv = "<a href=\"{0}\" class=\"previous\">上一页</a>";
            _string_format_next = "<a href=\"{0}\" class=\"next\">下一页</a>";
            _string_format_span = "<span>共<b>{0}</b>条 第<b>{1}</b>页/共<b>{2}</b>页</span>";

            string_format = string.Format(string_format, cs, "{0}");

            if (show_prv)
                string_format_first = string.Format(string_format_first, string.Format(cs, "1"));
            else
                string_format_first = string.Empty;

            if (show_next)
                string_format_last = string.Format(string_format_last, string.Format(cs, page_count));
            else
                string_format_last = string.Empty;

            if (page_index > 1)
                string_format_prv = string.Format(string_format_prv, string.Format(cs, page_index - 1));
            else
                string_format_prv = string.Empty;

            if (page_index < page_count)
                string_format_next = string.Format(string_format_next, string.Format(cs, page_index + 1));
            else
                string_format_next = string.Empty;

            string_format_span = string.Format(string_format_span, records_count, page_index, page_count);

            for (int i = startPage; i <= endPage; i++)
            {
                if (i == page_index)
                    sb.Append(string.Format(string_format_sel, i));
                else
                    sb.Append(string.Format(string_format, i));
            }
        }

        private void Render_Default(HtmlTextWriter output)
        {
            output.Write(string_format_span);
            output.Write(string_format_first);
            output.Write(string_format_prv);
            output.Write(sb.ToString());
            output.Write(string_format_next);
            output.Write(string_format_last);

            if (isShowJump)
            {
                output.Write("<span class=\"s2\"><form method=\"get\">");
                output.Write("到第<input type=\"text\" class=\"jump_input\" name=\"" + query_param + "\" maxlength=\"8\" value=\"" + (page_index + 1) + "\" />页 ");
                output.Write("<button type=\"submit\" class=\"list_p6\">确定</button>");

                if (this.Dict != null)
                {
                    foreach (string sKey in this.Dict.Keys)
                    {
                        output.Write("<input type=\"hidden\" name=\"" + sKey + "\" value=\"" + this.Dict[sKey] + "\" />");
                    }
                }
                else
                {
                    foreach (string s in HttpContext.Current.Request.QueryString)
                    {
                        if (s == query_param)
                            continue;

                        output.Write("<input type=\"hidden\" name=\"" + s + "\" value=\"" + Req.GetQueryString(s) + "\" />");
                    }
                }

                output.Write("</form></span>");

            }
        }
        #endregion

        #region 样式 Ajax_Style_1
        private void OnLoad_Ajax_Style_1()
        {
            _string_format = "<a href=\"{0}\">{1}</a>";
            _string_format_sel = "<a class=\"cp\">{0}</a>";
            _string_format_first = "<a href=\"{0}\" class=\"first\">首页</a>";
            _string_format_last = "<a href=\"{0}\" class=\"next\">尾页</a>";
            _string_format_prv = "<a href=\"{0}\" class=\"previous\">上一页</a>";
            _string_format_next = "<a href=\"{0}\" class=\"next\">下一页</a>";
            _string_format_span = "<span>共<b>{0}</b>条 第<b>{1}</b>页/共<b>{2}</b>页</span>";

            string_format = string.Format(string_format, cs, "{0}");

            if (show_prv)
                string_format_first = string.Format(string_format_first, string.Format(cs, "1"));
            else
                string_format_first = string.Empty;

            if (show_next)
                string_format_last = string.Format(string_format_last, string.Format(cs, page_count));
            else
                string_format_last = string.Empty;

            if (page_index > 1)
                string_format_prv = string.Format(string_format_prv, string.Format(cs, page_index - 1));
            else
                string_format_prv = string.Empty;

            if (page_index < page_count)
                string_format_next = string.Format(string_format_next, string.Format(cs, page_index + 1));
            else
                string_format_next = string.Empty;

            string_format_span = string.Format(string_format_span, records_count, page_index, page_count);

            for (int i = startPage; i <= endPage; i++)
            {
                if (i == page_index)
                    sb.Append(string.Format(string_format_sel, i));
                else
                    sb.Append(string.Format(string_format, i));
            }
        }

        private void Render_Ajax_Style_1(HtmlTextWriter output)
        {
            output.Write(string_format_span);
            output.Write(string_format_first);
            output.Write(string_format_prv);
            output.Write(sb.ToString());
            output.Write(string_format_next);
            output.Write(string_format_last);
        }
        #endregion

        #region 属性
        /// <summary>
        /// 普通连接格式
        /// </summary>
        public string string_format
        {
            get { return _string_format; }
            set { _string_format = value; }
        }

        /// <summary>
        /// 选中格式
        /// </summary>
        public string string_format_sel
        {
            get { return _string_format_sel; }
            set { _string_format_sel = value; }
        }

        /// <summary>
        /// 首页
        /// </summary>
        public string string_format_first
        {
            get { return _string_format_first; }
            set { _string_format_first = value; }
        }

        /// <summary>
        /// 尾页
        /// </summary>
        public string string_format_last
        {
            get { return _string_format_last; }
            set { _string_format_last = value; }
        }

        /// <summary>
        /// 上一页
        /// </summary>
        public string string_format_prv
        {
            get { return _string_format_prv; }
            set { _string_format_prv = value; }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        public string string_format_next
        {
            get { return _string_format_next; }
            set { _string_format_next = value; }
        }

        /// <summary>
        /// 页码显示格式
        /// </summary>
        public string string_format_span
        {
            get { return _string_format_span; }
            set { _string_format_span = value; }
        }

        /// <summary>
        /// 当前页 前面个数 prv_count = 5
        /// </summary>
        public int prv_count
        {
            get { return _prv_count; }
            set { _prv_count = value; }
        }

        /// <summary>
        /// 当前页后面个数 next_count = 5
        /// </summary>
        public int next_count
        {
            get { return _next_count; }
            set { _next_count = value; }
        }

        /// <summary>
        /// suger.model.fy 类型
        /// </summary>
        public IPaging f
        {
            get { return _f; }
            set { _f = value; }
        }

        /// <summary>
        /// 格式 ?p={0}
        /// </summary>
        public string cs
        {
            get { return _cs; }
            set { _cs = value; }
        }

        public bool IsShowJump
        {
            get { return isShowJump; }
            set { isShowJump = value; }
        }
        #endregion

        public Dictionary<string, string> Dict
        {
            get { return this._dict; }
            set { this._dict = value; }
        }

        #region IPostBackEventHandler 成员
        //public event EventHandler Click;

        //protected virtual void OnClick(EventArgs e)
        //{
        //    if (Click != null)
        //    {
        //        Click(this, e);
        //    }
        //}

        //public void RaisePostBackEvent(string eventArgument)
        //{
        //    OnClick(EventArgs.Empty);
        //}
        #endregion
    }

}
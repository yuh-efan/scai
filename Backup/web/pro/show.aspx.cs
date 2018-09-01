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
using WZ.Data;
using WZ.Common.CacheData;
using WZ.Common;
using WZ.Client.Data;
using WZ.Common.Config;
using System.Collections.Generic;
using System.Text;
using WZ.Data.Layout;

namespace WZ.Web.pro
{
    public partial class show : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/pro/show.aspx/");
        private int item = 0;

        protected SqlDataSelect d;
        protected int id;
        protected int fraction;
        protected string pageItem;
        protected string pageMS;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();

            string hid = Req.GetForm("hid");
            if (hid == "1")
            {
                string cmd = Req.GetForm("cmd");
                switch (cmd)
                {
                    case "ajax_page_eval":
                        EvaluateList_ajaxPage();
                        break;

                    case "ajax_page_msg":
                        MsgList_ajaxPage();
                        break;
                }
                Response.End();
            }

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sSQL = "select FK_Pro_Class,JoinType,ProName,Number,PicS,PicB,Price,Price1,PriceMarket,PriceCost,UnitNum,Unit,SellN,SellN1,hit,Detail1,Detail2,AddDate,ProIsHas,Item,MS_StartTime,MS_EndTime from vgPro_Info where ProSN=" + id;
            d = new SqlDataSelect(sSQL);

            if (d.Count > 0)
            {
                item = int.Parse(d.Eval("Item").ToString());
                int FK_Pro_Class = Convert.ToInt32(d.Eval("FK_Pro_Class"));
                CurPath(FK_Pro_Class);//位置

                //ShowAttr();//菜篮子 无公害
                GetItemValue();//显示属性

                GetMS();//秒杀
                Relate();//相关食谱,套餐
                GetGZ();//关注

                PicList();//商品多张图片
                EvaluateList();//评价列表
                ProSameClass(FK_Pro_Class);
                //this.ucHistory.ProID = id;

                FnData.SetHistory("proHistory", id, 5);

                GetFraction();
                HitAdd();
            }
        }

        #region 商品多张图片
        private void PicList()
        {
            string sSql = "select PicS,PicB from Pro_Pic where FK_Pro=" + id;
            DataTable dtPic = DbHelp.GetDataTable(sSql);
            if (dtPic.Rows.Count > 1)
            {
                Bind.BGRepeater(dtPic, this.rpPic);
            }
        }
        #endregion

        #region 位置
        private void CurPath(int pClassID)
        {
            DataTable dtProClass = PubData.GetDataTable("pro_class");

            GetClassPath gcp = new GetClassPath(GetURL.Pro.Class("{0}"));
            ClassPath cp = new ClassPath(dtProClass, gcp);
            cp.Exe(pClassID);
            this.curPath.Text = gcp.GetPath;
        }
        #endregion

        #region 评论相关
        private void EvaluateList()
        {
            string sSql = "select top 10 ev.Fraction,ev.Detail,ev.ReDetail,ev.AddDate,ui.UserName from Pro_Evaluate ev left join User_Info ui on ev.FK_User=ui.UserSN where Purview=1 and FK_Pro=" + id + " order by ev.AddDate desc";

            DataTable dt = DbHelp.GetDataTable(sSql);
            Bind.BGRepeater(dt, this.rpEvaluate);
        }

        private void MsgList()
        {
            string sSql = "select top 10 ev.Detail,ev.ReDetail,ev.AddDate,ui.UserName from Pro_Msg ev left join User_Info ui on ev.FK_User=ui.UserSN where Purview=1 and FK_Pro=" + id + " order by ev.AddDate desc";
            DataTable dt = DbHelp.GetDataTable(sSql);
            Bind.BGRepeater(dt, this.rpMsg);
        }

        private void EvaluateList_ajaxPage()
        {
            EvaluateList();
            Response.Write(Fn.GetControlHtml(this.comment));
            Response.End();
        }

        private void MsgList_ajaxPage()
        {
            MsgList();
            Response.Write(Fn.GetControlHtml(this.comment1));
            Response.End();
        }

        private void GetFraction()
        {
            string sSql = "select count(0) as cou,sum(Fraction) as sum from Pro_Evaluate where FK_Pro=" + id;
            using (IDataReader dr = DbHelp.Read(sSql))
            {
                if (dr.Read())
                {
                    int cou = int.Parse(dr["cou"].ToString());
                    int sum = Fn.IsInt(dr["sum"].ToString(), 0);
                    if (cou > 0)
                        fraction = sum / cou;
                    else
                        fraction = 5;
                }
            }

        }
        #endregion

        #region 菜篮子 无公害
        //private void ShowAttr()
        //{
        //    int Item = Convert.ToInt32(d.Eval("Item"));

        //    int iItem2 = (int)PubEnum.ProItem.无公害;
        //    if (d.Eval("JoinType").ToString()=="0")
        //        this.liAttr1.Visible = true;

        //    if ((Item & iItem2) == iItem2)
        //        this.liAttr2.Visible = true;
        //}
        #endregion

        #region 同类产品
        private void ProSameClass(int pClassID)
        {
            string sql = string.Format("select top 4 ProSN,ProName,PicS,Price,Item from vgPro_Info a,T_Pro_Class_GetChildAndSelf({0}) b where a.FK_Pro_Class=b.id order by EditDate desc", pClassID);
            DataTable dt = cac.GetDataTable("pro_sameclass" + pClassID, sql);
            this.rpProSameClass.dt = dt;
            this.rpProSameClass.listEvent = new CycleEvent(ProLay.d_list3);

            //Bind.BGRepeater(dt, this.rpProSameClass);
        }
        #endregion

        #region hit+1
        private void HitAdd()
        {
            string sql = "update Pro_Info set Hit=Hit+1 where ProSN=" + id;
            DbHelp.Update(sql);
        }
        #endregion

        #region 显示属性
        private void GetItemValue()
        {
            const string fmat = "<li><img src=\"/images/item_detail/Label_{0}.gif\" alt=\"{1}\" /></li>";
            StringBuilder sb = new StringBuilder();

            if (d.Eval("JoinType").ToString() == "0")
                sb.Append(string.Format(fmat, "01", "菜篮子"));

            if ((item & 128) == 128)
                sb.Append(string.Format(fmat, "02", "无公害"));

            if ((item & 1) == 1)
                sb.Append(string.Format(fmat, "03", "新品"));

            if ((item & 2) == 2)
                sb.Append(string.Format(fmat, "04", "推荐"));

            if ((item & 8) == 8)
                sb.Append(string.Format(fmat, "05", "热销"));

            pageItem = sb.ToString();
        }
        #endregion

        #region 秒杀,促销
        private void GetMS()
        {
            if ((item & 16) == 16)
            {
                DateTime MS_StartTime = Fn.IsDate(d.Eval("MS_StartTime").ToString(), DateTime.Now.AddDays(-1));
                DateTime MS_EndTime = Fn.IsDate((d.Eval("MS_EndTime").ToString()), DateTime.Now.AddDays(-1));
                DateTime now = DateTime.Now;

                if (MS_StartTime > now || MS_EndTime < now)
                { }
                else
                {
                    string startTime = d.Eval("MS_StartTime").ToString();
                    string endTime = d.Eval("MS_EndTime").ToString();

                    DateTime startTime1;
                    DateTime endTime1;

                    if(DateTime.TryParse(startTime,out startTime1))
                    {
                        startTime = startTime1.ToString("MM-dd hh:mm");
                    }

                    if (DateTime.TryParse(endTime, out endTime1))
                    {
                        endTime = endTime1.ToString("MM-dd hh:mm");
                    }

                    pageMS = "<li class=\"SecKill\">秒杀价格：<span class=\"red3\">￥" + d.Eval("Price1") + "</span> 从<em>" + startTime + "</em>到<em>" + endTime + "</em></li>";
                }
            }
            else if ((item & 4) == 4)
            {
                pageMS = "<li>促销：<span class=\"Red2\">￥" + d.Eval("Price1") + "</span>";
            }
        }
        #endregion

        #region 相关食谱
        protected DataTable relateDt;
        private void Relate()
        {
            string caiPuID = string.Empty;
            string sql = "select top 5 ProSN,ProName,PicS from vgCaiPu_Info where ProSN in (select FK_CaiPu from CaiPu_Pro where FK_Pro=" + id + ") order by EditDate desc";
            relateDt = DbHelp.GetDataTable(sql);

            this.rpRelateCaiPu.dt = relateDt;
            this.rpRelateCaiPu.listEvent = CaiPuLay.d_list2;
        }
        #endregion

        //关注排行
        private void GetGZ()
        {
            int classID = int.Parse(d.Eval("FK_Pro_Class").ToString());

            string sql = "select top 10 ProSN,ProName,PicS,Price from vgPro_Info a ,T_Pro_Class_GetChildAndSelf(" + classID + ") b where a.FK_Pro_Class=b.id order by Hit desc, EditDate desc";
            DataTable dt = cac.GetDataTable("pro_classgz" + classID, sql);

            this.rpGZ.dt = dt;
            this.rpGZ.listEvent = ProLay.d_list4;
        }
    }
}
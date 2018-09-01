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
using System.Text;
using WZ.Data.Layout;

namespace WZ.Web.taoCan
{
    public partial class show : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/taoCan/show.aspx/");
        protected SqlDataSelect d;
        protected int id;
        protected int fraction;
        protected StringBuilder pageClassAttr = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sSQL = "select FK_Pro_Class,FK_Join,ProName,Number,PicS,PicB,UnitNum,Unit,StockN,SellN,SellN1,hit,Detail1,Detail2,AddDate,EditDate,ProIsHas,Item from vgTaoCan_Info where ProSN=" + id;
            d = new SqlDataSelect(sSQL);

            if (d.Count > 0)
            {
                int FK_Pro_Class = Convert.ToInt32(d.Eval("FK_Pro_Class"));
                CurPath(FK_Pro_Class);//位置

                ShowAttr();//显示属性
                GetClassAttr();//分类属性
                Relate();
                GetGZ();//关注 
                
                PicList();//商品多张图片
                EvaluateList();//评价列表
                SameClass(FK_Pro_Class);
                //this.ucHistory.ProID = id;
                FnData.SetHistory("taoCanHistory", id, 5);
                GetFraction();
                HitAdd();
                GetChild();
            }
        }

        #region 商品多张图片
        private void PicList()
        {
            string sSql = "select PicS,PicB from TaoCan_Pic where FK_Pro=" + id;
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
            DataTable dtClass = PubData.GetDataTable("TaoCan_Class");

            GetClassPath gcp = new GetClassPath(GetURL.TaoCan.Class("{0}"));
            ClassPath cp = new ClassPath(dtClass, gcp);
            cp.Exe(pClassID);
            this.curPath.Text = " &gt; <a href=\"" + GetURL.TaoCan.Default() + "\">营养套餐</a>" + gcp.GetPath;
        }
        #endregion

        #region 评论相关
        private void EvaluateList()
        {
            string sSql = "select top 5 ev.Fraction,ev.FK_User,ev.Detail,ev.ReDetail,ev.AddDate,ui.UserName from TaoCan_Evaluate ev left join User_Info ui on ev.FK_User=ui.UserSN where Purview=1 and FK_Pro=" + id + " order by ev.AddDate desc";
            DataTable dt = DbHelp.GetDataTable(sSql);
            Bind.BGRepeater(dt, this.rpEvaluate);
        }

        private void GetFraction()
        {
            string sSql = "select count(0) as cou,sum(Fraction) as sum from TaoCan_Evaluate where FK_Pro=" + id;
            using (IDataReader dr = DbHelp.Read(sSql))
            {
                if (dr.Read())
                {
                    int cou = int.Parse(dr["cou"].ToString());
                    int sum = Fn.IsInt(dr["sum"].ToString(), 0);
                    if (cou > 0)
                        fraction = sum / cou;
                    else
                        fraction = 0;
                }
            }

        }
        #endregion

        #region 显示属性
        private void ShowAttr()
        {
            int Item = Convert.ToInt32(d.Eval("Item"));

            int iItem1 = (int)PubEnum.TaoCanItem.菜蓝子;
            int iItem2 = (int)PubEnum.TaoCanItem.无公害;
            if ((Item & iItem1) == iItem1)
                this.liAttr1.Visible = true;

            if ((Item & iItem2) == iItem2)
                this.liAttr2.Visible = true;
        }
        #endregion
        
        #region 同类产品
        private void SameClass(int pClassID)
        {
            string sSQL = string.Format("select top 4 ProSN,ProName,PicS,Price,Item from TaoCan_Info a,T_TaoCan_Class_GetChildAndSelf({0}) b where a.FK_Pro_Class=b.id order by EditDate desc", pClassID);
            DataTable dt = DbHelp.GetDataTable(sSQL);
            this.rpSameClass.dt = dt;
            this.rpSameClass.listEvent = new CycleEvent(TaoCanLay.list1);
            //Bind.BGRepeater(dt, this.rpSameClass);
        }
        #endregion

        #region hit+1
        private void HitAdd()
        {
            string sql = "update TaoCan_Info set Hit=Hit+1 where ProSN=" + id;
            DbHelp.Update(sql);
        }
        #endregion

        #region 菜谱
        private void GetChild()
        {
            //string sSql="select pi.ProSN,pi.ProName,pi.Price,pi.PicS from "
            //    + "vgPro_Info pi left join CaiPu_Pro caip on pi.ProSN=caip.FK_Pro "
            //    + "left join TaoCan_Pro taoc on caip.FK_CaiPu=taoc.FK_CaiPu"
            //    + " where taoc.FK_TaoCan=" + id;

            string sql;

            sql = "select ci.ProSN,ci.ProName,ci.PicS from TaoCan_CaiPu tc left join vgCaiPu_Info ci on tc.FK_CaiPu=ci.ProSN where tc.FK_TaoCan=" + id;
            Bind.BGRepeater(sql, this.rpChild);

            sql = "select pi.ProSN,pi.ProName,pi.Price,pi.PicS from TaoCan_Pro tc left join vgPro_Info pi on tc.FK_CaiPu=pi.ProSN where tc.FK_TaoCan=" + id;
            Bind.BGRepeater(sql, this.rpChild1);
        }
        #endregion

        #region 分类属性
        private void GetClassAttr()
        {
            DataTable dtClassAttr = PubData.GetDataTable("TaoCan_ClassAttr");

            string sql = "select FK_Info_ClassAttr1,FK_Info_ClassAttr2 from TaoCan_ClassAttrInfo where FK_Info=" + id;
            DataTable dt = DbHelp.GetDataTable(sql);

            foreach (DataRow drw in dt.Rows)
            {
                string a1 = string.Empty;
                string a2 = string.Empty;
                foreach (DataRow drw1 in dtClassAttr.Rows)
                {
                    if (drw["FK_Info_ClassAttr1"].ToString() == drw1["ClassSN"].ToString())
                    {
                        a1 = "<span>" + drw1["ClassName"].ToString() + "</span>";
                    }

                    if (drw["FK_Info_ClassAttr2"].ToString() == drw1["ClassSN"].ToString())
                    {
                        a2 = "<a href=\"/search/taoCan.aspx?s=------" + drw1["ClassSN"] + "\" target=\"_blank\" title=\"搜索与'" + drw1["ClassName"].ToString() + "'相关的套餐\">" + drw1["ClassName"].ToString() + "</a>";
                    }
                }

                if (a1.Length > 0)
                {
                    pageClassAttr.Append("<li>");
                    pageClassAttr.Append(a1);
                    pageClassAttr.Append(a2);
                    pageClassAttr.Append("</li>");
                }

            }

        }
        #endregion

        #region 相关食谱,套餐
        public void Relate()
        {
            string sql = "select top 6 ProSN,ProName,PicS from vgTaoCan_Info where ProSN in (select FK_TaoCan from TaoCan_Pro where FK_CaiPu in (select FK_CaiPu from TaoCan_Pro where FK_TaoCan=" + id + ")) order by EditDate desc";
            this.rpRelateTaoCan.dt = DbHelp.GetDataTable(sql);
            this.rpRelateTaoCan.listEvent = new CycleEvent(TaoCanLay.list1);
            //Bind.BGRepeater(sql, this.rpRelateTaoCan);

            //sql = "select top 6 ProSN,ProName,PicS from TaoCan_Info where ProSN in (select FK_TaoCan from TaoCan_Pro where FK_CaiPu =" + id + ") order by EditDate desc";
            //Bind.BGRepeater(sql, this.rpRelateTaoCan);
        }
        #endregion

        public void GetGZ()
        {
            int classID = int.Parse(d.Eval("FK_Pro_Class").ToString());

            string sql = "select top 10 ProSN,ProName,PicS from vgTaoCan_Info a ,T_TaoCan_Class_GetChildAndSelf(" + classID + ") b where a.FK_Pro_Class=b.id order by Hit desc, EditDate desc";
            DataTable dt = DbHelp.GetDataTable(sql);

            this.rpGZ.dt = dt;
            this.rpGZ.listEvent = new CycleEvent(TaoCanLay.list2);
        }
    }
}

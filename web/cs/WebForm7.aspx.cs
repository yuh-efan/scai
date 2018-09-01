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
using System.Collections.Generic;

namespace WZ.Web.cs
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        public delegate void mydelegate(string s, string a);
        public delegate string mydelegate1(string s, string a);

        protected void Page_Load(object sender, EventArgs e)
        {
            mydelegate deg;
            mydelegate1 deg1;

            

            deg = delegate(string s, string a)
            {
                Response.Write(s + "<br>");
                Response.Write(a + "<br>");
            };

            deg += (s, a) =>
            {
                Response.Write(s + "<br>");
                Response.Write(a + "<br>");
            };


            deg1 = (s, a) => { return s + a; };

            deg("2222222", "fffffffff");

            var g = BLL.Get部门();
            BindDepartment(g);

        }

        private void BindDepartment(部门 g)
        {
            //var treenode = new TreeNode { Text = g.名称, Value = g.编号 };
            //treeNodeCollection.Add(treenode);

            Response.Write(g.名称 + "<br>");

            if (g.下级部门.Count > 0)
                g.下级部门.ForEach(x => { BindDepartment(x); });


            //if (g.下级部门.Count > 0)
            //    g.下级部门.ForEach(new Action<部门>(BindDepartment));
        }




    }

    public class 部门
    {
        public string 名称 { get; set; }

        public string 编号 { get; set; }

        private List<部门> _children = new List<部门>();

        public List<部门> 下级部门
        {
            get
            {
                return _children;
            }
        }
    }

    public class 员工
    {
        public string 姓名 { get; set; }
        public int 生日_月 { get; set; }
        public int 生日_日 { get; set; }
    }

    public static class BLL
    {
        private static Random Rnd = new Random();

        public static 部门 Get部门()
        {
            var x = new 部门 { 名称 = "公司", 编号 = "0" };
            var x1 = new 部门 { 名称 = "总经办", 编号 = "001" };
            var x3 = new 部门 { 名称 = "人事劳资", 编号 = "003" };
            x.下级部门.Add(x1);
            x.下级部门.Add(x3);
            var x32 = new 部门 { 名称 = "食堂", 编号 = "00302" };
            x3.下级部门.Add(x32);
            return x;
        }

        public static List<员工> Get部门员工(string code)
        {
            if (code == null)
                return new List<员工>();

            var ret = new List<员工>();
            for (var i = 0; i < Rnd.Next(10, 101); i++)
                ret.Add(new 员工
                {
                    姓名 = "部门" + code + "员工_" + i.ToString(),
                    生日_月 = Rnd.Next(1, 13),
                    生日_日 = Rnd.Next(1, 29)
                });
            return ret;
        }
    }

}

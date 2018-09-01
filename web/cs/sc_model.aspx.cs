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

namespace WZA.Web.cs
{
    public partial class sc_model : System.Web.UI.Page
    {
        private string tn;
        protected void Page_Load(object sender, EventArgs e)
        {
            tn = Req.GetQueryString("tn");

            Response.Write(tn);
            Response.End();

            if (tn.Length > 0)
            {
                insert();
                update();
                para();
                a1();
                a2();
                a3();
                fz();
                fzMod();
                winput();
            }
        }

        //输出input
        public void winput()
        {
            br();
            w("----------输出input------------");
            br();
            string f = "<tr><td><asp:TextBox ID=\"txt{0}\" runat=\"server\"></asp:TextBox></td></tr>";
            w("<table>");
            using (IDataReader dr = DbHelp.Read("select top 1 * from " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    string t = gettype(dr.GetFieldType(i).ToString());
                    w(string.Format(f, dr.GetName(i)));
                }
                dr.Close();
            }
            w("</table>");

        }

        //赋值
        public void fz()
        {
            br();
            w("----------赋值------------");
            br();
            string f = "this.c{0}.Text = dr[\"{1}\"].ToString();<br />";
            using (IDataReader dr = DbHelp.Read("select top 1 * from " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    string t = gettype(dr.GetFieldType(i).ToString());
                    w(string.Format(f, dr.GetName(i), dr.GetName(i)));


                }
                dr.Close();
            }

        }


        //赋值Mod
        public void fzMod()
        {
            br();
            w("----------赋值Mod------------");
            br();
            string f = "Mod.{0} = {1};<br />";
            using (IDataReader dr = DbHelp.Read("select top 1 * from " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    string t = gettype(dr.GetFieldType(i).ToString());
                    w(string.Format(f, dr.GetName(i), dr.GetName(i)));


                }
                dr.Close();
            }

            w("----------赋值string------------");
            br();
            f = "string {0} =  Req.GetForm(\"c{1}\").Trim();<br />";
            using (IDataReader dr = DbHelp.Read("select top 1 * from " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    string t = gettype(dr.GetFieldType(i).ToString());
                    w(string.Format(f, dr.GetName(i), dr.GetName(i)));


                }
                dr.Close();
            }

        }

        //声明变量
        public void a1()
        {
            br();
            w("----------声明变量------------");
            br();
            string f = "public {0} {1};<br />";
            
            using (IDataReader dr = DbHelp.Read("select top 1 * from " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    string t = gettype(dr.GetFieldType(i).ToString());
                    w(string.Format(f, t, dr.GetName(i)));


                }
                dr.Close();
            }

        }

        public void insert()
        {
            br();
            w("----------insert------------");
            br();
            string f = "{0},";
            string f1 = "@{0},";

           
            using (IDataReader dr = DbHelp.Read("select top 1 * from  " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    w(string.Format(f, dr.GetName(i)));
                }
                br();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    w(string.Format(f1, dr.GetName(i)));
                }
                dr.Close();
            }
        }


        public void para()
        {
            br();
            w("----------para------------");
            br();
            string f = "DbHelp.Def.AddParam(\"@{0}\",pMod.{1}),<br />";
            using (IDataReader dr = DbHelp.Read("select top 1 * from  " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    w(string.Format(f, dr.GetName(i), dr.GetName(i)));
                }
                dr.Close();
            }
        }

        public void update()
        {
            br();
            w("----------update------------");
            br();
            string f = "{0}=@{1},";
            using (IDataReader dr = DbHelp.Read("select top 1 * from  " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    w(string.Format(f, dr.GetName(i), dr.GetName(i)));
                }
                dr.Close();
            }
        }

        //枚举
        public void a2()
        {
            br();
            w("----------枚举------------");
            br();
            string f = "{0},<br />";
            using (IDataReader dr = DbHelp.Read("select top 1 * from  " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    w(string.Format(f, dr.GetName(i)));
                }
                dr.Close();
            }
        }

        //数组
        public void a3()
        {
            br();
            w("----------数组------------");
            br();
            string f = "\"{0}\",<br />";
            using (IDataReader dr = DbHelp.Read("select top 1 * from  " + tn))
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    w(string.Format(f, dr.GetName(i)));
                }
                dr.Close();
            }
        }

        private string gettype(string pType)
        {
            pType = pType.Replace("System.", "");
            pType = pType.Replace("Int32", "int");
            pType = pType.Replace("String", "string");
            pType = pType.Replace("Boolean", "byte");
            pType = pType.Replace("Decimal", "double");
            return pType;

        }

        private void br()
        {
            w("<br />");
        }

        private void w(object pStr)
        {
            Response.Write(pStr);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString()+"?tn="+this.TextBox1.Text.Trim());
        }
    }
}

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
using System.Reflection;
using System.Web.SessionState;

namespace WZ.Web.cs
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //IEnumerator enumerator = Session.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Response.Write("Session   Value: " + enumerator.Current.ToString() + " <br/> ");
            //}

            cla1 m = new cla1();
            
            Type type = m.GetType();
            MethodInfo[] arrM = type.GetMethods((BindingFlags)(int.Parse(Request.QueryString["a"])));

            //Response.Write(((BindingFlags)(int.Parse(Request.QueryString["a"]))) + "<br>");
            //Response.Write(((ddd)(3)) + "<br>");
            //SessionStateModule ssm = new SessionStateModule();



            foreach (MethodInfo mi in arrM)
            {

                //mi.Invoke(m);
                if (mi.Name == "aaa")
                {
                    mi.Invoke(m, null);
                }

                //HttpContext.Current.Response.Write(mi.MethodHandle.Value + " " + mi.Name + "<br>");

            }


        }

        public class cla1
        {
            private void aaa()
            {
                HttpContext.Current.Response.Write("fffffffff<br>");
            }
        }

        [Flags]
        public enum ddd
        { 
            aaa=1,
            bbb=2
        }
    }


}

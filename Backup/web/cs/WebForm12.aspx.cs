using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Web.Caching;
using WZ.Common;


namespace WZ.Web.cs
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpRuntime.Cache["a1"] = DateTime.Now.Ticks;

            // Put page in default state.
            enabledTables.Visible = true;
            disableTable.Visible = true;
            enabledTablesMsg.Text = "Tables enabled for change notification:";

            tableName.Visible = true;
            enableTable.Visible = true;
            tableEnableMsg.Text = "Enable change notification on table(s):";
            enableTableErrorMsg.Visible = false;

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            
            try
            {
                string[] enabledTablesList =
                SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(ConnString.SqlServer);
                if (enabledTablesList.Length > 0)
                {
                    enabledTables.DataSource = enabledTablesList;
                    enabledTables.DataBind();
                }
                else
                {
                    enabledTablesMsg.Text = "No tables are enabled for change notifications.";
                    enabledTables.Visible = false;
                    disableTable.Visible = false;
                }
            }
            catch (DatabaseNotEnabledForNotificationException ex)
            {
                enabledTables.Visible = false;
                disableTable.Visible = false;
                enabledTablesMsg.Text = "Cache notifications are not enabled in this database.";

                tableName.Visible = false;
                enableTable.Visible = false;
                tableEnableMsg.Text = "Must enable database for notifications before enabling tables";
            }
        }

        protected void enableNotification_Click(object sender, EventArgs e)
        {
            SqlCacheDependencyAdmin.EnableNotifications(ConnString.SqlServer);
        }

        protected void disableNotification_Click(object sender, EventArgs e)
        {
            SqlCacheDependencyAdmin.DisableNotifications(ConnString.SqlServer);
        }

        protected void disableTable_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in enabledTables.Items)
            {
                if (item.Selected)
                {
                    SqlCacheDependencyAdmin.DisableTableForNotifications(ConnString.SqlServer,
                      item.Text);
                }
            }
        }
        protected void enableTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (tableName.Text.Contains(";"))
                {
                    string[] tables = tableName.Text.Split(new Char[] { ';' });
                    for (int i = 0; i < tables.Length; i++)
                        tables[i] = tables[i].Trim();

                    SqlCacheDependencyAdmin.EnableTableForNotifications(ConnString.SqlServer,
                      tables);
                }
                else
                {
                    SqlCacheDependencyAdmin.EnableTableForNotifications(ConnString.SqlServer,
                      tableName.Text);
                }
            }
            catch (HttpException ex)
            {
                enableTableErrorMsg.Text = "<br />" +
                  "An error occured enabling a table.<br />" +
                  "The error message was: " +
                  ex.Message;
                enableTableErrorMsg.Visible = true;
            }
        }

    }
}
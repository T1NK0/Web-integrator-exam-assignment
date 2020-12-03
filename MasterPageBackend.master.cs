using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageBackend : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"SELECT Users.*, Roles.*, FROM Users INNER JOIN Roles ON Users.fk_role_id = Roles.Role_id WHERE User_id = @User_id";
        cmd.Parameters.AddWithValue("@User_id", Convert.ToInt32(Session["bruger_id"]));



        if (Session["User_id"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void LinkButton_Logud_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Default.aspx");
    }
}

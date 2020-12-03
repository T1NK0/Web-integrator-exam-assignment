using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminReviews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_id"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if (Convert.ToInt32(Session["Role_id"]) == 2)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void Repeater_Accept_Deny_Reviews_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Slet")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"DELETE FROM Review WHERE Review_id = @Review_id";
            cmd.Parameters.AddWithValue("@Review_id", e.CommandArgument);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("AdminReviews.aspx");
        }

        if (e.CommandName == "Deny")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"UPDATE Review SET fk_confirm_id = 2 WHERE Review_id = @Review_id";
            cmd.Parameters.AddWithValue("@Review_id", e.CommandArgument);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("AdminReviews.aspx");
        }

        if (e.CommandName == "Accept")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"UPDATE Review SET fk_confirm_id = 1 WHERE Review_id = @Review_id";
            cmd.Parameters.AddWithValue("@Review_id", e.CommandArgument);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("AdminReviews.aspx");
        }
    }
}
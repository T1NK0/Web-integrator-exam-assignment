using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminFrontpageEditing : System.Web.UI.Page
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
    protected void Repeater_Ret_WelcomeText_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Slet")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"DELETE FROM Welcome_Text WHERE Welcome_id = @Welcome_id";
            cmd.Parameters.AddWithValue("@Welcome_id", e.CommandArgument);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("AdminFrontpageEditing.aspx");
        }

        if (e.CommandName == "Ret")
        {
            Panel_EditFrontpage.Visible = true;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Welcome_Text WHERE Welcome_id = @Welcome_id", conn);
            cmd.Parameters.AddWithValue("@Welcome_id", e.CommandArgument);
            ViewState["Welcome_id"] = e.CommandArgument;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TextBox_Title.Text = reader["Welcome_heading"].ToString();
                TextBox_Text.Text = reader["Welcome_text"].ToString();
            }
            conn.Close();
        }
    }

    protected void Button_Gem_Ret_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"UPDATE Welcome_Text SET Welcome_text = @text, Welcome_heading = @Heading WHERE Welcome_id = @Welcome_id";

        cmd.Parameters.AddWithValue("@Welcome_id", ViewState["Welcome_id"]);
        cmd.Parameters.AddWithValue("@Heading", TextBox_Title.Text);
        cmd.Parameters.AddWithValue("@text", TextBox_Text.Text);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("AdminFrontpageEditing.aspx");
    }
}
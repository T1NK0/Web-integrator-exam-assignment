using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminGenre : System.Web.UI.Page
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

    protected void Repeater_EditGenre_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Panel_Edit.Visible = true;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Genre WHERE Genre_id = @Genre_id", conn);
            cmd.Parameters.AddWithValue("@Genre_id", e.CommandArgument);
            ViewState["Genre_id"] = e.CommandArgument;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //skriver de hentede værdier til formular felterne
                TextBox_GenreName.Text = reader["Genre_name"].ToString();
            }
            conn.Close();
        }
    }

    protected void Button_Gem_Ret_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"UPDATE Genre SET Genre_name = @name WHERE Genre_id = @Genre_id";

        cmd.Parameters.AddWithValue("@Genre_id", ViewState["Genre_id"]);
        cmd.Parameters.AddWithValue("@name", TextBox_GenreName.Text);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("AdminGenre.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminGrunker : System.Web.UI.Page
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

    protected void Repeater_Delete_Users_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Slet")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"DELETE FROM Users WHERE User_id = @User_id";
            cmd.Parameters.AddWithValue("@User_id", e.CommandArgument);

            HiddenField img1 = e.Item.FindControl("HiddenField_img_slet1") as HiddenField;
            string Journalist_image1 = img1.Value.ToString();
            File.Delete(Server.MapPath("~/Images/ProfilePicture/" + Journalist_image1));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("AdminUsers.aspx");
        }

        if (e.CommandName == "Tildel")
        {
            HiddenField x = (HiddenField)e.Item.FindControl("HiddenField_Grunker");
            {
                TildelGrunker(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(x.Value));
            }
        }

        if (e.CommandName == "Reset")
        {
            HiddenField x = (HiddenField)e.Item.FindControl("HiddenField_Grunker");
            {
                ResetGrunker(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(x.Value));
            }
        }
        Repeater_Delete_Users.DataBind();
    }

    public void TildelGrunker (int Grunker, int GrunkerId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "Update Users SET User_grunker = (User_grunker + 500) WHERE User_id = @User_id";
        cmd.Connection = conn;

        cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = GrunkerId;

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void ResetGrunker(int Grunker, int GrunkerId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "Update Users SET User_grunker = 1500";
        cmd.Connection = conn;

        cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = GrunkerId;

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Album : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_id"] != null)
        {
            Panel_NotLoggedIn.Visible = false;
            Panel_LoggedIn.Visible = true;
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT TOP(3) Albums.Album_name, Albums.Album_price, Albums.Album_img, Albums.Album_id, Albums.fk_genre_id FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id WHERE (Genre.Genre_id = @Genre_id) ORDER BY NewID()";

        cmd.Parameters.AddWithValue("@Genre_id", Request.QueryString["Genre_id"].ToString());

        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        Repeater_Albums.DataSource = reader;
        Repeater_Albums.DataBind();
    }

    protected void Button_MakeReview_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"INSERT INTO Review (Review_title, Review_text, Review_date, fk_album_id, fk_user_id) VALUES (@Title, @Text, GETDATE(), @Album_id, @User_id)";
        cmd.Parameters.AddWithValue("@Title", TextBox_Title.Text);
        cmd.Parameters.AddWithValue("@Text", TextBox_Content.Text);
        cmd.Parameters.AddWithValue("@Album_id", Request.QueryString["Album_id"].ToString());
        cmd.Parameters.AddWithValue("@User_id", SqlDbType.Int).Value = Session["User_id"];

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        Response.Redirect(Request.RawUrl);
    }
    protected void Repeater_Album_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        HiddenField x = (HiddenField)e.Item.FindControl("HiddenField_Grunker");
        {
            KøbAlbum(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(x.Value));
        }
    }

    public void KøbAlbum(int Grunker, int GrunkerId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "Update Users SET User_grunker = (User_grunker - Album_price) WHERE User_id = @User_id";
        cmd.Connection = conn;

        cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = GrunkerId;

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}
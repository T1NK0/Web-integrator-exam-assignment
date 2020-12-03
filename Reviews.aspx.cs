using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reviews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_id"] != null)
        {
            Panel_Your_Reviews.Visible = true;
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT Albums.Album_id, Genre.Genre_name, Albums.Album_artist, Albums.Album_img, Albums.Album_price, Albums.Album_name, Genre.Genre_id, Albums.Album_postdate FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id", conn);

        conn.Open();
        RepeaterAlbums.DataSource = cmd.ExecuteReader();
        RepeaterAlbums.DataBind();
        conn.Close();

        GetAlbums();
    }

    private void GetAlbums()
    {
        int news_pr_side = 5;
        int current_page = 1;
        if (Request.QueryString["pagenr"] != null)
        {
            if (!int.TryParse(Request.QueryString["pagenr"].ToString(), out current_page))
            {
                current_page = 1;
            }
        }

        int total_pages = (int)Math.Ceiling(AntalAlbums() / (double)news_pr_side);

        string links = "<ul class='pagination'>";
        for (int i = 1; i <= total_pages; i++)
        {
            links += "<li " + (current_page == i ? "class='active'" : "") + ">";
            links += "<a href='MusicShop.aspx?pagenr=" + i + "'>" + i + "</a>";
            links += "</li>";
        }
        links += "</ul>";
        Literal_Pager.Text = links;

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"SELECT Albums.Album_id, Albums.Album_name, Albums.Album_img, Albums.Album_price, Albums.Album_artist, Albums.Album_postdate, Genre.Genre_name, Genre.Genre_id, Review.fk_confirm_id, Review.fk_album_id, Review.Review_id FROM Albums INNER JOIN Review ON Albums.Album_id = Review.fk_album_id INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id WHERE (Review.fk_confirm_id = 1) ORDER BY Album_postdate DESC OFFSET @offset ROWS FETCH NEXT @news_per_page ROWS ONLY";
        cmd.Parameters.Add("@news_per_page", SqlDbType.Int).Value = news_pr_side;
        int offset = (current_page - 1) * news_pr_side;
        cmd.Parameters.Add("@offset", SqlDbType.Int).Value = offset;

        conn.Open();
        RepeaterAlbums.DataSource = cmd.ExecuteReader();
        RepeaterAlbums.DataBind();
        conn.Close();
    }

    private int AntalAlbums()
    {
        int antal_items = 0;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"SELECT COUNT (Review_id) AS antal FROM Review";

        conn.Open();
        antal_items = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();

        return antal_items;
    }
    //protected void Button_ReadReviews_Click(object sender, EventArgs e)
    //{
    //    //Panel_Egne_Anmeldelser.Visible = true;

    //    //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    //    //SqlCommand cmd = new SqlCommand();
    //    //cmd.Connection = conn;
    //    //cmd.CommandText = @"SELECT Albums.Album_id, Albums.Album_name, Albums.Album_img, Albums.Album_price, Albums.Album_artist, Albums.Album_postdate, Genre.Genre_name, Genre.Genre_id, Review.fk_confirm_id, Review.fk_album_id, Review.Review_id FROM Albums INNER JOIN Review ON Albums.Album_id = Review.fk_album_id INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id WHERE (Review.fk_confirm_id = 1) ORDER BY Album_postdate DESC OFFSET @offset ROWS FETCH NEXT @news_per_page ROWS ONLY";

    //    //conn.Open();
    //    //Repeater_User_Reviews.DataSource = cmd.ExecuteReader();
    //    //Repeater_User_Reviews.DataBind();
    //    //conn.Close();
    //}
}
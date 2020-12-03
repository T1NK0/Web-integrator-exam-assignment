using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Albums : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT Albums.Album_id, Genre.Genre_name, Albums.Album_artist, Albums.Album_img, Albums.Album_price, Albums.Album_name, Genre.Genre_id, Albums.Album_postdate FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id", conn);
        
        conn.Open();
        RepeaterAlbums.DataSource = cmd.ExecuteReader();
        RepeaterAlbums.DataBind();
        conn.Close();

        GetAlbums();
    }


    protected void LinkButton_OrderBy_Aritst_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT TOP (5) Albums.Album_id, Genre.Genre_name, Albums.Album_artist, Albums.Album_img, Albums.Album_price, Albums.Album_name, Genre.Genre_id, Albums.Album_postdate FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id ORDER BY Album_artist ASC", conn);

        conn.Open();
        RepeaterAlbums.DataSource = cmd.ExecuteReader();
        RepeaterAlbums.DataBind();
        conn.Close();
    }

    protected void LinkButton_OrderBy_Album_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT TOP (5) Albums.Album_id, Genre.Genre_name, Albums.Album_artist, Albums.Album_img, Albums.Album_price, Albums.Album_name, Genre.Genre_id, Albums.Album_postdate FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id ORDER BY Album_name ASC", conn);

        conn.Open();
        RepeaterAlbums.DataSource = cmd.ExecuteReader();
        RepeaterAlbums.DataBind();
        conn.Close();
    }

    protected void LinkButton_OrderBy_Genre_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT TOP (5) Albums.Album_id, Genre.Genre_name, Albums.Album_artist, Albums.Album_img, Albums.Album_price, Albums.Album_name, Genre.Genre_id, Albums.Album_postdate FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id ORDER BY Genre_name ASC", conn);

        conn.Open();
        RepeaterAlbums.DataSource = cmd.ExecuteReader();
        RepeaterAlbums.DataBind();
        conn.Close();
    }

    protected void LinkButton_OrderBy_Newest_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand("SELECT TOP (5) Albums.Album_id, Genre.Genre_name, Albums.Album_artist, Albums.Album_img, Albums.Album_price, Albums.Album_name, Genre.Genre_id, Albums.Album_postdate FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id ORDER BY Album_postdate DESC", conn);

        conn.Open();
        RepeaterAlbums.DataSource = cmd.ExecuteReader();
        RepeaterAlbums.DataBind();
        conn.Close();
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
        cmd.CommandText = @"SELECT * FROM Albums INNER JOIN Genre ON Genre_id = Albums.fk_genre_id ORDER BY Album_postdate DESC OFFSET @offset ROWS FETCH NEXT @news_per_page ROWS ONLY";
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

        cmd.CommandText = @"SELECT COUNT (Album_id) AS antal FROM Albums";

        conn.Open();
        antal_items = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();

        return antal_items;
    }
}
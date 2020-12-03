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

public partial class AdminAlbums : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd2 = new SqlCommand("SELECT Genre_id, Genre_name FROM Genre"))
                {
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Connection = conn;
                    conn.Open();
                    DropDownList_Genres.DataSource = cmd2.ExecuteReader();
                    DropDownList_Genres.DataTextField = "Genre_name";
                    DropDownList_Genres.DataValueField = "Genre_id";
                    DropDownList_Genres.DataBind();
                    conn.Close();
                }
            }
            DropDownList_Genres.Items.Insert(0, new ListItem("--Vælg kategori--", "0"));
        }
    }
    protected void Button_Opret_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"INSERT INTO Albums (Album_name, Album_price, Album_artist, Album_img, fk_genre_id, Album_postdate) VALUES (@name, @price, @artist, @img, @Genre_id, GETDATE());";
        cmd.Parameters.AddWithValue("@name", TextBox_Name.Text);
        cmd.Parameters.AddWithValue("@price", TextBox_Price.Text);
        cmd.Parameters.AddWithValue("@Artist", TextBox_Artist.Text);
        cmd.Parameters.AddWithValue("@Genre_id", DropDownList_Genres.SelectedValue);


        //database sti til billede
        string bill_sti = "intetbillede.jpg";

        //Hvis der er en fil i FilUploaden
        #region image1
        if (FileUpload_Img1.HasFile)
        {
            //NewGuid danner uniq navn for billeder
            bill_sti = Guid.NewGuid() + Path.GetExtension(FileUpload_Img1.FileName);
            // Opret
            String UploadeMappe = Server.MapPath("~/Images/Original/");
            String CroppedMappe1 = Server.MapPath("~/Images/200x200/");
            String CroppedMappe2 = Server.MapPath("~/Images/50x50/");
            String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img1.FileName;
            bill_sti = Filnavn;

            //Gem det orginale Billede
            FileUpload_Img1.SaveAs(UploadeMappe + Filnavn);

            // Definer hvordan
            ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
            //Lav nogle nye skalerings instillinger
            BilledeSkalering = new ImageResizer.ResizeSettings();
            BilledeSkalering.Width = 200;
            BilledeSkalering.Height = 200;
            BilledeSkalering.Mode = ImageResizer.FitMode.Crop;

            //Udfør selve skaleringen
            ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe1 + Filnavn, BilledeSkalering);

            //Lav nogle nye skalerings instillinger
            BilledeSkalering = new ImageResizer.ResizeSettings();
            BilledeSkalering.Width = 50;
            BilledeSkalering.Height = 50;
            BilledeSkalering.Mode = ImageResizer.FitMode.Crop;

            //Udfør selve skaleringen
            ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe2 + Filnavn, BilledeSkalering);

        }
        // Tildel parameter-værdierne, fra input felterne.
        cmd.Parameters.AddWithValue("@img", bill_sti);
        #endregion

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        Response.Redirect("AdminAlbums.aspx");
    }
    protected void Button_Gem_Ret_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"UPDATE Albums SET Album_name = @name, Album_price = @price, Album_artist = @artist, Album_img = @img, fk_genre_id = @genre_id WHERE Album_id = @Album_id";

        cmd.Parameters.AddWithValue("@Album_id", ViewState["Album_id"]);
        cmd.Parameters.AddWithValue("@name", TextBox_Name.Text);
        cmd.Parameters.AddWithValue("@price", TextBox_Price.Text);
        cmd.Parameters.AddWithValue("@artist", TextBox_Artist.Text);
        cmd.Parameters.AddWithValue("@genre_id", DropDownList_Genres.SelectedValue);


        #region Image 1
        string product_image1 = HiddenField_oldImage1.Value;
        if (FileUpload_Img1.HasFile)
        {
            //NewGuid danner uniq navn for billeder
            product_image1 = Guid.NewGuid() + Path.GetExtension(FileUpload_Img1.FileName);
            // Opret
            String UploadeMappe = Server.MapPath("~/Images/Original/");
            String CroppedMappe1 = Server.MapPath("~/Images/200x200/");
            String CroppedMappe2 = Server.MapPath("~/Images/50x50/");
            String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img1.FileName;
            product_image1 = Filnavn;

            //Gem det orginale Billede
            FileUpload_Img1.SaveAs(UploadeMappe + Filnavn);

            // Definer hvordan
            ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
            //Lav nogle nye skalerings instillinger
            BilledeSkalering = new ImageResizer.ResizeSettings();
            BilledeSkalering.Width = 200;
            BilledeSkalering.Height = 200;
            BilledeSkalering.Mode = ImageResizer.FitMode.Crop;

            //Udfør selve skaleringen
            ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe1 + Filnavn, BilledeSkalering);

            //Lav nogle nye skalerings instillinger
            BilledeSkalering = new ImageResizer.ResizeSettings();
            BilledeSkalering.Width = 50;
            BilledeSkalering.Height = 50;
            BilledeSkalering.Mode = ImageResizer.FitMode.Crop;

            //Udfør selve skaleringen
            ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe2 + Filnavn, BilledeSkalering);

            string old_img = HiddenField_oldImage1.Value;
            if (File.Exists(Server.MapPath("~/Images/Original") + old_img))
            {
                File.Delete(Server.MapPath("~/Images/Original") + old_img);
            }
            if (File.Exists(Server.MapPath("~/Images/200x200") + old_img))
            {
                File.Delete(Server.MapPath("~/Images/200x200") + old_img);
            }
            if (File.Exists(Server.MapPath("~/Images/50x50/") + old_img))
            {
                File.Delete(Server.MapPath("~/Images/50x50/") + old_img);
            }
        }
        cmd.Parameters.AddWithValue("@img", product_image1);
        #endregion

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("AdminAlbums.aspx");
    }
    protected void Repeater_Ret_Journalister_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Slet")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"DELETE FROM Albums WHERE Album_id = @Album_id";
            cmd.Parameters.AddWithValue("@Album_id", e.CommandArgument);

            HiddenField img1 = e.Item.FindControl("HiddenField_img_slet1") as HiddenField;
            string Journalist_image1 = img1.Value.ToString();
            File.Delete(Server.MapPath("~/Images/200x200/" + Journalist_image1));
            File.Delete(Server.MapPath("~/Images/50x50/" + Journalist_image1));
            File.Delete(Server.MapPath("~/Images/Original/" + Journalist_image1));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("AdminAlbums.aspx");
        }

        if (e.CommandName == "Ret")
        {
            Button_Gem_Ret.Visible = true;
            Button_Opret.Visible = false;
            Image_Ret1.Visible = true;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Albums WHERE Album_id = @Album_id", conn);
            cmd.Parameters.AddWithValue("@Album_id", e.CommandArgument);
            ViewState["Album_id"] = e.CommandArgument;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //skriver de hentede værdier til formular felterne
                TextBox_Name.Text = reader["Album_name"].ToString();
                TextBox_Price.Text = reader["Album_price"].ToString();
                TextBox_Artist.Text = reader["Album_artist"].ToString();
                DropDownList_Genres.Text = reader["fk_genre_id"].ToString();
                Image_Ret1.ImageUrl = "~/Images/200x200/" + reader["Album_img"].ToString();
                Image_Ret1.ImageUrl = "~/Images/50x50/" + reader["Album_img"].ToString();
                Image_Ret1.ImageUrl = "~/Images/Original/" + reader["Album_img"].ToString();
            }
            conn.Close();
        }
    }
}
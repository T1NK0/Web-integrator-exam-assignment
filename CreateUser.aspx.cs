using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void button_create_user_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"INSERT INTO Users (User_email, User_name, User_password, User_description, User_img) VALUES (@Email, @Name, @Password, @Description, @Img)";
        cmd.Parameters.AddWithValue("@Email", TextBox_Email_Create.Text);
        cmd.Parameters.AddWithValue("@Name", TextBox_Username_Create.Text);
        cmd.Parameters.AddWithValue("@Password", TextBox_Password_Create1.Text);
        cmd.Parameters.AddWithValue("@Description", TextBox_Description.Text);

        string bill_sti = "intetbillede.jpg";

        #region image1
        if (FileUpload_Img.HasFile)
        {
            //NewGuid danner uniq navn for billeder
            bill_sti = Guid.NewGuid() + Path.GetExtension(FileUpload_Img.FileName);
            // Opret
            String UploadeMappe = Server.MapPath("~/Images/ProfilePicture/");
            String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img.FileName;
            bill_sti = Filnavn;

            //Gem det orginale Billede
            FileUpload_Img.SaveAs(UploadeMappe + Filnavn);
        }
        // Tildel parameter-værdierne, fra input felterne.
        cmd.Parameters.AddWithValue("@Img", bill_sti);
        #endregion

        conn.Open();
        object user_id = cmd.ExecuteScalar();
        conn.Close();
        Response.Redirect("Default.aspx");
    }
    protected void Button_login_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"SELECT * FROM Users INNER JOIN Roles ON fk_role_id = Role_id WHERE User_email = @email AND User_password = @password";
        cmd.Parameters.AddWithValue("@email", TextBox_email.Text);
        cmd.Parameters.AddWithValue("@password", TextBox_password.Text);

        conn.Open();
        //SqlDataReader, skal benyttes for at kunne læse data fra databasen
        SqlDataReader reader = cmd.ExecuteReader();
        //Hvis der kan hentes data ud af reader'en, gemmes bruger_id i session
        if (reader.Read())
        {
            Session["User_id"] = reader["User_id"];
            Session["Role_id"] = reader["Role_id"];

            if (Convert.ToInt32(Session["Role_id"]) == 1)
            {
                Response.Redirect("AdminAlbums.aspx");
            }

            if (Convert.ToInt32(Session["Role_id"]) == 2)
            {
                Response.Redirect("MusicShop.aspx");
            }

            Response.Redirect("UserProfile.aspx");
            conn.Close();
        }
        else
        {
            Label_ErrorMessage.Text = "Forkert Brugernavn eller Password";
        }
    }
}
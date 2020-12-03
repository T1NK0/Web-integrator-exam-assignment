using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageFrontend : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

        //string LogFile = "BrugereLogin.txt";

        //string LogText = DateTime.Now.ToString("yyyy-MM-dd:hh:mm::ss") + "User XYZ Loggede på";
        //StreamWriter LogFileWriter = new StreamWriter(Server.MapPath("~/Log/" + LogFile), true);

        //LogFileWriter.WriteLine(LogText);

        //LogFileWriter.Flush();
        //LogFileWriter.Close();
        //LogFileWriter.Dispose();
    }
}

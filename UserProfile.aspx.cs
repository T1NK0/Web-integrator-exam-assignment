using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_id"] == null)
        {
            Response.Redirect("CreateUser.aspx");
        }
    }

    protected void Repeater_User_Profile_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Ret_Profil")
        {
            Image_Ret1.Visible = true;
            Panel_Edit_User.Visible = true;
            Panel_User_Info.Visible = false;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE User_id = @User_id", conn);
            cmd.Parameters.AddWithValue("@User_id", e.CommandArgument);
            ViewState["User_id"] = e.CommandArgument;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TextBox_Description.Text = reader["User_description"].ToString();
                Image_Ret1.ImageUrl = "~/Images/ProfilePicture/" + reader["User_img"].ToString();
            }
            conn.Close();
        }
    }
    protected void button_Edit_User_Confirm_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"UPDATE Users SET User_description = @Description, User_img = @img WHERE User_id = @User_id";

        cmd.Parameters.AddWithValue("@User_id", ViewState["User_id"]);
        cmd.Parameters.AddWithValue("@Description", TextBox_Description.Text);


        #region Image 1
        string product_image1 = HiddenField_oldImage1.Value;
        if (FileUpload_Img1.HasFile)
        {
            //NewGuid danner uniq navn for billeder
            product_image1 = Guid.NewGuid() + Path.GetExtension(FileUpload_Img1.FileName);
            // Opret
            String UploadeMappe = Server.MapPath("~/Images/ProfilePicture/");
            String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img1.FileName;
            product_image1 = Filnavn;

            //Gem det orginale Billede
            FileUpload_Img1.SaveAs(UploadeMappe + Filnavn);

            string old_img = HiddenField_oldImage1.Value;
            if (File.Exists(Server.MapPath("~/Images/ProfilePicture") + old_img))
            {
                File.Delete(Server.MapPath("~/Images/ProfilePicture") + old_img);
            }
        }
        cmd.Parameters.AddWithValue("@img", product_image1);
        #endregion

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("UserProfile.aspx");
    }
}
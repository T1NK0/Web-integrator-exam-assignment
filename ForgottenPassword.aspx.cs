using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgottenPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void Button_Email_Check_Click(object sender, EventArgs e)
    //{
    //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.Connection = conn;

    //    cmd.CommandText = @"SELECT * FROM Users WHERE User_email = @Email = TextBox_User_Email.Text";
        
    //    if (Reader.HasRows)
    //    {
            
    //    }

    //}
    //protected void Button_New_Password_Click(object sender, EventArgs e)
    //{
    //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.Connection = conn;

    //    cmd.CommandText = @"UPDATE Users SET User_password = @Pass WHERE User_email = @SessionGlemt";

    //    cmd.Parameters.AddWithValue("@Pass" = TextBox_Password1.Text);
    //    cmd.Parameters.AddWithValue("@SessionGlemt" = Session['glemt'].ToString();

    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //}
}
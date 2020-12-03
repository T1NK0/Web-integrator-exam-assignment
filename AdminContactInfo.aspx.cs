using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminContactInfo : System.Web.UI.Page
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

    protected void Button_Gem_Ret_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"UPDATE Contact SET Contact_phone = @Phone, Contact_email = @Email, Contact_location_name = @Location_name, Contact_address = @Address, Contact_postal_number = @Postal, Contact_opening_monday_friday = @Monday_friday, Contact_opening_saturday = @Saturday, Contact_opening_sunday = @Sunday WHERE Contact_id = @Contact_id";

        cmd.Parameters.AddWithValue("@Contact_id", ViewState["Contact_id"]);
        cmd.Parameters.AddWithValue("@Phone", TextBox_tlf.Text);
        cmd.Parameters.AddWithValue("@Email", TextBox_email.Text);
        cmd.Parameters.AddWithValue("@Location_name", TextBox_Location_Name.Text);
        cmd.Parameters.AddWithValue("@Address", TextBox_Address.Text);
        cmd.Parameters.AddWithValue("@Postal", TextBox_Postal_Number.Text);
        cmd.Parameters.AddWithValue("@Monday_friday", TextBox_Opening_Monday_Friday.Text);
        cmd.Parameters.AddWithValue("@Saturday", TextBox_Opening_Saturday.Text);
        cmd.Parameters.AddWithValue("@Sunday", TextBox_Opening_Sunday.Text);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("AdminContactInfo.aspx");
    }

    protected void Repeater_Ret_ContactInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Ret")
        {
            Panel_EditContactInfo.Visible = true;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Contact WHERE Contact_id = @Contact_id", conn);
            cmd.Parameters.AddWithValue("@Contact_id", e.CommandArgument);
            ViewState["Contact_id"] = e.CommandArgument;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TextBox_tlf.Text = reader["Contact_phone"].ToString();
                TextBox_email.Text = reader["Contact_email"].ToString();
                TextBox_Location_Name.Text = reader["Contact_location_name"].ToString();
                TextBox_Address.Text = reader["Contact_address"].ToString();
                TextBox_Postal_Number.Text = reader["Contact_postal_number"].ToString();
                TextBox_Opening_Monday_Friday.Text = reader["Contact_opening_monday_friday"].ToString();
                TextBox_Opening_Saturday.Text = reader["Contact_opening_saturday"].ToString();
                TextBox_Opening_Sunday.Text = reader["Contact_opening_sunday"].ToString();
            }
            conn.Close();
        }
    }
}
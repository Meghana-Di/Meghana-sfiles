using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(@"Data source=DESKTOP-3VC78I8\SQLEXPRESS;initial catalog=Work2021;integrated security=True"))
            {
                sqlcon.Open();
             string query = "Select Count(1) from Users where Username=@Username and Password=@Password";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@Username",txtUsername.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count==1)
                {
                    Session["@username"] = txtUsername.Text.Trim();
                    Response.Redirect("DefaultPage.aspx");
                }
                else { lblErrorMessage.Visible = true; }
            }
        }

        
    }
}
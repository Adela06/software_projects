using System;
using System.Web.UI;

namespace WebApplication2
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is already logged in, if yes, redirect to dashboard
            if (Session["UserId"] != null)
            {
                // Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get username and password from textboxes
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            localhostU.userService webService = new localhostU.userService();
            string adminStatus = webService.Login(username, password);

            // Check if login was successful
            if (adminStatus != null)
            {
                // Set user role in session
                Session["AdminStatus"] = adminStatus;

                // Redirect to dashboard based on user role
                if (adminStatus == "yes")
                {
                    Response.Redirect("WebFormAdmin.aspx");
                }
                else
                {
                    Response.Redirect("WebFormUsers.aspx");
                }
            }
            else
            {
                // Display error message if login failed
                lblMessage.Text = "Invalid username or password.";
                lblMessage.Visible = true;
            }
        }
    }
}

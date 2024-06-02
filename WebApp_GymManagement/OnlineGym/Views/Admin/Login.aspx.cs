using System.Data;
using System;

namespace OnlineGym.Views.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        private Models.Functions Con;
        public static string AgentId = "";
        public static string AgentName = "";
        public bool IsValidUser = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (AdminRadio.Checked)
            {
                // Admin login logic
                if (PasswordTb.Value == "Admin" && EmailTb.Value == "Admin@gmail.com")
                {
                    // Generate a unique session token for the admin user
                    string authToken = Guid.NewGuid().ToString();

                    // Store the token in the session with a prefix indicating the user type
                    Session["AdminAuthToken"] = authToken;

                    // Redirect to the admin page with the token in the URL
                    Response.Redirect("/Views/Admin/Admin.aspx?token=" + authToken);
                }
                else
                {
                    ErrMsg.InnerText = "Wrong Credentials";
                }
            }
            else
            {
                // Receptionist login logic
                try
                {
                    string Query = "select RecepId,RecepName,RecepPass from ReceptionistTbl where RecepEmail='{0}' and RecepPass='{1}'";
                    Query = string.Format(Query, EmailTb.Value, PasswordTb.Value);
                    DataTable dt = Con.GetData(Query);

                    if (dt.Rows.Count == 0)
                    {
                        ErrMsg.InnerText = "Invalid Receptionist Credentials";
                    }
                    else
                    {
                        // Generate a unique session token for the receptionist user
                        string authToken = Guid.NewGuid().ToString();

                        // Store the token in the session with a prefix indicating the user type
                        Session["RecepAuthToken"] = authToken;

                        // Redirect to the receptionist page with the token in the URL
                        Response.Redirect("/Views/Admin/Receptionist.aspx?token=" + authToken);
                    }
                }
                catch (Exception ex)
                {
                    ErrMsg.InnerText = ex.Message;
                }
            }
        }

        private string SetSessionToken(string userType)
        {
            // Set a unique session token
            string authToken = Guid.NewGuid().ToString();

            // Store the token in the session with a prefix indicating the user type
            Session[userType + "AuthToken"] = authToken;

            return authToken;
        }
    }
}
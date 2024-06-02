using System;
using System.Web;

namespace OnlineGym.Views.Admin
{
    public partial class Receptionist : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check access before processing the page
            CheckAccess();

            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowReceptionist();
            }
        }

        private void CheckAccess()
        {
            // Get the user type (Admin or Recep)
            string userType = GetUserType(); // Implement a method to determine the user type

            // Get the session token from the URL or session
            string requestToken = GetRequestToken();

            // Get the currently authenticated user's token
            string authenticatedToken = Session[userType + "AuthToken"] as string;

            // Check if the tokens match
            if (string.IsNullOrEmpty(requestToken) || requestToken != authenticatedToken)
            {
                // Redirect to the main login page
               // Response.Redirect("/Views/Admin/Login.aspx");
            }
        }

        private string GetUserType()
        {
            return "Receptionist";
        }

        private string GetRequestToken()
        {

            return Request.QueryString["token"];
        }

        private void ShowReceptionist()
        {
            string Query = "select * from ReceptionistTbl";
            ReceptionistList.DataSource = Con.GetData(Query);
            ReceptionistList.DataBind();
        }

        //pentru search
        private void ShowReceptionist(string searchName = "")
        {
            string query = "SELECT * FROM ReceptionistTbl";

            if (!string.IsNullOrEmpty(searchName))
            {
                query += $" WHERE RecepName LIKE '%{searchName}%'";
            }

            ReceptionistList.DataSource = Con.GetData(query);
            ReceptionistList.DataBind();
        }

        private void SearchReceptionist(string searchName)
        {
            ShowReceptionist(searchName);
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchName = SearchTb.Value.Trim();
                SearchReceptionist(searchName);
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
        ///pt search



        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {

                RecTb.Value = "";
                RGenCb.SelectedIndex = -1;
                RDOBTb.Value = "";
                RecAddTb.Value = "";
                PhoneTb.Value = "";
                PasswordTb.Value = "";
                EmailTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void ReceptionistList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecTb.Value = ReceptionistList.SelectedRow.Cells[2].Text;
            RGenCb.Text = ReceptionistList.SelectedRow.Cells[3].Text;

            RecAddTb.Value = ReceptionistList.SelectedRow.Cells[5].Text;
            PhoneTb.Value = ReceptionistList.SelectedRow.Cells[6].Text;

            PasswordTb.Value = ReceptionistList.SelectedRow.Cells[7].Text;
            EmailTb.Value = ReceptionistList.SelectedRow.Cells[8].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {

                RecTb.Value = "";
                RGenCb.SelectedIndex = -1;
                RDOBTb.Value = "";
                RecAddTb.Value = "";
                PhoneTb.Value = "";
                PasswordTb.Value = "";
                EmailTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {

                RecTb.Value = "";
                RGenCb.SelectedIndex = -1;
                RDOBTb.Value = "";
                RecAddTb.Value = "";
                PhoneTb.Value = "";
                PasswordTb.Value = "";
                EmailTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}

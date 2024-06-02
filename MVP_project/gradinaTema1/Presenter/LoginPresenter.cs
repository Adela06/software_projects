using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Presenter
{
    public class LoginPresenter
    {
        private ILoginGUI loginGUI;
        private UserRepository userRepository;

        internal void Initialize(LoginForm loginForm)
        {
            this.loginGUI = loginForm;
            this.userRepository = new UserRepository("GradinaB");
        }
        public bool AuthenticateUser(string username, string password)
        {

            User user = userRepository.SearchUserLogIn(username,password);

            // Initialize a variable to hold the result of authentication
            bool isAuthenticated = false;
            if(user != null) { isAuthenticated = true; }
            else { loginGUI.ShowMessage("Error"); }

            if (isAuthenticated)
            {
                loginGUI.Hide();
                if (user.AdminStatus == "yes")
                {
                    // Log in as admin and display AdminForm
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    // Log in as employee and display UserForm
                    EmployeeForm employeeForm = new EmployeeForm();
                    employeeForm.Show();
                }
            }
            else
            {
                loginGUI.ShowMessage("Invalid username or password.");
            }

            return isAuthenticated;
        }
    }
}

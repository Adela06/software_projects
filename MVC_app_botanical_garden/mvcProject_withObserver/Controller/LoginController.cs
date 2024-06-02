using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace gradinaTema1.Controller
{
    public class LoginController
    {
        private LoginForm loginForm;
        private String status;
        private Dictionary<string, string> dict;

        public LoginController()
        {
            this.loginForm = new LoginForm();
            dict = new Dictionary<string, string>();

            this.loginForm.Login().Click += new EventHandler(AuthenticateUser);

        }

        public LoginForm getLoginForm()
        {
            return this.loginForm;
        }


        private void AuthenticateUser(object sender, EventArgs e)
        {
            string username = loginForm.GetUsername().Text;
            string password = loginForm.GetPassword().Text;
            UserRepository userRepository = new UserRepository("GradinaB");
            User user = userRepository.SearchUserLogIn(username, password);
            if (user != null)
            {
                status = user.AdminStatus;
                if (status == "yes")
                {
                    loginForm.Hide();
                    AdminController adminController = new AdminController();
                    adminController.getAdminForm().Show();
                }
                else
                {
                    loginForm.Hide();
                    EmployeeController employeeController = new EmployeeController();
                    employeeController.getEmployeeForm().Show();
                }
                return;
            }
            loginForm.ShowMessage("Error during login!");
            //return false;
        }
    }
}



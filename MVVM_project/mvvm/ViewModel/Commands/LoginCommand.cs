using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using gradinaTema1.View;
using System;
using System.Windows.Forms;

namespace gradinaTema1.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        private UserVM userVM;
        private LoginForm loginForm;

        public LoginCommand(UserVM userVM, LoginForm loginForm)
        {
            this.userVM = userVM;
            this.loginForm = loginForm;
        }

        public void Execute()
        {
            bool isAuthenticated = AuthenticateUser(userVM.Username, userVM.Password);

            if (isAuthenticated)
            {
                loginForm.Hide();
                if (userVM.AdminStatus == "yes")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    EmployeeForm employeeForm = new EmployeeForm();
                    employeeForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            UserRepository userRepository = new UserRepository("GradinaB");
            User user = userRepository.SearchUserLogIn(username, password);
            if (user != null)
            {
                userVM.AdminStatus = user.AdminStatus; 
                return true;
            }
            return false;
        }

    }
}

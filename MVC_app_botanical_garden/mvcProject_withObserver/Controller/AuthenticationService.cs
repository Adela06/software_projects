// AuthenticationService.cs
using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using gradinaTema1.View;

namespace gradinaTema1.Controller
{
    public static class AuthenticationService
    {
        public static void AuthenticateUser(LoginForm loginForm, string username, string password)
        {
            UserRepository userRepository = new UserRepository("GradinaB");
            User user = userRepository.SearchUserLogIn(username, password);
            if (user != null)
            {
                string status = user.AdminStatus;
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
            }
            else
            {
                loginForm.ShowMessage("Error during login!");
            }
        }
    }
}

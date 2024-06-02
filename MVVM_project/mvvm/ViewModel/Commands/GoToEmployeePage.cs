using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.ViewModel.Commands
{
    public class GoToEmployeePage: ICommand
    {
        private LoginForm loginForm;

        public GoToEmployeePage(LoginForm loginForm)
        {
            this.loginForm = loginForm;
        }

        public void Execute()
        {
            loginForm.Hide();
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.Show();
        }
    }
}

using gradinaTema1.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data;
using ICommand = gradinaTema1.ViewModel.Commands.ICommand;
using System.Windows.Forms;
using gradinaTema1.View;

namespace gradinaTema1.ViewModel
{
    public class UserVM
    {
        public string userID;
        public string person;
        public string password;
        public string username;
        public string adminStatus;
        public DataTable users;

        public ICommand CreateUser;
        public ICommand UpdateUser;
        public ICommand DeleteUser;
        public ICommand ViewUsers;
        public ICommand EditUser;
        public ICommand GoToGuestPage;
        public ICommand LoginCommand;

        public UserVM(AdminForm adminForm,DataGridView dataGridView)
        {
            this.userID = "";
            this.person = "";
            this.password = "";
            this.username = "";
            this.adminStatus = "";
            this.users = new DataTable();
            this.CreateUser = new CreateUserCommand(this);
            this.UpdateUser = new UpdateUserCommand(this, dataGridView);
            this.DeleteUser = new DeleteUserCommand(this, dataGridView);
            this.ViewUsers = new ViewUsersCommand(this);
            this.GoToGuestPage = new GoToGuestPageCommand(adminForm);

            users.Columns.Add("ID");
            users.Columns.Add("Username");
            users.Columns.Add("Password");
            users.Columns.Add("Admin_status");
        }

        public UserVM(LoginForm loginForm)
        {
            this.userID = "";
            this.person = "";
            this.password = "";
            this.username = "";
            this.adminStatus = "";
            this.users = new DataTable();
            this.CreateUser = new CreateUserCommand(this);
            this.LoginCommand = new LoginCommand(this, loginForm);

            users.Columns.Add("ID");
            users.Columns.Add("Username");
            users.Columns.Add("Password");
            users.Columns.Add("Admin_status");
        }


        public UserVM()
        {
            this.userID = "";
            this.person = "";
            this.password = "";
            this.username = "";
            this.adminStatus = "";
            this.users = new DataTable();
            this.CreateUser = new CreateUserCommand(this);

            users.Columns.Add("ID");
            users.Columns.Add("Username");
            users.Columns.Add("Password");
            users.Columns.Add("Admin_status");
        }


        public UserVM(LoginForm loginForm, DataGridView dataGridView)
        {

            this.LoginCommand = new LoginCommand(this, loginForm);
        }
        public string UserID
        { get { return this.userID; } set { this.userID = value; } }
        public string Person {  get { return this.person; } set { this.person = value; } }  
        public string Password {  get { return this.password; } set { password = value; } }
        public string Username {  get { return this.username; } set { username = value; } }
        public string AdminStatus {  get { return this.adminStatus; } set { adminStatus = value; } }

    }
}

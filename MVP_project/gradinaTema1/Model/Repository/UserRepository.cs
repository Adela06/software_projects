using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Model.Repository
{
    public class UserRepository
    {
        private Repository repository;
        private string dbName = "GradinaB";

        public UserRepository(string dbName)
        {
            this.dbName = dbName;
            this.repository = new Repository(dbName);
        }

        public bool AddUser(User user)
        {
            string command = $"INSERT INTO Users(person_id, username, password, admin_status) VALUES('{user.Person}', '{user.Username}', '{user.Password}', '{user.AdminStatus}');";
            return repository.ExecuteCommand(command);
        }

        public bool UpdateUser(string id, User u)
        {
            string command = $"UPDATE Users SET person_id = '{u.Person}', username = '{u.Username}', password = '{u.Password}', admin_status = '{u.AdminStatus}' WHERE user_id = {id};";
            return repository.ExecuteCommand(command);
        }

        public bool DeleteUser(string id)
        {
            string command = $"DELETE FROM Users WHERE user_id = {id};";
            return repository.ExecuteCommand(command);
        }

        public User SearchUser(string id)
        {
            string search = $"SELECT * FROM Users WHERE user_id = {id};";
            DataTable dataTable = repository.GetTable(search);
            User u = null;

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                string userId = row["user_id"].ToString();
                string person = row["person_id"].ToString();
                string username = row["username"].ToString();
                string password = row["password"].ToString();
                string status = row["admin_status"].ToString();

                u = new User(userId, person, username, password, status);
            }

            return u;
        }

        public User SearchUserLogIn(string username, string password)
        {
            //string search = $"SELECT * FROM Users WHERE username = '{username}' AND password = '{password}';";
            string search = $"SELECT * FROM Users WHERE username = '{username}' AND password = '{password}';";

           
            DataTable dataTable = this.repository.GetTable(search);
            User u = null;
            

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                string userId = row["user_id"].ToString();
                string person = row["person_id"].ToString();
                string user = row["username"].ToString();
                string pass = row["password"].ToString();
                string status = row["admin_status"].ToString();

                u = new User(userId, person, pass, user, status);
            }

            //u = new User("1", "1", "pass", "user", "no");

            return u;
        }

        public List<User> UserList()
        {
            List<User> users = new List<User>();

            string getUsers = "SELECT * FROM Users";
            DataTable dataTable = repository.GetTable(getUsers);

            foreach (DataRow row in dataTable.Rows)
            {
                string userID = row["user_id"].ToString();
                string id = row["person_id"].ToString();
                string password = row["password"].ToString();
                string username = row["username"].ToString();
                string status = row["admin_status"].ToString();

                User u = new User(userID, id, username, password, status);
                users.Add(u);
            }

            return users;
        }
    }
}

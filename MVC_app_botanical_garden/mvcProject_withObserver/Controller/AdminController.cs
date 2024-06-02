using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sets.Model;
using System.IO;

namespace gradinaTema1.Controller
{
    public class AdminController
    {
        private AdminForm form;
        private Dictionary<string, string> dict;

        public AdminController()
        {
            form = new AdminForm();
           UserRepository userRepository = new UserRepository("GradinaB");

            List<User> users = userRepository.UserList();
            if (users != null && users.Count != 0)
            {
                setTableList(users);
            }
            else
            {
                users = new List<User> { new User("", "", "", "") };
                setTableList(users);
            }

            // Add event handlers for buttons
            form.getAddButton().Click += new EventHandler(AddUser);
            form.getUpdateButton().Click += new EventHandler(UpdateUser);
            form.getDeleteButton().Click += new EventHandler(DeleteUser);

            form.getAdminStatusCheckBox().CheckedChanged += new EventHandler(AdminStatusCheckBox_CheckedChanged);
            form.getEmployeeStatusCheckBox().CheckedChanged += new EventHandler(EmployeeStatusCheckBox_CheckedChanged);

            form.getRomanaButton().Click += new EventHandler(SwitchToRomana);
            form.getEnglezaButton().Click += new EventHandler(SwitchToEngleza);
            form.getGermanaButton().Click += new EventHandler(SwitchToGermana);

            RefreshUserList();
        }



        private void SwitchToRomana(object sender, EventArgs e)
        {
            String line;
            dict = new Dictionary<string, string>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("D:\\AN3_SEM2\\PS\\Laborator\\Tema3\\romana.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    string[] word = line.Split(';');
                    dict.Add(word[0], word[1]);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            form.getEnglezaButton().Text = dict["English"];
            form.getRomanaButton().Text = dict["Romanian"];
            form.getGermanaButton().Text = dict["German"];

            form.getAddButton().Text = dict["Create"];
            form.getDeleteButton().Text = dict["Delete"];
            form.getUpdateButton().Text = dict["Update"];

            form.getAdminStatusCheckBox().Text = dict["Admin"];
            form.getEmployeeStatusCheckBox().Text = dict["Employee"];

            form.getUsernameLabel().Text = dict["Username"];
            form.getPasswordLabel().Text = dict["Password"];
            form.getStatusLabel().Text = dict["Status"];
        }


        private void SwitchToEngleza(object sender, EventArgs e)
        {
            String line;
            dict = new Dictionary<string, string>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("D:\\AN3_SEM2\\PS\\Laborator\\Tema3\\engleza.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    string[] word = line.Split(';');
                    dict.Add(word[0], word[1]);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            form.getEnglezaButton().Text = dict["English"];
            form.getRomanaButton().Text = dict["Romanian"];
            form.getGermanaButton().Text = dict["German"];

            form.getAddButton().Text = dict["Create"];
            form.getDeleteButton().Text = dict["Delete"];
            form.getUpdateButton().Text = dict["Update"];

            form.getAdminStatusCheckBox().Text = dict["Admin"];
            form.getEmployeeStatusCheckBox().Text = dict["Employee"];

            form.getUsernameLabel().Text = dict["Username"];
            form.getPasswordLabel().Text = dict["Password"];
            form.getStatusLabel().Text = dict["Status"];
        }


        private void SwitchToGermana(object sender, EventArgs e)
        {
            String line;
            dict = new Dictionary<string, string>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("D:\\AN3_SEM2\\PS\\Laborator\\Tema3\\germana.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    string[] word = line.Split(';');
                    dict.Add(word[0], word[1]);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            form.getEnglezaButton().Text = dict["English"];
            form.getRomanaButton().Text = dict["Romanian"];
            form.getGermanaButton().Text = dict["German"];

            form.getAddButton().Text = dict["Create"];
            form.getDeleteButton().Text = dict["Delete"];
            form.getUpdateButton().Text = dict["Update"];

            form.getAdminStatusCheckBox().Text = dict["Admin"];
            form.getEmployeeStatusCheckBox().Text = dict["Employee"];

            form.getUsernameLabel().Text = dict["Username"];
            form.getPasswordLabel().Text = dict["Password"];
            form.getStatusLabel().Text = dict["Status"];

        }


        private void AdminStatusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshUserList();
        }

        private void EmployeeStatusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshUserList();
        }


        private void setTableList(List<User> users)
        {
            foreach (User u in users)
            {
                form.getUsers().Rows.Add(u.Id, u.Password, u.Username, u.AdminStatus);
            }
        }

        private void AddUser(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository("GradinaB");
            string username = form.getUsernameTextBox().Text;
            string password = form.getPasswordTextBox().Text;
            string adminStatus = form.getAdminStatusTextBox().Text;

            User newUser = new User("", "", password, username,adminStatus);
            userRepository.AddUser(newUser);
            RefreshUserList();
        }

        private void UpdateUser(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository("GradinaB");
            if (form.getUsers().SelectedRows.Count > 0)
            {
                string userId = form.getUsers().SelectedRows[0].Cells["ID"].Value.ToString();
                string username = form.getUsernameTextBox().Text;
                string password = form.getPasswordTextBox().Text;
                string adminStatus = form.getAdminStatusTextBox().Text;

                User updatedUser = new User(userId, "", password, username, adminStatus);
                userRepository.UpdateUser(userId, updatedUser);
                RefreshUserList();
            }
        }

        private void DeleteUser(object sender, EventArgs e)
        {
            if (form.getUsers().SelectedRows.Count > 0)
            {
                string userId = form.getUsers().SelectedRows[0].Cells["ID"].Value.ToString();

                if (!string.IsNullOrEmpty(userId))
                {
                    UserRepository userRepository = new UserRepository("GradinaB");
                    userRepository.DeleteUser(userId);
                }


                RefreshUserList();
            }
        }


        /*   private void RefreshUserList()
           {
               UserRepository userRepository = new UserRepository("GradinaB");
               form.getUsers().Rows.Clear();
               List<User> users = userRepository.UserList();
               if (users != null && users.Count != 0)
               {
                   setTableList(users);
               }
               else
               {
                   users = new List<User> { new User("", "", "", "") };
                   setTableList(users);
               }
           }*/

        private void RefreshUserList()
        {
            UserRepository userRepository = new UserRepository("GradinaB");
            form.getUsers().Rows.Clear();

            List<User> users = new List<User>();

            if (form.getAdminStatusCheckBox().Checked)
            {
                users = userRepository.UserList().Where(u => u.AdminStatus == "yes").ToList();
            }
            else if (form.getEmployeeStatusCheckBox().Checked)
            {
                users = userRepository.UserList().Where(u => u.AdminStatus == "no").ToList();
            }
            else
            {
                users = userRepository.UserList();
            }

            if (users != null && users.Count != 0)
            {
                setTableList(users);
            }
            else
            {
                users = new List<User> { new User("", "", "", "") };
                setTableList(users);
            }
        }


        public AdminForm getAdminForm()
        {
            return this.form;
        }


    }
}

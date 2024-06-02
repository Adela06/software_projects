using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Presenter
{
    public class UserPresenter
    {
        private IUserGUI userGUI;
        private UserRepository userRepository;

        internal void Initialize(AdminForm adminForm)
        {
            this.userGUI = adminForm;
            this.userRepository = new UserRepository("GradinaB");
        }
        public void UserList()
        {
            //afisarea listei utilizatorilor
            List<User> users = userRepository.UserList();
            if(users != null && users.Count != 0) 
            {
                userGUI.SetTableList(users);
                ResetFields();
            }
            else
            {
                users = new List<User> { new User("","","","","") };
                userGUI.SetTableList(users);
                ResetFields();
                userGUI.SetMessage("Empty list!");
            }
        }
        public void addUser()
        {
            string username = userGUI.getUsername();
            string password = userGUI.getPassword();    
            string adminStatus = userGUI.getAdminStatus();
            User u = new User("1", "1", adminStatus, password, username);
            bool res = userRepository.AddUser(u);
        }
        public void deleteUser(string id)
        {
            userRepository.DeleteUser(id);
        }

        public void updateUser(string id)
        {
            string username = userGUI.getUsername();
            string password = userGUI.getPassword();
            string adminStatus = userGUI.getAdminStatus();

            //Console.WriteLine(username + " " + password);
      
            User u = new User("1", "1", adminStatus, password, username);

            bool res = userRepository.UpdateUser(id,u);
            //Console.WriteLine(res);
        }


        private void ResetFields()
        {

        }

        public void newPlantPage()
        {
            //userGUI.HideForm();
            PlantForm plantForm = new PlantForm();
            plantForm.Show();
        }
    }
}

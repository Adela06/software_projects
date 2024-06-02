using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradinaTema1.ViewModel.Commands
{
    public class ViewUsersCommand : ICommand
    {
        private UserVM vm;
        public ViewUsersCommand(UserVM vm) {  this.vm = vm; }
       
        public void Execute()
        {
            UserRepository userRepository = new UserRepository("GradinaB");

            this.vm.users.Rows.Clear();
            List<User> users = userRepository.UserList();
            if (users != null && users.Count != 0)
            {
                setTableList(users);
            }
            else
            {
                users = new List<User> { new User("", "", "", "", "") };
                setTableList(users);
            }
        }

        private void setTableList(List<User> users)
        {
            foreach (User u in users)
            {
                this.vm.users.Rows.Add(u.Id, u.Password, u.Username, u.AdminStatus);
            }
        }

    }
}

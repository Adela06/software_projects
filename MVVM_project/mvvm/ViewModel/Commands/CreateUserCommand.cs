using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace gradinaTema1.ViewModel.Commands
{
    public class CreateUserCommand : ICommand
    {
        private UserVM vm;

        public CreateUserCommand(UserVM vm)
        {
            this.vm = vm;
        }

        public void Execute()
        {
           UserRepository userRepository = new UserRepository("GradinaB");

            User newUser = new User
            {
                Person = vm.UserID,
                Username = vm.Username,
                Password = vm.Password,
                AdminStatus = vm.AdminStatus
            };
            userRepository.AddUser(newUser);
        }
    }
}

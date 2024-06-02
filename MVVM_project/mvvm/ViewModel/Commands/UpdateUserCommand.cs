using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using System;
using System.Windows.Forms;

namespace gradinaTema1.ViewModel.Commands
{
    public class UpdateUserCommand : ICommand
    {
        private UserVM vm;
        private DataGridView dataGridView;

        public UpdateUserCommand(UserVM vm, DataGridView dataGridView)
        {
            this.vm = vm;
            this.dataGridView = dataGridView;
        }

        public void Execute()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {       
                string userID = dataGridView.SelectedRows[0].Cells["ID"].Value.ToString();

                if (!string.IsNullOrEmpty(userID))
                {
                    User updatedUser = new User
                    {
                        Person = vm.Person,
                        Username = vm.Username,
                        Password = vm.Password,
                        AdminStatus = vm.AdminStatus
                    };

                    UserRepository userRepository = new UserRepository("GradinaB");
                    userRepository.UpdateUser(userID, updatedUser);
                }
            }
        }
    }
}

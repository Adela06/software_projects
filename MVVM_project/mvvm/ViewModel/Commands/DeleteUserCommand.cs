using gradinaTema1.Model.Repository;
using System.Windows.Forms;

namespace gradinaTema1.ViewModel.Commands
{
    public class DeleteUserCommand : ICommand
    {
        private UserVM vm;
        private DataGridView dataGridView;

        public DeleteUserCommand(UserVM vm, DataGridView dataGridView)
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
                    UserRepository userRepository = new UserRepository("GradinaB");

                    userRepository.DeleteUser(userID);

       
                }
                else
                {
                    MessageBox.Show("Selectati un user pt a fi sters!");

                }
            }
          
        }
    }
}

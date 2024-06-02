using gradinaTema1.View;
using System.Windows.Forms;

namespace gradinaTema1.ViewModel.Commands
{
    public class GoToGuestPageCommand : ICommand
    {
        private AdminForm adminForm; 

        public GoToGuestPageCommand(AdminForm adminForm)
        {
            this.adminForm = adminForm;
        }

        public void Execute()
        {
            adminForm.Hide();
            PlantForm guestForm = new PlantForm();
            guestForm.Show();
        }
    }
}

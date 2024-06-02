using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.ViewModel.Commands
{
    public class GoToLoginPage : ICommand
    {
        private PlantForm plantForm;

        public GoToLoginPage(PlantForm plantForm)
        {
            this.plantForm = plantForm;
        }

        public void Execute()
        {
            plantForm.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}

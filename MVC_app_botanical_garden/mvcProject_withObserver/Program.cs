using gradinaTema1.Controller;
using gradinaTema1.Model.Repository;
using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradinaTema1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // LoginController loginController = new LoginController();
            //Application.Run(loginController.getLoginForm());

             PlantController plantController = new PlantController();
             Application.Run(plantController.getPlantForm());
        }
    }
}

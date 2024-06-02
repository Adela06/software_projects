using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.View
{
    public interface ILoginGUI: IGUI
    {
        string Username { get; }
        string Password { get; }
        event Action CancelClicked;
        event Action LoginClicked;

        void Hide();
        void ShowMessage(string message);
        void btnCancel_Click(object sender, EventArgs e);
        void btnLogin_Click(object sender, EventArgs e);
        void button1_Click(object sender, EventArgs e);

    }

}

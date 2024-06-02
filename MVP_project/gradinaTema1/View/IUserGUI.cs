using gradinaTema1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.View
{
    public interface IUserGUI : IGUI
    {
        void SetMessage(string v);
        void SetTableList(List<User> users);
        string getUsername();
        string getPassword();
        string getAdminStatus();
    }
}

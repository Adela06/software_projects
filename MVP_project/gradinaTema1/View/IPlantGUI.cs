using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gradinaTema1.View;
using System.Windows.Forms;
using gradinaTema1.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gradinaTema1.View
{
    public interface IPlantGUI : IGUI
    {
        string GetSearchedInformation();

        string GetSelectedFilter();
        void SetMessage(string v);
        void SetTableList(List<Plant> plants);
        string getName();
        string getTip();
        string getSpecie();
        string getLocatie();
        string getCarnivore();
    }
}

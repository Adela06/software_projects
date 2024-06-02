using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.View
{
    public interface IGUI
    {
        void SetMessage(string title, string message);
        void HideForm();
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class WindowsGUIFactory : GUIFactory
    {
        public IButton button()
        {
            return new WindowsButton();
        }

        public ICheckBox checkBox()
        {
            return new WindowsCheckBox();
        }
    }
}

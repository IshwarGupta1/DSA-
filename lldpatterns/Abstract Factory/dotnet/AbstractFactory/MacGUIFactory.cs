using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class MacGUIFactory : GUIFactory
    {
        public IButton button()
        {
            return new MacButton();
        }

        public ICheckBox checkBox()
        {
            return new MacCheckBox();
        }
    }
}

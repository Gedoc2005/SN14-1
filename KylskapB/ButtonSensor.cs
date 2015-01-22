using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    public class ButtonSensor
    {
        public bool IsOn { get; private set; }

        public ButtonSensor(bool isOn)
        {
            IsOn = isOn;
        }
    }
}

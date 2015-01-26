using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    public class DoorSensor
    {
        //Aggregat till TemperatureDisplay
        public bool DoorIsOpen { get; private set; }

        public DoorSensor(bool doorIsOpen)
        {
            DoorIsOpen = doorIsOpen;
        }
    }
}

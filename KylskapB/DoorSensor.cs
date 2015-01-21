using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    public class DoorSensor
    {
        public bool DoorIsOpen { get; } //todo mattias kolla med mattias om open eller closed. ska den verkligen vara readonly?

        public DoorSensor(bool doorIsOpen)
        {
            DoorIsOpen = doorIsOpen;//todo readonly?
        }






    }
}

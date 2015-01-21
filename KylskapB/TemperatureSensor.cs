using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    public class TemperatureSensor
    {
        private decimal _temperature;

        public decimal Temperature { get; private set; }

        public TemperatureSensor(decimal temperature)
        {
            Temperature = temperature;//todo fält eller egenskap?
        }

        public void Simulate(decimal targetTemperature, decimal outsideTemperature, bool isOn, bool doorIsOpen)
        {
            if (IsOn)// todo hmmmmmmmm?
            {
                if (DoorIsOpen)
                {
                    InsideTemperature += 0.2M;//todo ska denna klass prop tilldelas?
                }
                else
                {
                    InsideTemperature -= 0.2M;
                }
            }
            else
            {
                if (DoorIsOpen)
                {
                    InsideTemperature += 0.5M;
                }
                else
                {
                    InsideTemperature += 0.1M;
                }
            }
        }




    }
}

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

        public decimal Temperature //todo ska nog kasta exception här!
        {
            get { return _temperature; }
            private set
            {
                if (value < 0 || value > 45)
                {
                    throw new ArgumentException("Innertemperaturen är  inte i intervallet 0 - 45°C");
                }
                _temperature = value;
            }
        }

        public TemperatureSensor(decimal temperature)
        {
            Temperature = temperature;
        }

        public void Simulate(decimal targetTemperature, decimal outsideTemperature, bool isOn, bool doorIsOpen)
        {
            if (Temperature < outsideTemperature)
            {
                if (isOn)
                {
                    if (doorIsOpen)
                    {
                        Temperature += 0.2M;//todo ska denna klassprop tilldelas?
                    }
                    else
                    {
                        Temperature -= 0.2M;
                    }
                }
                else
                {
                    if (doorIsOpen)
                    {
                        Temperature += 0.5M;
                    }
                    else
                    {
                        Temperature += 0.1M;
                    }
                }
            } 
        }




    }
}

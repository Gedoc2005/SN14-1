﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    //Aggregat till TemperatureDisplay
    public class TemperatureSensor
    {
        private decimal _temperature;

        public decimal Temperature
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

        //Simulera temperaturskiftningen för en minut utifrån givna förutsättningar:
        public void Simulate(decimal targetTemperature, decimal outsideTemperature, bool isOn, bool doorIsOpen)
        {
            decimal change = 0;
            if (isOn)
            {
                if (doorIsOpen)
                {
                    change = 0.2M;
                }
                else
                {
                    change = -0.2M;
                }
            }
            else
            {
                if (doorIsOpen)
                {
                    change = 0.5M;
                }
                else
                {
                    change = 0.1M;
                }
            }
            if (Temperature + change > outsideTemperature)
            {
                Temperature = outsideTemperature;
            }
            else if (Temperature + change < targetTemperature)
            {
                Temperature = targetTemperature;
            }
            else
            {
                Temperature += change;
            }
        }
    }
}

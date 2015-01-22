using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    public class Cooler
    {
        private TemperatureDisplay _temperatureDisplay;

        public bool DoorIsOpen { get { return _temperatureDisplay.DoorIsOpen; } }
        public decimal InsideTemperature { get { return _temperatureDisplay.InsideTemperature; } }
        public bool IsOn { get { return _temperatureDisplay.IsOn; } }
        public decimal TargetTemperature { get { return _temperatureDisplay.TargetTemperature; } }

        public Cooler()
            : this(0M, 0M)
        {

        }
        public Cooler(decimal temperature, decimal targetTemperature)
            : this(temperature, targetTemperature, false, false)
        {

        }
        public Cooler(decimal temperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
        {
            _temperatureDisplay = new TemperatureDisplay(temperature, targetTemperature, isOn, doorIsOpen);
        }

        public bool Tick()
        {
            return _temperatureDisplay.Tick();
        }
        public override string ToString()
        {
            return _temperatureDisplay.ToString();
        }
    }
}

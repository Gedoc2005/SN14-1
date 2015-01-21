using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    public class TemperatureDisplay
    {
        private TemperatureSensor _insideTemperatureSensor = new TemperatureSensor();
        private DoorSensor _doorSensor = new DoorSensor();
        private ButtonSensor _buttonSensor = new ButtonSensor();
        private decimal _targetTemperature;
        private const decimal OutsideTemperature = 23.7M;

        //todo ska jag koppla dessas props till instanserna oovan?
        public bool DoorIsOpen { get; }
        public decimal InsideTemperature { get; }
        public bool IsOn { get; }
        public decimal TargetTemperature 
        { 
            get
            {
                return _targetTemperature;
            }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentException("blabla!!");//todo korrekt sträng!
                }
            }
        }

        public TemperatureDisplay(decimal insideTemperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
        {//todo detta är jag osäker på?
            DoorIsOpen = doorIsOpen;
            InsideTemperature = insideTemperature;//todo mattias ska ddet var inside eller utan?
            IsOn = isOn;
            TargetTemperature = _targetTemperature;
        }

        public bool Tick()
        {
            _insideTemperatureSensor.Simulate();//todo mattias vad ska jag stoppa i för instansvärden?
        }
        public override string ToString()
        {//todo mattias ska den returnera värdet för cooler, har jag inte redan en sådan?
            string returnValue;
            returnValue = String.Format("[{0}] : {1:F1}°C : ({2:F1}°C) - {3}",
                IsOn == true ? "PÅ" : "AV",
                InsideTemperature,
                TargetTemperature,
                DoorIsOpen == true ? "Öppet" : "Stängt");
            return returnValue;
        }













    }
}

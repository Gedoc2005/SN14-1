using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    public class Cooler
    {
        private TemperatureDisplay _temperatureDisplay = new TemperatureDisplay();// todo är detta korrekt? 

        public bool DoorIsOpen { get { return _temperatureDisplay.DoorIsOpen; } }//todo fixa dessa sen
        public decimal InsideTemperature { get { return _temperatureDisplay.InsideTemperature; } }
        public bool IsOn { get { return _temperatureDisplay.IsOn; } }
        public decimal TargetTemperature
        {
            get { return _temperatureDisplay.TargetTemperature; }
            set { _temperatureDisplay.TargetTemperature = value; }//todo mattias klassdiagrammet visar readonly?
        }

        public Cooler()
            : this(0M, 0M)
        {

        }
        public Cooler(decimal temperature, decimal targetTemperature)
            : this(temperature, targetTemperature, false, false)//todo false eller true?
        {

        }
        public Cooler(decimal temperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
        {
            //todo mattias den har ju inga värden att tilldela!!!

        }

        public bool Tick()
        {
            //todo mattias ska metoden simulate anropas som på något annat ställle?
        }
        public override string ToString()
        {
            string returnString;
            returnString = String.Format("[{0}] : {1:F1}°C : ({2:F1}°C) - {3}",
                IsOn == true ? "PÅ" : "AV",
                InsideTemperature,
                TargetTemperature,
                DoorIsOpen == true ? "Öppet" : "Stängt");
            return returnString;
        }








    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapA
{
    public class Cooler//todo ska den modifieras till public?
    {
        private decimal _insideTemperature;
        private decimal _targetTemperature;
        public const decimal OutsideTemperature = 23.7M;

        public bool DoorIsOpen { get; set; }
        public decimal InsideTemperature 
        { 
            get
            {
                return _insideTemperature;
            }
            set
            {
                if (value < 0 || value > 45)// TODO: Kolla om jag ska kunna skicka in 0 och 45?
                {
                    throw new ArgumentException("Innertemperaturen är inte i intervallet 0 - 45°C");
                }
                else if (value < _targetTemperature)
                {
                    _insideTemperature = _targetTemperature;// todo jävligt osäker på detta är rätt!
                }
                else if (value > OutsideTemperature)
                {
                    _insideTemperature = OutsideTemperature;
                }
                else
                {
                    _insideTemperature = value; 
                }
            }
        }
        public bool IsOn { get; set; }
        public decimal TargetTemperature 
        { 
            get
            {
                return _targetTemperature;
            }
            set
            {
                if (value < 0 || value > 20)// TODO: Kolla om jag ska kunna skicka in 0 och 20? Är det rätt värden? Ska jag handla det var?
                {
                    throw new ArgumentException("Måltemperaturen är inte i intervallet 0 - 20°C");
                }
                _targetTemperature = value;
            }
        }

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
            InsideTemperature = temperature;// todo rätt egenskap?
            TargetTemperature = targetTemperature;
            IsOn = isOn;
            DoorIsOpen = doorIsOpen;
        }

        public void Tick()
        {
            if (IsOn)
            {
                if (DoorIsOpen)
	            {
		            InsideTemperature += 0.2M; 
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
        public override string ToString()
        {
            //todo formatera detta korrekt!
            //tex 2 decimaler
            //behöver jag en variabel?
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

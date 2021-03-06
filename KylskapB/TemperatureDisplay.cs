﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    public class TemperatureDisplay
    {
        //Förutom TargetTemperature, som TemperatureDisplay kontrollerar, ska egenskaperna vara aggregat:
        //Deklarera konstanten OutsideTemperature:
        private TemperatureSensor _insideTemperatureSensor;
        private DoorSensor _doorSensor;
        private ButtonSensor _buttonSensor;
        private decimal _targetTemperature;
        private const decimal OutsideTemperature = 23.7M;

        public bool DoorIsOpen { get { return _doorSensor.DoorIsOpen; } }
        public decimal InsideTemperature { get { return _insideTemperatureSensor.Temperature; } }
        public bool IsOn { get { return _buttonSensor.IsOn; } }
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
                    throw new ArgumentException("Måltemperaturen är  inte i intervallet 0 - 20°C");
                }
                _targetTemperature = value;
            }
        }

        //Initiera utgångsvärden för kylskåp:
        public TemperatureDisplay(decimal insideTemperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
        {
            _doorSensor = new DoorSensor(doorIsOpen);
            _insideTemperatureSensor = new TemperatureSensor(insideTemperature);
            _buttonSensor = new ButtonSensor(isOn);
            TargetTemperature = targetTemperature;
        }

        //Aktivera simulering för en minut och kontrollera om måltemperatur är uppnådd:
        public bool Tick()
        {
            _insideTemperatureSensor.Simulate(TargetTemperature, OutsideTemperature, IsOn, DoorIsOpen);
            return InsideTemperature == TargetTemperature ? true : false;
        }

        //Skapa sträng att skriva ut till konsollfönstret:
        public override string ToString()
        {
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

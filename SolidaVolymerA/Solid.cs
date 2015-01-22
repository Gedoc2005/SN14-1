using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymerA
{
    public abstract class Solid
    {
        private double _height;
        private double _radius;

        public abstract double BaseArea { get; }
        public double Height 
        { 
            get { return _height; } 
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                _height = value; 
            } 
        }
        public double HeightSquared { get { return _height * _height; } }
        public double Radius 
        {
            get { return _radius; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                _radius = value;
            }
        }
        public double RadiusSquared { get { return _radius * _radius; } }
        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }

        protected Solid(double radius, double height)
        {
            //todo vad ska in här?
        }
        public override string ToString()
        {
            string returnValue;
            returnValue = String.Format("{0,-10}{10,-10}{1}\n{2,-10}{10,-10}{3}\n{4,-10}{10,-10}{5}\n{6,-10}{10,-10}{7}\n{8,-10}{10,-10}{9}",
                "Radie (r)", Radius,
                "Höjd (h)", Height, 
                "Volym", Volume, 
                "Basarea", BaseArea, 
                "Ytarea", SurfaceArea, 
                ":");
            return returnValue;
        }
    }
}

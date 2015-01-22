using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymerB
{
    enum SolidType { CircularCone, Cylinder};

    public abstract class Solid : IComparable
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
                    throw new ArgumentException("\nFel! Ange ett flyttal större än 0.\n");
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
                    throw new ArgumentException("\nFel! Ange ett flyttal större än 0.\n");
                }
                _radius = value;
            }
        }
        public double RadiusSquared { get { return _radius * _radius; } }
        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }

        protected Solid(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }
        public override string ToString()//todo fixa här
        {
            string returnValue = String.Format("{0}{1,10}{2,6}{3,13}{4,13}{5,13}", 
                this.GetType(), Radius, )
            
            return returnValue;
        }
        public int CompareTo(object obj)//todo fixa här
        {
            throw new NotImplementedException();
        }
    }
}

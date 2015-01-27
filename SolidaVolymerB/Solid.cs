using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymerB
{
    //Skapa enum för typer av solider:
    enum SolidType { CircularCone, Cylinder};

    //Skapa generalisering av solidtypers egenskaper och metoder som abstrakt klass:
    //Skapa kontrakt med IComparable. Implementera dess metod CompareTo att jämföra objekts volymer:
    public abstract class Solid : IComparable
    {
        private double _height;
        private double _radius;

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
        public abstract double BaseArea { get; }
        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }

        //Instansiera subklasserna här:
        protected Solid(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        //Gör egen implementation av ToString, ärvd från klassen Object
        public override string ToString()
        {
            string returnValue = String.Format("{0,-12}{1,9:F1}{2,7:F1}{3,13:F2}{4,13:F2}{5,13:F2}",
                GetType().Name, Radius, Height, Volume, BaseArea, SurfaceArea);

            return returnValue;
        }
        public int CompareTo(object obj)
        {
            Solid solid = obj as Solid;
            if (solid == null)
            {
                throw new ArgumentException();
            }
            if (obj == null)
            {
                return 1;
            }
            return Volume.CompareTo(solid.Volume);
        }
    }
}
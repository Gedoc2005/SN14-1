using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymerA
{
    enum SolidType { CircularCone, Cylinder}

    class Program
    {
        static void Main(string[] args)
        {

        }

        private static Solid CreateSolid(SolidType solidType)
        {
            
            Solid solid;
            double radius = ReadDoubleGreaterThanZero("Ange radien (r): ");
            double height = ReadDoubleGreaterThanZero("Ange höjden (h)");
            switch (solidType)
            {
                case SolidType.CircularCone:
                    return solid = new CircularCone(radius, height);
                case SolidType.Cylinder:
                    return solid = new Cylinder(radius, height);
            }
        }
        private static double ReadDoubleGreaterThanZero(string prompt)
        {

        }
        private static void ViewMenu()
        {

        }
        private static void ViewSolidDetail(Solid solid)
        {

        }
    }
}

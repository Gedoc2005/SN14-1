using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymerB
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                //Slumpa fram värden till ett slumpat antal slumpvalda solider:
                Solid[] solids = RandomizeSolids();

                //Sortera efter volym och visa soliderna:
                Array.Sort(solids);
                ViewSolids(solids);

                //Välj att avsluta eller fortsätta:
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nTryck på valfri tangent för att fortsätta - ESC avslutar.\n");
                Console.ResetColor();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static Solid[] RandomizeSolids()
        {
            Random random = new Random();
            Solid[] solids = new Solid[random.Next(5, 21)];//Slumpa fram antalet solider.
            const double doubleMax = 100.0;
            const double doubleMin = 5.0;
            double radius;
            double height;

            for (int solid = 0; solid < solids.Length; solid++)
            {
                //Slumpa, inom givna konstanter, radie och höjd för soliderna:
                radius = random.NextDouble() * (doubleMax - doubleMin) + doubleMin;
                height = random.NextDouble() * (doubleMax - doubleMin) + doubleMin;

                //Slumpa fram vilken typ av solid:
                switch ((SolidType)random.Next(0, 2))
                {
                    case SolidType.CircularCone:
                        solids[solid] = new CircularCone(radius, height);
                        break;
                    case SolidType.Cylinder:
                        solids[solid] = new Cylinder(radius, height);
                        break;
                }
            }
            return solids;

        }
        private static void ViewSolids(Solid[] solids)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                                 ║");
            Console.WriteLine("║                          Solida Volymer                         ║");
            Console.WriteLine("║                                                                 ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("{0,-12}{1,9}{2,7}{3,13}{4,13}{5,13}", 
                "Solid", "Radie", "Höjd", "Volym", "Basarea", "Ytarea");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════");
            foreach (var solid in solids)
            {
                Console.WriteLine(solid.ToString());
            }
        }
    }
}

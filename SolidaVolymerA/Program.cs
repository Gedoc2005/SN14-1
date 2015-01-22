using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymerA
{
    enum SolidType { CircularCone, Cylinder }

    class Program
    {
        static void Main(string[] args)
        {
            int index;


            do
            {
                Console.Clear();
                ViewMenu();
                if (int.TryParse(Console.ReadLine(), out index) && index <= 2 && index >= 0)
                {
                    switch (index)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                          Kon                         ║");
                            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
                            Console.ResetColor();
                            Console.WriteLine();
                            ViewSolidDetail(CreateSolid(SolidType.CircularCone));
                            break;
                        case 2:
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                       Cylinder                       ║");
                            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
                            Console.ResetColor();
                            Console.WriteLine();
                            ViewSolidDetail(CreateSolid(SolidType.Cylinder));
                            break;
                    }  
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFel! Du måste ange ett nummer mellan 0 och 2.");
                    Console.ResetColor();
                }
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nTryck valfri tangent för att börja om - ESC avslutar.");
                Console.ResetColor();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static Solid CreateSolid(SolidType solidType)
        {

            Solid solid;
            double radius = ReadDoubleGreaterThanZero("Ange radien (r): ");
            double height = ReadDoubleGreaterThanZero("Ange höjden (h): ");
            switch (solidType)
            {
                case SolidType.CircularCone:
                    return solid = new CircularCone(radius, height);
                case SolidType.Cylinder:
                    return solid = new Cylinder(radius, height);
            }
            return null;//todo fixa
        }
        private static double ReadDoubleGreaterThanZero(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    return value;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFel! Ange ett flyttal större än 0.\n");
                    Console.ResetColor();
                } 
            }
        }
        private static void ViewMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║                   Solida Volymer                     ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("0. Avsluta.\n");
            Console.WriteLine("1. Kon.\n");
            Console.WriteLine("2. Cylinder.\n");
            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.Write("Ange ditt menyval [0-2]: ");
        }
        private static void ViewSolidDetail(Solid solid)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        Detaljer                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(solid.ToString());
            Console.WriteLine();
            Console.WriteLine("════════════════════════════════════════════════════════");
        }
    }
}

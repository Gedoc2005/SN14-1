using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapB
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo mattias är det cooler som ska instansieras i testen?
            Cooler cooler = new Cooler(5.3M, 4M, true, false);
            Run(cooler, 10);
        }

        private static void Run(Cooler c, int minutes)
        {
            for (int ticks = 0; ticks < minutes; ticks++)
            {
                if (!c.Tick())
                {
                    Console.WriteLine(c.ToString());
                } 
            }
        }
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

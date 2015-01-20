using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylskapA
{
    class Program
    {
        static void Main(string[] args)
        {
            Cooler cooler;
            //1
            cooler = new Cooler();
            Console.WriteLine(cooler.ToString());
            //2
            cooler = new Cooler(24.5M, 4M);
            Console.WriteLine(cooler.ToString());
            //3
            cooler = new Cooler(19.5M, 4M, true, false);
            Console.WriteLine(cooler.ToString());
            //4
            cooler = new Cooler(5.3M, 4M, true, false);
            Console.WriteLine(cooler.ToString());
            Run(cooler, 10);
            //5
            cooler = new Cooler(5.3M, 4M, false, false);
            Console.WriteLine(cooler.ToString());
            Run(cooler, 10);
            //6
            cooler = new Cooler(5.3M, 4M, true, true);
            Console.WriteLine(cooler.ToString());
            Run(cooler, 10);
            //7
            cooler = new Cooler(19.7M, 4M, false, true);
            Console.WriteLine(cooler.ToString());
            Run(cooler, 10);
            //8
            //try
            //{
            //    cooler.InsideTemperature = 100M;//argument
            //}
            //catch (ArgumentException ex)
            //{
            //    ViewErrorMessage(ex.Message);
            //}

            //try
            //{
            //    cooler.TargetTemperature = 100M;
            //}
            //catch (ArgumentException ex)
            //{
            //    ViewErrorMessage(ex.Message);
            //}
            //9
            //try
            //{
            //    cooler = new Cooler(100M, 100M, false, true);
            //}
            //catch (ArgumentException ex)
            //{
            //    ViewErrorMessage(ex.Message);
            //}
            decimal innerTemperature, targetTemperature;
            
            for (int testNumber = 1; testNumber < 11; testNumber++)
            {
                switch (switch_on)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    default:
                }
            }




        }

        private static void Run(Cooler c, int minutes)
        {
            for (int ticks = 0; ticks < minutes; ticks++)
            {
                
                c.Tick();
                Console.WriteLine(c.ToString());
            }
        }
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void ViewTestHeader(string header)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Test nummer.");
            Console.WriteLine(header);
        }
        private static void Test()
        {

        }
    }
}

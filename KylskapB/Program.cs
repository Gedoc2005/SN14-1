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
            RunTest();
        }

        private static void Run(Cooler c, int minutes)
        {
            for (int ticks = 0; ticks < minutes; ticks++)
            {
                Console.WriteLine(c.ToString());
                c.Tick();
            }
        }
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void RunTest()
        {
            Cooler cooler;

            for (int testNumber = 1; testNumber < 10; testNumber++)// todo finns det något bättre testalternativ?
            {
                Console.WriteLine("════════════════════════════════════════");
                Console.WriteLine("Test {0}.", testNumber);

                switch (testNumber)
                {
                    case 1:
                        Console.WriteLine("Test av standardkonstruktorn\n");
                        cooler = new Cooler();
                        Console.WriteLine(cooler.ToString());
                        break;
                    case 2:
                        Console.WriteLine("Test av konstruktorn med två parametrar, (24,5 och 4)\n");
                        cooler = new Cooler(24.5M, 4M);
                        Console.WriteLine(cooler.ToString());
                        break;
                    case 3:
                        Console.WriteLine("Test av konstruktorn med 4 parametrar, (19,5, 4, True, False)\n");
                        cooler = new Cooler(19.5M, 4M, true, false);
                        Console.WriteLine(cooler.ToString());
                        break;
                    case 4:
                        Console.WriteLine("Test av kylning med metoden Tick\n");
                        cooler = new Cooler(5.3M, 4M, true, false);
                        Run(cooler, 10);
                        Console.WriteLine(cooler.ToString());
                        break;
                    case 5:
                        Console.WriteLine("Test av avstängt kylskåp med metoden Tick, vara avslaget och ha stängd dörr\n");
                        cooler = new Cooler(5.3M, 4M, false, false);
                        Run(cooler, 10);
                        Console.WriteLine(cooler.ToString());
                        break;
                    case 6:
                        Console.WriteLine("Test av påslaget kylskåp med metoden Tick, vara på och ha öppen dörr\n");
                        cooler = new Cooler(5.3M, 4M, true, true);
                        Run(cooler, 10);
                        Console.WriteLine(cooler.ToString());
                        break;
                    case 7:
                        Console.WriteLine("Test av avslaget kylskåp med metoden Tick, ha öppen dörr\n");
                        cooler = new Cooler(19.7M, 4M, false, true);
                        Run(cooler, 10);
                        Console.WriteLine(cooler.ToString());
                        break;
                    case 8:
                        Console.WriteLine("Test av egenskaperna så att undantag kastas då innertemperaturen och måltemperaturen tilldelas felaktiga värden\n");
                        TemperatureDisplay temperatureDisplay = new TemperatureDisplay(10M, 10M, false, false);
                        try
                        {
                            temperatureDisplay.TargetTemperature = 21M;
                        }
                        catch (ArgumentException ex)
                        {
                            ViewErrorMessage(ex.Message);
                        }
                        try
                        {
                            temperatureDisplay.TargetTemperature = -1M;
                        }
                        catch (ArgumentException ex)
                        {
                            ViewErrorMessage(ex.Message);
                        }
                        break;
                    case 9:
                        Console.WriteLine("Test av konstruktorerna så att undantag kastas då innertemperaturen och måltemperaturen tilldelas felaktiga värden\n");
                        cooler = new Cooler();
                        try
                        {
                            cooler = new Cooler(46M, 0M);
                        }
                        catch (ArgumentException ex)
                        {
                            ViewErrorMessage(ex.Message);
                        }
                        try
                        {
                            cooler = new Cooler(-1M, 0M);
                        }
                        catch (ArgumentException ex)
                        {
                            ViewErrorMessage(ex.Message);
                        }
                        try
                        {
                            cooler = new Cooler(0M, 21M);
                        }
                        catch (ArgumentException ex)
                        {
                            ViewErrorMessage(ex.Message);
                        }
                        try
                        {
                            cooler = new Cooler(0M, -1M);
                        }
                        catch (ArgumentException ex)
                        {
                            ViewErrorMessage(ex.Message);
                        }
                        break;
                }
                Console.WriteLine();

            }
        }
    }
}

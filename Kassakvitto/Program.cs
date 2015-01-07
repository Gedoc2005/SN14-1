using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassakvitto
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalsumma = 0;
            int erhalletBelopp = 0;
            decimal oresavrundning = 0;
            int totalsummaAvrundat = 0;
            int beloppTillbaka = 0;

            //Loopar tills godkänd totalsumma är inmatad och inte är under 1 kr:
            while (true)
            {
                try
                {
                    Console.Write("{0,-20}: ", "Ange totalsumma");
                    totalsumma = decimal.Parse(Console.ReadLine());
                    if ((Math.Round(totalsumma) < 1))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nTotalsumman är för liten. Köpet kunde inte genomföras.");
                        Console.ResetColor();

                        return;
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! Erhållen totalsumma är felaktig!\n");
                    Console.ResetColor();
                }
            }

            //Loopar tills godkänt belopp är inmatad och inte är mindre än totalsumman:
            while (true)
        	{
                try
                {
                    Console.Write("{0,-20}: ", "Ange erhållet belopp");
                    erhalletBelopp = int.Parse(Console.ReadLine());
                    if (totalsumma > erhalletBelopp)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nErhållet belopp är för litet. Köpet kunde inte genomföras.");
                        Console.ResetColor();

                        return;
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! Erhållet belopp är felaktigt!\n");
                    Console.ResetColor();
                }
            }

            //Beräkna kvitto:
            totalsummaAvrundat = (int)Math.Round(totalsumma);
            oresavrundning = totalsummaAvrundat - totalsumma;
            beloppTillbaka = erhalletBelopp - totalsummaAvrundat;

            //Skriv ut kvitto:
            Console.WriteLine("\nKVITTO\n-------------------------------");
            Console.WriteLine("{0,-17}:{1,13:C}", "Totalt", totalsumma);
            Console.WriteLine("{0,-17}:{1,13:C}", "Öresavrundning", oresavrundning);
            Console.WriteLine("{0,-17}:{1,13:C0}", "Att betala", totalsummaAvrundat);
            Console.WriteLine("{0,-17}:{1,13:C0}", "Kontant", erhalletBelopp);
            Console.WriteLine("{0,-17}:{1,13:C0}", "Tillbaka", beloppTillbaka);
            Console.WriteLine("-------------------------------\n");

            //Beräkna och skriv ut typ och antal valörer man får tillbaka:
            int rest = 0;
            int antal = 0;
            antal = beloppTillbaka / 500; //T ex: Räknar ut hur många 500-lappar det går på beloppet man får tillbaka.
            rest = beloppTillbaka % 500; //T ex: Räknar ut vad som blir över när man räknat ut ovanstående rad.
            Console.WriteLine("{0,-17}: {1}", "500-lappar", antal);
            antal = rest / 100;
            rest %= 100;
            Console.WriteLine("{0,-17}: {1}", "100-lappar", antal);
            antal = rest / 20;
            rest %= 20;
            Console.WriteLine("{0,-17}: {1}", "20-lappar", antal);
            antal = rest / 5;
            rest %= 5;
            Console.WriteLine("{0,-17}: {1}", "5-kronor", antal);
            Console.WriteLine("{0,-17}: {1}", "1-kronor", rest);
        }
    }
}

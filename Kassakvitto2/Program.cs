using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassakvitto2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tangentTyp; //Variabeln som ska innehålla valet av knapptryck senare.
            //Starta do while-satsen för att loopa programet tills man väljer att avbryta det. 
            do
            {
                //Läs in totalsumma och erhållet belopp:
                double totalsumma = LasPositivDouble("Ange totalsumma");
                uint totalsummaAvrundat = (uint)Math.Round(totalsumma); //Metoden på nästa rad,LasUInt(), accepterar bara positiva HELTAL.
                uint erhalletBelopp = LasUInt("Ange erhållet belopp",totalsummaAvrundat);

                //Beräkna kvitto:
                double oresavrundning = 0d;
                uint beloppTillbaka = 0U;
                oresavrundning = Math.Round((totalsummaAvrundat - totalsumma),2); //Använder Math för runda av till två decimaler.
                beloppTillbaka = erhalletBelopp - totalsummaAvrundat;

                //Skriv ut kvitto:
                Console.WriteLine("\nKVITTO\n-------------------------------");
                Console.WriteLine("{0,-17}:{1,13:C}", "Totalt", totalsumma);
                Console.WriteLine("{0,-17}:{1,13:C}", "Öresavrundning", oresavrundning);
                Console.WriteLine("{0,-17}:{1,13:C0}", "Att betala", totalsummaAvrundat);
                Console.WriteLine("{0,-17}:{1,13:C0}", "Kontant", erhalletBelopp);
                Console.WriteLine("{0,-17}:{1,13:C0}", "Tillbaka", beloppTillbaka);
                Console.WriteLine("-------------------------------\n");

                //Skriv ut typ och antal valörer man får tillbaka:
                DelaUppIFaktorer(beloppTillbaka);

                //Fråga om omstart av programmet:
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTryck tangent för ny beräkning - Esc avslutar.");
                Console.ResetColor();
                tangentTyp  = Console.ReadKey();

                //Avsluta eller loopa programmet:
            } while (tangentTyp.Key != ConsoleKey.Escape);
            return;
        }
        static double LasPositivDouble(string titel)
        {
            //Skilj på inmatat värde och godkänt returvärde, för att få rätt värde på placeholdern i felmeddelandet:
            string inmatadSumma = "";
            double godkandSumma = 0d;

            //Loopa frågan tills man får en godkänd returtyp:
            while (true)
            {
                try
                {
                    Console.Write("{0,-20}: ", titel);
                    inmatadSumma = Console.ReadLine();
                    godkandSumma = double.Parse(inmatadSumma);

                    if ((Math.Round(godkandSumma) < 1))
                    {
                        throw new Exception();
                    }
                    return godkandSumma;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! '{0}' kan inte tolkas som en giltig summa pengar.\n", inmatadSumma);
                    Console.ResetColor();
                }
            }
        }
        static uint LasUInt(string titel, uint minVarde)
        {
            //Skilj på inmatat värde och godkänt returvärde, för att få rätt värde på placeholdern i felmeddelandet:
            string inmatatBelopp = "";
            uint godkantBelopp = 0U;

            //Loopa frågan tills man får en godkänd returtyp:
            while (true)
            {
                try
                {
                    Console.Write("{0,-20}: ", titel);
                    inmatatBelopp = Console.ReadLine();
                    godkantBelopp = uint.Parse(inmatatBelopp);

                    if (minVarde > godkantBelopp)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    return godkantBelopp;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! '{0}' kan inte tolkas som en giltig summa pengar.\n", inmatatBelopp);
                    Console.ResetColor();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! {0} kr är ett för litet belopp.\n", godkantBelopp);
                    Console.ResetColor();
                }
                
            }
        }
        static void DelaUppIFaktorer(uint vaxel)
        {
            uint[] valorer = {500, 100, 50, 20, 10, 5, 1};
            string[] valorTyper = { "-lappar", "-lappar", "-lappar", "-lappar", "-kronor", "-kronor", "-kronor" };
            uint antal = 0U;

            for (int i = 0; i < valorer.Length; i++)
            {
                //Räkna ut antal sedlar/mynt det går på varje valör... :
                antal = vaxel / valorer[i];
                //... och hur mycket växel som blir över efter varje iteration:
                vaxel %= valorer[i];

                //Om resterande växel gick att dela med nuvarande valören, skriv ut detta:
                if (antal != 0)
                {
                    Console.WriteLine("{0, -17}: {1}", valorer[i] + valorTyper[i], antal);
                }
            }
        }
    }
}

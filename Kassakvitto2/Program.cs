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
            /*Jag kunde inte komma på hur jag BRA skulle kunna skilja på sedlar/mynt i utskriften
            så jag chansade och skrev en ful while-sats. Väl medveten om att det troligen är fel tillvägagångssätt
            då jag antar att det, enligt instruktionerna, menas att man bara får använda ett "decision statement" 
            (det är bara att byta ut nyckelordet while till if så har man ett "decision statement"). Hade jag haft fria händer hade jag 
            istället lagt till en if-sats för att bestämma valör för utskriften. Jag testade också andra tillvägagångsätt 
            (kalla på metoder, switch-satser, dubbla while-satser m fl) men de blev för långa.*/
            uint[] valorer = {500, 100, 50, 20, 10, 5, 1};
            uint antal = 0U;
            string valorTyp = "";

            foreach (uint valor in valorer)
            {
                //Räkna ut antal sedlar/mynt det går på varje valör... :
                antal = vaxel / valor;
                //... och hur mycket växel som blir över efter varje iteration:
                vaxel %= valor;

                //Om resterande växel gick att dela med nuvarande valören, skriv ut detta:
                if (antal != 0)
                {
                    //Välj sedel/mynt-utskrift:
                    valorTyp = "-kronor";
                    while (valor > 10) //Detta är while-satsen jag är osäker på.
                    {
                        valorTyp = "-lappar";
                        break;
                    }
                    Console.WriteLine("{0, -17}: {1}", valor + valorTyp, antal);
                }
            }
        }
    }
}

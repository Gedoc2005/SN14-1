using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Loopa programmet tills användaren avbryter:
            do
            {
                try
                {
                    //Mata in antal löner:
                    int salariesCount = ReadInt("Ange antal löner att mata in: ");
                    Console.WriteLine();
                    if (salariesCount > 1)
                    {
                        ProcessSalaries(salariesCount); //Metoden matar in löner, beräknar lönerna och redovisar lönerna.
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning!");
                    Console.ResetColor();
                }

                //Programmet avslutas om användaren, vid förfrågan, trycker på Escape.
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTryck tangent för ny beräkning - Esc avslutar.\n");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            return;
        }
        private static int ReadInt(string question)
        {
            //Skilj på sträng och integer för att kunna skriva ut svaret i felmeddelandet:
            int approvedInput = 0;
            string input = "";

            //Låt användaren mata in data tills godkänt värde matas in:
            while (true)
	        {
	            try
                {
                    Console.Write(question);
                    input = Console.ReadLine();
                    approvedInput = int.Parse(input);
                    if (approvedInput >= 0)
	                {
                        return approvedInput;
	                }
                    else
                    {
                        throw new Exception();
                    }
                }

                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nFEL! '{0}' kan inte tolkas som ett heltal.\n", input);
                    Console.WriteLine();
                    Console.ResetColor();
                } 
	        }

        }
        private static void ProcessSalaries(int count)
        {
            int[] salariesValues = new int[count];
            int[] salariesValuesSorted = new int[count];
            double salaryMedian;
            double salaryAverage;
            int salarySpread;

            //Mata in lön för varje element i salariesValues[]:
            for (int currentSalary = 0; currentSalary < count; currentSalary++)
            {
                string question = string.Format("Ange lön nummer {0}: ", (currentSalary + 1));
                salariesValues[currentSalary] = ReadInt(question);
            }
            Console.WriteLine();

            //Beräkna spridning och medellön:
            salarySpread = salariesValues.Max() - salariesValues.Min();
            salaryAverage = salariesValues.Average();

            //Beräkna medianen genom att först kopiera sedan sortera kopian:
            Array.Copy(salariesValues, salariesValuesSorted, count);
            Array.Sort(salariesValuesSorted);

            //Avgör om medianen ska räknas ut för jämnt eller udda antal löner, samt räkna ut medianen:
            if ((count % 2) == 0)
            {
		        int middleElement1 = salariesValuesSorted[(count / 2) - 1];
                int middleElement2 = salariesValuesSorted[(count / 2)];
                salaryMedian = (middleElement1 + middleElement2) / 2;
            }
            else
	        {
                salaryMedian = salariesValuesSorted[(count / 2)];
	        }

            //Skriv ut median, medel och spridning för lönerna:
            Console.WriteLine("------------------------------");
            Console.WriteLine("{0,-15}{1,9:C0}", "Medianlön:", salaryMedian); //hur många decimaler ska jag ha?
            Console.WriteLine("{0,-15}{1,9:C0}", "Medellön:", salaryAverage);
            Console.WriteLine("{0,-15}{1,9:C0}", "Lönespridning:", salarySpread);
            Console.WriteLine("------------------------------");

            //Skriv ut lönerna i orginal arrayen, 3 löner per rad:
            for (int colCount = 0; colCount < count; colCount++)
            {
                
                if ((colCount != 0) && (colCount % 3 == 0))
                {
                    Console.WriteLine();
                }
                Console.Write("{0,8}", salariesValues[colCount]);
            }
            Console.WriteLine();
            return;
        }

    }
}

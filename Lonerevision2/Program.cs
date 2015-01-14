using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonerevision
{
    class Program
    {
        private static void Main(string[] args)
        {
            //Loopa programmet tills användaren, när förfrågad, trycker på Escape:
            do
            {
                try
                {
                    //Mata in antal löner och kontrollera returvärdet:
                    int salariesCount = ReadInt("Ange antal löner att mata in: ");
                    Console.WriteLine();
                    if (salariesCount < 2)
                    {
                        throw new Exception();
                    }

                    //Mata in löner:
                    int[] salaryValues = ReadSalaries(salariesCount);

                    //Skriv ut löner:
                    ViewResults(salaryValues);
                }
                catch (Exception)
                {
                    ViewMessage("Du måste mata in minst två löner för att kunna göra en beräkning!", true);
                }

                //Skicka förfrågan och returnera svar om omstart av programmet:
            } while (IsContinuing());
            return;
        }
        #region Methods
        private static int GetDispersion(int[] source)
        {
            return source.Max() - source.Min();
        }
        private static int GetMedian(int[] source)
        {
            int[] sourceSorted = new int[source.Length];
            int sourceLength = source.Length;

            //Beräkna medianen genom att först kopiera, sedan sortera kopian:
            Array.Copy(source, sourceSorted, sourceLength);
            Array.Sort(sourceSorted);

            //Avgör om medianen ska räknas ut för jämnt eller udda antal löner, samt räkna ut och returnera medianen:
            if ((sourceLength % 2) == 0)
            {
                int middleElement1 = sourceSorted[(sourceLength / 2) - 1];
                int middleElement2 = sourceSorted[(sourceLength / 2)];
                return (middleElement1 + middleElement2) / 2;
            }
            else
            {
                return sourceSorted[(sourceLength / 2)];
            }
        }
        private static bool IsContinuing()
        {
            //Fråga om att fortsätta programmet:
            string message = string.Format("\n {0} Tryck tangent för ny beräkning - Esc avslutar.", (char)16);
            ViewMessage(message, false);

            //Läs och returnera knappnedtryck som bool:
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }
        private static int ReadInt(string prompt)
        {
            //Skilj på inmatat och godkänt värde för att kunna skriva ut svaret i felmeddelandet:
            int approvedInput = 0;
            string input = "";

            //Låt användaren mata in data tills godkänt värde matas in:
            while (true)
            {
                try
                {
                    Console.Write(prompt);
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
                    string message = string.Format("\nFEL! '{0}' kan inte tolkas som ett heltal.\n", input);
                    ViewMessage(message, true);
                }
            }
        }
        private static int[] ReadSalaries(int count)
        {
            int[] salaryValues = new int[count];

            //Skriv in lön för respektive element i array:
            for (int currentSalary = 0; currentSalary < count; currentSalary++)
            {
                string question = string.Format("Ange lön nummer {0}: ", (currentSalary + 1));
                salaryValues[currentSalary] = ReadInt(question);
            }
            Console.WriteLine();
            return salaryValues;
        }
        private static void ViewMessage(string message, bool isError)
        {
            //Skriv ut som felmeddelande:
            if (isError)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ResetColor();
            }
            //Skriv ut som meddelande:
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        private static void ViewResults(int[] salaries)
        {
            //Skriv ut median, medel och spridning för lönerna. Anropa respektive metoder för varje utskrift:
            Console.WriteLine("------------------------------");
            Console.WriteLine("{0,-15}{1,9:C0}", "Medianlön:", GetMedian(salaries));
            Console.WriteLine("{0,-15}{1,9:C0}", "Medellön:", salaries.Average());
            Console.WriteLine("{0,-15}{1,9:C0}", "Lönespridning:", GetDispersion(salaries));
            Console.WriteLine("------------------------------");

            //Skriv ut lönerna, 3 löner per rad:
            for (int colCount = 0; colCount < salaries.Length; colCount++)
            {
                if ((colCount != 0) && (colCount % 3 == 0))
                {
                    Console.WriteLine();
                }
                Console.Write("{0,8}", salaries[colCount]);
            }
            Console.WriteLine();
            return;
        }
        #endregion
    }
}

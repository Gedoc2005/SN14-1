﻿using System;
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
            //Loopa programmet tills användaren avbryter:
            do
            {
                try
                {
                    //Mata in antal löner:
                    int salariesCount = ReadInt("Ange antal löner att mata in: ");
                    Console.WriteLine(); //Går det verkligen inte att lägga in radbryt i metoden?
                    if (salariesCount < 2)
                    {
                        throw new Exception();
                    }

                    int[] salaryValues = ReadSalaries(salariesCount);

                    ViewResults(salaryValues);
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning!");
                    Console.ResetColor();
                }
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

            //Beräkna medianen genom att först kopiera sedan sortera kopian:
            Array.Copy(source, sourceSorted, sourceLength);
            Array.Sort(sourceSorted);

            //Avgör om medianen ska räknas ut för jämnt eller udda antal löner, samt räkna ut medianen:
            if ((sourceLength % 2) == 0)
            {
                int middleElement1 = sourceSorted[(sourceLength / 2) - 1];
                int middleElement2 = sourceSorted[(sourceLength / 2)];
                return middleElement1 + middleElement2 / 2;
            }
            else
            {
                return sourceSorted[(sourceLength / 2)];
            }
        }
        private static bool IsContinuing()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nTryck tangent för ny beräkning - Esc avslutar.\n");
            Console.ResetColor();
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }
        private static int ReadInt(string prompt)
        {
            //Skilj på sträng och integer för att kunna skriva ut svaret i felmeddelandet:
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
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nFEL! '{0}' kan inte tolkas som ett heltal.\n", input);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }
        private static int[] ReadSalaries(int count)
        {
            int[] salaryValues = new int[count];
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

        }
        private static void ViewResults(int[] salaries)
        {
            //Skriv ut median, medel och spridning för lönerna:
            Console.WriteLine("------------------------------");
            Console.WriteLine("{0,-15}{1,9:C0}", "Medianlön:", GetMedian(salaries));
            Console.WriteLine("{0,-15}{1,9:C0}", "Medellön:", salaries.Average());
            Console.WriteLine("{0,-15}{1,9:C0}", "Lönespridning:", GetDispersion(salaries));
            Console.WriteLine("------------------------------");

            //Skriv ut lönerna i orginal arrayen, 3 löner per rad:
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

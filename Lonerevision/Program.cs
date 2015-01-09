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


            do
            {
                try
                {
                    int salariesCount = ReadInt("Ange antal löner att mata in: ");
                    int[] salaries = new int[salariesCount];

                    if (salaries.Length < 2)
                    {
                        throw new Exception();
                    }

                    for (int currentSalary = 0; currentSalary < salaries.Length; currentSalary++)
                    {
                        string question = "Ange lön nummer " + (currentSalary + 1) + ": ";//Detta är nog inte okej (string.format?)!
                        salaries[currentSalary] = ReadInt(question);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning!");
                } 
            } while (true);//Skicka frågan här istället!

            


        }
        private static int ReadInt(string question)
        {
            int approvedInput = 0;
            string input = "";

            while (true)
	        {
	            try
                {
                    Console.Write(question);
                    input = Console.ReadLine();
                    approvedInput = int.Parse(input);
                    if (approvedInput < 0)
	                {
		                throw new Exception();
	                }
                    return approvedInput;
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

    }
}

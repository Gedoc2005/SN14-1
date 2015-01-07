using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitaAsterisker2
{
    class Program
    {
        const int BaseMaxValue = 79;
        const string Filling = "*";
        const string Surrounding = " ";

        static void Main(string[] args)
        {
            ConsoleKeyInfo keyPressed; //Variabeln som ska innehålla valet av knapptryck senare.
            //Starta do while-satsen för att loopa programet tills man väljer att avbryta det. 
            do
            {
                //Hämta triangelns bas-värde:
                byte cols = ReadOddByte();

                //Rita ut triangeln:
                RenderTriangle(cols);

                //Fråga om omstart av programmet:
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTryck tangent för att fortsätta - Esc avslutar.");
                Console.ResetColor();
                keyPressed = Console.ReadKey();

                //Avsluta eller loopa programmet:
            } while (keyPressed.Key != ConsoleKey.Escape);
            return;
        }
        static byte ReadOddByte() //privata metoder?
        {
            while (true)
	        {
	            try 
	            {
                    Console.Write("Ange det udda antalet asterisker (max {0}) i triangelns bas: ", BaseMaxValue);
                    byte value = byte.Parse(Console.ReadLine());
                    if ((value > BaseMaxValue) || ((value % 2) != 1))
                    {
                        throw new Exception();
                    }
                    return value;
	            }
	            catch (Exception)
	            {
                    Console.BackgroundColor = ConsoleColor.Red;
	                Console.ForegroundColor = ConsoleColor.White;
		            Console.WriteLine("\nFEL! Det inmatade värdet är inte ett udda heltal mellan 1 och {0}.\n", BaseMaxValue);
                    Console.ResetColor();
	            } 
	        }
        }
        static void RenderTriangle(byte cols)
        {
            int test = (cols + 1) / 2;
            int test2 = 1;
            int test3 = (cols - 1) / 2;

            for (int r = 0; r < test; r++)
            {
                Console.WriteLine();
                for (int i = 0; i < test3; i++)
                {
                    Console.Write(Surrounding);
                }
                test3--;

                for (int j = 0; j < test2; j++)
                {
                    Console.Write(Filling);
                }
                test2 += 2;
            }
            return;
            
        }

    }
}

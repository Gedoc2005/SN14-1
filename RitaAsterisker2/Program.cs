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
        const string Printing = "*";
        const string Indentation = " ";

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
        private static byte ReadOddByte()
        {
            //Fortsätt fråga tills godkänt värde returneras:
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
        private static void RenderTriangle(byte cols)
        {
            int rowCount = (cols + 1) / 2; //Ger förhållandet mellan triangelns bas och antal rader.
            int indentationCount = (cols - 1) / 2; //Som ovan fast för hur många "Indentation" som skrivs ut i första raden.
            int printingCount = 1; //Första antalet iterationer för utskrift av "Printing".

            //Iterera för varje rad:
            for (int row = 0; row < rowCount; row++)
            {
                Console.WriteLine();

                //Starta utskrift av konstanten "Indentation":
                for (int column = 0; column < indentationCount; column++)
                {
                    Console.Write(Indentation);
                }
                indentationCount--; //Minska antalet iterationer/utskrifter inför nästa rad.

                //Starta utskrift av konstanten "Printing":
                for (int column = 0; column < printingCount; column++)
                {
                    Console.Write(Printing);
                }
                printingCount += 2; //Öka antalet iterationer/utskrifter inför nästa rad.
            }
            return;
        }
    }
}

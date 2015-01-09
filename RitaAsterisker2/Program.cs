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
        private static byte ReadOddByte()
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
        private static void RenderTriangle(byte cols)
        {
            int rowCount = (cols + 1) / 2; //Ger förhållandet mellan triangelns bas och antal rader.
            int surroundingCount = (cols - 1) / 2; //Som ovan fast för hur många "Surroundings" som skrivs ut i första raden.
            int fillingCount = 1; 

            //Starta itereration för varje rad:
            for (int row = 0; row < rowCount; row++)
            {
                Console.WriteLine();

                //Starta iteration för varje "Surrounding":
                for (int colSur = 0; colSur < surroundingCount; colSur++)
                {
                    Console.Write(Surrounding);
                }
                surroundingCount--;

                //Starta itereration för varje "Filling":
                for (int colFill = 0; colFill < fillingCount; colFill++)
                {
                    Console.Write(Filling);
                }
                fillingCount += 2;
            }
            return;
            
        }

    }
}

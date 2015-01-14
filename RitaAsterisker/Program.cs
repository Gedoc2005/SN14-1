using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitaAsterisker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gör en iteration för varje rad:
            for (int rad = 0; rad < 25; rad++)
            {
                //Välj vilken färg som ska skrivas ut:
                switch (rad % 3)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    default:
                        break;
                }

                //Indentera om nuvarande iteration/rad är udda:
                if (rad % 2 == 1)
                {
                        Console.Write(" ");
                }

                //Skriv ut dessa asterisker/kolumner för varje iteration/rad:
                for (int kolumn = 0; kolumn < 39; kolumn++)
                {
                    Console.Write("* ");
                }

                //Återställ färg och bryt rad:
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}

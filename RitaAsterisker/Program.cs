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
            //Skapa loop för raderna:
            for (int rad = 0; rad < 25; rad++)
            {
                //Välj vilken färg som ska skrivas ut:
                switch (ValjFarg(rad))
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

                //Intendera nuvarande iterations rad, om metoden Indentera() är true:
                if (Indentera(rad))
                {
                        Console.Write(" ");
                }

                //Skriv ut asteriskerna för varje rad:
                for (int kol = 0; kol < 39; kol++)
                {
                    
                    Console.Write("* ");
                }

                //Återställ färg och bryt rad:
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        #region Metoder

        //Genomför modulus-operation på aktuellt iterationsvärde och returnera ett booleanskt värde:
        static bool Indentera(int varde)
        {
            return varde % 2 != 0;
        }

        //Genomför modulus-operation på aktuellt iterationsvärde och returnera en integer mellan 0-2 (tre möjliga värden):
        static int ValjFarg(int varde)
        {
            return varde % 3;
        }
        #endregion //Avsluta Metoder.
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.A
{
    public class SecretNumber
    {
        //Deklarera variabler och initiera konstanten;
        private int _count; //Räknar svaren.
        private int _number; //Det hemliga numret.
        public const int MaxNumberOfGuesses = 7;

        public void Initialize()
        {
            //Skapa objekt av klassen Random och initiera övriga variabler:
            Random random = new Random();
            _number = random.Next(1, 101);
            _count = 0;
        }
        public bool MakeGuess(int number)
        {
            //Kolla om argumentet och antalet frågor som är ställda är godkända:
            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }
            else if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                _count++; //inkrementera "svarsräknaren".
            }

            //Skapa en variabel som visar hur många frågor man har kvar:
            int invertedCount = -1 * (_count - MaxNumberOfGuesses);

            //Skriv ut respektive svar beroende på argumenet/gissningen:
            if (number == _number)
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök", _count);
                return true;
            }
            else if (number < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar. ",
                    number, invertedCount);
            }
            else if (number > _number)
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar. ",
                    number, invertedCount);
            }

            //Lägg till detta i utskriften när man gissat max antal gånger:
            if (_count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
            }
            return false;
        }
        public SecretNumber()
        {
            Initialize();
        }
    }
}

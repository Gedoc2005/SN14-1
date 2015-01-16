using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.B
{
    public class SecretNumber
    {
        private int[] _guessedNumbers;
        private int _number; //Det hemliga numret.
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess { get; private set; }
        public int Count { get; private set; } //Räknar antalet gissningar.

        public int GuessesLeft 
        { 
            get { return -1 * (Count - MaxNumberOfGuesses); } 
        }

        public void Initialize()
        {
            //Se till att vi inte lagrar några värden i _guessedNumbers:
            Array.Clear(_guessedNumbers, 0, _guessedNumbers.Length);

            //Initiera det hemliga numret:
            Random random = new Random();
            _number = random.Next(1, 101);

            //Återställ egenskaperna:
            CanMakeGuess = true;
            Count = 0;
        }
        public bool MakeGuess(int number)
        {
            //Kontrollera om vi får göra fler gissningar och att argumentet är godkänt 
            if (Count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }
            else if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            //Om gissningen är unik => spara gissningen och inkrementera "gissningsräknaren":
            if (Array.IndexOf(_guessedNumbers, number) > -1)
            {
                Console.WriteLine("Du har redan gissat på {0}. Gör om gissningen!", number);
                return false;
            }
            else
            {
                _guessedNumbers[Count] = number;
                Count++;
            }
            
            //Skriv ut respektive svar beroende på argumenet/gissningen:
            if (number == _number)
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök", Count);
                CanMakeGuess = false;
                return true;
            }
            else if (number < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar. ",
                    number, GuessesLeft);
            }
            else
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar. ", number, GuessesLeft);
            }

            //Lägg till detta i utskriften när man gissat max antal gånger:
            if (Count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
                CanMakeGuess = false;
            }
            return false;
        }

        public SecretNumber()
        {
            //Initiera objektet:
            _guessedNumbers = new int[MaxNumberOfGuesses];
            Initialize();
        }
    }
}

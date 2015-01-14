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
        private int _number;
        private int _count;
        private bool _canMakeGuess;
        public const int MaxNumberOfGuesses = 7;

        //Behöver jag sätta get som public specifikt och behöver jag lägga till fält, behöver jag kunna getta?
        public bool CanMakeGuess { get { return _canMakeGuess; } private set { _canMakeGuess = value; } }
        public int Count 
        { 
            get { return _count; } 
            private set 
            {
                if (value >= MaxNumberOfGuesses)
                {
                    throw new ApplicationException();
                }
                _count = value;
            } 
        }
        public int GuessesLeft { get { return -1 * (Count - MaxNumberOfGuesses); } }

        public void Initialize()
        {
            Array.Clear(_guessedNumbers, 0, _guessedNumbers.Length);

            Random random = new Random();
            _number = random.Next(1, 101);

            CanMakeGuess = true;
            Count = 0;
        }
        public bool MakeGuess(int number)
        {

            //Kolla är godkända:
            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            int a = Array.IndexOf(_guessedNumbers, number);//tillfälligt
            if (a > -1)
            {
                Console.WriteLine("Du har redan gissat på {0}. Gör om gissningen!", number);
                return false;
            }
            _guessedNumbers[Count] = number;



            try
            {
                Count++; //inkrementera "svarsräknaren".
            }
            catch (ApplicationException)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
                CanMakeGuess = false;
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
            else if (number > _number)
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar. ",
                    number, GuessesLeft);
            }

            //Lägg till detta i utskriften när man gissat max antal gånger:
            //if (Count == MaxNumberOfGuesses)//Är detta uttryck överflödigt, kolla countprop
            //{
            //    Console.WriteLine("Det hemliga talet är {0}", _number);
            //    CanMakeGuess = false;
            //}
            return false;
        }
        public SecretNumber()
        {
            _guessedNumbers = new int[MaxNumberOfGuesses];
            Initialize();
        }



    }
}

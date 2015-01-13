using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.A
{
    public class SecretNumber
    {
        private int _count;
        private int _number;
        public const int MaxNumberOfGuesses = 7;

        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);
            _count = 0;
        }
        public bool MakeGuess(int number)
        {
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
                _count++;
            }

            int invertedCount = -1 * (_count - MaxNumberOfGuesses);

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

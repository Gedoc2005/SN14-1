using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GissaTaletMVC.Models
{
    public class SecretNumber
    {
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess { get { return Count < MaxNumberOfGuesses ? true : false; } }
        public int? Count { get { return GuessedNumbers.Count; } }
        public IReadOnlyList<GuessedNumber> GuessedNumbers { get { return _guessedNumbers.AsReadOnly(); } }
        public GuessedNumber LastGuessedNumber { get { return _lastGuessedNumber; } }
        public int? Number { get { return CanMakeGuess ? null : _number; } private set { _number = value; } }

        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            Initialize();
        }

        public void Initialize()
        {
            _guessedNumbers.Clear();
            _lastGuessedNumber.Outcome = Outcome.Undefined;

            Random random = new Random();
            Number = random.Next(1, 101);
        }
        public Outcome MakeGuess(int guess)//todo skita i returyyp?
        {
            Outcome pending;

            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (Count == MaxNumberOfGuesses)
            {
                pending = Outcome.NoMoreGuesses;
            }
            else if (GuessedNumbers.Any(x => x.Number == guess))
            {
                pending = Outcome.OldGuess;
            }
            else if (guess == _number)
            {
                pending = Outcome.Right;
            }
            else if (guess < _number)
            {
                pending = Outcome.Low;
            }
            else
            {
                pending = Outcome.High;
            }

            _lastGuessedNumber = new GuessedNumber() { Number = guess, Outcome = pending };

            if (pending != Outcome.NoMoreGuesses && pending != Outcome.OldGuess)
            {
                _guessedNumbers.Add(_lastGuessedNumber);
            }

            return pending;
        }
    }
}
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

        public bool CanMakeGuess { get { return Count < MaxNumberOfGuesses ? true : false; } }//todo kolla så att operatorn stämmer! kan jag hantera null här?
        public int? Count { get { return GuessedNumbers.Count; } }
        public IReadOnlyList<GuessedNumber> GuessedNumbers { get { return _guessedNumbers; } } //todo användandet av asreadonly()
        public GuessedNumber LastGuessedNumber { get { return _lastGuessedNumber; } }
        public int? Number { get { return CanMakeGuess ? null : _number; } private set { _number = value; } }//todo ge null tills antal gissningar uppnåts? ska bara returneras om gissningar är slut!!!!!

        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();//todo rätt?
            Initialize();
            
        }

        public void Initialize()//todo är det här jag ska ge undefined? eller på konstruktorn?
        {
            _guessedNumbers.Clear();
            _lastGuessedNumber.Outcome = Outcome.Undefined;

            Random random = new Random();
            Number = random.Next(1, 101);
            //todo fler fält/egenskaper som behöver instansiers?
        }
        public Outcome MakeGuess(int guess)//todo ordna iferna och ska inte alla enum vara med?
        {
            Outcome pending;

            if (guess < 1 && guess > 100)
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
            else if (guess == _number)//todo det är väl inte möjligt med switch?
            {
                pending = Outcome.Right;
            }
            else if (guess < _number)//todo är det rätt
            {
                pending = Outcome.Low;
            }
            else //(guess > _number)//todo else?
            {
                pending = Outcome.High;
            }

            _lastGuessedNumber = new GuessedNumber() { Number = guess, Outcome = pending };//todo är det rätt att inte mata in lastnumber i gissade nummer?

            if (pending != Outcome.NoMoreGuesses && pending != Outcome.OldGuess)//todo osäker, se ovan!
            {
                _guessedNumbers.Add(_lastGuessedNumber);
            }
            return pending;
        }
    }
}
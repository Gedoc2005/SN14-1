using GissaTaletMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GissaTaletMVC.ViewModels
{
    public class SecretNumberViewModel
    {
        #region Fields/Properties
        private readonly string[] _countTexts = new string[] { "Första", "Andra", "Tredje", "Fjärde", "Femte", "Sjätte", "Sjunde" };

        public IReadOnlyList<GuessedNumber> GuessedNumbers { get; set; }
        public int? Number { get; set; }
        public bool CanMakeGuess { get; set; }
        public int Count { get; set; }
        public GuessedNumber LastGuessedNumber { get; set; }

        [Remote("IsOldGuess", "Home")]
        [Required(ErrorMessage = "Du måste göra en gissning.")]
        [Range(1, 100, ErrorMessage = "Talet måste vara mellan 1 och 100.")]
        [RegularExpression("\\d+", ErrorMessage = "Det måste vara ett tal.")]
        public int Guess { get; set; }
        public string Header 
        { 
            get 
            {
                if (Count == 0)
                {
                    return "";
                }
                return LastGuessedNumber.Outcome == Outcome.Right ? "Rätt gissat!" : _countTexts[Count - 1] + " gissningen";
            } 
        }
        public string Message 
        { 
            get 
            {
                string message = "";

                switch (LastGuessedNumber.Outcome)
                {
                    case Outcome.Right:
                        return String.Format("Grattis, du klarade det på {0} försöket!", _countTexts[Count - 1].ToString().ToLower());
                    case Outcome.OldGuess:
                        return String.Format("Du har redan gissat på {0}, välj ett annat tal.", LastGuessedNumber.Number);
                    case Outcome.High:
                        message = String.Format("{0} är för högt.", LastGuessedNumber.Number);
                        break;
                    case Outcome.Low:
                        message = String.Format("{0} är för lågt.", LastGuessedNumber.Number);
                        break;
                }

                if (!CanMakeGuess)
                {
                    message = String.Format("{0} Inga fler gissningar, det hemliga talet var {1}", message, Number);
                }

                return message;
            } 
        }
        #endregion
    }

    //Skapa "extensionmetod" för att mappa till vymodell:
    public static class MyExtensions
    {
        public static SecretNumberViewModel ToViewModel(this SecretNumber x, int guess = 0)
        {
            return new SecretNumberViewModel
               {
                   GuessedNumbers = x.GuessedNumbers,
                   Number = x.Number,
                   Count = x.Count,
                   LastGuessedNumber = x.LastGuessedNumber,
                   CanMakeGuess = x.CanMakeGuess,
                   Guess = guess
               };
        }
    }
}
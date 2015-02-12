﻿using GissaTaletMVC.Models;
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
        #region Properties
        private Dictionary<int?, string> _countTexts = new Dictionary<int?, string>//todo konstant?
        {
            {1, "Första"},
            {2, "Andra"},
            {3, "Tredje"},
            {4, "Fjärde"},
            {5, "Femte"},
            {6, "Sjätte"},
            {7, "Sjunde"}
        };

        public IReadOnlyList<GuessedNumber> GuessedNumbers { get; set; }
        public int? Number { get; set; }

        [Remote("IsOldGuess", "Home")]
        [Required(ErrorMessage = "Du måste göra en gissning.")]
        [Range(1, 100, ErrorMessage = "Talet måste vara mellan 1 och 100.")]
        public int Guess { get; set; }

        public bool CanMakeGuess { get; set; }
        public int? Count { get; set; }
        public GuessedNumber LastGuessedNumber { get; set; }
        #endregion

        public string GetMessage(Outcome outcome)
        {
            string message = "";

            switch (outcome)
            {
                case Outcome.Right:
                    return String.Format("Grattis, du klarade det på {0} försöket!", _countTexts[Count].ToString().ToLower());
                case Outcome.OldGuess:
                    return String.Format("Du har redan gissat på {0}, välj ett annat tal.", LastGuessedNumber.Number);
                case Outcome.High:
                    message = String.Format("{0} är för lågt.", LastGuessedNumber.Number);
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
        public string GetHeader()
        {
            if (Count == 0)//todo amatörmässigt? null?
            {
                return "";
            }
            return LastGuessedNumber.Outcome == Outcome.Right ? "Rätt gissat!" : _countTexts[Count] + " gissningen";
        }
    }

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
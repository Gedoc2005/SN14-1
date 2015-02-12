using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GissaTaletMVC.Models
{
    public enum Outcome
    {
        Undefined,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }
}
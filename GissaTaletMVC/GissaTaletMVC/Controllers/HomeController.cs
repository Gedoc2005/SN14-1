using GissaTaletMVC.Models;
using GissaTaletMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace GissaTaletMVC.Controllers
{
    public class HomeController : Controller
    {
        // Hämtar/Skapar användare att mappa till vymodell och skicka till vyn:
        public ActionResult Index()
        {
            return View(GetUser().ToViewModel());
        }

        // Om datan är korrekt görs en gissning, annars skickas den tillbaka till vyn:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guess([Bind(Include = "Guess")] SecretNumberViewModel x)
        {
            if (Session.IsNewSession)
            {
                Session["User"] = null;
                return View("SessionError");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    GetUser().MakeGuess(x.Guess);
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }
            return View("Index",
                    GetUser().ToViewModel(x.Guess));
        }

        // Skapar ny spelomgång:
        public ActionResult Initialize()
        {
            GetUser().Initialize();
            return RedirectToAction("Index");
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]// Ser till att inga requests cashas hos clienten
        public JsonResult IsOldGuess(int guess)
        {
            if (Session.IsNewSession)// Ser till att POST-metoden verkligen känner igen att en ny "session" har inletts.
            {
                Session.Abandon();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            if (GetUser().GuessedNumbers.Any(x => x.Number == guess))
            {
                string message = String.Format("Du har redan gissat på {0}.", guess);
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // Hämtar/Skapar en "användare":
        private SecretNumber GetUser()
        {
            SecretNumber x = Session["User"] as SecretNumber;
            if (x == null)
            {
                x = new SecretNumber();
                Session["User"] = x;
            }
            return x;
        }
    }
}
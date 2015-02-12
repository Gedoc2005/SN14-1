using GissaTaletMVC.Models;
using GissaTaletMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GissaTaletMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(GetUser().ToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guess(SecretNumberViewModel x)
        {
            if (Session.IsNewSession)//todo fanskapet fungerar inte längre
            {
                Session["User"] = null;
                return View("SessionError");
            }

            if (ModelState.IsValid)
            {
                GetUser().MakeGuess(x.Guess);
                return View("Index",
                    GetUser().ToViewModel(x.Guess));//todo onödigt att skicka tillbak tll action?
            }
            else
            {
                return View("Index",
                    GetUser().ToViewModel(x.Guess));//todo behöver jag skicka user? och dubblering!!!!!!!!
            }
        }

        public ActionResult Initialize()
        {
            GetUser().Initialize();
            return RedirectToAction("Index");
        }

        public JsonResult IsOldGuess(int guess)
        {
            if (GetUser().GuessedNumbers.Any(x => x.Number == guess))
            {
                string message = String.Format("Du har redan gissat på {0}.", guess);
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private SecretNumber GetUser()
        {
            SecretNumber x = (SecretNumber)Session["User"];
            if (x == null)
            {
                x = new SecretNumber();
                Session["User"] = x;
            }
            return x;
        }
    }
}
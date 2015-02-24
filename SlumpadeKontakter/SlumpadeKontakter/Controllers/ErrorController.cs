using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlumpadeKontakter.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            Response.StatusCode = 500;
            return View();
        }

        public ActionResult NotFound(string message)
        {
            
            return View(model: message);
        }
    }
}
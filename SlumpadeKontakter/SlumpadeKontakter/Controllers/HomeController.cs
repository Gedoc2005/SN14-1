using SlumpadeKontakter.Models;
using SlumpadeKontakter.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SlumpadeKontakter.Controllers
{
    public class HomeController : Controller
    {
        #region Repository Setup
        private readonly IRepository _repository;


        public HomeController()
            : this(new XmlRepository()) { }

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        #endregion


        public ActionResult Index()
        {
            return View(_repository.GetLastContacts());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            try
            {
                _repository.Add(contact);
                _repository.Save();
                TempData["success"] = "Personen blev korrekt ifylld och sparad";
            }
            catch (Exception)
            {
                TempData["fail"] = "Personen blev inte skapad";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                throw new HttpException(404, "Du begärde ett oglitigt GUID");
            }
            var contact = _repository.GetContactById(id.Value);
            if (contact == null)
            {
                throw new HttpException(404, "Kontakten du begärde finns inte eller har just blivit borttagen");
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            try
            {
                _repository.Update(contact);
                _repository.Save();
                TempData["success"] = "Personen blev korrekt redigerad och sparad";
            }
            catch (Exception)
            {
                TempData["fail"] = "Personen blev inte redigerad och sparad";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                throw new HttpException(404, "Du begärde ett oglitigt GUID");
            }
            var contact = _repository.GetContactById(id.Value);
            if (contact == null)
            {
                throw new HttpException(404, "Kontakten du begärde finns inte eller har just blivit borttagen");
            }
            return View(contact);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var x = _repository.GetContactById(id);

            if (x == null)
            {
                throw new HttpException(404, "Kontakten du begärde finns inte eller har just blivit borttagen");
            }
            try
            {
                _repository.Delete(x);
                _repository.Save();
                TempData["success"] = "Personen blev korrekt borttagen";
            }
            catch (Exception)
            {
                TempData["fail"] = "Personen blev inte borttagen";
            }

            return RedirectToAction("Index");
        }
    }
}
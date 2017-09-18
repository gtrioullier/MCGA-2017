using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Languages.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Languages/Language
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.LanguageProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Languages/Language/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.LanguageProcess();
            var language = cp.Find(id);
            return View(language);
        }

        //GET: Languages/Language/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Languages/Language/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Language model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.LanguageProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Languages/Language/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.LanguageProcess();
            var language = cp.Find(id);
            return View(language);
        }

        //POST: Languages/Language/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Language model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.LanguageProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Languages/Language/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.LanguageProcess();
            var language = cp.Find(id);
            return View(language);
        }

        //POST: Languages/Language/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Language model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.LanguageProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
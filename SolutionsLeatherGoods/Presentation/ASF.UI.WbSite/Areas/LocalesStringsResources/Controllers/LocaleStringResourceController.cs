using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.LocalesStringsResources
{
    public class LocaleStringResourceController : Controller
    {
        // GET: LocalesStringsResources/LocaleStringResource
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.LocaleStringResourceProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: LocalesStringsResources/LocaleStringResource/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.LocaleStringResourceProcess();
            var localestringresource = cp.Find(id);
            return View(localestringresource);
        }

        //GET: LocalesStringsResources/LocaleStringResource/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: LocalesStringsResources/LocaleStringResource/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.LocaleStringResource model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.LocaleStringResourceProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: LocaleStringResources/LocaleStringResource/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.LocaleStringResourceProcess();
            var localestringresource = cp.Find(id);
            return View(localestringresource);
        }

        //POST: LocalesStringsResources/LocaleStringResource/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.LocaleStringResource model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.LocaleStringResourceProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: LocalesStringsResources/LocaleStringResource/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.LocaleStringResourceProcess();
            var localestringresource = cp.Find(id);
            return View(localestringresource);
        }

        //POST: LocalesStringsResources/LocaleStringResource/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.LocaleStringResource model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.LocaleStringResourceProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Countries.Controllers
{
    public class CountryController : Controller
    {
        // GET: Countries/Country
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.CountryProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Categories/Country/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.CountryProcess();
            var country = cp.Find(id);
            return View(country);
        }

        //GET: Categories/Country/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Categories/Country/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Country model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CountryProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Categories/Country/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.CountryProcess();
            var country = cp.Find(id);
            return View(country);
        }

        //POST: Categories/Country/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Country model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CountryProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Categories/Country/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.CountryProcess();
            var country = cp.Find(id);
            return View(country);
        }

        //POST: Categories/Country/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Country model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CountryProcess();
                model.ChangedOn = DateTime.Now;
                if (model.CreatedBy == 0)
                {
                    model.CreatedBy = null;
                }
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }

    }
}
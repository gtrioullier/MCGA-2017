using ASF.UI.WbSite.Services.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Countries.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        // GET: Countries/Country
        public ActionResult Index()
        {
            //var cp = new ASF.UI.Process.CountryProcess();
            //var lista = cp.SelectList();
            var lista = DataCacheService.Instance.CountryList();
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
            var model = new ASF.Entities.Country();

            model.ChangedOn = DateTime.Now;
            model.CreatedOn = DateTime.Now;
            model.ChangedBy = 0;
            model.CreatedBy = 0;

            return View(model);
        }

        //POST: Categories/Country/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Country model)
        {
            if (ModelState.IsValid)
            {
                DataCacheService.Instance.ClearCountry();
                var cp = new ASF.UI.Process.CountryProcess();
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
                DataCacheService.Instance.ClearCountry();
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
                DataCacheService.Instance.ClearCountry();
                var cp = new ASF.UI.Process.CountryProcess();
                model.ChangedOn = DateTime.Now;
                model.ChangedBy = 0;
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }

    }
}
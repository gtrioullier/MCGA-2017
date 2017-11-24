using ASF.UI.WbSite.Services.Cache;
using ASF.UI.WbSite.Services.Audit;
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
            var audit = Audit.getAudit();
            model.ChangedOn = audit.date;
            model.CreatedOn = audit.date;
            model.ChangedBy = audit.user;
            model.CreatedBy = audit.user;

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
                var audit = Audit.getAudit();
                model.ChangedOn = audit.date;
                model.ChangedBy = audit.user;
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }

    }
}
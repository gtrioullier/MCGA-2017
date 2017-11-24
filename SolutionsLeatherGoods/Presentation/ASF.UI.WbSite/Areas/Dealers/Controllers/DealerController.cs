using ASF.UI.WbSite.Services.Cache;
using ASF.UI.WbSite.Services.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ASF.UI.WbSite.Areas.Dealers.Controllers
{
    [Authorize]
    public class DealerController : Controller
    {
        // GET: Dealers/Dealer
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.DealerProcess();
            var cpCountry = new ASF.UI.Process.CountryProcess();
            var cpCategory = new ASF.UI.Process.CategoryProcess();
            var lista = cp.SelectList().OrderBy(d => d.LastName);
            var countries = DataCacheService.Instance.CountryList();
            var categories = DataCacheService.Instance.CategoryList();

            foreach (var l in lista)
            {
                l.Category = categories.Find(c => c.Id == l.CategoryId);
                l.Country = countries.Find(c => c.Id == l.CountryId);
            }

            return View(lista.OrderBy(l => l.LastName));
        }

        //GET: Dealers/Dealer/Details/5
        public ActionResult Details(Guid Rowid)
        {
            var cp = new ASF.UI.Process.DealerProcess();
            var dealer = cp.Find(Rowid);
            return View(dealer);
        }

        //GET: Dealers/Dealer/Create
        public ActionResult Create()
        {
            var countries = DataCacheService.Instance.CountryList();
            var categories = DataCacheService.Instance.CategoryList();
            var userid =  User.Identity.GetUserId(); // varchar(128)

            ViewBag.countries = countries;
            ViewBag.categories = categories;

            ASF.Entities.Dealer model = new Entities.Dealer();

            Guid g;
            g = Guid.NewGuid();
            var audit = Audit.getAudit();
            model.Rowid = g;
            model.CreatedOn = audit.date;
            model.ChangedOn = audit.date;
            model.CreatedBy = audit.user;
            model.ChangedBy = audit.user;

            return View(model);
        }

        //POST: Dealers/Dealer/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Dealer model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.DealerProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Dealers/Dealer/Delete
        public ActionResult Delete(Guid Rowid)
        {
            var cp = new ASF.UI.Process.DealerProcess();
            var dealer = cp.Find(Rowid);
            return View(dealer);
        }

        //POST: Dealers/Dealer/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Dealer model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.DealerProcess();
                cp.Delete(model.Rowid);
            }
            return RedirectToAction("Index");

        }

        //GET: Dealers/Dealer/Edit
        public ActionResult Edit(Guid Rowid)
        {
            var countries = DataCacheService.Instance.CountryList();
            var categories = DataCacheService.Instance.CategoryList();

            ViewBag.countries = countries;
            ViewBag.categories = categories;

            var cp = new ASF.UI.Process.DealerProcess();
            var dealer = cp.Find(Rowid);
            return View(dealer);
        }

        //POST: Dealers/Dealer/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Dealer model)
        {
            if (ModelState.IsValid)
            {
                var audit = Audit.getAudit();
                model.ChangedOn = audit.date;
                model.ChangedBy = audit.user;
                var cp = new ASF.UI.Process.DealerProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
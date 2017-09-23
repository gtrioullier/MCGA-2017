using ASF.UI.WbSite.Services.Cache;
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
            var lista = cp.SelectList().OrderBy(d => d.LastName);

            return View(lista);
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
            model.Rowid = g;
            model.CreatedOn = DateTime.Now;
            model.ChangedOn = DateTime.Now;
            model.CreatedBy = 0; // int32, no es posible la conversión
            model.ChangedBy = 0;

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
                model.ChangedOn = DateTime.Now;
                model.ChangedBy = 0;
                var cp = new ASF.UI.Process.DealerProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
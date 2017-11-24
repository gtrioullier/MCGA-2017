using ASF.UI.WbSite.Services.Cache;
using ASF.UI.WbSite.Services.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ASF.UI.WbSite.Areas.Clients.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Clients/Client
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.ClientProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Clients/Client/Details/5
        public ActionResult Details(Guid Rowid)
        {
            var cp = new ASF.UI.Process.ClientProcess();
            var cliente = cp.Find(Rowid);
            return View(cliente);
        }

        //GET: Clients/Client/Create
        public ActionResult Create()
        {
            var model = new ASF.Entities.Client();
            var countries = DataCacheService.Instance.CountryList();
            Guid g;
            g = Guid.NewGuid();
            var audit = Audit.getAudit();

            model.OrderCount = 0;
            model.SignupDate = DateTime.Now;
            model.CreatedBy = audit.user;
            model.CreatedOn = audit.date;
            model.ChangedBy = audit.user;
            model.ChangedOn = audit.date;
            model.Rowid = g;
            model.Email=User.Identity.Name;
            model.AspNetUsers = User.Identity.GetUserId();

            ViewBag.countries = countries;
            
            return View(model);
        }

        //POST: Clients/Client/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Client model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ClientProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Clients/Client/Delete
        public ActionResult Delete(Guid Rowid)
        {
            var cp = new ASF.UI.Process.ClientProcess();
            var cliente = cp.Find(Rowid);
            return View(cliente);
        }

        //POST: Clients/Client/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Client model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ClientProcess();
                cp.Delete(model.Rowid);
            }
            return RedirectToAction("Index");

        }

        //GET: Clients/Client/Edit
        public ActionResult Edit(Guid Rowid)
        {
            var cp = new ASF.UI.Process.ClientProcess();
            var cliente = cp.Find(Rowid);
            var countries = DataCacheService.Instance.CountryList();

            ViewBag.countries = countries;
           
            return View(cliente);
        }

        //POST: Clients/Client/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Client model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ClientProcess();
                var audit = Audit.getAudit();
                model.ChangedOn = audit.date;
                model.ChangedBy = audit.user;
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
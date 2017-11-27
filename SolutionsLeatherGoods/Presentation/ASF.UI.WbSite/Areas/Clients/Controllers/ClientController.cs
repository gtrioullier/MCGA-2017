using ASF.UI.WbSite.Services.Cache;
using ASF.UI.WbSite.Services.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;

namespace ASF.UI.WbSite.Areas.Clients.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Clients/Client
        public ActionResult Index(int? page, string q = "")
        {
            if (User.IsInRole("Administrador"))
            {
                var cp = new ASF.UI.Process.ClientProcess();
                var countries = DataCacheService.Instance.CountryList();
                var lista = cp.SelectList().OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
                var search = cp.SelectList().Where(c => c.LastName.ToLower().StartsWith(q)).OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
                
                if (q == "")
                {
                    //return View(lista);
                    var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
                    var onePageOfClients = lista.ToPagedList(pageNumber, 10); // will only contain 10 clients max because of the pageSize
                    foreach (var client in onePageOfClients)
                    {
                        client.CreatedBy = countries.Where(c => c.Id == client.CountryId).Select(c => c.Name).FirstOrDefault();
                    }
                    ViewBag.onePageOfClients = onePageOfClients;
                }
                else
                {
                    var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
                    var onePageOfClients = search.ToPagedList(pageNumber, 10); // will only contain 10 clients max because of the pageSize
                    foreach (var client in onePageOfClients)
                    {
                        client.CreatedBy = countries.Where(c => c.Id == client.CountryId).Select(c => c.Name).FirstOrDefault();
                    }
                    ViewBag.Contries = countries;
                    ViewBag.onePageOfClients = onePageOfClients;
                    ViewBag.searchQuery = q;
                }

                return View();
            }
            else
            {
                return View("~/Views/Error/Unauthorized.cshtml");
            }
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
            model.Email = User.Identity.Name;
            model.AspNetUsers = User.Identity.Name;

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
            return RedirectToAction("Index", "Manage", new { area = "" });
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
            return RedirectToAction("Index", "Manage", new { area = "" });
        }

        public ActionResult getClient(string aspnetuser)
        {
            var cp = new ASF.UI.Process.ClientProcess();

            var client = cp.SelectList().Where(c => c.AspNetUsers.ToLower() == aspnetuser).FirstOrDefault();

            if (client != null)
            {
                var countries = DataCacheService.Instance.CountryList();

                ViewBag.country = countries.Where(c => c.Id == client.CountryId).FirstOrDefault().Name;

                return PartialView("_partialClient", client);
            }
            else
            {
                return PartialView("_partialCreateClient");
            }
        }

        //public ActionResult _partialCreateClient()
        //{
        //    var model = new ASF.Entities.Client();
        //    var countries = DataCacheService.Instance.CountryList();
        //    Guid g;
        //    g = Guid.NewGuid();
        //    var audit = Audit.getAudit();

        //    model.OrderCount = 0;
        //    model.SignupDate = DateTime.Now;
        //    model.CreatedBy = audit.user;
        //    model.CreatedOn = audit.date;
        //    model.ChangedBy = audit.user;
        //    model.ChangedOn = audit.date;
        //    model.Rowid = g;
        //    model.Email = User.Identity.Name;
        //    model.AspNetUsers = User.Identity.Name;

        //    ViewBag.countries = countries;

        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult _partialCreateClient(ASF.Entities.Client model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cp = new ASF.UI.Process.ClientProcess();
        //        cp.Create(model);
        //    }
        //    return RedirectToAction("Index", "Manage", new { area = ""});
        //}

    }
}
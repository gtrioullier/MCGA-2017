using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Clients.Controllers
{
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
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.ClientProcess();
            var cliente = cp.Find(id);
            return View(cliente);
        }

        //GET: Clients/Client/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Clients/Client/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Client model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ClientProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Clients/Client/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.ClientProcess();
            var cliente = cp.Find(id);
            return View(cliente);
        }

        //POST: Clients/Client/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Client model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ClientProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Clients/Client/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.ClientProcess();
            var cliente = cp.Find(id);
            return View(cliente);
        }

        //POST: Clients/Client/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Client model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ClientProcess();
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
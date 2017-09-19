using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsRoles.Controllers
{
    public class AspNetRolesController : Controller
    {
        // GET: AspsNetsRoles/AspNetRoles
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.AspNetRolesProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: AspsNetsRoles/AspNetRoles/Details/5
        public ActionResult Details(string id)
        {
            var cp = new ASF.UI.Process.AspNetRolesProcess();
            var aspnetroles = cp.Find(id);
            return View(aspnetroles);
        }

        //GET: AspsNetsRoles/AspNetRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: AspsNetsRoles/AspNetRoles/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.AspNetRoles model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetRolesProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: AspsNetsRoles/AspNetRoles/Delete
        public ActionResult Delete(string id)
        {
            var cp = new ASF.UI.Process.AspNetRolesProcess();
            var aspnetroles = cp.Find(id);
            return View(aspnetroles);
        }

        //POST: AspsNetsRoles/AspNetRoles/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.AspNetRoles model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetRolesProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: AspsNetsRoles/AspNetRoles/Edit
        public ActionResult Edit(string id)
        {
            var cp = new ASF.UI.Process.AspNetRolesProcess();
            var aspnetroles = cp.Find(id);
            return View(aspnetroles);
        }

        //POST: AspsNetsRoles/AspNetRoles/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.AspNetRoles model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetRolesProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
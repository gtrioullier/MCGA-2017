using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsUsersRoles.Controllers
{
    public class AspNetUserRolesController : Controller
    {
        // GET: AspsNetsUsersRoles/AspNetUserRoles
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.AspNetUserRolesProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: AspsNetsUsersRoles/AspNetUserRoles/Details/5
        public ActionResult Details(ASF.Entities.AspNetUserRoles model)
        {
            var cp = new ASF.UI.Process.AspNetUserRolesProcess();
            var aspnetuserroles = cp.Find(model);
            return View(aspnetuserroles);
        }

        //GET: AspsNetsUsersRoles/AspNetUserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: AspsNetsUsersRoles/AspNetUserRoles/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.AspNetUserRoles model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetUserRolesProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        ////GET: AspsNetsUsersRoles/AspNetUserRoles/Delete
        //public ActionResult Delete(ASF.Entities.AspNetUserRoles model)
        //{
        //    var cp = new ASF.UI.Process.AspNetUserRolesProcess();
        //    var aspnetuserroles = cp.Find(model);
        //    return View(aspnetuserroles);
        //}

        ////POST: AspsNetsUsersRoles/AspNetUserRoles/Delete
        //[HttpPost]
        //public ActionResult Delete(ASF.Entities.AspNetUserRoles model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cp = new ASF.UI.Process.AspNetUserRolesProcess();
        //        cp.Delete(model);
        //    }
        //    return RedirectToAction("Index");

        //}

        ////GET: AspsNetsUsersRoles/AspNetUserRoles/Edit
        //public ActionResult Edit(ASF.Entities.AspNetUserRoles model)
        //{
        //    var cp = new ASF.UI.Process.AspNetUserRolesProcess();
        //    var aspnetuserroles = cp.Find(model);
        //    return View(aspnetuserroles);
        //}

        ////POST: AspsNetsUsersRoles/AspNetUserRoles/Edit
        //[HttpPost]
        //public ActionResult Edit(ASF.Entities.AspNetUserRoles model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cp = new ASF.UI.Process.AspNetUserRolesProcess();
        //        cp.Edit(model);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
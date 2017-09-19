using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsUsersLogins.Controllers
{
    public class AspNetUserLoginsController : Controller
    {
        // GET: AspsNetsUsersLogins/AspNetUserLogins
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.AspNetUserLoginsProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: AspsNetsUsersLogins/AspNetUserLogins/Details/5
        public ActionResult Details(ASF.Entities.AspNetUserLogins model)
        {
            var cp = new ASF.UI.Process.AspNetUserLoginsProcess();
            var aspnetuserlogins = cp.Find(model);
            return View(aspnetuserlogins);
        }

        //GET: AspsNetsUsersLogins/AspNetUserLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: AspsNetsUsersLogins/AspNetUserLogins/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.AspNetUserLogins model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetUserLoginsProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        ////GET: AspsNetsUsersLogins/AspNetUserLogins/Delete
        //public ActionResult Delete(ASF.Entities.AspNetUserLogins model)
        //{
        //    var cp = new ASF.UI.Process.AspNetUserLoginsProcess();
        //    var aspnetuserlogins = cp.Find(model);
        //    return View(aspnetuserlogins);
        //}

        ////POST: AspsNetsUsersLogins/AspNetUserLogins/Delete
        //[HttpPost]
        //public ActionResult Delete(ASF.Entities.AspNetUserLogins model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cp = new ASF.UI.Process.AspNetUserLoginsProcess();
        //        cp.Delete(model);
        //    }
        //    return RedirectToAction("Index");

        //}

        ////GET: AspsNetsUsersLogins/AspNetUserLogins/Edit
        //public ActionResult Edit(ASF.Entities.AspNetUserLogins model)
        //{
        //    var cp = new ASF.UI.Process.AspNetUserLoginsProcess();
        //    var aspnetuserlogins = cp.Find(model);
        //    return View(aspnetuserlogins);
        //}

        ////POST: AspsNetsUsersLogins/AspNetUserLogins/Edit
        //[HttpPost]
        //public ActionResult Edit(ASF.Entities.AspNetUserLogins model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cp = new ASF.UI.Process.AspNetUserLoginsProcess();
        //        cp.Edit(model);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
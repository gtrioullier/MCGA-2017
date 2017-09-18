using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsUsers.Controllers
{
    public class AspNetUsersController : Controller
    {
        // GET: AspsNetsUsers/AspNetUsers
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.AspNetUsersProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: AspsNetsUsers/AspNetUsers/Details/5
        public ActionResult Details(string id)
        {
            var cp = new ASF.UI.Process.AspNetUsersProcess();
            var aspnetusers = cp.Find(id);
            return View(aspnetusers);
        }

        //GET: AspsNetsUsers/AspNetUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: AspsNetsUsers/AspNetUsers/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.AspNetUsers model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetUsersProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: AspsNetsUsers/AspNetUsers/Delete
        public ActionResult Delete(string id)
        {
            var cp = new ASF.UI.Process.AspNetUsersProcess();
            var aspnetusers = cp.Find(id);
            return View(aspnetusers);
        }

        //POST: AspsNetsUsers/AspNetUsers/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.AspNetUsers model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetUsersProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: AspsNetsUsers/AspNetUsers/Edit
        public ActionResult Edit(string id)
        {
            var cp = new ASF.UI.Process.AspNetUsersProcess();
            var aspnetusers = cp.Find(id);
            return View(aspnetusers);
        }

        //POST: AspsNetsUsers/AspNetUsers/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.AspNetUsers model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetUsersProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
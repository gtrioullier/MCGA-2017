using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsUsersClaims.Controllers
{
    public class AspNetUserClaimsController : Controller
    {
        // GET: AspsNetsUsersClaims/AspNetUserClaims
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.AspNetUserClaimsProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: AspsNetsUsersClaims/AspNetUserClaims/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.AspNetUserClaimsProcess();
            var aspnetuserclaims = cp.Find(id);
            return View(aspnetuserclaims);
        }

        //GET: AspsNetsUsersClaims/AspNetUserClaims/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: AspsNetsUsersClaims/AspNetUserClaims/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.AspNetUserClaims model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetUserClaimsProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: AspsNetsUsersClaims/AspNetUserClaims/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.AspNetUserClaimsProcess();
            var aspnetuserclaims = cp.Find(id);
            return View(aspnetuserclaims);
        }

        //POST: AspsNetsUsersClaims/AspNetUserClaims/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.AspNetUserClaims model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetUserClaimsProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: AspsNetsUsersClaims/AspNetUserClaims/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.AspNetUserClaimsProcess();
            var aspnetuserclaims = cp.Find(id);
            return View(aspnetuserclaims);
        }

        //POST: AspsNetsUsersClaims/AspNetUserClaims/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.AspNetUserClaims model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.AspNetUserClaimsProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
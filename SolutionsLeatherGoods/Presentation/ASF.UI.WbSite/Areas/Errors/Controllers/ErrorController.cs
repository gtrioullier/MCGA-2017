using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Errors.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Errors/Error
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.ErrorProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Errors/Error/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.ErrorProcess();
            var error = cp.Find(id);
            return View(error);
        }

        //GET: Errors/Error/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Errors/Error/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Error model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ErrorProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Errors/Error/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.ErrorProcess();
            var error = cp.Find(id);
            return View(error);
        }

        //POST: Errors/Error/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Error model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ErrorProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Errors/Error/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.ErrorProcess();
            var error = cp.Find(id);
            return View(error);
        }

        //POST: Errors/Error/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Error model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ErrorProcess();
                model.ChangedOn = DateTime.Now;
                //if (model.CreatedBy == 0)
                //{
                //    model.CreatedBy = null;
                //}
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
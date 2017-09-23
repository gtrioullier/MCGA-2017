using ASF.UI.WbSite.Services.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Categories.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Categories/Category
        public ActionResult Index()
        {
            //var cp = new ASF.UI.Process.CategoryProcess();
            //var lista = cp.SelectList();
            var lista = DataCacheService.Instance.CategoryList();
            return View(lista);
        }

        //GET: Categories/Category/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.CategoryProcess();
            var categoria = cp.Find(id);
            return View(categoria);
        }

        //GET: Categories/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Categories/Category/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Category model)
        {
            if (ModelState.IsValid)
            {
                DataCacheService.Instance.ClearCategory();
                var cp = new ASF.UI.Process.CategoryProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Categories/Category/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.CategoryProcess();
            var categoria = cp.Find(id);
            return View(categoria);
        }

        //POST: Categories/Category/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Category model)
        {
            if (ModelState.IsValid)
            {
                DataCacheService.Instance.ClearCategory();
                var cp = new ASF.UI.Process.CategoryProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Categories/Category/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.CategoryProcess();
            var categoria = cp.Find(id);
            return View(categoria);
        }

        //POST: Categories/Category/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Category model)
        {
            if (ModelState.IsValid)
            {
                DataCacheService.Instance.ClearCategory();
                var cp = new ASF.UI.Process.CategoryProcess();
                model.ChangedOn = DateTime.Now;
                model.ChangedBy = 0;
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
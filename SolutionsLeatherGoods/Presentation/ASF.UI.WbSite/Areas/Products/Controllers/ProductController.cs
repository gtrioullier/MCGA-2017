using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Products.Controllers
{
    public class ProductController : Controller
    {
        // GET: Products/Product
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Products/Product/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var product = cp.Find(id);
            return View(product);
        }

        //GET: Products/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Products/Product/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Product model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ProductProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Products/Product/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var product = cp.Find(id);
            return View(product);
        }

        //POST: Products/Product/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Product model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ProductProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Products/Product/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var product = cp.Find(id);
            return View(product);
        }

        //POST: Products/Product/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Product model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ProductProcess();
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
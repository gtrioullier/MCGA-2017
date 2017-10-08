using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Products.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Products/Product
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var cpd = new ASF.UI.Process.DealerProcess();
            var dealers = cpd.SelectList();
            var lista = cp.SelectList();

            foreach(var l in lista)
            {
                l.Vendedor = dealers.Find(v => v.Id == l.DealerId);
            }

            return View(lista.OrderBy(l => l.Vendedor.LastName));
        }

        //GET: Products/Product/Details/5
        public ActionResult Details(Guid Rowid)
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var product = cp.Find(Rowid);
            return View(product);
        }

        //GET: Products/Product/Create
        public ActionResult Create()
        {
            var cpDealers = new ASF.UI.Process.DealerProcess();
            var dealers = cpDealers.SelectList().Select(d => new {
                Id = d.Id,
                Text = string.Format("{0}, {1}", d.LastName, d.FirstName)
            }).ToList();

            var model = new ASF.Entities.Product();

            ViewBag.dealers = dealers.OrderBy(d => d.Text);

            model.CreatedBy = 0;
            model.ChangedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ChangedOn = DateTime.Now;
            model.Rowid = Guid.NewGuid();
            model.AvgStars = 0;
            model.QuantitySold = 0;

            return View(model);
        }

        //POST: Products/Product/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Product model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ProductProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Products/Product/Delete
        public ActionResult Delete(Guid Rowid)
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var product = cp.Find(Rowid);
            return View(product);
        }

        //POST: Products/Product/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Product model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.ProductProcess();
                cp.Delete(model.Rowid);
            }
            return RedirectToAction("Index");

        }

        //GET: Products/Product/Edit
        public ActionResult Edit(Guid Rowid)
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var product = cp.Find(Rowid);
            var cpDealers = new ASF.UI.Process.DealerProcess();
            var dealers = cpDealers.SelectList().Select(d => new
            {
                Id = d.Id,
                Text = string.Format("{0}, {1}", d.LastName, d.FirstName)
            }).ToList();

            ViewBag.dealers = dealers.OrderBy(d =>d.Text);

            return View(product);
        }

        //POST: Products/Product/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Product model)
        {
            if (ModelState.IsValid)
            {
                model.ChangedBy = 0;
                model.ChangedOn = DateTime.Now;
                var cp = new ASF.UI.Process.ProductProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
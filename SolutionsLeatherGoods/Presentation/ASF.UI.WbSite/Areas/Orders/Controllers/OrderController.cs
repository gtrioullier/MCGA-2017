using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Orders.Controllers
{
    public class OrderController : Controller
    {
        // GET: Orders/Order
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.OrderProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Orders/Order/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.OrderProcess();
            var order = cp.Find(id);
            return View(order);
        }

        //GET: Orders/Order/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Orders/Order/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Order model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.OrderProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Orders/Order/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.OrderProcess();
            var order = cp.Find(id);
            return View(order);
        }

        //POST: Orders/Order/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Order model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.OrderProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Orders/Order/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.OrderProcess();
            var order = cp.Find(id);
            return View(order);
        }

        //POST: Orders/Order/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Order model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.OrderProcess();
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
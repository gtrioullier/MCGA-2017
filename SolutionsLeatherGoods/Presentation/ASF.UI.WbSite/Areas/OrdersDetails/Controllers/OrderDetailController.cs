using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.WbSite.Services.Audit;

namespace ASF.UI.WbSite.Areas.OrdersDetails.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: OrdersDetails/OrderDetail
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.OrderDetailProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: OrderDetails/OrderDetail/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.OrderDetailProcess();
            var orderdetail = cp.Find(id);
            return View(orderdetail);
        }

        //GET: OrderDetails/OrderDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: OrderDetails/OrderDetail/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.OrderDetail model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.OrderDetailProcess();
                var audit = Audit.getAudit();
                model.CreatedOn = audit.date;
                model.ChangedOn = audit.date;
                model.ChangedBy = audit.user;
                model.CreatedBy = audit.user;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: OrderDetails/OrderDetail/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.OrderDetailProcess();
            var orderdetail = cp.Find(id);
            return View(orderdetail);
        }

        //POST: OrderDetails/OrderDetail/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.OrderDetail model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.OrderDetailProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: OrderDetails/OrderDetail/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.OrderDetailProcess();
            var orderdetail = cp.Find(id);
            return View(orderdetail);
        }

        //POST: OrderDetails/OrderDetail/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.OrderDetail model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.OrderDetailProcess();
                var audit = Audit.getAudit();
                model.ChangedBy = audit.user;
                model.ChangedOn = audit.date;
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
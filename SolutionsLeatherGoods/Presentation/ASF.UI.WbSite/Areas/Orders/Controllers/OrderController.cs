using ASF.UI.WbSite.Services.Audit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ASF.UI.WbSite.Areas.Orders.Models;
using System.Data.Entity;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Orders.Controllers
{
    public class OrderController : Controller
    {
        // GET: Orders/Order
        public ActionResult Index()
        {
            //var order = db.Order.Include(o => o.Client);
            //return View(order.ToList());

            var cp = new ASF.UI.Process.OrderProcess();
            var lista = cp.SelectList();

            return View(lista);
        }

        //GET: Orders/Order/Details/5
        public ActionResult Details(Guid Rowid)
        {
            var cp = new ASF.UI.Process.OrderProcess();
            var order = cp.Find(Rowid);
            var cpDetails = new ASF.UI.Process.OrderDetailProcess();
            var details = cpDetails.SelectList().Where(d => d.OrderId == order.Id).ToList();
            order.OrderDetail = new List<OrderDetail>();
            foreach (var detail in details)
            {
                var cpProductos = new ASF.UI.Process.ProductProcess();
                var producto = cpProductos.SelectList().Where(p => p.Id == detail.ProductId).FirstOrDefault();
                detail.Product = producto;
                order.OrderDetail.Add(detail);
            }

            return View(order);
        }

        ////GET: Orders/Order/Create
        public ActionResult Create()
        {
            var order = new ASF.Entities.Order();
            var audit = Audit.getAudit();

            order.ChangedBy = audit.userId;
            order.ChangedOn = audit.date;
            order.CreatedBy = order.ChangedBy;
            order.CreatedOn = order.ChangedOn;
            order.Rowid = Guid.NewGuid();
            order.OrderNumber = OrderNumberService.Instance.Next();
            return View(order);
        }

        //POST: Orders/Order/Create desde carrito
        [HttpPost]
        public Order Create(double total, string state, DateTime orderdate, int itemcount)
        {
            var order = new ASF.Entities.Order();
            var audit = Audit.getAudit();

            order.ChangedBy = audit.userId;
            order.ChangedOn = audit.date;
            order.CreatedBy = order.ChangedBy;
            order.CreatedOn = order.ChangedOn;
            order.Rowid = Guid.NewGuid();
            order.OrderNumber = OrderNumberService.Instance.Next();
            order.OrderDate = orderdate;
            order.ItemCount = itemcount;
            order.State = state;
            order.TotalPrice = total;
            order.ClientId = 4;

            var cp = new ASF.UI.Process.OrderProcess();
            cp.Create(order);

            Order neworder = cp.Find(order.Rowid);

            return neworder;
        }

        //POST: Orders/Order/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Order model)
        {
            //decode enum
            switch (model.State)
            {
                case "0": { model.State = "Reviewed"; break; }
                case "1": { model.State = "Suspended"; break; }
                case "2": { model.State = "Closed"; break; }
                case "3": { model.State = "Cancelled"; break; }
                case "4": { model.State = "Approved"; break; }
            }

            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.OrderProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Orders/Order/Delete
        public ActionResult Delete(Guid Rowid)
        {
            var cp = new ASF.UI.Process.OrderProcess();
            var order = cp.Find(Rowid);
            return View(order);
        }

        //POST: Orders/Order/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Order model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.OrderProcess();
                cp.Delete(model.Rowid);
            }
            return RedirectToAction("Index");

        }

        //GET: Orders/Order/Edit
        public ActionResult Edit(Guid Rowid)
        {
            var cp = new ASF.UI.Process.OrderProcess();
            var order = cp.Find(Rowid);
            var audit = Audit.getAudit();

            order.ChangedOn = audit.date;
            order.ChangedBy = audit.userId;

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

        public ActionResult CancelOrder( Guid rowid)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.OrderProcess();
                var order = cp.Find(rowid);
                order.State = "Cancelled";
                cp.Edit(order);
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public JsonResult GetClients(string Areas, string term = "")
        {

            if (term != "")
            {
                try
                {
                    var cp = new ASF.UI.Process.ClientProcess();
                    var clientes = cp.SelectList().Where(c => c.LastName.StartsWith(term, true, CultureInfo.CurrentCulture)).Select(c => new
                    {
                        LastName = c.LastName,
                        FirstName = c.FirstName,
                        Id = c.Id
                    });
                    return Json(clientes, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(string.Empty, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
    }

    public class OrderNumberService
    {
        #region Singleton

        private static OrderNumberService _instance;
        private static readonly object InstanceLock = new object();
        private int _contador;
        private ASF.UI.Process.OrderNumberProcess cp = new ASF.UI.Process.OrderNumberProcess();
        private OrderNumberService()
        {

        }

        public int Next()
        {
            //para el caso de no tener órdenes aún, la llamada a contador volverá con error, al no hacer nada en el catch
            //la ejecución continúa y da el número 1 a la primer orden
            try
            {
                _contador = cp.SelectList().Max(x => x.Number);
            }
            catch (Exception)
            {
            }

            var val = _contador + 1;
            var audit = Audit.getAudit();

            OrderNumber orderNumber = new OrderNumber();
            orderNumber.Number = val;
            orderNumber.CreatedOn = audit.date;
            orderNumber.CreatedBy = audit.userId;
            orderNumber.ChangedBy = orderNumber.CreatedBy;
            orderNumber.ChangedOn = orderNumber.CreatedOn;

            //graba la nueva orden para mantener la correlatividad
            cp.Create(orderNumber);

            return val;
        }

        public static OrderNumberService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new OrderNumberService();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion
    }
}

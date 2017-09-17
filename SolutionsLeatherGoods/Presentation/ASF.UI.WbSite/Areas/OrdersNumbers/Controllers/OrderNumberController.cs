using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.OrdersNumbers.Controllers
{
    public class OrderNumberController : Controller
    {
        // GET: OrdersNumbers/OrderNumber
        public ActionResult Index()
        {
            var cp = new OrderNumberProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: OrderNumbersNumbers/OrderNumber/Details/5
        public ActionResult Details(int id)
        {
            var cp = new OrderNumberProcess();
            var ordernumber = cp.Find(id);
            return View(ordernumber);
        }

        //GET: OrderNumbersNumbers/OrderNumber/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: OrderNumbersNumbers/OrderNumber/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.OrderNumber model)
        {
            if (ModelState.IsValid)
            {
                var cp = new OrderNumberProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: OrderNumbersNumbers/OrderNumber/Delete
        public ActionResult Delete(int id)
        {
            var cp = new OrderNumberProcess();
            var ordernumber = cp.Find(id);
            return View(ordernumber);
        }

        //POST: OrderNumbersNumbers/OrderNumber/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.OrderNumber model)
        {
            if (ModelState.IsValid)
            {
                var cp = new OrderNumberProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: OrderNumbersNumbers/OrderNumber/Edit
        public ActionResult Edit(int id)
        {
            var cp = new OrderNumberProcess();
            var ordernumber = cp.Find(id);
            return View(ordernumber);
        }

        //POST: OrderNumbersNumbers/OrderNumber/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.OrderNumber model)
        {
            if (ModelState.IsValid)
            {
                var cp = new OrderNumberProcess();
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
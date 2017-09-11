using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Carts.Controllers
{
    public class CartController : Controller
    {
        // GET: Carts/Cart
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.CartProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Carts/Cart/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.CartProcess();
            var cart = cp.Find(id);
            return View(cart);
        }

        //GET: Carts/Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Carts/Cart/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Cart model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CartProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Carts/Cart/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.CartProcess();
            var cart = cp.Find(id);
            return View(cart);
        }

        //POST: Carts/Cart/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Cart model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CartProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Carts/Cart/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.CartProcess();
            var cart = cp.Find(id);
            return View(cart);
        }

        //POST: Carts/Cart/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Cart model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CartProcess();
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
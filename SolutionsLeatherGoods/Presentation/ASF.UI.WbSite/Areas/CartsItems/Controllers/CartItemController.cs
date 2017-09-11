using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.CartsItems.Controllers
{
    public class CartItemController : Controller
    {
        // GET: CartItemsItems/CartItem
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.CartItemProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: CartItemsItems/CartItem/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.CartItemProcess();
            var cartitem = cp.Find(id);
            return View(cartitem);
        }

        //GET: CartItemsItems/CartItem/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: CartItemsItems/CartItem/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.CartItem model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CartItemProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: CartItemsItems/CartItem/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.CartItemProcess();
            var cartitem = cp.Find(id);
            return View(cartitem);
        }

        //POST: CartItemsItems/CartItem/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.CartItem model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CartItemProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: CartItemsItems/CartItem/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.CartItemProcess();
            var cartitem = cp.Find(id);
            return View(cartitem);
        }

        //POST: CartItemsItems/CartItem/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.CartItem model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CartItemProcess();
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
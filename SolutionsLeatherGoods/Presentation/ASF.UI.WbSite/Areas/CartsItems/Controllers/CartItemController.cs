using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.WbSite.Services.Audit;
using ASF.UI.WbSite.Services.Cache;

namespace ASF.UI.WbSite.Areas.CartsItems.Controllers
{
    [Authorize]
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
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //POST: CartItemsItems/CartItem/Create
        //[HttpPost]
        //public ActionResult Create(ASF.Entities.CartItem model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cp = new ASF.UI.Process.CartItemProcess();
        //        model.CreatedOn = DateTime.Now;
        //        model.ChangedOn = DateTime.Now;
        //        cp.Create(model);
        //    }
        //    return RedirectToAction("Index");
        //}

        //GET: CartItemsItems/CartItem/Create/5
        [AllowAnonymous]
        public ActionResult Create(Guid productRowid)
        {
            var audit = Audit.getAudit();
            ASF.Entities.CartItem cartItem = new Entities.CartItem();
            Guid cartRowid = new Guid();
            if (Request.Cookies["cartCookie"] != null)
            {
                string stringcartRowid = Request.Cookies["cartCookie"].Value;
                cartRowid = Guid.Parse(stringcartRowid);
            }
            var cpCart = new ASF.UI.Process.CartProcess();
            var cart = cpCart.Find(cartRowid);
            var cpProduct = new ASF.UI.Process.ProductProcess();
            var product = cpProduct.Find(productRowid);

            cartItem.CartId = cart.Id;
            cartItem.ProductId = product.Id;
            cartItem.Quantity = 1;
            cartItem.Price = product.Price * cartItem.Quantity;
            cartItem.CreatedOn = audit.date;
            cartItem.CreatedBy = audit.user;
            cartItem.ChangedOn = audit.date;
            cartItem.ChangedBy = audit.user;

            var cpCartItem = new ASF.UI.Process.CartItemProcess();
            cpCartItem.Create(cartItem);

            //sumar 1 a item count del carrito
            cart.ItemCount = cart.ItemCount + 1;
            cpCart.Edit(cart);
            
            return RedirectToAction("Details","Cart", new { area="Carts", Rowid=cartRowid});
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
                var audit = Audit.getAudit();
                model.ChangedOn = audit.date;
                model.ChangedBy = audit.user;
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult addItem(int cartItemId)
        {
            var cp = new ASF.UI.Process.CartItemProcess();
            var cartItem = cp.Find(cartItemId);
            var productPrice = cartItem.Price / cartItem.Quantity;
            var audit = Audit.getAudit();
            cartItem.ChangedOn = audit.date;
            cartItem.ChangedBy = audit.user;
            cartItem.Quantity = cartItem.Quantity + 1;
            cartItem.Price = productPrice * cartItem.Quantity;
            cp.Edit(cartItem);
            var value = cartItem.Quantity;

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult removeItem(int cartItemId)
        {
            var cp = new ASF.UI.Process.CartItemProcess();
            var cartItem = cp.Find(cartItemId);
            var productPrice = cartItem.Price / cartItem.Quantity;
            var audit = Audit.getAudit();
            cartItem.ChangedOn = audit.date;
            cartItem.ChangedBy = audit.user;
            cartItem.Quantity = cartItem.Quantity - 1;
            cartItem.Price = productPrice * cartItem.Quantity;
            cp.Edit(cartItem);
            var value = cartItem.Quantity;

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult removeDetail(int cartItemId)
        {
            var cp = new ASF.UI.Process.CartItemProcess();
            cp.Delete(cartItemId);
            Guid cartRowid = new Guid();
            if (Request.Cookies["cartCookie"] != null)
            {
                string stringcartRowid = Request.Cookies["cartCookie"].Value;
                cartRowid = Guid.Parse(stringcartRowid);
            }
            var cpCart = new ASF.UI.Process.CartProcess();
            var cart = cpCart.Find(cartRowid);
            cart.ItemCount = cart.ItemCount - 1;
            cpCart.Edit(cart);

            return Json("Deleted succesfully", JsonRequestBehavior.AllowGet);
        }
    }
}
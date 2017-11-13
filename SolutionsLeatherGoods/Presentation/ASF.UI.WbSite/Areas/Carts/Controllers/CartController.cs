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
        public ActionResult Details(Guid Rowid)
        {
            var cp = new ASF.UI.Process.CartProcess();
            var cart = cp.Find(Rowid);
            var cpItems = new ASF.UI.Process.CartItemProcess();
            var items = cpItems.SelectList().Where(i => i.CartId == cart.Id).ToList();
            cart.CartItem = new List<Entities.CartItem>();
            foreach (var item in items)
            {
                var cpProductos = new ASF.UI.Process.ProductProcess();
                var producto = cpProductos.SelectList().Where(p => p.Id == item.ProductId).FirstOrDefault();
                item.Product = producto;
                cart.CartItem.Add(item);
            }
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
                var id = cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Carts/Cart/Delete
        public ActionResult Delete(Guid Rowid)
        {
            var cp = new ASF.UI.Process.CartProcess();
            var cart = cp.Find(Rowid);
            return View(cart);
        }

        //POST: Carts/Cart/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Cart model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CartProcess();
                cp.Delete(model.Rowid);
            }
            return RedirectToAction("Index");

        }

        //GET: Carts/Cart/Edit
        public ActionResult Edit(Guid Rowid)
        {
            var cp = new ASF.UI.Process.CartProcess();
            var cart = cp.Find(Rowid);
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

        public JsonResult getCartId()
        {
            var cart = new ASF.Entities.Cart();
            var cp = new ASF.UI.Process.CartProcess();
            cart.CreatedOn = DateTime.Now;
            cart.ChangedOn = DateTime.Now;
            cart.CreatedBy = 0;
            cart.ChangedBy = 0;
            cart.CartDate = DateTime.Now;
            cart.Rowid = Guid.NewGuid();
            cart.Cookie = cart.Rowid.ToString();
            var newcart = cp.Create(cart);
            var Cookie = newcart.Cookie;
            return Json(Cookie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Buy(Guid CartRowid)
        {
            var Cart = new ASF.Entities.Cart();
            var cpCart = new ASF.UI.Process.CartProcess();
            Cart = cpCart.Find(CartRowid);
            var CartItems = new List<ASF.Entities.CartItem>();
            var cpCartItems = new ASF.UI.Process.CartItemProcess();
            CartItems = cpCartItems.SelectList().Where(i => i.CartId == Cart.Id).ToList();
            var orden = new ASF.Entities.Order();
            var cpOrden = new ASF.UI.Process.OrderProcess();
            double totalPrice = 0;

            orden.OrderDate = Cart.CartDate;
            orden.ItemCount = Cart.ItemCount;
            
            foreach (var item in CartItems)
            {
                totalPrice = totalPrice + item.Price;
            }

            orden.TotalPrice = totalPrice;
            orden.State = "Reviewed";

            var ctrlOrder = new Orders.Controllers.OrderController();
            ctrlOrder.ControllerContext = ControllerContext;
            ctrlOrder.Create(orden.TotalPrice, orden.State, orden.OrderDate, orden.ItemCount);

            //cpOrden.Create(orden);

            //RedirectToAction("Create", "Order", new { total = totalPrice, state = orden.State, orderdate = orden.OrderDate, itemcount= orden.ItemCount });

            foreach (var item in CartItems)
            {
                var ordenDetalle = new ASF.Entities.OrderDetail();
                var cpOrdenDetalle = new ASF.UI.Process.OrderDetailProcess();
                ordenDetalle.ProductId = item.ProductId;
                ordenDetalle.Price = item.Price;
                ordenDetalle.OrderId = orden.Id;
                ordenDetalle.Quantity = item.Quantity;
                ordenDetalle.CreatedOn = DateTime.Today;
                ordenDetalle.CreatedBy = 0;
                ordenDetalle.ChangedOn = DateTime.Today;
                ordenDetalle.ChangedBy = 0;
                cpOrdenDetalle.Create(ordenDetalle);
            }

            return RedirectToAction("Index", "Home", null);
        }
    }
}
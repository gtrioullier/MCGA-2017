﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.WbSite.Services.Audit;
using ASF.UI.WbSite.Services.Cache;

namespace ASF.UI.WbSite.Areas.Carts.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
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
            var model = new ASF.Entities.Cart();
            var audit = Audit.getAudit();
            model.ChangedBy = audit.user;
            model.ChangedOn = audit.date;
            model.CreatedBy = audit.user;
            model.CreatedOn = audit.date;
            return View();
        }

        //POST: Carts/Cart/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Cart model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.CartProcess();
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
                var audit = Audit.getAudit();
                model.ChangedBy = audit.user;
                model.ChangedOn = audit.date;
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult getCartId()
        {
            var cart = new ASF.Entities.Cart();
            var cp = new ASF.UI.Process.CartProcess();
            var audit = Audit.getAudit();
            cart.ChangedBy = audit.user;
            cart.ChangedOn = audit.date;
            cart.CreatedBy = audit.user;
            cart.CreatedOn = audit.date;
            cart.CartDate = DateTime.Now;
            cart.Rowid = Guid.NewGuid();
            cart.Cookie = cart.Rowid.ToString();
            var newcart = cp.Create(cart);
            var Cookie = newcart.Cookie;
            return Json(Cookie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Buy(Guid CartRowid)
        {
            var audit = Audit.getAudit();
            var clientId = Audit.isClient(User.Identity.Name);

            if (clientId != Guid.Empty)
            {
                var cpc = new ASF.UI.Process.ClientProcess();
                var client = cpc.Find(clientId);
                client.OrderCount = client.OrderCount + 1;
                client.ChangedBy = audit.user;
                client.ChangedOn = audit.date;
                cpc.Edit(client);
            }
            else
            {
                return RedirectToAction("Index", "Manage", new { area = "" });
            }


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
            orden = ctrlOrder.Create(orden.TotalPrice, orden.State, orden.OrderDate, orden.ItemCount);

            foreach (var item in CartItems)
            {
                var ordenDetalle = new ASF.Entities.OrderDetail();
                var cpOrdenDetalle = new ASF.UI.Process.OrderDetailProcess();
                ordenDetalle.ProductId = item.ProductId;
                ordenDetalle.Price = item.Price;
                ordenDetalle.OrderId = orden.Id;
                ordenDetalle.Quantity = item.Quantity;
                ordenDetalle.CreatedOn = audit.date;
                ordenDetalle.CreatedBy = audit.user;
                ordenDetalle.ChangedOn = audit.date;
                ordenDetalle.ChangedBy = audit.user;
                cpOrdenDetalle.Create(ordenDetalle);
            }

            if (Request.Cookies["cartCookie"] != null)
            {
                Response.Cookies["cartCookie"].Expires = DateTime.Now.AddDays(-1);
            }

            //En lugar de ir a Home a seguir comprando, debería mostrar la orden para pagarla
            return RedirectToAction("Details", "Order", new { area = "Orders", Rowid = orden.Rowid });
        }
    }
}
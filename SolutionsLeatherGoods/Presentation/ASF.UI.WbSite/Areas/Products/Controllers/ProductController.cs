﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.WbSite.Services.Cache;
using ASF.UI.WbSite.Services.Audit;
using System.Globalization;
using PagedList;

namespace ASF.UI.WbSite.Areas.Products.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Products/Product
        [AllowAnonymous]
        public ActionResult Index(int? page, string q = "")
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var cpd = new ASF.UI.Process.DealerProcess();
            var dealers = cpd.SelectList();
            var lista = cp.SelectList().OrderBy(p => p.Description).ThenBy(p => p.Price);
            var search = cp.SelectList().Where(p => p.Description.ToLower().Contains(q)).OrderBy(c => c.Description).ThenBy(c => c.Price);

            if (q == "")
            {
                foreach (var l in lista)
                {
                    l.Vendedor = dealers.Find(v => v.Id == l.DealerId);
                }

                var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
                var onePageOfProducts = lista.ToPagedList(pageNumber, 6); // will only contain 10 clients max because of the pageSize
                ViewBag.onePageOfProducts = onePageOfProducts;
            }
            else
            {
                foreach (var l in search)
                {
                    l.Vendedor = dealers.Find(v => v.Id == l.DealerId);
                }

                var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
                var onePageOfProducts = search.ToPagedList(pageNumber, 6); // will only contain 10 clients max because of the pageSize
                ViewBag.onePageOfProducts = onePageOfProducts;
                ViewBag.searchQuery = q;
            }

            return View();
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
            var dealers = cpDealers.SelectList().Select(d => new
            {
                Id = d.Id,
                Text = string.Format("{0}, {1}", d.LastName, d.FirstName)
            }).ToList();

            var model = new ASF.Entities.Product();
            var audit = Audit.getAudit();
            ViewBag.dealers = dealers.OrderBy(d => d.Text);

            model.CreatedBy = audit.user;
            model.ChangedBy = audit.user;
            model.CreatedOn = audit.date;
            model.ChangedOn = audit.date;
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

            ViewBag.dealers = dealers.OrderBy(d => d.Text);

            return View(product);
        }

        //POST: Products/Product/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Product model)
        {
            if (ModelState.IsValid)
            {
                var audit = Audit.getAudit();
                var cp = new ASF.UI.Process.ProductProcess();
                model.ChangedBy = audit.user;
                model.ChangedOn = audit.date;
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }


        //GET: Products/Product/fillCarusel
        [AllowAnonymous]
        public ActionResult fillCarusel(string categoria)
        {
            var lista = new List<ASF.Entities.Product>();
            var categories = DataCacheService.Instance.CategoryList();
            var categoryid = categories.Where(c => c.Name.ToLower() == categoria).Select(c => c.Id).FirstOrDefault();
            var cpdealers = new ASF.UI.Process.DealerProcess();
            var dealers = cpdealers.SelectList().Where(d => d.CategoryId == categoryid).Select(d => d.Id);
            foreach (var dealer in dealers)
            {
                var cp = new ASF.UI.Process.ProductProcess();
                lista = cp.SelectList().Where(p => p.DealerId == dealer).Take(12).ToList();
            }
            return PartialView("_partialProductCarusel", lista);
        }

        //GET: Products/Product/Sell/5
        [AllowAnonymous]
        public ActionResult Sell(Guid Rowid)
        {
            var cp = new ASF.UI.Process.ProductProcess();
            var product = cp.Find(Rowid);
            return View(product);
        }

        [AllowAnonymous]
        public JsonResult GetProducts(string Areas, string term = "")
        {
            {

                if (term != "")
                {
                    try
                    {
                        var cp = new ASF.UI.Process.ProductProcess();
                        var productos = cp.SelectList().Where(p => p.Description.StartsWith(term, true, CultureInfo.CurrentCulture)).Select(p => new
                        {
                            Description = p.Description,
                            Price = p.Price,
                            Rowid = p.Rowid
                        });
                        return Json(productos, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        return Json(string.Empty, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(string.Empty, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
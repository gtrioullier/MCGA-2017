using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Dealers.Controllers
{
    public class DealerController : Controller
    {
        // GET: Dealers/Dealer
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.DealerProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Dealers/Dealer/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.DealerProcess();
            var dealer = cp.Find(id);
            return View(dealer);
        }

        //GET: Dealers/Dealer/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Dealers/Dealer/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Dealer model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.DealerProcess();
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Dealers/Dealer/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.DealerProcess();
            var dealer = cp.Find(id);
            return View(dealer);
        }

        //POST: Dealers/Dealer/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Dealer model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.DealerProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Dealers/Dealer/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.DealerProcess();
            var dealer = cp.Find(id);
            return View(dealer);
        }

        //POST: Dealers/Dealer/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Dealer model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.DealerProcess();
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
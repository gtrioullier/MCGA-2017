using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ASF.UI.WbSite.Services.Audit;

namespace ASF.UI.WbSite.Areas.Ratings.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        // GET: Ratings/Rating
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.RatingProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Ratings/Rating/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.RatingProcess();
            var rating = cp.Find(id);
            return View(rating);
        }

        //GET: Ratings/Rating/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Ratings/Rating/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Rating model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.RatingProcess();
                var audit = Audit.getAudit();
                model.CreatedOn = audit.date;
                model.ChangedOn = audit.date;
                model.ChangedBy = audit.user;
                model.CreatedBy = audit.user;
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Ratings/Rating/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.RatingProcess();
            var rating = cp.Find(id);
            return View(rating);
        }

        //POST: Ratings/Rating/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Rating model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.RatingProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Ratings/Rating/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.RatingProcess();
            var rating = cp.Find(id);
            return View(rating);
        }

        //POST: Ratings/Rating/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Rating model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.RatingProcess();
                var audit = Audit.getAudit();
                model.ChangedOn = audit.date;
                model.ChangedBy = audit.user;
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }

        public JsonResult UpdateRate(int rate, int productId)
        {
            var cpc = new ASF.UI.Process.ClientProcess();
            var cpp = new ASF.UI.Process.ProductProcess();
            var cp = new ASF.UI.Process.RatingProcess();
            var clientId = cpc.SelectList().Where(c => c.AspNetUsers == User.Identity.GetUserName()).Select(c => c.Id).FirstOrDefault();
            var rating = new ASF.Entities.Rating();
            var audit = Audit.getAudit();
            rating.ProductId = productId;
            rating.ClientId = clientId;
            rating.CreatedBy = audit.user;
            rating.ChangedBy = audit.user;
            rating.CreatedOn = audit.date;
            rating.ChangedOn = audit.date;
            rating.Stars = rate;
            cp.Create(rating);

            float newrate = 0;
            var ratings = cp.SelectList().Where(r => r.ProductId == productId).ToList();
            var product = cpp.SelectList().Where(p => p.Id == productId).FirstOrDefault();
            product.QuantitySold = product.QuantitySold + 1;
            foreach(var _rating in ratings)
            {
                newrate = newrate + _rating.Stars;
            }
            product.AvgStars = Math.Round(Convert.ToDouble(newrate / product.QuantitySold),2);
            cpp.Edit(product);

            return Json (rating, JsonRequestBehavior.AllowGet);
        }
    }
}
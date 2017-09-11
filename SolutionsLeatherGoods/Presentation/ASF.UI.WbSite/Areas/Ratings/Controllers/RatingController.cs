using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Ratings.Controllers
{
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
                model.CreatedOn = DateTime.Now;
                model.ChangedOn = DateTime.Now;
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
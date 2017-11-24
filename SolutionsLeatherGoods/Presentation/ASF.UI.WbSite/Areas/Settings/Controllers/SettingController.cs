using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.WbSite.Services.Audit;

namespace ASF.UI.WbSite.Areas.Settings.Controllers
{
    public class SettingController : Controller
    {
        // GET: Settings/Setting
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.SettingProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: Settings/Setting/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.SettingProcess();
            var setting = cp.Find(id);
            return View(setting);
        }

        //GET: Settings/Setting/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Settings/Setting/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Setting model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.SettingProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: Settings/Setting/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.SettingProcess();
            var setting = cp.Find(id);
            return View(setting);
        }

        //POST: Settings/Setting/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.Setting model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.SettingProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: Settings/Setting/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.SettingProcess();
            var setting = cp.Find(id);
            return View(setting);
        }

        //POST: Settings/Setting/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.Setting model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.SettingProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
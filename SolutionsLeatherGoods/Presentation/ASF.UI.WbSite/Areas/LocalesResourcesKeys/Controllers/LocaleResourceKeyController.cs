using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.WbSite.Services.Cache;

namespace ASF.UI.WbSite.Areas.LocalesResourcesKeys.Controllers
{
    [Authorize]
    public class LocaleResourceKeyController : Controller
    {
        // GET: LocalesResourcesKeys/LocaleResourceKey
        public ActionResult Index()
        {
            var cp = new ASF.UI.Process.LocaleResourceKeyProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        //GET: LocalesResourcesKeys/LocaleResourceKey/Details/5
        public ActionResult Details(int id)
        {
            var cp = new ASF.UI.Process.LocaleResourceKeyProcess();
            var localeresourcekey = cp.Find(id);
            return View(localeresourcekey);
        }

        //GET: LocalesResourcesKeys/LocaleResourceKey/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: LocalesResourcesKeys/LocaleResourceKey/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.LocaleResourceKey model)
        {
            if (ModelState.IsValid)
            {
                DataCacheService.Instance.ClearLocaleResourceKey();
                DataCacheService.Instance.ClearLangDictionary();
                var cp = new ASF.UI.Process.LocaleResourceKeyProcess();
                cp.Create(model);
            }
            return RedirectToAction("Index");
        }

        //GET: LocaleResourceKeys/LocaleResourceKey/Delete
        public ActionResult Delete(int id)
        {
            var cp = new ASF.UI.Process.LocaleResourceKeyProcess();
            var localeresourcekey = cp.Find(id);
            return View(localeresourcekey);
        }

        //POST: LocalesResourcesKeys/LocaleResourceKey/Delete
        [HttpPost]
        public ActionResult Delete(ASF.Entities.LocaleResourceKey model)
        {
            if (ModelState.IsValid)
            {
                var cp = new ASF.UI.Process.LocaleResourceKeyProcess();
                cp.Delete(model.Id);
            }
            return RedirectToAction("Index");

        }

        //GET: LocalesResourcesKeys/LocaleResourceKey/Edit
        public ActionResult Edit(int id)
        {
            var cp = new ASF.UI.Process.LocaleResourceKeyProcess();
            var localeresourcekey = cp.Find(id);
            return View(localeresourcekey);
        }

        //POST: LocalesResourcesKeys/LocaleResourceKey/Edit
        [HttpPost]
        public ActionResult Edit(ASF.Entities.LocaleResourceKey model)
        {
            if (ModelState.IsValid)
            {
                DataCacheService.Instance.ClearLocaleResourceKey();
                DataCacheService.Instance.ClearLangDictionary();
                var cp = new ASF.UI.Process.LocaleResourceKeyProcess();
                cp.Edit(model);
            }
            return RedirectToAction("Index");
        }
    }
}
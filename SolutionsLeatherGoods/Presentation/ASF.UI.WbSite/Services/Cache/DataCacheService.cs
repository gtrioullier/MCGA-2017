using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Services.Cache
{
    public class DataCacheService
    {
        #region Sigleton
        private static DataCacheService _instance;
        private static readonly object InstanceLock = new Object();
        public static DataCacheService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataCacheService();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        private readonly ICacheService _cacheService;

        private DataCacheService()
        {
            _cacheService = DependencyResolver.Current.GetService<ICacheService>();
        }

        public List<Category> CategoryList()
        {
            var lista = _cacheService.GetOrAdd(CacheSetting.Category.Key, () =>
                {
                    var cp = new CategoryProcess();
                    return cp.SelectList();
                },
                CacheSetting.Category.SlidingExpiration);
            return lista;
        }

        public void ClearCategory()
        {
            _cacheService.Remove(CacheSetting.Category.Key);
        }


        public List<Country> CountryList()
        {
            var lista = _cacheService.GetOrAdd(CacheSetting.Country.Key, () =>
            {
                var cp = new CountryProcess();
                return cp.SelectList();
            },
                CacheSetting.Country.SlidingExpiration);
            return lista;
        }

        public void ClearCountry()
        {
            _cacheService.Remove(CacheSetting.Country.Key);
        }
    }
}
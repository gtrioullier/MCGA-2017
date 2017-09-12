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
    }
}
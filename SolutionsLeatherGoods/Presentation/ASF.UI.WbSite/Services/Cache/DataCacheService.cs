using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
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

        public List<Language> LanguageList()
        {
            var lista = _cacheService.GetOrAdd(CacheSetting.Language.Key, () =>
            {
                var cp = new LanguageProcess();
                return cp.SelectList();
            },
            CacheSetting.Language.SlidingExpiration);
            return lista;
        }

        public void ClearLanguage()
        {
            _cacheService.Remove(CacheSetting.Language.Key);
        }

        public List<LocaleResourceKey> LocaleResourceKeyList()
        {
            var lista = _cacheService.GetOrAdd(CacheSetting.LocaleResourceKey.Key, () =>
            {
                var cp = new LocaleResourceKeyProcess();
                return cp.SelectList();
            },
            CacheSetting.LocaleResourceKey.SlidingExpiration);
            return lista;
        }

        public void ClearLocaleResourceKey()
        {
            _cacheService.Remove(CacheSetting.LocaleResourceKey.Key);
        }

        public Dictionary<string, string> LangDictionary()
        {
            var dictionary = _cacheService.Get<Dictionary<string, string>>(CacheSetting.LangDictionary.key);

            //si no está cacheado el diccionario, lo creo y cacheo
            if (dictionary == null)
            {
                dictionary = new Dictionary<string, string>();
                var languageId = LanguageList().Where(l => l.LanguageCulture == HttpContext.Current.Request.UserLanguages[0]).Select(l => l.Id).FirstOrDefault();
                var keys = LocaleResourceKeyList();
                if (languageId < 1)
                {
                    //llamar a settings, por ahora lo fijo en castellano a mano.
                    languageId = 2;
                }
                var cp = new LocaleStringResourceProcess();
                var recursos = cp.SelectList().Where(l => l.Language_Id == languageId).ToList();
                foreach (var key in keys)
                {
                    dictionary.Add(key.Name, recursos.Where(x => x.LocaleResourceKey_Id == key.Id).Select(x => x.ResourceValue).FirstOrDefault());
                };

                _cacheService.GetOrAdd(CacheSetting.LangDictionary.key, () => dictionary, CacheSetting.LangDictionary.SlidingExpiration);
                return dictionary;
            }

            return dictionary;
        }

        public void ClearLangDictionary()
        {
            _cacheService.Remove(CacheSetting.LangDictionary.key);
        }
    }
}
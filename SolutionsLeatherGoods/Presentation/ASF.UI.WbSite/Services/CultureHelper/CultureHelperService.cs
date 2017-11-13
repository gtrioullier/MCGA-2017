using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using ASF.Entities;
using ASF.UI.WbSite.Services.Cache;
using System.Data.Entity;
using ASF.UI.WbSite.Constants;

namespace ASF.UI.WbSite.Services.CultureHelper
{
    public class CultureHelperService : ICultureHelperService
    {
        private Dictionary<string, string> dictionary = DataCacheService.Instance.LangDictionary();

        public string getResourceString(string Key)
        {
            if (!String.IsNullOrEmpty(Key))
            {
                try
                {
                    if (dictionary.ContainsKey(Key))
                    {
                        var result = dictionary[Key];
                        if (!string.IsNullOrEmpty(result))
                        {
                            return result;
                        }
                    }
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
            return Key;
        }
    }
}
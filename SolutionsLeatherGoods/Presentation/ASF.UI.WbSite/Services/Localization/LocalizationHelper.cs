using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Services.Localization
{ 
    public static class LocalizationHelper
    {

        public static string getResourceString(this HtmlHelper helper, string key)
        {
            return Lang(helper, key);
        }

        public static string Lang(this HtmlHelper helper, string key)
        {
            var _localizationHelper = DependencyResolver.Current.GetService<ILocalizationHelperService>();
            var clave = _localizationHelper.getResourceString(key);
            return clave;
        }
    }
}
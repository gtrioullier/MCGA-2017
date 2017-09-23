using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace ASF.UI.WbSite.Services.CultureHelper
{
    public class CultureHelperService
    {
        public static string Translate(string key)
        {
            var cp = new LocaleStringResourceProcess();
            return cp.Translate(getLanguageId(), getLocaleResourceKey(key));
        }

        private static int getLanguageId()
        {
            var cp = new LanguageProcess();
            var culture = CultureInfo.CurrentCulture.Name;
            return cp.getId(culture);
        }

        private static int getLocaleResourceKey(string key)
        {
            var cp = new LocaleResourceKeyProcess();
            return cp.getId(key);
        }
    }
}
using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using ASF.Entities;

namespace ASF.UI.WbSite.Services.CultureHelper
{
    public class CultureHelperService : ICultureHelperService
    {
        //Toma el nombre de la cultura que se está utilizando en el navegador:      
        private CultureInfo culture = CultureInfo.CurrentCulture;

        public string getResourceString(string Key)
        {
            if (!String.IsNullOrEmpty(Key)) {
                try
                {
                    var cp = new LocaleStringResourceProcess();
                    var lista = cp.SelectList().Where(l => l.Language_Id == getLanguageId()).Where(l => l.LocaleResourceKey_Id == getLocaleResourceKey(Key));
                    var recurso = lista.Select(l =>l.ResourceValue).FirstOrDefault();
                    var result = recurso.ToString();
                    return result;
                }
                catch (Exception)
                {
                    return Key;
                }
            }
            return string.Empty;
        }

        private int getLanguageId()
        {
            var cp = new LanguageProcess();
            var lista = cp.SelectList().Where(l => l.LanguageCulture == culture.Name);
            var language = lista.Select(l => l.Id).FirstOrDefault();
            var result = Convert.ToInt32(language);
            return result;
        }

        private int getLocaleResourceKey(string key)
        {
            var cp = new LocaleResourceKeyProcess();
            var lista = cp.SelectList().Where(l => l.Name == key);
            var resource = lista.Select(l => l.Id).FirstOrDefault();
            var result = Convert.ToInt32(resource);
            return result;
        }
    }
}
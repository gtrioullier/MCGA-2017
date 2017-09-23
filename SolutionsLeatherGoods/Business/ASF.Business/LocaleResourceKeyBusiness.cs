using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class LocaleResourceKeyBusiness
    {
        public List<LocaleResourceKey> All()
        {
            var localeresourcekeyDac = new LocaleResourceKeyDAC();
            var result = localeresourcekeyDac.Select();
            return result;
        }

        public LocaleResourceKey Find(int id)
        {
            var localeresourcekeyDac = new LocaleResourceKeyDAC();
            var result = localeresourcekeyDac.SelectById(id);
            return result;
        }

        public LocaleResourceKey Add(LocaleResourceKey localeresourcekey)
        {
            var localeresourcekeyDac = new LocaleResourceKeyDAC();
            return localeresourcekeyDac.Create(localeresourcekey);
        }

        public void Remove(int id)
        {
            var localeresourcekeyDac = new LocaleResourceKeyDAC();
            localeresourcekeyDac.DeleteById(id);
        }

        public void Edit(LocaleResourceKey localeresourcekey)
        {
            var localeresourcekeyDac = new LocaleResourceKeyDAC();
            localeresourcekeyDac.UpdateById(localeresourcekey);
        }

        public int getId(string key)
        {
            var localeresourcekeyDac = new LocaleResourceKeyDAC();
            return localeresourcekeyDac.getId(key);
        }
    }
}

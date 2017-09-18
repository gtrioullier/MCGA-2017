using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class LocaleStringResourceBusiness
    {
        public List<LocaleStringResource> All()
        {
            var localestringresourceDAC = new LocaleStringResourceDAC();
            var result = localestringresourceDAC.Select();
            return result;
        }

        public LocaleStringResource Find(int id)
        {
            var localestringresourceDAC = new LocaleStringResourceDAC();
            var result = localestringresourceDAC.SelectById(id);
            return result;
        }

        public LocaleStringResource Add(LocaleStringResource localestringresource)
        {
            var localestringresourceDAC = new LocaleStringResourceDAC();
            return localestringresourceDAC.Create(localestringresource);
        }

        public void Remove(int id)
        {
            var localestringresourceDAC = new LocaleStringResourceDAC();
            localestringresourceDAC.DeleteById(id);
        }

        public void Edit(LocaleStringResource localestringresource)
        {
            var localestringresourceDAC = new LocaleStringResourceDAC();
            localestringresourceDAC.UpdateById(localestringresource);
        }
    }
}

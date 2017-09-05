using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CountryBusiness
    {
        public List<Country> All()
        {
            var countryDac = new CountryDAC();
            var result = countryDac.Select();
            return result;
        }

        public Country Find(int id)
        {
            var countryDac = new CountryDAC();
            var result = countryDac.SelectById(id);
            return result;
        }

        public Country Add(Country country)
        {
            var countryDac = new CountryDAC();
            return countryDac.Create(country);
        }

        public void Remove(int id)
        {
            var countryDac = new CountryDAC();
            countryDac.DeleteById(id);
        }

        public void Edit(Country country)
        {
            var countryDac = new CountryDAC();
            countryDac.UpdateById(country);
        }
    }
}

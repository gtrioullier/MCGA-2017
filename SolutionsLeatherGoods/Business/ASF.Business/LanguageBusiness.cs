using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class LanguageBusiness
    {
        public List<Language> All()
        {
            var languageDac = new LanguageDAC();
            var result = languageDac.Select();
            return result;
        }

        public Language Find(int id)
        {
            var languageDac = new LanguageDAC();
            var result = languageDac.SelectById(id);
            return result;
        }

        public Language Add(Language language)
        {
            var languageDac = new LanguageDAC();
            return languageDac.Create(language);
        }

        public void Remove(int id)
        {
            var languageDac = new LanguageDAC();
            languageDac.DeleteById(id);
        }

        public void Edit(Language language)
        {
            var languageDac = new LanguageDAC();
            languageDac.UpdateById(language);
        }
    }
}

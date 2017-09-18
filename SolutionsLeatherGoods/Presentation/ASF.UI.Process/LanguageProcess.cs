using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ASF.UI.Process
{
    public class LanguageProcess : ProcessComponent
    {
        public List<Language> SelectList()
        {
            var response = HttpGet<AllLanguageResponse>("rest/Language/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Language Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindLanguageResponse>("rest/Language/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(Language R)
        {
            var request = HttpPost<Language>("rest/Language/Add", R, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindLanguageResponse>("rest/Language/Remove", parameters, MediaType.Json);
        }

        public void Edit(Language R)
        {
            var request = HttpPost<Language>("rest/Language/Edit", R, MediaType.Json);
        }
    }
}

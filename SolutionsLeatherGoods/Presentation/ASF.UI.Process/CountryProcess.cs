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
    public class CountryProcess : ProcessComponent
    {
        public List<Country> SelectList()
        {
            var response = HttpGet<AllCountryResponse>("rest/Country/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Country Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindCountryResponse>("rest/Country/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(Country C)
        {
            var request = HttpPost<Country>("rest/Country/Add", C, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindCategoryResponse>("rest/Country/Remove", parameters, MediaType.Json);
        }

        public void Edit(Country C)
        {
            var request = HttpPost<Country>("rest/Country/Edit", C, MediaType.Json);
        }
    }
}

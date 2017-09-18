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
    public class LocaleResourceKeyProcess : ProcessComponent
    {
        public List<LocaleResourceKey> SelectList()
        {
            var response = HttpGet<AllLocaleResourceKeyResponse>("rest/LocaleResourceKey/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public LocaleResourceKey Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindLocaleResourceKeyResponse>("rest/LocaleResourceKey/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(LocaleResourceKey R)
        {
            var request = HttpPost<LocaleResourceKey>("rest/LocaleResourceKey/Add", R, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindLocaleResourceKeyResponse>("rest/LocaleResourceKey/Remove", parameters, MediaType.Json);
        }

        public void Edit(LocaleResourceKey R)
        {
            var request = HttpPost<LocaleResourceKey>("rest/LocaleResourceKey/Edit", R, MediaType.Json);
        }
    }
}

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
    public class LocaleStringResourceProcess : ProcessComponent
    {
        public List<LocaleStringResource> SelectList()
        {
            var response = HttpGet<AllLocaleStringResourceResponse>("rest/LocaleStringResource/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public LocaleStringResource Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindLocaleStringResourceResponse>("rest/LocaleStringResource/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(LocaleStringResource R)
        {
            var request = HttpPost<LocaleStringResource>("rest/LocaleStringResource/Add", R, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindLocaleStringResourceResponse>("rest/LocaleStringResource/Remove", parameters, MediaType.Json);
        }

        public void Edit(LocaleStringResource R)
        {
            var request = HttpPost<LocaleStringResource>("rest/LocaleStringResource/Edit", R, MediaType.Json);
        }

    }
}

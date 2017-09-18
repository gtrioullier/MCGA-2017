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
    public class AspNetUsersProcess : ProcessComponent
    {
        public List<AspNetUsers> SelectList()
        {
            var response = HttpGet<AllAspNetUsersResponse>("rest/AspNetUsers/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public AspNetUsers Find(string id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindAspNetUsersResponse>("rest/AspNetUsers/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(AspNetUsers A)
        {
            var request = HttpPost<AspNetUsers>("rest/AspNetUsers/Add", A, MediaType.Json);
        }

        public void Delete(string id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindAspNetUsersResponse>("rest/AspNetUsers/Remove", parameters, MediaType.Json);
        }

        public void Edit(AspNetUsers A)
        {
            var request = HttpPost<AspNetUsers>("rest/AspNetUsers/Edit", A, MediaType.Json);
        }
    }
}

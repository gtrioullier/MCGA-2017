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
    public class AspNetRolesProcess : ProcessComponent
    {
        public List<AspNetRoles> SelectList()
        {
            var response = HttpGet<AllAspNetRolesResponse>("rest/AspNetRoles/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public AspNetRoles Find(string id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindAspNetRolesResponse>("rest/AspNetRoles/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(AspNetRoles A)
        {
            var request = HttpPost<AspNetRoles>("rest/AspNetRoles/Add", A, MediaType.Json);
        }

        public void Delete(string id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindAspNetRolesResponse>("rest/AspNetRoles/Remove", parameters, MediaType.Json);
        }

        public void Edit(AspNetRoles A)
        {
            var request = HttpPost<AspNetRoles>("rest/AspNetRoles/Edit", A, MediaType.Json);
        }
    }
}

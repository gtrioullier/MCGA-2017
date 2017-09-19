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
    public class AspNetUserLoginsProcess : ProcessComponent
    {
        public List<AspNetUserLogins> SelectList()
        {
            var response = HttpGet<AllAspNetUserLoginsResponse>("rest/AspNetUserLogins/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public AspNetUserLogins Find(AspNetUserLogins A)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("UserId", A.UserId);
            parameters.Add("LoginProvider", A.LoginProvider);
            parameters.Add("ProviderKey", A.ProviderKey);
            var response = HttpGet<FindAspNetUserLoginsResponse>("rest/AspNetUserLogins/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(AspNetUserLogins A)
        {
            var request = HttpPost<AspNetUserLogins>("rest/AspNetUserLogins/Add", A, MediaType.Json);
        }

        public void Delete(AspNetUserLogins A)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("UserId", A.UserId);
            parameters.Add("LoginProvider", A.LoginProvider);
            parameters.Add("ProviderKey", A.ProviderKey);
            var response = HttpGet<FindAspNetUserLoginsResponse>("rest/AspNetUserLogins/Remove", parameters, MediaType.Json);
        }

        public void Edit(AspNetUserLogins A)
        {
            var request = HttpPost<AspNetUserLogins>("rest/AspNetUserLogins/Edit", A, MediaType.Json);
        }
    }
}

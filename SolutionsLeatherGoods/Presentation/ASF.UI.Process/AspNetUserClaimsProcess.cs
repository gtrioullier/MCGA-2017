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
    public class AspNetUserClaimsProcess : ProcessComponent
    {
        public List<AspNetUserClaims> SelectList()
        {
            var response = HttpGet<AllAspNetUserClaimsResponse>("rest/AspNetUserClaims/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public AspNetUserClaims Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindAspNetUserClaimsResponse>("rest/AspNetUserClaims/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(AspNetUserClaims A)
        {
            var request = HttpPost<AspNetUserClaims>("rest/AspNetUserClaims/Add", A, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindAspNetUserClaimsResponse>("rest/AspNetUserClaims/Remove", parameters, MediaType.Json);
        }

        public void Edit(AspNetUserClaims A)
        {
            var request = HttpPost<AspNetUserClaims>("rest/AspNetUserClaims/Edit", A, MediaType.Json);
        }
    }
}

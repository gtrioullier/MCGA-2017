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
    public class AspNetUserRolesProcess : ProcessComponent
    {
        public List<AspNetUserRoles> SelectList()
        {
            var response = HttpGet<AllAspNetUserRolesResponse>("rest/AspNetUserRoles/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public AspNetUserRoles Find(AspNetUserRoles A)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("UserId", A.UserId);
            parameters.Add("RoleId", A.RoleId);
            var response = HttpGet<FindAspNetUserRolesResponse>("rest/AspNetUserRoles/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(AspNetUserRoles A)
        {
            var request = HttpPost<AspNetUserRoles>("rest/AspNetUserRoles/Add", A, MediaType.Json);
        }

        public void Delete(AspNetUserRoles A)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("UserId", A.UserId);
            parameters.Add("RoleId", A.RoleId);
            var response = HttpGet<FindAspNetUserRolesResponse>("rest/AspNetUserRoles/Remove", parameters, MediaType.Json);
        }

        public void Edit(AspNetUserRoles A)
        {
            var request = HttpPost<AspNetUserRoles>("rest/AspNetUserRoles/Edit", A, MediaType.Json);
        }
    }
}

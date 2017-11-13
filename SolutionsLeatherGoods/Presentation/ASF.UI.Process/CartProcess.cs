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
    public class CartProcess : ProcessComponent
    {
        public List<Cart> SelectList()
        {
            var response = HttpGet<AllCartResponse>("rest/Cart/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Cart Find(Guid Rowid)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("Rowid", Rowid);
            var response = HttpGet<FindCartResponse>("rest/Cart/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public Cart Create(Cart C)
        {
            var request = HttpPost<Cart>("rest/Cart/Add", C, MediaType.Json);
            return request;
        }

        public void Delete(Guid Rowid)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("Rowid", Rowid);
            var response = HttpGet<FindCartResponse>("rest/Cart/Remove", parameters, MediaType.Json);
        }

        public void Edit(Cart C)
        {
            var request = HttpPost<Cart>("rest/Cart/Edit", C, MediaType.Json);
        }
    }
}

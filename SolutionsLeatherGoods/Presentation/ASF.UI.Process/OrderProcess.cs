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
    public class OrderProcess : ProcessComponent
    {
        public List<Order> SelectList()
        {
            var response = HttpGet<AllOrderResponse>("rest/Order/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Order Find(Guid Rowid)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("Rowid", Rowid);
            var response = HttpGet<FindOrderResponse>("rest/Order/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public Order Create(Order O)
        {
            var request = HttpPost<Order>("rest/Order/Add", O, MediaType.Json);
            return request;
        }

        public void Delete(Guid Rowid)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("Rowid", Rowid);
            var response = HttpGet<FindOrderResponse>("rest/Order/Remove", parameters, MediaType.Json);
        }

        public void Edit(Order O)
        {
            var request = HttpPost<Order>("rest/Order/Edit", O, MediaType.Json);
        }

    }
}

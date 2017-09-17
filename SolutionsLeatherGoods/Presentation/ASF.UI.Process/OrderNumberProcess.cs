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
    public class OrderNumberProcess : ProcessComponent
    {
        public List<OrderNumber> SelectList()
        {
            var response = HttpGet<AllOrderNumberResponse>("rest/OrderNumber/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public OrderNumber Find(int id)
        {
            var response = HttpGet<FindOrderNumberResponse>("rest/OrderNumber/Find", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Create(OrderNumber O)
        {
            var request = HttpPost<OrderNumber>("rest/OrderNumber/Add", O, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id",id);
            var response = HttpGet<FindOrderResponse>("rest/OrderNumber/Remove", parameters, MediaType.Json);
        }

        public void Edit(OrderNumber O)
        {
            var request = HttpPost<OrderNumber>("rest/OrderNumber/Edit", O, MediaType.Json);
        }
    }
}

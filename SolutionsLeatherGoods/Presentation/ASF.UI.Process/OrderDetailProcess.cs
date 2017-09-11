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
    public class OrderDetailProcess : ProcessComponent
    {
        public List<OrderDetail> SelectList()
        {
            var response = HttpGet<AllOrderDetailResponse>("rest/OrderDetail/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public OrderDetail Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindOrderDetailResponse>("rest/OrderDetail/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(OrderDetail O)
        {
            var request = HttpPost<OrderDetail>("rest/OrderDetail/Add", O, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindOrderDetailResponse>("rest/OrderDetail/Remove", parameters, MediaType.Json);
        }

        public void Edit(OrderDetail O)
        {
            var request = HttpPost<OrderDetail>("rest/OrderDetail/Edit", O, MediaType.Json);
        }
    }
}

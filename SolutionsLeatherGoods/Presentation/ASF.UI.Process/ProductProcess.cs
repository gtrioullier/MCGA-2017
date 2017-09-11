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
    public class ProductProcess : ProcessComponent
    {
        public List<Product> SelectList()
        {
            var response = HttpGet<AllProductResponse>("rest/Product/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Product Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindProductResponse>("rest/Product/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(Product P)
        {
            var request = HttpPost<Product>("rest/Product/Add", P, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindProductResponse>("rest/Product/Remove", parameters, MediaType.Json);
        }

        public void Edit(Product P)
        {
            var request = HttpPost<Product>("rest/Product/Edit", P, MediaType.Json);
        }
    }
}

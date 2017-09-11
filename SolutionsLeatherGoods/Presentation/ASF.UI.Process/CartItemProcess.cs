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
    public class CartItemProcess : ProcessComponent
    {
        public List<CartItem> SelectList()
        {
            var response = HttpGet<AllCartItemResponse>("rest/CartItem/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public CartItem Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindCartItemResponse>("rest/CartItem/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(CartItem P)
        {
            var request = HttpPost<CartItem>("rest/CartItem/Add", P, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindCartItemResponse>("rest/CartItem/Remove", parameters, MediaType.Json);
        }

        public void Edit(CartItem P)
        {
            var request = HttpPost<CartItem>("rest/CartItem/Edit", P, MediaType.Json);
        }
    }
}

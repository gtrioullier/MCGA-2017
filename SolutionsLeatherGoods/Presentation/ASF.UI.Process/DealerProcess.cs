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
    public class DealerProcess : ProcessComponent
    {
        public List<Dealer> SelectList()
        {
            var response = HttpGet<AllDealerResponse>("rest/Dealer/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Dealer Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindDealerResponse>("rest/Dealer/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(Dealer D)
        {
            var request = HttpPost<Dealer>("rest/Dealer/Add", D, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindDealerResponse>("rest/Dealer/Remove", parameters, MediaType.Json);
        }

        public void Edit(Dealer D)
        {
            var request = HttpPost<Dealer>("rest/Dealer/Edit", D, MediaType.Json);
        }
    }
}

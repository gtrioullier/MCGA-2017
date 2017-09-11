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
    public class ClientProcess : ProcessComponent
    {
        public List<Client> SelectList()
        {
            var response = HttpGet<AllClientResponse>("rest/Client/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Client Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindClientResponse>("rest/Client/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(Client C)
        {
            var request = HttpPost<Client>("rest/Client/Add", C, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindClientResponse>("rest/Client/Remove", parameters, MediaType.Json);
        }

        public void Edit(Client C)
        {
            var request = HttpPost<Client>("rest/Client/Edit", C, MediaType.Json);
        }
    }
}

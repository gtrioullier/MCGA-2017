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
    public class ErrorProcess : ProcessComponent
    {
        public List<Error> SelectList()
        {
            var response = HttpGet<AllErrorResponse>("rest/Error/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Error Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindErrorResponse>("rest/Error/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(Error E)
        {
            var request = HttpPost<Error>("rest/Error/Add", E, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindErrorResponse>("rest/Error/Delete", parameters, MediaType.Json);
        }

        public void Edit(Error E)
        {
            var request = HttpPost<Error>("rest/Error/Edit", E, MediaType.Json);
        }
    }
}

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
    public class SettingProcess : ProcessComponent
    {
        public List<Setting> SelectList()
        {
            var response = HttpGet<AllSettingResponse>("rest/Setting/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Setting Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindSettingResponse>("rest/Setting/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(Setting R)
        {
            var request = HttpPost<Setting>("rest/Setting/Add", R, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindSettingResponse>("rest/Setting/Remove", parameters, MediaType.Json);
        }

        public void Edit(Setting R)
        {
            var request = HttpPost<Setting>("rest/Setting/Edit", R, MediaType.Json);
        }
    }
}

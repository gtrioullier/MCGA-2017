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
    public class CategoryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Category/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Category Find(int id)
        {
            var response = HttpGet<FindResponse>("rest/Category/Find/"+id, new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Create(Category C)
        {
            var request = HttpPost<Category>("rest/Category/Add", C, MediaType.Json);
        }

        public void Delete(int id)//Service es remove{id}
        {
            var response = HttpGet<FindResponse>("rest/Category/Remove/"+id, new Dictionary<string, object>(), MediaType.Json);
        }

        public void Edit(Category C)//Service es edit{category}
        {
            var request = HttpPost<Category>("rest/Category/Edit/", C, MediaType.Json);//cambié HttpPut por HttpPost
        }
    }
}
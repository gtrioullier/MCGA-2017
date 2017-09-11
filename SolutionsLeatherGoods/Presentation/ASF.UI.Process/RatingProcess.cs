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
    public class RatingProcess : ProcessComponent
    {
        public List<Rating> SelectList()
        {
            var response = HttpGet<AllRatingResponse>("rest/Rating/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Rating Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindRatingResponse>("rest/Rating/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(Rating R)
        {
            var request = HttpPost<Rating>("rest/Rating/Add", R, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindRatingResponse>("rest/Rating/Remove", parameters, MediaType.Json);
        }

        public void Edit(Rating R)
        {
            var request = HttpPost<Rating>("rest/Rating/Edit", R, MediaType.Json);
        }
    }
}

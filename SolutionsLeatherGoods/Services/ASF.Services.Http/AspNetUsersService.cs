using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;


namespace ASF.Services.Http
{
    [RoutePrefix("rest/AspNetUsers")]
    public class AspNetUsersService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllAspNetUsersResponse All()
        {
            try
            {
                var response = new AllAspNetUsersResponse();
                var bc = new AspNetUsersBusiness();
                response.Result = bc.All();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("Find")]
        public FindAspNetUsersResponse Find(string id)
        {
            try
            {
                var response = new FindAspNetUsersResponse();
                var bc = new AspNetUsersBusiness();
                response.Result = bc.Find(id);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Add")]
        public AspNetUsers Add(AspNetUsers aspnetusers)
        {
            try
            {
                var bc = new AspNetUsersBusiness();
                return bc.Add(aspnetusers);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("Remove")]
        public void Remove(string id)
        {
            try
            {
                var bc = new AspNetUsersBusiness();
                bc.Remove(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Edit")]
        public void Edit(AspNetUsers aspnetusers)
        {
            try
            {
                var bc = new AspNetUsersBusiness();
                bc.Edit(aspnetusers);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}

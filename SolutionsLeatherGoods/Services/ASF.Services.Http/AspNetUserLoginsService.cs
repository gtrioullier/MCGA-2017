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
    [RoutePrefix("rest/AspNetUserLogins")]
    public class AspNetUserLoginsService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllAspNetUserLoginsResponse All()
        {
            try
            {
                var response = new AllAspNetUserLoginsResponse();
                var bc = new AspNetUserLoginsBusiness();
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
        public FindAspNetUserLoginsResponse Find(AspNetUserLogins aspnetuserslogins)
        {
            try
            {
                var response = new FindAspNetUserLoginsResponse();
                var bc = new AspNetUserLoginsBusiness();
                response.Result = bc.Find(aspnetuserslogins);
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
        public AspNetUserLogins Add(AspNetUserLogins aspnetuserslogins)
        {
            try
            {
                var bc = new AspNetUserLoginsBusiness();
                return bc.Add(aspnetuserslogins);
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
        public void Remove(AspNetUserLogins aspnetuserslogins)
        {
            try
            {
                var bc = new AspNetUserLoginsBusiness();
                bc.Remove(aspnetuserslogins);
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
        public void Edit(AspNetUserLogins aspnetuserslogins)
        {
            try
            {
                var bc = new AspNetUserLoginsBusiness();
                bc.Edit(aspnetuserslogins);
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

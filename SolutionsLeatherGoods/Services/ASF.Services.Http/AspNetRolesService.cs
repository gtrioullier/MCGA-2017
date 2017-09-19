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
    [RoutePrefix("rest/AspNetRoles")]
    public class AspNetRolesService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllAspNetRolesResponse All()
        {
            try
            {
                var response = new AllAspNetRolesResponse();
                var bc = new AspNetRolesBusiness();
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
        public FindAspNetRolesResponse Find(string id)
        {
            try
            {
                var response = new FindAspNetRolesResponse();
                var bc = new AspNetRolesBusiness();
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
        public AspNetRoles Add(AspNetRoles aspnetusersclaims)
        {
            try
            {
                var bc = new AspNetRolesBusiness();
                return bc.Add(aspnetusersclaims);
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
                var bc = new AspNetRolesBusiness();
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
        public void Edit(AspNetRoles aspnetusersclaims)
        {
            try
            {
                var bc = new AspNetRolesBusiness();
                bc.Edit(aspnetusersclaims);
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

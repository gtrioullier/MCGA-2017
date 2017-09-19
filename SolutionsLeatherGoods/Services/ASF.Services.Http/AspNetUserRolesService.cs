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
    [RoutePrefix("rest/AspNetUserRoles")]
    public class AspNetUserRolesService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllAspNetUserRolesResponse All()
        {
            try
            {
                var response = new AllAspNetUserRolesResponse();
                var bc = new AspNetUserRolesBusiness();
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
        public FindAspNetUserRolesResponse Find(AspNetUserRoles aspnetusersroles)
        {
            try
            {
                var response = new FindAspNetUserRolesResponse();
                var bc = new AspNetUserRolesBusiness();
                response.Result = bc.Find(aspnetusersroles);
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
        public AspNetUserRoles Add(AspNetUserRoles aspnetusersroles)
        {
            try
            {
                var bc = new AspNetUserRolesBusiness();
                return bc.Add(aspnetusersroles);
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
        public void Remove(AspNetUserRoles aspnetusersroles)
        {
            try
            {
                var bc = new AspNetUserRolesBusiness();
                bc.Remove(aspnetusersroles);
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
        public void Edit(AspNetUserRoles aspnetusersroles)
        {
            try
            {
                var bc = new AspNetUserRolesBusiness();
                bc.Edit(aspnetusersroles);
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

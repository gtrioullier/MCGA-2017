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
    [RoutePrefix("rest/AspNetUserClaims")]
    public class AspNetUserClaimsService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllAspNetUserClaimsResponse All()
        {
            try
            {
                var response = new AllAspNetUserClaimsResponse();
                var bc = new AspNetUserClaimsBusiness();
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
        public FindAspNetUserClaimsResponse Find(int id)
        {
            try
            {
                var response = new FindAspNetUserClaimsResponse();
                var bc = new AspNetUserClaimsBusiness();
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
        public AspNetUserClaims Add(AspNetUserClaims aspnetusersclaims)
        {
            try
            {
                var bc = new AspNetUserClaimsBusiness();
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
        public void Remove(int id)
        {
            try
            {
                var bc = new AspNetUserClaimsBusiness();
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
        public void Edit(AspNetUserClaims aspnetusersclaims)
        {
            try
            {
                var bc = new AspNetUserClaimsBusiness();
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

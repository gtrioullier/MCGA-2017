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
    [RoutePrefix("rest/Error")]
    public class ErrorService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllErrorResponse All()
        {
            try
            {
                var response = new AllErrorResponse();
                var bc = new ErrorBusiness();
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
        public FindErrorResponse Find(int id)
        {
            try
            {
                var response = new FindErrorResponse();
                var bc = new ErrorBusiness();
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
        public Error Add(Error error)
        {
            try
            {
                var bc = new ErrorBusiness();
                return bc.Add(error);
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
                var bc = new ErrorBusiness();
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
        public void Edit(Error error)
        {
            try
            {
                var bc = new ErrorBusiness();
                bc.Edit(error);
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

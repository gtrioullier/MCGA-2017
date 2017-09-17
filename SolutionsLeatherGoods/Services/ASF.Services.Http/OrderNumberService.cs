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
    [RoutePrefix("rest/OrderNumber")]
    public class OrderNumberService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllOrderNumberResponse All()
        {
            try
            {
                var response = new AllOrderNumberResponse();
                var bc = new OrderNumberBusiness();
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
        public FindOrderNumberResponse Find(int id)
        {
            try
            {
                var response = new FindOrderNumberResponse();
                var bc = new OrderNumberBusiness();
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
        public OrderNumber Add(OrderNumber ordernumber)
        {
            try
            {
                var bc = new OrderNumberBusiness();
                return bc.Add(ordernumber);
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
                var bc = new OrderNumberBusiness();
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
        public void Edit(OrderNumber ordernumber)
        {
            try
            {
                var bc = new OrderNumberBusiness();
                bc.Edit(ordernumber);
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

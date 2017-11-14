using Core2WebApi.Services.BrokersService;
using Microsoft.AspNetCore.Mvc;
using Core2WebApi.Models;
using System.Net.Http;
using src.Common.Extensions;

namespace Core2WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/brokers")]
    public class BrokersController : Controller
    {
        private readonly IBrokersService _brokersService;
        public BrokersController(IBrokersService brokersService)
        {
            _brokersService = brokersService;
        }

        [HttpGet]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public PagedDataInquiryResponse<Broker> Get(HttpRequestMessage requestMessage)
        {
            requestMessage.RequestUri = Request.GetUri();
            var brokers = _brokersService.GetBroekrs(requestMessage);
            return brokers;
        }

        [HttpGet("{id}")]
        public Broker Get(int id)
        {
            var b = _brokersService.GetById(id);
            return b;
        }
    }
}
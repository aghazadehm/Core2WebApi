using System.Net.Http;
using Core2WebApi.Models;
using Core2WebApi.Services.BrokersService;
using Microsoft.AspNetCore.Mvc;
using Core2WebApi.Common.Extensions;

namespace Core2WebApi.Controllers.V1 {
    /// <summary>
    /// کنترلر اطلاعات کارگزاری‌ها
    /// </summary>
    [ApiVersion ("1.0")]
    [Route ("api/{version:apiVersion}/brokers")]
    public class BrokersController : ControllerBase {
        private readonly IBrokersService _brokersService;
        
        /// <summary>
        /// Broker controller cons
        /// </summary>
        /// <param name="brokersService"></param>
        public BrokersController (IBrokersService brokersService) {
            _brokersService = brokersService;
        }

        /// <summary>
        /// این متد برای خواندن اطلاعات کلی کارگزاری هاست
        /// </summary>
        /// <param name="requestMessage"></param>``
        /// <returns></returns>

        [HttpGet]
        public PagedDataInquiryResponse<Broker> Get (HttpRequestMessage requestMessage) {
            requestMessage.RequestUri = Request.GetUri ();
            var brokers = _brokersService.GetBroekrs (requestMessage);
            return brokers;
        }

        [HttpGet ("{id}")]
        public Broker Get (int id) {
            var b = _brokersService.GetById (id);
            return b;
        }
    }
}
using System.Net.Http;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;
using Core2WebApi.Services.Derivatives.Future;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Future;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Core2WebApi.Controllers.V1.Derivatives.Future {
    /// <summary>
    /// برای دریافت اطلاعات فراردادهای آتی 
    /// </summary>
    [ApiVersion ("1.0")]
    [Route ("api/{version:apiVersion}/derivatives/future/contracts")]
    public class ContractsController : ControllerBase {
        private readonly IFutureContractsService _futureContractsService;

        /// <summary>
        /// سازنده
        /// </summary>
        public ContractsController (IFutureContractsService futureContractsService) {
            _futureContractsService = futureContractsService;
        }

        /// <summary>
        /// دریافت اطلاعات قراردادهای آتی
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        //[Route ("", Name = "GetContractsRoute")]
        [HttpGet]
        public PagedDataInquiryResponse<FutureContract> Get (HttpRequestMessage requestMessage) {
            requestMessage.RequestUri = Request.GetUri ();
            var conrtacts = _futureContractsService.GetContracts (requestMessage);
            return conrtacts;
        }

        //[Route ("", Name = "GetFutureContractRoute")]
        [HttpGet ("{id}")]
        public FutureContract Get (int id) {
            var contract = _futureContractsService.GetById (id);
            return contract;
        }
    }
}
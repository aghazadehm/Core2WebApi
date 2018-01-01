using System.Net.Http;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;
using Core2WebApi.Services.Derivatives.Future;
using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Future;
using Microsoft.AspNetCore.Mvc;

namespace Core2WebApi.Controllers.V1.Derivatives.Future {
    /// <summary>
    /// برای دریافت اطلاعات فراردادهای آتی 
    /// </summary>
    [ApiVersion ("1.0")]
    [Route ("api/{version:apiVersion}/contracts")]
    public class ContractsController : ControllerBase {
        private readonly IAllFutureContractInquiryProcessor _allFutureContractInquiryProcessor;
        private readonly IPagedDataRequestFactory _padedDataRequestFactory;
        //private readonly IFutureContractByIdInquiryProcessor _futureContractByIdInquiryProcessor;

        /// <summary>
        /// سازنده
        /// </summary>
        public ContractsController (IFutureContractsDependencyBlock futureContractDependencyBlock) {
            _allFutureContractInquiryProcessor = futureContractDependencyBlock.AllFutureContractInquiryProcessor;
            _padedDataRequestFactory = futureContractDependencyBlock.PagedDataRequestFactory;
            //_futureContractByIdInquiryProcessor = futureContractControllerDependencyBlock.FutureContractByIdInquiryProcessor;
        }

        /// <summary>
        /// دریافت اطلاعات قراردادهای آتی
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        //[Route ("", Name = "GetContractsRoute")]
        [HttpGet]
        public PagedDataInquiryResponse<FutureContract> GetContracts (HttpRequestMessage requestMessage) {
            var request = _padedDataRequestFactory.Create (requestMessage.RequestUri);
            var conrtacts = _allFutureContractInquiryProcessor.GetContracts (request);
            return conrtacts;
        }

        // [Route ("", Name = "GetFutureContractRoute")]

        // public FutureContract GetFutureContract (int id) {
        //     var contract = _futureContractByIdInquiryProcessor.GetFutureContract (id);
        //     return contract;
        // }
    }
}
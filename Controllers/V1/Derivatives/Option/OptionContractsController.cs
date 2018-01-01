using System.Net.Http;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Option;
using Core2WebApi.Services.Derivatives.Option;
using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Option;
using Microsoft.AspNetCore.Mvc;

namespace Core2WebApi.Controllers.V1.Derivatives.Option {
    public class OptionContractsController : ControllerBase {
        private readonly IAllOptionContractInquiryProcessor _allOptionContractInquiryProcessor;
        private readonly IPagedDataRequestFactory _padedDataRequestFactory;
        private readonly IOptionContractByIdInquiryProcessor _optionContractByIdInquiryProcessor;

        /// <summary>
        /// سازنده
        /// </summary>
        public OptionContractsController (IOptionContractsDependencyBlock OptionContractDependencyBlock) {
            _allOptionContractInquiryProcessor = OptionContractDependencyBlock.AllOptionContractInquiryProcessor;
            _padedDataRequestFactory = OptionContractDependencyBlock.PagedDataRequestFactory;
            _optionContractByIdInquiryProcessor = OptionContractDependencyBlock.OptionContractByIdInquiryProcessor;
        }

        [Route ("", Name = "GetOptionContractsRoute")]
        public PagedDataInquiryResponse<OptionContract> GetOptionContracts (HttpRequestMessage requestMessage) {
            var request = _padedDataRequestFactory.Create (requestMessage.RequestUri);
            var conrtacts = _allOptionContractInquiryProcessor.GetOptionContracts (request);
            return conrtacts;
        }

        [Route ("", Name = "GetOptionContractRoute")]

        public OptionContract GetOptionContract (int id) {
            var contract = _optionContractByIdInquiryProcessor.GetOptionContract (id);
            return contract;
        }
    }
}
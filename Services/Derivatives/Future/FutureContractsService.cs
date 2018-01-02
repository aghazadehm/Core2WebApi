using System.Net.Http;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;
using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Future;

namespace Core2WebApi.Services.Derivatives.Future {
    public class FutureContractsService : IFutureContractsService {
        private readonly IAllFutureContractInquiryProcessor _allFutureContractInquiryProcessor;
        private readonly IFutureContractByIdInquiryProcessor _futureContractByIdInquiry;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        public FutureContractsService (IFutureContractsDependencyBlock futureContractDependencyBlock) {
            _allFutureContractInquiryProcessor = futureContractDependencyBlock.AllFutureContractInquiryProcessor;
            _futureContractByIdInquiry = futureContractDependencyBlock.FutureContractByIdInquiry;
            _pagedDataRequestFactory = futureContractDependencyBlock.PagedDataRequestFactory;
        }

        public FutureContract GetById (int id) {
            FutureContract contract = _futureContractByIdInquiry.GetFutureContract (id);
            return contract;
        }

        public PagedDataInquiryResponse<FutureContract> GetContracts (HttpRequestMessage requestMessage) {
            var request = _pagedDataRequestFactory.Create(requestMessage.RequestUri);
            var contracts = _allFutureContractInquiryProcessor.GetContracts(request);
            return contracts;
        }
    }
}
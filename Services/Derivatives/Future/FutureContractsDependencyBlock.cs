using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Future;

namespace Core2WebApi.Services.Derivatives.Future {
    public class FutureContractsDependencyBlock : IFutureContractsDependencyBlock {
        public IAllFutureContractInquiryProcessor AllFutureContractInquiryProcessor { get; private set; }
        public IPagedDataRequestFactory PagedDataRequestFactory { get; private set; }

        public IFutureContractByIdInquiryProcessor FutureContractByIdInquiry { get; private set; }
        public FutureContractsDependencyBlock (
            IAllFutureContractInquiryProcessor allFutureContractInquiryProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IFutureContractByIdInquiryProcessor futureContractByIdInquiryProcessor) {
            AllFutureContractInquiryProcessor = allFutureContractInquiryProcessor;
            PagedDataRequestFactory = pagedDataRequestFactory;
            FutureContractByIdInquiry = futureContractByIdInquiryProcessor;
        }
    }
}
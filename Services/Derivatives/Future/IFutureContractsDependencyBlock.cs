using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Future;

namespace Core2WebApi.Services.Derivatives.Future {
    public interface IFutureContractsDependencyBlock {
        IAllFutureContractInquiryProcessor AllFutureContractInquiryProcessor { get; }
        IPagedDataRequestFactory PagedDataRequestFactory { get; }
        //IFutureContractByIdInquiryProcessor FutureContractByIdInquiryProcessor { get; set; }
    }
}
using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Future;

namespace Core2WebApi.Controllers.V1.Derivatives.Future {
    public interface IFutureContractControllerDependencyBlock {
        IAllFutureContractInquiryProcessor AllFutureContractInquiryProcessor { get; }
        IPagedDataRequestFactory PagedDataRequestFactory { get; }
        //IFutureContractByIdInquiryProcessor FutureContractByIdInquiryProcessor { get; set; }
    }
}
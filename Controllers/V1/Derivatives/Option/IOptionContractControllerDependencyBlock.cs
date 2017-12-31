using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Option;

namespace Core2WebApi.Controllers.V1.Derivatives.Option {
    public interface IOptionContractControllerDependencyBlock {
        IAllOptionContractInquiryProcessor AllOptionContractInquiryProcessor { get; }
        IPagedDataRequestFactory PagedDataRequestFactory { get; }
        IOptionContractByIdInquiryProcessor OptionContractByIdInquiryProcessor { get; set; }
    }
}
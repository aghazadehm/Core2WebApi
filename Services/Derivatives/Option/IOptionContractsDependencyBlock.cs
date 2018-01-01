using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Option;

namespace Core2WebApi.Services.Derivatives.Option {
    public interface IOptionContractsDependencyBlock {
        IAllOptionContractInquiryProcessor AllOptionContractInquiryProcessor { get; }
        IPagedDataRequestFactory PagedDataRequestFactory { get; }
        IOptionContractByIdInquiryProcessor OptionContractByIdInquiryProcessor { get; set; }
    }
}
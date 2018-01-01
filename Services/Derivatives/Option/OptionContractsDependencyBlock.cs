using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Option;

namespace Core2WebApi.Services.Derivatives.Option
{
    public class OptionContractsDependencyBlock : IOptionContractsDependencyBlock
    {
        public IAllOptionContractInquiryProcessor AllOptionContractInquiryProcessor => throw new System.NotImplementedException();

        public IPagedDataRequestFactory PagedDataRequestFactory => throw new System.NotImplementedException();

        public IOptionContractByIdInquiryProcessor OptionContractByIdInquiryProcessor { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
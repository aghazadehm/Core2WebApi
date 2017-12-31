using Core2WebApi.Data;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Option;

namespace Core2WebApi.Services.InquiryProcessing.Derivatives.Option {
    public interface IOptionContractByIdInquiryProcessor {
        OptionContract GetOptionContract (int contractId);
    }
}
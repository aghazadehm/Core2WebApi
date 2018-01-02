using Core2WebApi.Models.Derivatives.Future;

namespace Core2WebApi.Services.InquiryProcessing.Derivatives.Future {
    public interface IFutureContractByIdInquiryProcessor {
        FutureContract GetFutureContract (int id);
    }
}
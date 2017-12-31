using Core2WebApi.Data;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;

namespace Core2WebApi.Services.InquiryProcessing.Derivatives.Future
{
    public interface IAllFutureContractInquiryProcessor
    {
         PagedDataInquiryResponse<FutureContract> GetContracts(PagedDataRequest pagedDataRequest);
    }
}
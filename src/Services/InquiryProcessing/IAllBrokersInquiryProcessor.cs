using Core2WebApi.Data;
using Core2WebApi.Models;

namespace Core2WebApi.Services.InquiryProcessing
{
    public interface IAllBrokersInquiryProcessor
    {
         PagedDataInquiryResponse<Broker> GetBrokers(PagedDataRequest request);
    }
}
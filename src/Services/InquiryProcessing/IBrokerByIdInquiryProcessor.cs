using Core2WebApi.Models;

namespace Core2WebApi.Services.InquiryProcessing
{
    public interface IBrokerByIdInquiryProcessor
    {
         Broker GetBroker(int brokerId);
    }
}
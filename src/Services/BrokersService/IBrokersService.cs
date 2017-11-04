using System.Net.Http;
using Core2WebApi.Models;

namespace Core2WebApi.Services.BrokerService
{
    public interface IBrokersService
    {
        PagedDataInquiryResponse<Broker> GetBroekrs(HttpRequestMessage equestMessage);
        Broker GetById(int id);
    }
}
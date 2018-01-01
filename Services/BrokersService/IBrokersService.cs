using System.Net.Http;
using Core2WebApi.Models;

namespace Core2WebApi.Services.BrokersService
{
    public interface IBrokersService
    {
        PagedDataInquiryResponse<Broker> GetBroekrs(HttpRequestMessage requestMessage);
        Broker GetById(int id);
    }
}
using Core2WebApi.Models;

namespace Core2WebApi.LinkServices
{
    public interface IBrokerLinkService
    {
        void AddLinks(Broker broker);
        Link GetAllBrokersLink();
        void AddSelfLink(Broker broker);
        Link GetSelfLink(int brokerId);
    }
}
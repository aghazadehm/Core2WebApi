using System.Net.Http;
using Core2WebApi.Common;
using Core2WebApi.Models;

namespace Core2WebApi.LinkServices
{
    public class BrokerLinkService : IBrokerLinkService
    {
        private readonly ICommonLinkService _commonLinkService;
        public BrokerLinkService(ICommonLinkService commonLinkService)
        {
            _commonLinkService = commonLinkService;
        }
        public void AddLinks(Broker broker)
        {
            AddSelfLink(broker);
            AddAllBrokersLink(broker);
            //AddLinksToChildObjects(broker);
        }

        private void AddAllBrokersLink(Broker broker)
        {
            broker.AddLink(GetAllBrokersLink());
        }

        public void AddSelfLink(Broker broker)
        {
            broker.AddLink(GetSelfLink(broker.Id));
        }

        public Link GetAllBrokersLink()
        {
            const string pathFragment = "brokers";
            return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
        }

        public Link GetSelfLink(int brokerId)
        {
            var pathFragment = string.Format("brokers/{0}", brokerId);
            var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
            return link;
        }
    }
}
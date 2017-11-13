using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Core2WebApi.Models;
using Core2WebApi.Services.BrokersService;
using Core2WebApi.Services.InquiryProcessing;

namespace Core2WebApi.Services.BrokersService
{
    public class BrokersService : IBrokersService
    {
        private readonly IAllBrokersInquiryProcessor _allBrokersInquiryProcessor;
        private readonly IBrokerByIdInquiryProcessor _brokerByIdInquiryProcessor;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        public BrokersService(IBrokerServiceDependencyBlock brokerServiceDependencyBlock)
        {
            _allBrokersInquiryProcessor = brokerServiceDependencyBlock.AllBrokersInquiryProcessor;
            _pagedDataRequestFactory = brokerServiceDependencyBlock.PagedDataRequestFactory;
            _brokerByIdInquiryProcessor = brokerServiceDependencyBlock.BrokerByIdInquiryProcessor;
        }
        public List<Broker> _brokers { get; set; } = new List<Broker>();
        public PagedDataInquiryResponse<Broker> GetBroekrs(HttpRequestMessage requestMessage)
        {
            var request = _pagedDataRequestFactory.Create(requestMessage.RequestUri);
            var brokers = _allBrokersInquiryProcessor.GetBrokers(request);
            return brokers;
        }

        public Broker GetById(int id)
        {
            var broker = _brokerByIdInquiryProcessor.GetBroker(id);
            return broker;
        }
    }
}
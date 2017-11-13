using AutoMapper;
using Core2WebApi.LinkServices;
using Core2WebApi.Models;
using Core2WebApi.Data.Exceptions;
using Core2WebApi.Data.QueryProcessors;

namespace Core2WebApi.Services.InquiryProcessing {
    public class BrokerByIdInquiryProcessor : IBrokerByIdInquiryProcessor {
        private readonly IMapper _mapper;
        private readonly IBrokerByIdQueryProcessor _queryProcessor;
        private readonly IBrokerLinkService _linkService;

         public BrokerByIdInquiryProcessor(IBrokerByIdQueryProcessor queryProcessor, 
            IMapper mapper, IBrokerLinkService linkService)
         {
             _queryProcessor = queryProcessor;
             _mapper = mapper;
             _linkService = linkService;
         }
        public Broker GetBroker (int brokerId) 
        {
            var brokerEntity = _queryProcessor.GetBroker(brokerId);
            if(brokerEntity == null)
                throw new RootObjectNotFoundException("Broker Not Found");
            var broker = _mapper.Map<Broker>(brokerEntity);
            _linkService.AddLinks(broker);
            return broker;
        }
    }
}
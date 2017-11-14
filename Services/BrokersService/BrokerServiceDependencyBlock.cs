using Core2WebApi.Services.InquiryProcessing;

namespace Core2WebApi.Services.BrokersService {
    public class BrokerServiceDependencyBlock : IBrokerServiceDependencyBlock {
        public BrokerServiceDependencyBlock (IAllBrokersInquiryProcessor allBrokersInquiryProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IBrokerByIdInquiryProcessor brokerByIdInquiryProcessor) {
            AllBrokersInquiryProcessor = allBrokersInquiryProcessor;
            PagedDataRequestFactory = pagedDataRequestFactory;
            BrokerByIdInquiryProcessor = brokerByIdInquiryProcessor;
        }
        public IAllBrokersInquiryProcessor AllBrokersInquiryProcessor { get; private set; }

        public IPagedDataRequestFactory PagedDataRequestFactory { get; private set; }

        public IBrokerByIdInquiryProcessor BrokerByIdInquiryProcessor { get; private set; }
    }
}
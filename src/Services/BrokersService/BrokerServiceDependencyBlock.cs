using Core2WebApi.Services.InquiryProcessing;

namespace Core2WebApi.Services.BrokersService
{
    public class BrokerServiceDependencyBlock : IBrokerServiceDependencyBlock
    {
        public BrokerServiceDependencyBlock(IAllBrokersInquiryProcessor allBrokersInquiryProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory)
        {
            AllBrokersInquiryProcessor = allBrokersInquiryProcessor;
            PagedDataRequestFactory = pagedDataRequestFactory;
        }
        public IAllBrokersInquiryProcessor AllBrokersInquiryProcessor { get; private set; }

        public IPagedDataRequestFactory PagedDataRequestFactory { get; private set; }
    }
}
using Core2WebApi.Services.InquiryProcessing;

namespace Core2WebApi.Services.BrokersService
{
    public interface IBrokerServiceDependencyBlock
    {
        IAllBrokersInquiryProcessor AllBrokersInquiryProcessor { get; }
        IPagedDataRequestFactory PagedDataRequestFactory { get; }
    }
}
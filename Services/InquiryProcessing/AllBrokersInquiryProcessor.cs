using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core2WebApi.Data;
using Core2WebApi.Data.QueryProcessors;
using Core2WebApi.LinkServices;
using Core2WebApi.Models;
using Core2WebApi.Services.InquiryProcessing;
using PagedBrokerDataInquiryResponse =
    Core2WebApi.Models.PagedDataInquiryResponse<Core2WebApi.Models.Broker>;

namespace Core2WebApi.Services.InquiryProcessing {
    public class AllBrokersInquiryProcessor : IAllBrokersInquiryProcessor {
        public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

        private readonly IMapper _mapper;
        private readonly ICommonLinkService _commonLinkService;
        private readonly IAllBrokersQueryProcessor _queryProcessor;
        private readonly IBrokerLinkService _brokerLinkService;

        public AllBrokersInquiryProcessor (IAllBrokersQueryProcessor queryProcessor, IMapper mapper,
            IBrokerLinkService brokerLinkService, ICommonLinkService commmonLinkService) {
            _queryProcessor = queryProcessor;
            _mapper = mapper;
            _brokerLinkService = brokerLinkService;
            _commonLinkService = commmonLinkService;
        }
        public PagedDataInquiryResponse<Broker> GetBrokers (PagedDataRequest requestInfo) {
            var queryResult = _queryProcessor.GetBrokers (requestInfo);

            var brokers = GetBrokers (queryResult.QueriedItems).ToList ();

            var inquiryResponse = new PagedBrokerDataInquiryResponse {
                Items = brokers,
                PageCount = queryResult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };

            if (!requestInfo.ExcludeLinks) {
                AddLinksToInquiryResponse (inquiryResponse);
            }

            return inquiryResponse;
        }

        public virtual void AddLinksToInquiryResponse (PagedBrokerDataInquiryResponse inquiryResponse) {
            inquiryResponse.AddLink (_brokerLinkService.GetAllBrokersLink ());

            _commonLinkService.AddPageLinks (inquiryResponse, GetCurrentPageQueryString (inquiryResponse),
                GetPreviousPageQueryString (inquiryResponse),
                GetNextPageQueryString (inquiryResponse));
        }
        public virtual IEnumerable<Broker> GetBrokers (IEnumerable<Core2WebApi.Data.Entities.Broker> brokerEntites) {
            var brokers = brokerEntites.Select (x => _mapper.Map<Broker> (x)).ToList ();
            brokers.ForEach (x => {
                _brokerLinkService.AddSelfLink (x);
            });
            return brokers;
        }

        public virtual string GetCurrentPageQueryString (PagedBrokerDataInquiryResponse inquiryResponse) =>
            string.Format (QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);

        public virtual string GetPreviousPageQueryString (PagedBrokerDataInquiryResponse inquiryResponse) =>
            string.Format (QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);

        public virtual string GetNextPageQueryString (PagedBrokerDataInquiryResponse inquiryResponse) =>
            string.Format (QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
    }
}
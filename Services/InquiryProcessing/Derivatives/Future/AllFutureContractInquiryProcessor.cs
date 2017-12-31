using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core2WebApi.Data;
using Core2WebApi.Data.Entities;
using Core2WebApi.Data.QueryProcessors;
using Core2WebApi.LinkServices;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;
using PagedFutureContractDataInquiryResponse =
    Core2WebApi.Models.PagedDataInquiryResponse<Core2WebApi.Models.Derivatives.Future.FutureContract>;
namespace Core2WebApi.Services.InquiryProcessing.Derivatives.Future {
    public class AllFutureContractInquiryProcessor : IAllFutureContractInquiryProcessor {
        public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";
        private readonly IMapper _mapper;
        private readonly ICommonLinkService _commonLinkService;
        private readonly IAllFutureContractQueryProcessor _queryProcessor;
        private readonly IFutureContractLinkService _futureContractLinkService;
        public AllFutureContractInquiryProcessor (IMapper mapper, ICommonLinkService commonLinkService,
            IAllFutureContractQueryProcessor queryProcessor, IFutureContractLinkService futureLinkService) {
            _mapper = mapper;
            _commonLinkService = commonLinkService;
            _futureContractLinkService = futureLinkService;
            _queryProcessor = queryProcessor;
        }
        public PagedDataInquiryResponse<FutureContract> GetContracts (PagedDataRequest requestInfo) {
            var queryResult = _queryProcessor.GetFutureContracts (requestInfo);
            var contracts = GetContracts (queryResult.QueriedItems).ToList ();
            var inquiryResponse = new PagedFutureContractDataInquiryResponse {
                Items = contracts,
                PageCount = queryResult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };
            if (!requestInfo.ExcludeLinks) {
                AddLinksToInquiryResponse (inquiryResponse);
            }
            return inquiryResponse;
        }
        public virtual void AddLinksToInquiryResponse (PagedFutureContractDataInquiryResponse inquiryResponse) {
            inquiryResponse.AddLink (_futureContractLinkService.GetAllFutureContractsLink ());
            _commonLinkService.AddPageLinks (inquiryResponse, GetCurrentPageQueryString (inquiryResponse),
                GetPreviousPageQueryString (inquiryResponse),
                GetNextPAgeQueyString (inquiryResponse));
        }
        public virtual IEnumerable<FutureContract> GetContracts (IEnumerable<ContractFuture> futureContractEntities) {
            var contracts = futureContractEntities.Select (x => _mapper.Map<FutureContract> (x)).ToList ();
            contracts.ForEach (x => {
                _futureContractLinkService.AddSelfLink (x);
            });
            return contracts;
        }
        private string GetNextPAgeQueyString (PagedFutureContractDataInquiryResponse inquiryResponse) =>
            string.Format (QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);

        private string GetPreviousPageQueryString (PagedFutureContractDataInquiryResponse inquiryResponse) =>
            string.Format (QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);

        private string GetCurrentPageQueryString (PagedFutureContractDataInquiryResponse inquiryResponse) =>
            string.Format (QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);

    }
}
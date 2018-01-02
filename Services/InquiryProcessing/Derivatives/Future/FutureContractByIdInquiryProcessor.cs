using AutoMapper;
using Core2WebApi.Data.Exceptions;
using Core2WebApi.Data.QueryProcessors;
using Core2WebApi.LinkServices;
using Core2WebApi.Models.Derivatives.Future;

namespace Core2WebApi.Services.InquiryProcessing.Derivatives.Future {
    public class FutureContractByIdInquiryProcessor : IFutureContractByIdInquiryProcessor {
        private readonly IMapper _mapper;
        private readonly IFutureContractByIdQueryProcessor _queryProcessor;
        private readonly IFutureContractLinkService _linkService;
        public FutureContractByIdInquiryProcessor (IMapper mapper, IFutureContractByIdQueryProcessor queryProcessor,
            IFutureContractLinkService linkService) {
            _mapper = mapper;
            _queryProcessor = queryProcessor;
            _linkService = linkService;
        }
        //private readonly IFutureContractByIdQueryProcessor _queryProcessor;
        public FutureContract GetFutureContract (int id) {
            var contractEntity = _queryProcessor.GetContract (id);
            if (contractEntity == null)
                throw new RootObjectNotFoundException ("Broker Not Found");
            var contract = _mapper.Map<FutureContract> (contractEntity);
            _linkService.AddLinks (contract);
            return contract;
        }
    }
}
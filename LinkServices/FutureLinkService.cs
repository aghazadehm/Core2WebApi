using System;
using System.Net.Http;
using Core2WebApi.Common;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;

namespace Core2WebApi.LinkServices {
    public class FutureContractLinkService : IFutureContractLinkService {
        private readonly ICommonLinkService _commonLinkService;
        public FutureContractLinkService (ICommonLinkService commonLinkService) {
            _commonLinkService = commonLinkService;
        }
        public void AddLinks (FutureContract contract) {
            AddSelfLink (contract);
            AddAllFutureContractsLink (contract);
        }

        private void AddAllFutureContractsLink (FutureContract contract) {
            contract.AddLink (GetAllFutureContractsLink ());
        }

        public void AddSelfLink (FutureContract contract) {
            contract.AddLink(GetSelfLink(contract.ContractID));
        }

        public Link GetAllFutureContractsLink () {
            const string pathFragment = "futureContracts";
            return _commonLinkService.GetLink (pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
        }

        public Link GetSelfLink (long contractId) {
            var pathFragment = string.Format ("futureContracts/{0}", contractId);
            var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self,HttpMethod.Get);
            return link;
        }
    }
}
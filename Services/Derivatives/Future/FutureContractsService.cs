using System.Net.Http;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;

namespace Core2WebApi.Services.Derivatives.Future {
    public class FutureContractsService : IFutureContractsService {
        public FutureContractsService(IFutureContractsDependencyBlock futureContractDependencyBlock)
        {
            
        }

        public FutureContract GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public PagedDataInquiryResponse<FutureContract> GetContracts(HttpRequestMessage requestMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}
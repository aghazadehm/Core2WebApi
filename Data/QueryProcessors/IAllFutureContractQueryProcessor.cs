
using Core2WebApi.Data.Entities;

namespace Core2WebApi.Data.QueryProcessors
{
    public interface IAllFutureContractQueryProcessor
    {
         QueryResult<ContractFuture> GetFutureContracts(PagedDataRequest requestInfo);
    }
}
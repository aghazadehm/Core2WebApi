
using Core2WebApi.Data.Entities;

namespace Core2WebApi.Data.QueryProcessors
{
    public interface IFutureContractByIdQueryProcessor
    {
         ContractFuture GetContract(int id);
    }
}
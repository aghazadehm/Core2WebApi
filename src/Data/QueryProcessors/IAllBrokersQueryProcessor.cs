
using Core2WebApi.Data.Entities;

namespace Core2WebApi.Data.QueryProcessors
{
    public interface IAllBrokersQueryProcessor
    {
         QueryResult<DimBroker> GetBrokers(PagedDataRequest requestInfo);
    }
}
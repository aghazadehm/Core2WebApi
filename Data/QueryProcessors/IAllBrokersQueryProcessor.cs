
using Core2WebApi.Data.Entities;

namespace Core2WebApi.Data.QueryProcessors
{
    public interface IAllBrokersQueryProcessor
    {
         QueryResult<Broker> GetBrokers(PagedDataRequest requestInfo);
    }
}
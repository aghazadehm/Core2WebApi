using System.Linq;
using Core2WebApi.Data.Entities;
using Core2WebApi.Data.QueryProcessors;

namespace Core2WebApi.Data.SqlServer
{
    public class AllBrokersQueryProcessor : IAllBrokersQueryProcessor
    {
        public AllBrokersQueryProcessor() //ISession session)
        {
            //_session = session;
        }
        public QueryResult<DimBroker> GetBrokers(PagedDataRequest requestInfo)
        {
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
            var context = new InformingDBContext();
            var query = context.DimBroker;
            var totalItemCount = query.Count();
            var brokers = query.Skip(startIndex).Take(requestInfo.PageSize).ToList();
            var queryResult = new QueryResult<DimBroker>(brokers, totalItemCount, requestInfo.PageSize);
            return queryResult;
        }
    }
}
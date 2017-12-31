using System.Linq;
using Core2WebApi.Data.Entities;
using Core2WebApi.Data.QueryProcessors;
using Core2WebApi.Models.Derivatives.Future;

namespace Core2WebApi.Data.SqlServer.QueryProcessors {
    public class AllFutureContractQueryProcessor : IAllFutureContractQueryProcessor {

        public AllFutureContractQueryProcessor () {

        }
        public QueryResult<ContractFuture> GetFutureContracts (PagedDataRequest requestInfo) {
            var startIndex = ResultsPagingUtility.CalculateStartIndex (requestInfo.PageNumber, requestInfo.PageSize);
            var context = new FutureSnapshotContext ();
            var query = context.ContractFutures;
            var totalItemCount = query.Count ();
            var contracts = query.Skip (startIndex).Take (requestInfo.PageSize).ToList ();
            var queryResult = new QueryResult<ContractFuture> (contracts, totalItemCount, requestInfo.PageSize);
            return queryResult;
        }
    }
}
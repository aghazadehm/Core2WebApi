using System.Linq;
using Core2WebApi.Data.Entities;
using Core2WebApi.Data.QueryProcessors;
using Core2WebApi.Models.Derivatives.Future;

namespace Core2WebApi.Data.SqlServer.QueryProcessors {

    public class FutureContractByIdQueryProcessor : IFutureContractByIdQueryProcessor {
        private readonly FutureSnapshotContext _context;
        public FutureContractByIdQueryProcessor (FutureSnapshotContext context) {
            _context = context;
        }
        public ContractFuture GetContract (int id) {
            var contracts = _context.Set<ContractFuture> ();
            var contract = contracts.SingleOrDefault (c => c.ContractId == id);
            return contract;
        }
    }
}
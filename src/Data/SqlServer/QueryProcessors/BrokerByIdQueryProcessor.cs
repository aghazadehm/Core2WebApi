using System.Linq;
using Core2WebApi.Data.Entities;
using Core2WebApi.Data.QueryProcessors;
using Microsoft.AspNetCore.Http;

namespace Core2WebApi.Data.SqlServer.QueryProcessors {
    public class BrokerByIdQueryProcessor : IBrokerByIdQueryProcessor {
        private readonly InformingDBContext _context;

        public BrokerByIdQueryProcessor (InformingDBContext context) {
            _context = context;
        }
        public Broker GetBroker (int brokerId) {
            var brokers = _context.Set<Broker> ();
            var broker = brokers.SingleOrDefault (b => b.BrokerKey == brokerId);
            return broker;
        }
    }
}
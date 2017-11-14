using Core2WebApi.Data.Entities;

namespace Core2WebApi.Data.QueryProcessors
{
    public interface IBrokerByIdQueryProcessor
    {
         Broker GetBroker(int brokerId); 
    }
}
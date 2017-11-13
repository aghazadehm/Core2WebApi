using Core2WebApi.Data.Entities;

namespace Core2WebApi.Data.QueryProcessors
{
    public interface IBrokerByIdQueryProcessor
    {
         DimBroker GetBroker(int brokerId); 
    }
}